using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> AddAsync(ClienteDTO dto)
        {
            if (await clienteRepository.EmailExistsAsync(dto.Email))
            {
                throw new ArgumentException($"Ya existe un cliente con el Email '{dto.Email}'.");
            }

            if (await clienteRepository.DocumentoExistsAsync(dto.Documento))
            {
                throw new ArgumentException($"Ya existe un cliente con el documento '{dto.Documento}'.");
            }

            var fechaAlta = DateOnly.FromDateTime(DateTime.Now);
            Cliente cliente = new Cliente(dto.Id, dto.Documento, dto.TipoDocumento, dto.Nombre, dto.Apellido, dto.Telefono, dto.Email, fechaAlta);

            await clienteRepository.AddAsync(cliente);

            dto.Id = cliente.Id;
            dto.FechaAlta = cliente.FechaAlta;

            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await clienteRepository.DeleteAsync(id);
        }

        public async Task<ClienteDTO?> GetAsync(int id)
        {
            Cliente? cliente = await clienteRepository.GetAsync(id);

            if (cliente == null)
                return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Documento = cliente.Documento,
                TipoDocumento = cliente.TipoDocumento,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                FechaAlta = cliente.FechaAlta
            };
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            var clientes = await clienteRepository.GetAllAsync();

            return clientes.Select(cliente => new ClienteDTO
            {
                Id = cliente.Id, 
                Documento = cliente.Documento,
                TipoDocumento = cliente.TipoDocumento,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                FechaAlta = cliente.FechaAlta

            }).ToList();
        }

        public async Task<bool> UpdateAsync(ClienteDTO dto)
        {
            var existing = await clienteRepository.GetAsync(dto.Id);

            if (existing == null)
                return false;

            if (await clienteRepository.EmailExistsAsync(
                dto.Email, existing.Documento))
            {
                throw new ArgumentException(
                    $"Ya existe otro cliente con el Email '{dto.Email}'.");
            }

            Cliente cliente = new Cliente(
                dto.Id,
                existing.Documento,
                dto.TipoDocumento,
                dto.Nombre,
                dto.Apellido,
                dto.Telefono,
                dto.Email,
                existing.FechaAlta
            );

            cliente.SetId(existing.Id);

            return await clienteRepository.UpdateAsync(cliente);
        }
    }
}