namespace DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal? PrecioHoraInicial { get; set; } 
        public decimal? PrecioHoraVigente { get; set; }
        public TarifaDTO? TarifaVigente { get; set; }
    }
}
