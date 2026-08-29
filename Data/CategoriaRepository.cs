using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Data
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly TPIContext context;

        public CategoriaRepository(TPIContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await context.Categorias.FindAsync(id);

            if (categoria != null)
            {
                context.Categorias.Remove(categoria);
                await context.SaveChangesAsync();

                return true;
            }
            return false;
        }
        public async Task<Categoria?> GetAsync(int id)
        {
            return await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await context.Categorias.ToListAsync();
        }
        public async Task<bool> UpdateAsync(Categoria categoria)
        {
            var existing = await context.Categorias.FindAsync(categoria.Id);

            if (existing != null)
            {
                existing.SetDescripcion(categoria.Descripcion);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DescripcionExistsAsync(string descripcion, int? excludeId = null)
        {
            var query = context.Categorias.Where(c => c.Descripcion.ToLower() == descripcion.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }
        internal IEnumerable<Categoria> GetAllSync()
        {
            return context.Categorias.OrderBy(p => p.Descripcion).ToList();
        }

    }
}
