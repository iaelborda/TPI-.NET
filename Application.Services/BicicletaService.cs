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
        private readonly ISucursalRepository sucursalRepository;
        public BicicletaService(IBicicletaRepository bicicletaRepository, ICategoriaRepository categoriaRepository, ISucursalRepository sucursalRepository)
        {
            this.bicicletaRepository = bicicletaRepository;
            this.categoriaRepository = categoriaRepository;
            this.sucursalRepository = sucursalRepository;
        }

        public async Task<BicicletaDTO> AddAsync(BicicletaDTO dto)
        {
            var categoria = await categoriaRepository.GetAsync(dto.CategoriaId);
            if(categoria == null)
            {
                throw new ArgumentException($"Categoria con ID {dto.CategoriaId} no existe.");
            }

            var sucursal = await sucursalRepository.GetAsync(dto.SucursalId);

            if (sucursal == null)
            {
                throw new ArgumentException($"Sucursal con ID {dto.SucursalId} no existe.");
            }

            Bicicleta bicicleta = new Bicicleta(dto.Marca, dto.Modelo, dto.Estado, dto.CategoriaId, dto.SucursalId);
            await bicicletaRepository.AddAsync(bicicleta);
            dto.Id = bicicleta.Id;
            dto.DescripcionCategoria = categoria.Descripcion;
            dto.DireccionSucursal = sucursal.Direccion;
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
                SucursalId = bicicleta.SucursalId,
                DescripcionCategoria = bicicleta.Categoria?.Descripcion,
                DireccionSucursal = bicicleta.Sucursal?.Direccion,
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
                SucursalId = bicicleta.SucursalId,
                DescripcionCategoria = bicicleta.Categoria?.Descripcion,
                DireccionSucursal = bicicleta.Sucursal?.Direccion,
                Estado = bicicleta.Estado
            }).ToList();
        }

        public async Task<bool> UpdateAsync(BicicletaDTO dto)
        {
            var existing = await bicicletaRepository.GetAsync(dto.Id);
            var sucursal = await sucursalRepository.GetAsync(dto.SucursalId);

            if (existing == null) return false;
            var categoria = await categoriaRepository.GetAsync(dto.CategoriaId);
            if(categoria == null)
            {
                throw new ArgumentException($"Categoria con ID {dto.CategoriaId} no existe.");
            }

            if (sucursal == null)
            {
                throw new ArgumentException(
                    $"Sucursal con ID {dto.SucursalId} no existe.");
            }

            Bicicleta bicicleta = new Bicicleta(
                dto.Marca,
                dto.Modelo,
                dto.Estado,
                dto.CategoriaId,
                dto.SucursalId
                );
            bicicleta.SetId(dto.Id);

            return await bicicletaRepository.UpdateAsync(bicicleta);
        }
    }
}
