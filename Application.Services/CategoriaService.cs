using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository categoriaRepository;
        private readonly IBicicletaRepository bicicletaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository, IBicicletaRepository bicicletaRepository)
        {
            this.categoriaRepository = categoriaRepository;
            this.bicicletaRepository = bicicletaRepository;
        }

        public async Task<CategoriaDTO> AddAsync(CategoriaDTO dto)
        {
            if (await categoriaRepository.DescripcionExistsAsync(dto.Descripcion))
            {
                throw new ArgumentException($"La descripcion '{dto.Descripcion}' ya existe");
            }
            Categoria categoria = new Categoria(dto.Descripcion);
            await categoriaRepository.AddAsync(categoria);
            dto.Id = categoria.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await categoriaRepository.GetAsync(id);

            if (categoria == null) return false;

            var bicicletas = await bicicletaRepository.GetAllAsync();

            if(bicicletas.Any(b => b.CategoriaId == id))
            {
                throw new InvalidOperationException("No se puede borrar la categoría porque tiene bicicletas asociadas");
            }
            return await categoriaRepository.DeleteAsync(id);
        }

        public async Task<CategoriaDTO?> GetAsync(int id)
        {
            Categoria? categoria = await categoriaRepository.GetAsync(id);
            if (categoria == null)
            {
                return null;
            }
            return new CategoriaDTO
            {
                Id = categoria.Id,
                Descripcion = categoria.Descripcion
            };
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {
            var categorias = await categoriaRepository.GetAllAsync();
            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Descripcion = c.Descripcion
            }).ToList();
        }

        public async Task<bool> UpdateAsync(CategoriaDTO dto)
        {
            var busqueda = await categoriaRepository.GetAsync(dto.Id);
            if (busqueda == null)
            {
                return false;
            }
            if (await categoriaRepository.DescripcionExistsAsync(dto.Descripcion, dto.Id))
            {
                throw new ArgumentException($"Ya existe una sucursal con la descripcion '{dto.Descripcion}'");
            }
            Categoria categoria = new Categoria(dto.Descripcion);
            categoria.SetId(dto.Id);
            return await categoriaRepository.UpdateAsync(categoria);
        }
    }
}
