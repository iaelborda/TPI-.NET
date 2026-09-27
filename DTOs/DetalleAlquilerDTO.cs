using Domain.Model;
namespace DTOs
{
    public class DetalleAlquilerDTO
    {
        public int AlquilerId { get; set; }
        public int BicicletaId { get; set; }
        public string? BicicletaMarca { get; set; }
        public string? BicicletaModelo { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime ? HoraFin {  get; set; }
        public EstadoDetalleAlquiler Estado { get; set; }
        public decimal Subtotal { get; set; }
    }
}
