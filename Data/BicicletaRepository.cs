using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Data
{
    public class BicicletaRepository : IBicicletaRepository
    {
        private readonly TPIContext context;

        public BicicletaRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Bicicleta bicicleta)
        {
            context.Bicicletas.Add(bicicleta);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bicicleta = await context.Bicicletas.FindAsync(id);

            if (bicicleta != null)
            {
                context.Bicicletas.Remove(bicicleta);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Bicicleta?> GetAsync(int id)
        {
            return await context.Bicicletas
                .Include(b => b.Categoria)
                .Include(b => b.Sucursal)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Bicicleta>> GetAllAsync()
        {
            return await context.Bicicletas
                .Include(b => b.Categoria)
                .Include(b => b.Sucursal)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Bicicleta bicicleta)
        {
            var existing = await context.Bicicletas.FirstOrDefaultAsync(b => b.Id == bicicleta.Id);

            if (existing != null)
            {
                existing.SetMarca(bicicleta.Marca);
                existing.SetModelo(bicicleta.Modelo);
                existing.SetEstado(bicicleta.Estado);
                existing.SetCategoriaId(bicicleta.CategoriaId);
                existing.SetSucursalId(bicicleta.SucursalId);

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Bicicleta>> GetByCriteriaAsync(BicicletaCriteria criteria)
        {
            var query = context.Bicicletas.Include(b => b.Categoria).Include(b => b.Sucursal).AsQueryable();
            if (!string.IsNullOrWhiteSpace(criteria.Texto))
            {
                string t = criteria.Texto.Trim().ToLower();
                query = query.Where(b => b.Marca.ToLower().Contains(t) || b.Modelo.ToLower().Contains(t));
            }
            if(criteria.CategoriaId.HasValue && criteria.CategoriaId > 0)
            {
                query = query.Where (b => b.CategoriaId == criteria.CategoriaId.Value);
            }
            if(criteria.SucursalId.HasValue && criteria.SucursalId > 0)
            {
                query = query.Where(b=> b.SucursalId == criteria.SucursalId.Value);
            }
            if (criteria.Estado.HasValue)
            {
                query = query.Where(b => b.Estado == criteria.Estado.Value);
            }
            return await query.ToListAsync();
        }
    }
}