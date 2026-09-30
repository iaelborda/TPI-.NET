using Domain.Model;


namespace DTOs
{
    public class TarifaDTO
    {
        public int Id { get; set; }
        public decimal PrecioHora { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int CategoriaId { get; set; }
        public string? DescripcionCategoria { get; set; }
    }
}
