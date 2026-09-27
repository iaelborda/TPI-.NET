using Domain.Model;

namespace DTOs
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }
        public string Documento { get; set; } = string.Empty;
        public TipoDocumento TipoDocumento { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int Legajo { get; set; }
        public int SucursalId { get; set; }
        public string? NombreSucursal { get; set; }
    }
}
