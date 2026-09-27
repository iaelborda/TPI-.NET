using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly TPIContext context;

        public EmpleadoRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Empleado empleado)
        {
            context.Empleados.Add(empleado);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var empleado = await context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                context.Empleados.Remove(empleado);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Empleado?> GetAsync(int id)
        {
            return await context.Empleados
                .Include(e => e.Sucursal)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await context.Empleados
                .Include(e => e.Sucursal)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Empleado empleado)
        {
            var existing = await context.Empleados.FirstOrDefaultAsync(e => e.Id == empleado.Id);

            if (existing != null)
            {
                existing.SetNombre(empleado.Nombre);
                existing.SetApellido(empleado.Apellido);
                existing.SetTelefono(empleado.Telefono);
                existing.SetTipoDocumento(empleado.TipoDocumento);
                existing.SetSucursalId(empleado.SucursalId);

                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DocumentoExistsAsync(string documento)
        {
            return await context.Empleados.AnyAsync(e => e.Documento == documento);
        }

        public async Task<bool> LegajoExistsAsync(int legajo)
        {
            return await context.Empleados.AnyAsync(e => e.Legajo == legajo);
        }
    }
}
