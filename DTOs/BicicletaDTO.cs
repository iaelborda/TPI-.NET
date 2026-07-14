using Domain.Model;

namespace DTOs
{
    public class BicicletaDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public EstadoBicicleta Estado { get; set; }
        public int CategoriaId { get; set; }
    }
}
