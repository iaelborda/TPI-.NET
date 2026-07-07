using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ISucursalRepository
    {
        Task AddAsync(Sucursal sucursal);
        Task<bool> DeleteAsync(int id);
        Task<Sucursal?> GetAsync(int id);
        Task<IEnumerable<Sucursal>> GetAllAsync();
        Task<bool> UpdateAsync(Sucursal sucursal);
        Task<bool> NombreExistsAsync(string nombre, int? excludeId = null);
    }
}
