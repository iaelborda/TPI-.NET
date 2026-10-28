using Domain.Model;

namespace DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly? FechaAlta { get; set; }
    }
}