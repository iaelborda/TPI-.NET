using Domain.Model;

namespace Data
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task<bool> DeleteAsync(int id);
        Task<Cliente?> GetAsync(int id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<bool> UpdateAsync(Cliente cliente);
        Task<bool> EmailExistsAsync(string email, string? excludeDocumento = null);
        Task<bool> DocumentoExistsAsync(string documento);
    }
}