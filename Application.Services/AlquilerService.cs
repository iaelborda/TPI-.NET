using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class AlquilerService
    {
        private readonly AlquilerRepository alquilerRepository;
        private readonly IBicicletaRepository bicicletaRepository;
        private readonly ITarifaRepository tarifaRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly IEmpleadoRepository empleadoRepository;

        public AlquilerService(AlquilerRepository alquilerRepository, IBicicletaRepository bicicletaRepository, ITarifaRepository tarifaRepository, IClienteRepository clienteRepository, IEmpleadoRepository empleadoRepository)
        {
            this.alquilerRepository = alquilerRepository;
            this.bicicletaRepository = bicicletaRepository;
            this.tarifaRepository = tarifaRepository;
            this.clienteRepository = clienteRepository;
            this.empleadoRepository = empleadoRepository;
        }

        public async Task<AlquilerDTO> AddAsync(AlquilerDTO dto)
        {
            if (dto.Detalles == null || !dto.Detalles.Any())
                throw new ArgumentException("El alquiler debe tener al menos una bicicleta.");

            if (dto.Detalles.Any(d => d.BicicletaId <= 0))
                throw new ArgumentException("Todas las bicicletas deben tener un Id válido.");

            if (dto.Detalles.Select(d => d.BicicletaId).Distinct().Count() != dto.Detalles.Count)
                throw new ArgumentException("No se puede agregar la misma bicicleta más de una vez.");

            if (await clienteRepository.GetAsync(dto.ClienteId) == null)
                throw new ArgumentException("El cliente indicado no existe.");

            if (await empleadoRepository.GetAsync(dto.EmpleadoId) == null)
                throw new ArgumentException("El empleado indicado no existe.");

            var fechaAlquiler = DateTime.Now;
            var alquiler = new Alquiler(0, dto.ClienteId, dto.EmpleadoId, fechaAlquiler);

            foreach (var detalleDto in dto.Detalles)
            {
                var bicicleta = await bicicletaRepository.GetAsync(detalleDto.BicicletaId);

                if (bicicleta == null)
                    throw new ArgumentException($"No existe la bicicleta con Id {detalleDto.BicicletaId}.");

                if (await alquilerRepository.BicicletaEnAlquilerActivoAsync(bicicleta.Id))
                    throw new ArgumentException($"La bicicleta {bicicleta.Id} ya está en un alquiler activo.");

                var tarifa = await tarifaRepository.GetTarifaVigenteAsync(bicicleta.CategoriaId);

                if (tarifa == null)
                    throw new ArgumentException($"No hay una tarifa vigente para la bicicleta {bicicleta.Id}.");

                var detalle = new DetalleAlquiler(0, bicicleta.Id);
                detalle.SetHoraInicio(fechaAlquiler);
                detalle.SetPrecioHora(tarifa.PrecioHora);
                detalle.SetSubtotal(0);

                alquiler.AddDetalle(detalle);
            }

            await alquilerRepository.AddAsync(alquiler);

            dto.Id = alquiler.Id;
            dto.FechaAlquiler = alquiler.FechaAlquiler;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await alquilerRepository.DeleteAsync(id);
        }

        public async Task<AlquilerDTO?> GetAsync(int id)
        {
            var alquiler = await alquilerRepository.GetAsync(id);

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
                    CategoriaDescripcion = detalle.Bicicleta?.Categoria?.Descripcion,
                    HoraInicio = detalle.HoraInicio,
                    HoraFin = detalle.HoraFin,
                    Estado = detalle.Estado,
                    PrecioHora = detalle.PrecioHora,
                    Subtotal = detalle.Subtotal
                }).ToList()
            };
        }

        public async Task<IEnumerable<AlquilerDTO>> GetAllAsync()
        {
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
                    CategoriaDescripcion = detalle.Bicicleta?.Categoria?.Descripcion,
                    HoraInicio = detalle.HoraInicio,
                    HoraFin = detalle.HoraFin,
                    Estado = detalle.Estado,
                    PrecioHora = detalle.PrecioHora,
                    Subtotal = detalle.Subtotal
                }).ToList()
            }).ToList();
        }

        public async Task<bool> UpdateAsync(AlquilerDTO dto)
        {
            if (dto.Detalles == null || !dto.Detalles.Any())
                throw new ArgumentException("El alquiler debe tener al menos una bicicleta.");

            if (dto.Detalles.Select(d => d.BicicletaId).Distinct().Count() != dto.Detalles.Count)
                throw new ArgumentException("No se puede agregar la misma bicicleta más de una vez.");

            if (await clienteRepository.GetAsync(dto.ClienteId) == null)
                throw new ArgumentException("El cliente indicado no existe.");

            if (await empleadoRepository.GetAsync(dto.EmpleadoId) == null)
                throw new ArgumentException("El empleado indicado no existe.");

            var alquilerExistente = await alquilerRepository.GetAsync(dto.Id);

            if (alquilerExistente == null)
                return false;

            var alquiler = new Alquiler(dto.Id, dto.ClienteId, dto.EmpleadoId, alquilerExistente.FechaAlquiler);

            if (dto.EstadoAlquiler == EstadoDeAlquiler.Cancelado)
                alquiler.CancelarAlquiler();
            else
                alquiler.SetEstadoAlquiler(dto.EstadoAlquiler);

            foreach (var detalleDto in dto.Detalles)
            {
                var bicicleta = await bicicletaRepository.GetAsync(detalleDto.BicicletaId);

                if (bicicleta == null)
                    throw new ArgumentException($"No existe la bicicleta con Id {detalleDto.BicicletaId}.");

                if (await alquilerRepository.BicicletaEnAlquilerActivoAsync(bicicleta.Id, dto.Id))
                    throw new ArgumentException($"La bicicleta {bicicleta.Id} ya está en otro alquiler activo.");

                var tarifa = await tarifaRepository.GetTarifaVigenteAsync(bicicleta.CategoriaId);

                if (tarifa == null)
                    throw new ArgumentException($"No hay una tarifa vigente para la bicicleta {bicicleta.Id}.");

                var detalle = new DetalleAlquiler(dto.Id, bicicleta.Id);
                detalle.SetHoraInicio(detalleDto.HoraInicio);
                detalle.SetPrecioHora(tarifa.PrecioHora);

                if (detalleDto.HoraFin.HasValue)
                {
                    detalle.SetHoraFin(detalleDto.HoraFin);
                    detalle.CalcularSubTotal(tarifa.PrecioHora);
                    detalle.SetEstado(EstadoDetalleAlquiler.Devuelto);
                }
                else
                {
                    detalle.SetSubtotal(0);
                    detalle.SetEstado(EstadoDetalleAlquiler.Activo);
                }

                alquiler.AddDetalle(detalle);
            }

            return await alquilerRepository.UpdateAsync(alquiler);
        }
    }
}
