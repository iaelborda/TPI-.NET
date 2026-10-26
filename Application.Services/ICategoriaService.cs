using DTOs;

namespace Application.Services
{
    public interface ICategoriaService
    {
        Task<CategoriaDTO> AddAsync(CategoriaDTO dto);
        Task<CategoriaDTO?> GetAsync(int id);
        Task<IEnumerable<CategoriaDTO>> GetAllAsync();
        Task<bool> UpdateAsync(CategoriaDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
