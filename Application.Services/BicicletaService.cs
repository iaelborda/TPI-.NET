using Data;
using Domain.Model;
using DTOs;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Application.Services
{
    public class BicicletaService : IBicicletaService
    {
        private readonly IBicicletaRepository bicicletaRepository;
        private readonly ICategoriaRepository categoriaRepository;
        public BicicletaService(IBicicletaRepository bicicletaRepository, ICategoriaRepository categoriaRepository)
        {
            this.bicicletaRepository = bicicletaRepository;
            this.categoriaRepository = categoriaRepository;
        }

        public async Task<BicicletaDTO> AddAsync(BicicletaDTO dto)
        {
            var categoria = await categoriaRepository.GetAsync(dto.CategoriaId);
            if(categoria == null)
            {
                throw new ArgumentException($"Categoria con ID {dto.CategoriaId} no existe.");
            }

            Bicicleta bicicleta = new Bicicleta(0, dto.Marca, dto.Modelo, dto.Estado, dto.CategoriaId);
            await bicicletaRepository.AddAsync(bicicleta);
            dto.Id = bicicleta.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await bicicletaRepository.DeleteAsync(id);
        }

        public async Task<BicicletaDTO?> GetAsync(int id)
        {
            Bicicleta? bicicleta = await bicicletaRepository.GetAsync(id);

            if (bicicleta == null)
                return null;

            return new BicicletaDTO
            {
                Id = bicicleta.Id,
                Marca = bicicleta.Marca,
                Modelo = bicicleta.Modelo,
                CategoriaId = bicicleta.CategoriaId,
                Estado = bicicleta.Estado
            };
        }

        public async Task<IEnumerable<BicicletaDTO>> GetAllAsync()
        {
            var bicicletas = await bicicletaRepository.GetAllAsync();

            return bicicletas.Select(bicicleta => new BicicletaDTO
            {
                Id = bicicleta.Id,
                Marca = bicicleta.Marca,
                Modelo = bicicleta.Modelo,
                CategoriaId = bicicleta.CategoriaId,
                Estado = bicicleta.Estado
            }).ToList();
        }

        public async Task<bool> UpdateAsync(BicicletaDTO dto)
        {
            var existing = await bicicletaRepository.GetAsync(dto.Id);

            if(existing == null) return false;
            var categoria = await categoriaRepository.GetAsync(dto.CategoriaId);
            if(categoria == null)
            {
                throw new ArgumentException($"Categoria con ID {dto.CategoriaId} no existe.");
            }

            Bicicleta bicicleta = new Bicicleta(
                dto.Id,
                dto.Marca,
                dto.Modelo,
                dto.Estado,
                dto.CategoriaId
                );

            return await bicicletaRepository.UpdateAsync(bicicleta);
        }
    }
}
