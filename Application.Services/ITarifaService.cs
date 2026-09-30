using DTOs;

namespace Application.Services
{
    public interface ITarifaService
    {
        Task<TarifaDTO> AddAsync(TarifaDTO dto);
        Task<bool> UpdateAsync(TarifaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<TarifaDTO?> GetAsync(int id);
        Task<IEnumerable<TarifaDTO>> GetAllAsync();
        Task<IEnumerable<TarifaDTO>> GetByCategoriaIdAsync(int categoriaId);
        Task<TarifaDTO?> GetTarifaVigenteAsync(int categoriaId);

    }
}
