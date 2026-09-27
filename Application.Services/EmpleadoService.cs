using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        public async Task<EmpleadoDTO> AddAsync(EmpleadoDTO dto)
        {
            if (await empleadoRepository.DocumentoExistsAsync(dto.Documento))
            {
                throw new ArgumentException($"Ya existe un empleado con el documento '{dto.Documento}'.");
            }

            if (await empleadoRepository.LegajoExistsAsync(dto.Legajo))
            {
                throw new ArgumentException($"Ya existe un empleado con el legajo '{dto.Legajo}'.");
            }

            Empleado empleado = new Empleado(
                dto.Id,
                dto.Documento,
                dto.TipoDocumento,
                dto.Nombre,
                dto.Apellido,
                dto.Telefono,
                dto.Legajo,
                dto.SucursalId
            );

            await empleadoRepository.AddAsync(empleado);

            dto.Id = empleado.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await empleadoRepository.DeleteAsync(id);
        }

        public async Task<EmpleadoDTO?> GetAsync(int id)
        {
            var empleado = await empleadoRepository.GetAsync(id);
            if (empleado == null)
                return null;

            return new EmpleadoDTO
            {
                Id = empleado.Id,
                Documento = empleado.Documento,
                TipoDocumento = empleado.TipoDocumento,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Telefono = empleado.Telefono,
                Legajo = empleado.Legajo,
                SucursalId = empleado.SucursalId,
                NombreSucursal = empleado.Sucursal?.Nombre
            };
        }

        public async Task<IEnumerable<EmpleadoDTO>> GetAllAsync()
        {
            var empleados = await empleadoRepository.GetAllAsync();

            return empleados.Select(empleado => new EmpleadoDTO
            {
                Id = empleado.Id,
                Documento = empleado.Documento,
                TipoDocumento = empleado.TipoDocumento,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Telefono = empleado.Telefono,
                Legajo = empleado.Legajo,
                SucursalId = empleado.SucursalId,
                NombreSucursal = empleado.Sucursal?.Nombre
            }).ToList();
        }

        public async Task<bool> UpdateAsync(EmpleadoDTO dto)
        {
            var existing = await empleadoRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Empleado empleado = new Empleado(
                existing.Id,
                existing.Documento,
                dto.TipoDocumento,
                dto.Nombre,
                dto.Apellido,
                dto.Telefono,
                existing.Legajo,
                dto.SucursalId
            );

            return await empleadoRepository.UpdateAsync(empleado);
        }
    }
}
