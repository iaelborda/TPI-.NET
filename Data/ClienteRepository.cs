using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly TPIContext context;

        public ClienteRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id) 
        {
            var cliente = await context.Clientes.FindAsync(id);

            if(cliente != null)
            {
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<Cliente?> GetAsync(int id) 
        {
            return await context.Clientes.FirstOrDefaultAsync(c => c.Id ==id);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await context.Clientes.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            var existing = await context.Clientes.FindAsync(cliente.Id);

            if (existing != null)
            {
                existing.SetNombre(cliente.Nombre);
                existing.SetApellido(cliente.Apellido);
                existing.SetTelefono(cliente.Telefono);
                existing.SetEmail(cliente.Email);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> EmailExistsAsync(string email, string? excludeDocumento = null)
        {
            var query = context.Clientes.Where(c => c.Email.ToLower() == email.ToLower());
            
            if(!string.IsNullOrEmpty(excludeDocumento))
            {
                query = query.Where(c => c.Documento != excludeDocumento);
            }
            return await query.AnyAsync();
        }
        public async Task<bool> DocumentoExistsAsync(string documento)
        {
            return await context.Clientes.AnyAsync(c => c.Documento == documento);
        }
    }
}
