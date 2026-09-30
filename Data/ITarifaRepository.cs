using Domain.Model;

namespace Data
{
    public interface ITarifaRepository
    {
        Task AddAsync(Tarifa tarifa);
        Task<bool> DeleteAsync(int id);
        Task<Tarifa?> GetAsync(int id);
        Task<IEnumerable<Tarifa>> GetAllAsync();
        Task<IEnumerable<Tarifa>> GetByCategoriaIdAsync(int id);
        Task<bool> UpdateAsync(Tarifa tarifa);
    }
}
