namespace DTOs
{
    public class ReporteAlquileresDTO
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int SucursalId { get; set; }
        public string? Sucursal { get; set; }
        public int CantidadAlquileres { get; set; }
    }
}
