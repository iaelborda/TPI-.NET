using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
namespace Application.Services
{
    public interface IPagoService
    {
        Task<PagoDTO> AddAsync(PagoDTO dto);
        Task<PagoDTO?> GetAsync(int id);
        Task<IEnumerable<PagoDTO>> GetAllAsync();
        Task<PagoDTO?> GetByAlquilerIdAsync(int idAlquiler);
        Task<bool> UpdateAsync(PagoDTO dto);
        Task<bool> DeleteAsync(int id);

    }
}
