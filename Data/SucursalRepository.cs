using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public class SucursalRepository : ISucursalRepository
    {
        private static readonly List<Sucursal> sucursales = new List<Sucursal>();
        public static int nextId = 1;

        public Task AddAsync(Sucursal sucursal)
        {
            sucursal.SetId(nextId);
            nextId++;
            sucursales.Add(sucursal);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var sucursal = sucursales.FirstOrDefault(s => s.Id == id);
            if (sucursal != null)
            {
                sucursales.Remove(sucursal);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<Sucursal?> GetAsync(int id)
        {
            return Task.FromResult(sucursales.FirstOrDefault(s => s.Id == id));
        }
        
        public Task<IEnumerable<Sucursal>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Sucursal>>(sucursales.ToList());
        }

        public Task<bool> UpdateAsync(Sucursal sucursal)
        {
            var existente = sucursales.FirstOrDefault(s => s.Id == sucursal.Id);
            if (existente != null)
            {
                existente.SetNombre(sucursal.Nombre);
                existente.SetDireccion(sucursal.Direccion);
                existente.SetTelefono(sucursal.Telefono);
                existente.SetCapacidad(sucursal.Capacidad);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> NombreExistsAsync(string nombre, int? excludeId = null)
        {
            var busqueda = sucursales.Where(s => s.Nombre.ToLower() == nombre.ToLower());
            if (excludeId.HasValue)
            {
                busqueda = busqueda.Where(s => s.Id != excludeId.Value);
            }
            return Task.FromResult(busqueda.Any());
        }
    }
}
