using Domain.Model;

namespace Data
{
    public interface IBicicletaRepository
    {
        Task AddAsync(Bicicleta bicicleta);
        Task<bool> DeleteAsync(int id);
        Task<Bicicleta?> GetAsync(int id);
        Task<IEnumerable<Bicicleta>> GetAllAsync();
        Task<bool> UpdateAsync(Bicicleta bicicleta);
    }
}
