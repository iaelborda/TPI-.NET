using DTOs;

namespace Application.Services
{
    public interface IClienteService
    {
        Task<ClienteDTO> AddAsync(ClienteDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(ClienteDTO dto);
        Task<ClienteDTO?> GetAsync(int id);
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
    }
}