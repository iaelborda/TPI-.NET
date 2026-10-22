using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository pagoRepository;
        private readonly AlquilerRepository alquilerRepository;

        public PagoService(IPagoRepository pagoRepository, AlquilerRepository alquilerRepository)
        {
            this.pagoRepository = pagoRepository;
            this.alquilerRepository = alquilerRepository;
        }

        public async Task<PagoDTO> AddAsync(PagoDTO dto)
        {
            if(dto.IdAlquiler <= 0)
            {
                throw new ArgumentException("El Id de alquiler debe ser mayor que cero.");
            }
            var alquiler = await alquilerRepository.GetAsync(dto.IdAlquiler);
            if(alquiler == null)
            {
                throw new ArgumentException($"No se encontró el alquiler con Id {dto.IdAlquiler}.");
            }
            if(await pagoRepository.AlquilerTienePagoAsync(dto.IdAlquiler))
            {
                throw new InvalidOperationException($"El alquiler {dto.IdAlquiler} ya cuenta con un pago registrado.");
            }
            if (alquiler.EstadoAlquiler == EstadoDeAlquiler.Cancelado)
            {
                throw new InvalidOperationException("No se pueden pagar alquileres cancelados.");
            }
            if (alquiler.DetallesAlquiler == null || !alquiler.DetallesAlquiler.Any())
            {
                throw new InvalidOperationException("El alquiler no tiene bicicletas asignadas.");
            }
            if (alquiler.DetallesAlquiler.Any(d => d.HoraFin == null))
            {
                throw new InvalidOperationException("No se puede registrar el pago: aún hay bicicletas pendientes de devolución.");
            }
            var pago = new Pago(dto.IdAlquiler, dto.Metodo);
            pago.CalcularMonto(alquiler.DetallesAlquiler.ToList());
            await pagoRepository.AddAsync(pago);

            alquiler.SetEstadoAlquiler(EstadoDeAlquiler.Finalizado);
            await alquilerRepository.UpdateAsync(alquiler);

            dto.IdPago = pago.IdPago;
            dto.FechaPago = pago.FechaPago;
            dto.Monto = pago.Monto;
            dto.ClienteNombre = alquiler.Cliente?.Nombre;
            dto.ClienteApellido = alquiler.Cliente?.Apellido;
            dto.EmpleadoApellido = alquiler.Empleado?.Apellido;
            dto.FechaAlquiler = alquiler.FechaAlquiler;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pago = await pagoRepository.GetAsync(id);
            if (pago == null)
                return false;
            var alquiler = await alquilerRepository.GetAsync(pago.IdAlquiler);
            if (alquiler != null)
            {
                alquiler.SetEstadoAlquiler(EstadoDeAlquiler.Activo);
                await alquilerRepository.UpdateAsync(alquiler);
            }
            return await pagoRepository.DeleteAsync(id);
        }

        public async Task<PagoDTO?> GetAsync(int id)
        {
            var pago = await pagoRepository.GetAsync(id);
            if (pago == null)
            {
                return null;
            }
            var alquiler = await alquilerRepository.GetAsync(pago.IdAlquiler);
            return new PagoDTO
            {
                IdPago = pago.IdPago,
                IdAlquiler = pago.IdAlquiler,
                FechaPago = pago.FechaPago,
                Monto = pago.Monto,
                Metodo = pago.Metodo,
                ClienteNombre = alquiler?.Cliente?.Nombre,
                ClienteApellido = alquiler?.Cliente?.Apellido,
                EmpleadoApellido = alquiler?.Empleado?.Apellido,
                FechaAlquiler = alquiler?.FechaAlquiler
            };
        }

        public async Task<PagoDTO?> GetByAlquilerIdAsync(int alquilerId)
        {
            var pago = await pagoRepository.GetByAlquilerIdAsync(alquilerId);
            if (pago == null)
            {
                return null;
            }
            var alquiler = await alquilerRepository.GetAsync(pago.IdAlquiler);
            return new PagoDTO
            {
                IdPago = pago.IdPago,
                IdAlquiler = pago.IdAlquiler,
                FechaPago = pago.FechaPago,
                Monto = pago.Monto,
                Metodo = pago.Metodo,
                ClienteNombre = alquiler?.Cliente?.Nombre,
                ClienteApellido = alquiler?.Cliente?.Apellido,
                EmpleadoApellido = alquiler?.Empleado?.Apellido,
                FechaAlquiler = alquiler?.FechaAlquiler
            };
        }

        public async Task<IEnumerable<PagoDTO>> GetAllAsync()
        {
            var pagos = await pagoRepository.GetAllAsync();
            var alquileres = (await alquilerRepository.GetAllAsync()).ToDictionary(a => a.Id);
            return pagos.Select(p =>
            {
                alquileres.TryGetValue(p.IdAlquiler, out var alq);
                return new PagoDTO
                {
                    IdPago = p.IdPago,
                    IdAlquiler = p.IdAlquiler,
                    FechaPago = p.FechaPago,
                    Monto = p.Monto,
                    Metodo = p.Metodo,
                    ClienteNombre = alq?.Cliente?.Nombre,
                    ClienteApellido = alq?.Cliente?.Apellido,
                    EmpleadoApellido = alq?.Empleado?.Apellido,
                    FechaAlquiler = alq?.FechaAlquiler
                };
            }).ToList();
        }

        public async Task<bool> UpdateAsync(PagoDTO dto)
        {
            var existing = await pagoRepository.GetAsync(dto.IdPago);
            if (existing == null)
                return false;
            existing.SetMetodoPago(dto.Metodo);
            return await pagoRepository.UpdateAsync(existing);
        }
    }
}
