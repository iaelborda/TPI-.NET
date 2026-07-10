using System;
using Domain.Model;

namespace Data
{
    public class ClienteRepository : IClienteRepository
    {
        private static readonly List<Cliente> clientes = new List<Cliente>();
        public Task AddAsync(Cliente cliente)
        {
            clientes.Add(cliente);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(string documento) 
        { 
            var cliente = clientes.FirstOrDefault(c => c.Documento == documento);
            if (cliente != null) 
            {
                clientes.Remove(cliente);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<Cliente?> GetAsync(string documento) 
        {
            return Task.FromResult(clientes.FirstOrDefault(c => c.Documento == documento));
        }

        public Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Cliente>>(clientes.ToList());
        }

        public Task<bool> UpdateAsync(Cliente cliente)
        {
            var existing = clientes.FirstOrDefault(c => c.Documento == cliente.Documento);

            if (existing != null)
            {
                existing.SetNombre(cliente.Nombre);
                existing.SetApellido(cliente.Apellido);
                existing.SetTelefono(cliente.Telefono);
                existing.SetEmail(cliente.Email);

                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<bool> EmailExistsAsync(string email, string? excludeDocumento = null)
        {
            var query = clientes.Where(c => c.Email.ToLower() == email.ToLower());
            if (!string.IsNullOrEmpty(excludeDocumento))
            {
                query = query.Where(c => c.Documento != excludeDocumento);
            }
            return Task.FromResult(query.Any());
        }
        public Task<bool> DocumentoExistsAsync(string documento)
        {
            return Task.FromResult(clientes.Any(c => c.Documento == documento));
        }
    }
}
