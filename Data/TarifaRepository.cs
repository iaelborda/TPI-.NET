using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly TPIContext context;

        public TarifaRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Tarifa tarifa)
        {
            context.Tarifas.Add(tarifa);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tarifa = await context.Tarifas.FindAsync(id);
            if(tarifa != null)
            {
                context.Tarifas.Remove(tarifa);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Tarifa?> GetAsync(int id)
        {
            return await context.Tarifas.Include(t => t.Categoria).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarifa>> GetAllAsync()
        {
            return await context.Tarifas.Include(t => t.Categoria).ToListAsync();
        }

        public async Task<IEnumerable<Tarifa>> GetByCategoriaIdAsync(int id)
        {
            return await context.Tarifas.Include(t => t.Categoria).Where(t => t.CategoriaId == id).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Tarifa tarifa)
        {
            var existing = await context.Tarifas.FirstOrDefaultAsync(t => t.Id == tarifa.Id);
            if(existing != null)
            {
                existing.SetPrecioHora(tarifa.PrecioHora);
                existing.SetFechaDesde(tarifa.FechaDesde);
                existing.SetFechaHasta(tarifa.FechaHasta);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Tarifa?> GetTarifaVigenteAsync(int categoriaId)
        {
            return await context.Tarifas.FirstOrDefaultAsync(t => t.CategoriaId == categoriaId && t.FechaHasta == null);
        }
    }
}
