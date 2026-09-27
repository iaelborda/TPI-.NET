using DTOs;

namespace Application.Services
{
    public interface IEmpleadoService
    {
        Task<EmpleadoDTO> AddAsync(EmpleadoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<EmpleadoDTO?> GetAsync(int id);
        Task<IEnumerable<EmpleadoDTO>> GetAllAsync();
        Task<bool> UpdateAsync(EmpleadoDTO dto);
    }
}
