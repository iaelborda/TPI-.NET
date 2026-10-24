using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AlquilerRepository
    {
        private readonly TPIContext _context;

        public AlquilerRepository(TPIContext context)
        {
            _context = context;
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
        public async Task<List<ReporteAlquileresMensual>> GetReporteAlquileresMensualAsync(DateTime fechaDesde, DateTime fechaHasta, int? sucursalId)
        {
            DateTime desde = fechaDesde.Date;
            DateTime hasta = fechaHasta.Date.AddDays(1);

            var query = _context.Alquileres.Where(a => a.FechaAlquiler >= desde && a.FechaAlquiler < hasta && a.EstadoAlquiler != EstadoDeAlquiler.Cancelado);

            if (sucursalId.HasValue)
                query = query.Where(a => a.Empleado != null && a.Empleado.SucursalId == sucursalId.Value);

            var alquileres = await query
                .Select(a => new
                {
                    a.FechaAlquiler,
                    SucursalId = a.Empleado != null ? (int?)a.Empleado.SucursalId : null,
                    Sucursal = a.Empleado != null && a.Empleado.Sucursal != null
                        ? a.Empleado.Sucursal.Nombre
                        : null
                })
                .ToListAsync();

            return alquileres
                .GroupBy(a => new
                {
                    Anio = a.FechaAlquiler.Year,
                    Mes = a.FechaAlquiler.Month,
                    SucursalId = a.SucursalId ?? 0,
                    Sucursal = a.Sucursal ?? "Sin sucursal"
                })
                .Select(g => new ReporteAlquileresMensual
                {
                    Anio = g.Key.Anio,
                    Mes = g.Key.Mes,
                    SucursalId = g.Key.SucursalId,
                    Sucursal = g.Key.Sucursal,
                    CantidadAlquileres = g.Count()
                })
                .OrderBy(r => r.Anio)
                .ThenBy(r => r.Mes)
                .ThenBy(r => r.Sucursal)
                .ToList();
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
    }
}
