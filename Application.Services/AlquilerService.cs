using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class AlquilerService
    {
        public async Task<AlquilerDTO> AddAsync(AlquilerDTO dto)
        {
            var alquilerRepository = new AlquilerRepository();
            var fechaAlquiler = DateTime.Now;
            var alquiler = new Alquiler(0,dto.ClienteId,dto.EmpleadoId,fechaAlquiler);

            foreach (var detalleDto in dto.Detalles)
            {
                var detalle = new DetalleAlquiler(0,detalleDto.BicicletaId);

                alquiler.AddDetalle(detalle);
            }

            await alquilerRepository.AddAsync(alquiler);

            dto.Id = alquiler.Id;
            dto.FechaAlquiler = alquiler.FechaAlquiler;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alquilerRepository = new AlquilerRepository();
            return await alquilerRepository.DeleteAsync(id);
        }

        public async Task<AlquilerDTO?> GetAsync(int id)
        {
            var alquilerRepository = new AlquilerRepository();

            Alquiler? alquiler = await alquilerRepository.GetAsync(id);

            if (alquiler == null)
                return null;

            return new AlquilerDTO
            {
                Id = alquiler.Id,
                ClienteId = alquiler.ClienteId,
                ClienteNombre = alquiler.Cliente?.Nombre,
                ClienteApellido = alquiler.Cliente?.Apellido,
                EmpleadoId = alquiler.EmpleadoId,
                EmpleadoApellido = alquiler.Empleado?.Apellido,
                EmpleadoLegajo = alquiler.Empleado?.Legajo,
                FechaAlquiler = alquiler.FechaAlquiler,
                EstadoAlquiler = alquiler.EstadoAlquiler,

                Detalles = alquiler.DetallesAlquiler.Select(detalle => new DetalleAlquilerDTO
                {
                    AlquilerId = detalle.AlquilerId,
                    BicicletaId = detalle.BicicletaId,
                    BicicletaMarca = detalle.Bicicleta?.Marca,
                    BicicletaModelo = detalle.Bicicleta?.Modelo,
                    HoraInicio = detalle.HoraInicio,
                    HoraFin = detalle.HoraFin,
                    Estado = detalle.Estado,
                    Subtotal = detalle.Subtotal
                }).ToList()
            };
        }

        public async Task<IEnumerable<AlquilerDTO>> GetAllAsync()
        {
            var alquilerRepository = new AlquilerRepository();

            var alquileres = await alquilerRepository.GetAllAsync();

            return alquileres.Select(alquiler => new AlquilerDTO
            {
                Id = alquiler.Id,
                ClienteId = alquiler.ClienteId,
                ClienteNombre = alquiler.Cliente?.Nombre,
                ClienteApellido = alquiler.Cliente?.Apellido,
                EmpleadoId = alquiler.EmpleadoId,
                EmpleadoApellido = alquiler.Empleado?.Apellido,
                EmpleadoLegajo = alquiler.Empleado?.Legajo,
                FechaAlquiler = alquiler.FechaAlquiler,
                EstadoAlquiler = alquiler.EstadoAlquiler,

                Detalles = alquiler.DetallesAlquiler.Select(detalle => new DetalleAlquilerDTO
                {
                    AlquilerId = detalle.AlquilerId,
                    BicicletaId = detalle.BicicletaId,
                    BicicletaMarca = detalle.Bicicleta?.Marca,
                    BicicletaModelo = detalle.Bicicleta?.Modelo,
                    HoraInicio = detalle.HoraInicio,
                    HoraFin = detalle.HoraFin,
                    Estado = detalle.Estado,
                    Subtotal = detalle.Subtotal
                }).ToList()
            }).ToList();
        }

        public async Task<bool> UpdateAsync(AlquilerDTO dto)
        {
            var alquilerRepository = new AlquilerRepository();

            var alquiler = new Alquiler(dto.Id,dto.ClienteId,dto.EmpleadoId,dto.FechaAlquiler
            );

            foreach (var detalleDto in dto.Detalles)
            {
                var detalle = new DetalleAlquiler(dto.Id,detalleDto.BicicletaId
                );

                alquiler.AddDetalle(detalle);
            }

            return await alquilerRepository.UpdateAsync(alquiler);
        }
    }
}