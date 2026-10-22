using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;


namespace Data
{
    public interface IPagoRepository
    {
        Task<Pago?> GetAsync(int id);
        Task<Pago?> GetByAlquilerIdAsync(int id);
        Task<IEnumerable<Pago>> GetAllAsync();
        Task AddAsync(Pago pago);
        Task<bool> DeleteAsync(int id);
        Task<bool> AlquilerTienePagoAsync(int alquilerId);
        Task<bool> UpdateAsync(Pago pago);
    }
}
