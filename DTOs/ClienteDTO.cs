using Domain.Model;

namespace DTOs
{
    public class ClienteDTO
    {
        public string Documento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateOnly FechaAlta { get; set; }
    }
}