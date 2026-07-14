using System;
using Domain.Model;

namespace Data
{
    public class BicicletaRepository : IBicicletaRepository
    {
        private static readonly List<Bicicleta> bicicletas = new List<Bicicleta>();
        public Task AddAsync(Bicicleta bicicleta)
        {
            bicicletas.Add(bicicleta);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var bicicleta = bicicletas.FirstOrDefault(b => b.Id == id);
            if (bicicleta != null)
            {
                bicicletas.Remove(bicicleta);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<Bicicleta?> GetAsync(int id)
        {
            return Task.FromResult(bicicletas.FirstOrDefault(b => b.Id == id));
        }

        public Task<IEnumerable<Bicicleta>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Bicicleta>>(bicicletas.ToList());
        }

        public Task<bool> UpdateAsync(Bicicleta bicicleta)
        {
            var existing = bicicletas.FirstOrDefault(b => bicicleta.Id == b.Id);

            if(existing != null)
            {
                existing.SetMarca(bicicleta.Marca);
                existing.SetModelo(bicicleta.Modelo);
                existing.SetEstado(bicicleta.Estado);
                existing.SetCategoriaId(bicicleta.CategoriaId);

                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
