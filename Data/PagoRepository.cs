using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PagoRepository : IPagoRepository
    {
        private readonly TPIContext context;
        public PagoRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Pago pago)
        {
            context.Pagos.Add(pago);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pago = await context.Pagos.FindAsync(id);
            if(pago == null)
            {
                return false;
            }
            context.Pagos.Remove(pago);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pago>> GetAllAsync()
        {
            return await context.Pagos.ToListAsync();
        }

        public async Task<Pago?> GetAsync(int id)
        {
            return await context.Pagos.FirstOrDefaultAsync(p => p.IdPago == id);
        }

        public async Task<Pago?> GetByAlquilerIdAsync(int alquilerId)
        {
            return await context.Pagos.FirstOrDefaultAsync(p => p.IdAlquiler == alquilerId);
        }

        public async Task<bool> AlquilerTienePagoAsync(int alquilerId)
        {
            return await context.Pagos.AnyAsync(p => p.IdAlquiler == alquilerId);
        }

        public async Task<bool> UpdateAsync(Pago pago)
        {
            var existing = await context.Pagos.FindAsync(pago.IdPago);
            if(existing == null)
            {
                return false;
            }
            existing.SetMetodoPago(pago.Metodo);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
