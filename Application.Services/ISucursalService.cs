using DTOs;

namespace Application.Services
{
    public interface ISucursalService
    {
        Task<SucursalDTO> AddAsync(SucursalDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(SucursalDTO dto);
        Task<SucursalDTO?> GetAsync(int id);
        Task<IEnumerable<SucursalDTO>> GetAllAsync();
    }
}
