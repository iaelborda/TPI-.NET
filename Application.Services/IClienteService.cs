using DTOs;

namespace Application.Services
{
    public interface IClienteService
    {
        Task<ClienteDTO> AddAsync(ClienteDTO dto);
        Task<bool> DeleteAsync(string documento);
        Task<bool> UpdateAsync(ClienteDTO dto);
        Task<ClienteDTO?> GetAsync(string documento);
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
    }
}