using Domain.Model;

namespace DTOs
{
    public class BicicletaCriteriaDTO
    {
        public string? Busqueda { get; set; }
        public int? CategoriaId { get; set; }
        public int? SucursalId { get; set; }
        public EstadoBicicleta? Estado { get; set; }
    }
}
