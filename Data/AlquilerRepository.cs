using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Data
{
    public class AlquilerRepository
    {
        private readonly TPIContext _context;
        private readonly string _connectionString;

        public AlquilerRepository(TPIContext context, IConfiguration? configuration = null)
        {
            _context = context;
            _connectionString = configuration?.GetConnectionString("DefaultConnection")
                ?? _context.Database.GetConnectionString()
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'.");
        }

        public async Task AddAsync(Alquiler alquiler)
        {
            _context.Alquileres.Add(alquiler);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alquiler = await _context.Alquileres.FindAsync(id);

            if (alquiler == null)
                return false;

            _context.Alquileres.Remove(alquiler);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Alquiler?> GetAsync(int id)
        {
            return await _context.Alquileres
                .Include(a => a.Cliente)
                .Include(a => a.Empleado)
                .Include(a => a.DetallesAlquiler)
                    .ThenInclude(d => d.Bicicleta)
                        .ThenInclude(b => b.Categoria)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Alquiler>> GetAllAsync()
        {
            return await _context.Alquileres
                .Include(a => a.Cliente)
                .Include(a => a.Empleado)
                .Include(a => a.DetallesAlquiler)
                    .ThenInclude(d => d.Bicicleta)
                        .ThenInclude(b => b.Categoria)
                .ToListAsync();
        }

        public async Task<bool> BicicletaEnAlquilerActivoAsync(int bicicletaId, int? alquilerId = null)
        {
            var alquileres = _context.Alquileres.Where(a =>
                a.EstadoAlquiler == EstadoDeAlquiler.Activo &&
                a.DetallesAlquiler.Any(d => d.BicicletaId == bicicletaId && d.HoraFin == null));

            if (alquilerId.HasValue)
                alquileres = alquileres.Where(a => a.Id != alquilerId.Value);

            return await alquileres.AnyAsync();
        }

        public async Task<bool> UpdateAsync(Alquiler alquiler)
        {
            var existingAlquiler = await _context.Alquileres
                .Include(a => a.DetallesAlquiler)
                .FirstOrDefaultAsync(a => a.Id == alquiler.Id);

            if (existingAlquiler == null)
                return false;

            existingAlquiler.SetClienteId(alquiler.ClienteId);
            existingAlquiler.SetEmpleadoId(alquiler.EmpleadoId);
            existingAlquiler.SetEstadoAlquiler(alquiler.EstadoAlquiler);

            var detallesToDelete = existingAlquiler.DetallesAlquiler
                .Where(existing => !alquiler.DetallesAlquiler.Any(nuevo => nuevo.BicicletaId == existing.BicicletaId))
                .ToList();

            foreach (var detalle in detallesToDelete)
                existingAlquiler.RemoveDetalle(detalle);

            foreach (var nuevoDetalle in alquiler.DetallesAlquiler)
            {
                var existingDetalle = existingAlquiler.DetallesAlquiler
                    .FirstOrDefault(d => d.BicicletaId == nuevoDetalle.BicicletaId);

                if (existingDetalle == null)
                {
                    existingAlquiler.AddDetalle(nuevoDetalle);
                }
                else
                {
                    existingDetalle.SetHoraInicio(nuevoDetalle.HoraInicio);
                    existingDetalle.SetHoraFin(nuevoDetalle.HoraFin);
                    existingDetalle.SetEstado(nuevoDetalle.Estado);
                    existingDetalle.SetPrecioHora(nuevoDetalle.PrecioHora);
                    existingDetalle.SetSubtotal(nuevoDetalle.Subtotal);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Alquiler>> GetByCriteriaAsync(DateTime fechaDesde, DateTime fechaHasta, int? sucursalId)
        {
            DateTime desde = fechaDesde.Date;
            DateTime hasta = fechaHasta.Date.AddDays(1);

            var query = _context.Alquileres
                .Include(a => a.Cliente)
                .Include(a => a.Empleado)
                .Include(a => a.DetallesAlquiler)
                    .ThenInclude(d => d.Bicicleta)
                        .ThenInclude(b => b.Categoria)
                .Where(a => a.FechaAlquiler >= desde && a.FechaAlquiler < hasta);

            if (sucursalId.HasValue && sucursalId.Value > 0)
                query = query.Where(a => a.Empleado!.SucursalId == sucursalId.Value);

            return await query.ToListAsync();
        }


        public async Task<List<ReporteRankingBicicleta>> GetTop10BicicletasAnioAsync(int anio)
        {
            DateTime desde = new DateTime(anio, 1, 1);
            DateTime hasta = new DateTime(anio + 1, 1, 1);

            var query = _context.Alquileres
                .Where(a => a.FechaAlquiler >= desde &&
                            a.FechaAlquiler < hasta &&
                            a.EstadoAlquiler != EstadoDeAlquiler.Cancelado);

            var bicicletasAlquiladas = await query
                .SelectMany(a => a.DetallesAlquiler)
                .Select(d => new
                {
                    d.BicicletaId,
                    Marca = d.Bicicleta != null ? d.Bicicleta.Marca : "Sin marca",
                    Modelo = d.Bicicleta != null ? d.Bicicleta.Modelo : "Sin modelo"
                })
                .ToListAsync();

            return bicicletasAlquiladas
                .GroupBy(b => new { b.BicicletaId, b.Marca, b.Modelo })
                .Select(g => new ReporteRankingBicicleta
                {
                    IdBicicleta = g.Key.BicicletaId,
                    Marca = g.Key.Marca,
                    Modelo = g.Key.Modelo,
                    CantAlquileres = g.Count()
                })
                .OrderByDescending(r => r.CantAlquileres)
                .ThenBy(r => r.Marca)
                .ThenBy(r => r.Modelo)
                .Take(10)
                .ToList();
        }

        public async Task<List<ReporteAlquileresMensual>> GetReporteAlquileresMensualAsync(DateTime fechaDesde, DateTime fechaHasta, int? sucursalId)
        {
            DateTime desde = fechaDesde.Date;
            DateTime hasta = fechaHasta.Date.AddDays(1);
            const string sql = @"
                SELECT 
                    YEAR(a.FechaAlquiler) AS Anio,
                    MONTH(a.FechaAlquiler) AS Mes,
                    ISNULL(e.SucursalId, 0) AS SucursalId,
                    ISNULL(s.Nombre, 'Sin sucursal') AS Sucursal,
                    COUNT(a.Id) AS CantidadAlquileres
                FROM Alquileres a
                LEFT JOIN Empleados e ON a.EmpleadoId = e.Id
                LEFT JOIN Sucursales s ON e.SucursalId = s.Id
                WHERE a.FechaAlquiler >= @FechaDesde 
                  AND a.FechaAlquiler < @FechaHasta 
                  AND a.EstadoAlquiler <> 2 -- Excluye cancelados (EstadoDeAlquiler.Cancelado)
                  AND (@SucursalId IS NULL OR e.SucursalId = @SucursalId)
                GROUP BY YEAR(a.FechaAlquiler), MONTH(a.FechaAlquiler), e.SucursalId, s.Nombre
                ORDER BY Anio, Mes, Sucursal;";

            var resultado = new List<ReporteAlquileresMensual>();
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await using var command = new SqlCommand(sql, connection);
            command.Parameters.Add(new SqlParameter("@FechaDesde", SqlDbType.DateTime2) { Value = desde });
            command.Parameters.Add(new SqlParameter("@FechaHasta", SqlDbType.DateTime2) { Value = hasta });
            command.Parameters.Add(new SqlParameter("@SucursalId", SqlDbType.Int) { Value = (object?)sucursalId ?? DBNull.Value });
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultado.Add(new ReporteAlquileresMensual
                {
                    Anio = reader.GetInt32(reader.GetOrdinal("Anio")),
                    Mes = reader.GetInt32(reader.GetOrdinal("Mes")),
                    SucursalId = reader.GetInt32(reader.GetOrdinal("SucursalId")),
                    Sucursal = reader.IsDBNull(reader.GetOrdinal("Sucursal")) ? "Sin sucursal" : reader.GetString(reader.GetOrdinal("Sucursal")),
                    CantidadAlquileres = reader.GetInt32(reader.GetOrdinal("CantidadAlquileres"))
                });
            }
            return resultado;
        }
    }
}
