using Domain.Model;

namespace DTOs
{
    public class AlquilerDTO
    {
        public int Id { get; set; }
        public DateTime FechaAlquiler {  get; set; }
        public EstadoDeAlquiler EstadoAlquiler { get; set; }
        public int ClienteId { get; set; }
        public string? ClienteNombre { get; set; }
        public string? ClienteApellido { get; set; }
        public int EmpleadoId { get; set; }
        public string? EmpleadoApellido { get; set; }
        public int? EmpleadoLegajo { get; set; }
        public List<DetalleAlquilerDTO> Detalles { get; set; } = new();
    }
}
