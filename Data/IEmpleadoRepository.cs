using Domain.Model;

namespace Data
{
    public interface IEmpleadoRepository
    {
        Task AddAsync(Empleado empleado);
        Task<bool> DeleteAsync(int id);
        Task<Empleado?> GetAsync(int id);
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<bool> UpdateAsync(Empleado empleado);
        Task<bool> DocumentoExistsAsync(string documento);
        Task<bool> LegajoExistsAsync(int legajo);
    }
}
