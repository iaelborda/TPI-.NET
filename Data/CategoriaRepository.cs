using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private static readonly List<Categoria> categorias = new List<Categoria>();
        private static int nextId = 1;

        public Task AddAsync(Categoria categoria)
        {
            categoria.SetId(nextId);
            nextId++;
            categorias.Add(categoria);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            if(categoria != null)
            {
                categorias.Remove(categoria);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<Categoria?> GetAsync(int id)
        {
            return Task.FromResult(categorias.FirstOrDefault(c => c.Id == id));
        }

        public Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Categoria>>(categorias.ToList());
        }

        public Task<bool> UpdateAsync(Categoria categoria)
        {
            var busqueda = categorias.FirstOrDefault(c => c.Id == categoria.Id);
            if (busqueda != null)
            {
                busqueda.SetDescripcion(categoria.Descripcion);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> DescripcionExistsAsync (string descripcion, int? excludeId = null)
        {
            var busqueda = categorias.Where(c => c.Descripcion.ToLower() == descripcion.ToLower());
            if (excludeId.HasValue)
            {
                busqueda = busqueda.Where(c => c.Id != excludeId.Value);
            }
            return Task.FromResult(busqueda.Any());
        }

    }
}
