using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Data
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly TPIContext context;

        public SucursalRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Sucursal sucursal)
        {
            context.Sucursales.Add(sucursal);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sucursal = await context.Sucursales.FindAsync(id);

            if (sucursal != null)
            {
                context.Sucursales.Remove(sucursal);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Sucursal?> GetAsync(int id)
        {
            return await context.Sucursales.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Sucursal>> GetAllAsync()
        {
            return await context.Sucursales.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Sucursal sucursal)
        {
            var existente = await context.Sucursales.FindAsync(sucursal.Id);

            if (existente != null)
            {
                existente.SetNombre(sucursal.Nombre);
                existente.SetDireccion(sucursal.Direccion);
                existente.SetTelefono(sucursal.Telefono);
                existente.SetCapacidad(sucursal.Capacidad);

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> NombreExistsAsync(string nombre, int? excludeId = null)
        {
            var busqueda = context.Sucursales.Where(s => s.Nombre.ToLower() == nombre.ToLower());

            if (excludeId.HasValue)
            {
                busqueda = busqueda.Where(s => s.Id != excludeId.Value);
            }

            return await busqueda.AnyAsync();
        }
    }
}