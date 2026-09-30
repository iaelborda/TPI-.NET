using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AlquilerRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public async Task AddAsync(Alquiler alquiler)
        {
            using var context = CreateContext();

            context.Alquileres.Add(alquiler);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var context = CreateContext();

            var alquiler = await context.Alquileres.FindAsync(id);

            if (alquiler != null)
            {
                context.Alquileres.Remove(alquiler);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Alquiler?> GetAsync(int id)
        {
            using var context = CreateContext();

            return await context.Alquileres
                .Include(a => a.Cliente)
                .Include(a => a.Empleado)
                .Include(a => a.DetallesAlquiler)
                    .ThenInclude(d => d.Bicicleta)
                        .ThenInclude(b => b.Categoria)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Alquiler>> GetAllAsync()
        {
            using var context = CreateContext();

            return await context.Alquileres
                .Include(a => a.Cliente)
                .Include(a => a.Empleado)
                .Include(a => a.DetallesAlquiler)
                    .ThenInclude(d => d.Bicicleta)
                         .ThenInclude(b => b.Categoria)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Alquiler alquiler)
        {
            using var context = CreateContext();

            var existingAlquiler = await context.Alquileres
                .Include(a => a.DetallesAlquiler)
                .FirstOrDefaultAsync(a => a.Id == alquiler.Id);

            if (existingAlquiler == null)
            {
                return false;
            }

            existingAlquiler.SetClienteId(alquiler.ClienteId);
            existingAlquiler.SetEmpleadoId(alquiler.EmpleadoId);

            existingAlquiler.SetFechaAlquiler(alquiler.FechaAlquiler);
            existingAlquiler.SetEstadoAlquiler(alquiler.EstadoAlquiler);

            var detallesToDelete = existingAlquiler.DetallesAlquiler
                .Where(existing =>!alquiler.DetallesAlquiler.Any(nuevo => nuevo.BicicletaId == existing.BicicletaId))
                .ToList();

            foreach (var detalleToDelete in detallesToDelete)
            {
                existingAlquiler.RemoveDetalle(detalleToDelete);
            }

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

            await context.SaveChangesAsync();

            return true;
        }
    }
}