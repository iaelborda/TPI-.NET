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
        private readonly ITarifaRepository tarifaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository, IBicicletaRepository bicicletaRepository, ITarifaRepository tarifaRepository)
        {
            this.categoriaRepository = categoriaRepository;
            this.bicicletaRepository = bicicletaRepository;
            this.tarifaRepository = tarifaRepository;
        }

        public async Task<CategoriaDTO> AddAsync(CategoriaDTO dto)
        {
            if (await categoriaRepository.DescripcionExistsAsync(dto.Descripcion))
            {
                throw new ArgumentException($"La descripcion '{dto.Descripcion}' ya existe");
            }
            if (!dto.PrecioHoraInicial.HasValue || dto.PrecioHoraInicial.Value <= 0)
            {
                throw new ArgumentException("Debe ingresar un precio por hora inicial mayor a cero para la categoría.");
            }
            Categoria categoria = new Categoria(dto.Descripcion);
            await categoriaRepository.AddAsync(categoria);
            var tarifaInicial = new Tarifa(
                dto.PrecioHoraInicial.Value,
                DateTime.Now,
                null,
                categoria.Id
            );
            await tarifaRepository.AddAsync(tarifaInicial);
            dto.Id = categoria.Id;
            dto.PrecioHoraVigente = tarifaInicial.PrecioHora;
            dto.TarifaVigente = new TarifaDTO
            {
                Id = tarifaInicial.Id,
                PrecioHora = tarifaInicial.PrecioHora,
                FechaDesde = tarifaInicial.FechaDesde,
                FechaHasta = null,
                CategoriaId = categoria.Id,
                DescripcionCategoria = categoria.Descripcion
            };
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
            var tarifaVigente = categoria.tarifas?.FirstOrDefault(t => t.FechaHasta == null);
            return new CategoriaDTO
            {
                Id = categoria.Id,
                Descripcion = categoria.Descripcion,
                PrecioHoraVigente = tarifaVigente?.PrecioHora,
                TarifaVigente = tarifaVigente == null ? null : new TarifaDTO
                {
                    Id = tarifaVigente.Id,
                    PrecioHora = tarifaVigente.PrecioHora,
                    FechaDesde = tarifaVigente.FechaDesde,
                    FechaHasta = tarifaVigente.FechaHasta,
                    CategoriaId = tarifaVigente.CategoriaId,
                    DescripcionCategoria = categoria.Descripcion
                }
            };
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {
            var categorias = await categoriaRepository.GetAllAsync();
            return categorias.Select(c =>
            {
                var tarifaVigente = c.tarifas?.FirstOrDefault(t => t.FechaHasta == null);
                return new CategoriaDTO
                {
                    Id = c.Id,
                    Descripcion = c.Descripcion,
                    PrecioHoraVigente = tarifaVigente?.PrecioHora,
                    TarifaVigente = tarifaVigente == null ? null : new TarifaDTO
                    {
                        Id = tarifaVigente.Id,
                        PrecioHora = tarifaVigente.PrecioHora,
                        FechaDesde = tarifaVigente.FechaDesde,
                        FechaHasta = tarifaVigente.FechaHasta,
                        CategoriaId = tarifaVigente.CategoriaId,
                        DescripcionCategoria = c.Descripcion
                    }
                };
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
                throw new ArgumentException($"Ya existe una categoría con la descripcion '{dto.Descripcion}'");
            }
            Categoria categoria = new Categoria(dto.Descripcion);
            categoria.SetId(dto.Id);
            return await categoriaRepository.UpdateAsync(categoria);
        }
    }
}
