using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using DTOs;
using Data;

namespace Application.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository sucursalRepository;
        public SucursalService(ISucursalRepository sucursalRepository)
        {
            this.sucursalRepository = sucursalRepository;
        }

        public async Task<SucursalDTO> AddAsync(SucursalDTO dto)
        {
            if (await sucursalRepository.NombreExistsAsync(dto.Nombre))
            {
                throw new ArgumentException($"Ya existe una sucursal con el nombre '{dto.Nombre}'.");
            }
            Sucursal sucursal = new Sucursal(0, dto.Nombre, dto.Direccion, dto.Telefono, dto.Capacidad);
            await sucursalRepository.AddAsync(sucursal);
            dto.Id = sucursal.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await sucursalRepository.DeleteAsync(id);
        }

        public async Task<SucursalDTO?> GetAsync(int id)
        {
            Sucursal? sucursal = await sucursalRepository.GetAsync(id);
            if (sucursal == null)
            {
                return null;
            }
            return new SucursalDTO
            {
                Id = sucursal.Id,
                Nombre = sucursal.Nombre,
                Direccion = sucursal.Direccion,
                Telefono = sucursal.Telefono,
                Capacidad = sucursal.Capacidad
            };
        }

        public async Task<IEnumerable<SucursalDTO>> GetAllAsync()
        {
            var sucursales = await sucursalRepository.GetAllAsync();
            return sucursales.Select(sucursal => new SucursalDTO
            {
                Id = sucursal.Id,
                Nombre = sucursal.Nombre,
                Direccion = sucursal.Direccion,
                Telefono = sucursal.Telefono,
                Capacidad = sucursal.Capacidad
            }).ToList();
        }

        public async Task<bool> UpdateAsync(SucursalDTO dto)
        {
            var busqueda = await sucursalRepository.GetAsync(dto.Id);
            if (busqueda == null)
            {
                return false;
            }
            if(await sucursalRepository.NombreExistsAsync(dto.Nombre, dto.Id))
            {
                throw new ArgumentException($"Ya existe una sucursal con el nombre '{dto.Nombre}'");
            }
            Sucursal sucursal = new Sucursal(dto.Id, dto.Nombre, dto.Direccion, dto.Telefono, dto.Capacidad);
            return await sucursalRepository.UpdateAsync(sucursal);
        }
    }
}
