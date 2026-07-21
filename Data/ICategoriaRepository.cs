using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface ICategoriaRepository
    {
        Task AddAsync(Categoria categoria);
        Task<bool> DeleteAsync(int id);
        Task<Categoria?> GetAsync(int id);
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<bool> UpdateAsync(Categoria categoria);
        Task<bool> DescripcionExistsAsync(string descripcion, int? excludeId = null);
    }
}
