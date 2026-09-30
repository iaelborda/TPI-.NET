using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;
using System.Transactions;
namespace Application.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository tarifaRepository;
        private readonly ICategoriaRepository categoriaRepository;

        public TarifaService(ITarifaRepository tarifaRepository, ICategoriaRepository categoriaRepository)
        {
            this.tarifaRepository = tarifaRepository;
            this.categoriaRepository = categoriaRepository;
        }

        public async Task<TarifaDTO> AddAsync(TarifaDTO dto)
        {
            var categoria = await categoriaRepository.GetAsync(dto.CategoriaId);
            if(categoria == null)
            {
                throw new ArgumentException($"No existe la categoria con el Id {dto.CategoriaId}");
            }
            var ahora = DateTime.Now;

            var tarifaVigente = await tarifaRepository.GetTarifaVigenteAsync(dto.CategoriaId);
            if (tarifaVigente != null)
            {
                tarifaVigente.SetFechaHasta(ahora);
                await tarifaRepository.UpdateAsync(tarifaVigente);
            }
            Tarifa nuevaTarifa = new Tarifa(
                dto.PrecioHora,
                ahora,
                null,
                dto.CategoriaId);
            await tarifaRepository.AddAsync(nuevaTarifa);
            dto.Id = nuevaTarifa.Id;
            dto.FechaDesde = nuevaTarifa.FechaDesde;
            dto.FechaHasta = null;
            dto.DescripcionCategoria = categoria.Descripcion;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await tarifaRepository.DeleteAsync(id);
        }

        public async Task<TarifaDTO?> GetAsync(int id)
        {
            var tarifa = await tarifaRepository.GetAsync(id);
            if( tarifa == null)
            {
                return null;
            }
            return new TarifaDTO
            {
                Id = tarifa.Id,
                PrecioHora = tarifa.PrecioHora,
                FechaDesde = tarifa.FechaDesde,
                FechaHasta = tarifa.FechaHasta,
                CategoriaId = tarifa.CategoriaId,
                DescripcionCategoria = tarifa.Categoria?.Descripcion
            };
        }

        public async Task<IEnumerable<TarifaDTO>> GetAllAsync()
        {
            var tarifas = await tarifaRepository.GetAllAsync();
            return tarifas.Select(tarifa => new TarifaDTO
            {
                Id = tarifa.Id,
                PrecioHora = tarifa.PrecioHora,
                FechaDesde = tarifa.FechaDesde,
                FechaHasta = tarifa.FechaHasta,
                CategoriaId = tarifa.CategoriaId,
                DescripcionCategoria = tarifa.Categoria?.Descripcion
            }).ToList();
        }

        public async Task<IEnumerable<TarifaDTO>> GetByCategoriaIdAsync(int categoriaId)
        {
            var tarifas = await tarifaRepository.GetByCategoriaIdAsync(categoriaId);
            return tarifas.Select(tarifa => new TarifaDTO
            {
                Id = tarifa.Id,
                PrecioHora = tarifa.PrecioHora,
                FechaDesde = tarifa.FechaDesde,
                FechaHasta = tarifa.FechaHasta,
                CategoriaId = tarifa.CategoriaId,
                DescripcionCategoria = tarifa.Categoria?.Descripcion
            }).ToList();
        }

        public async Task<bool> UpdateAsync(TarifaDTO dto)
        {
            var existing = await tarifaRepository.GetAsync(dto.Id);
            if(existing == null)
            {
                return false;
            }
            var categoria = await categoriaRepository.GetAsync(dto.CategoriaId);
            if(categoria == null)
            {
                throw new ArgumentException($"No existe la categoria con el id {dto.CategoriaId}.");
            }
            if(dto.FechaHasta.HasValue && dto.FechaHasta < dto.FechaDesde)
            {
                throw new ArgumentException("La fecha hasta no puede ser menor a la fecha desde.");
            }
            Tarifa tarifa = new Tarifa(
                dto.PrecioHora,
                dto.FechaDesde,
                dto.FechaHasta,
                dto.CategoriaId);
            tarifa.SetId(dto.Id);
            return await tarifaRepository.UpdateAsync(tarifa);
        }
    }
}
