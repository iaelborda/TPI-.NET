using DTOs;

namespace Application.Services
{
    public interface IBicicletaService
    {
        Task<BicicletaDTO> AddAsync(BicicletaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(BicicletaDTO dto);
        Task<BicicletaDTO?> GetAsync(int id);
        Task<IEnumerable<BicicletaDTO>> GetAllAsync();
    }
}
