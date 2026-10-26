namespace Domain.Model
{
    public class Tarifa
    {
        public int Id { get; private set; }
        public decimal PrecioHora { get; private set; }
        public DateTime FechaDesde { get; private set; }
        public DateTime? FechaHasta { get; private set; }

        private int _categoriaId;
        private Categoria? _categoria;
        public int CategoriaId
        {
            get => _categoria?.Id ?? _categoriaId;
            private set => _categoriaId = value;
        }
        public Categoria? Categoria
        {
            get => _categoria;
            private set
            {
                _categoria = value;

                if (value != null && _categoriaId != value.Id)
                {
                    _categoriaId = value.Id;
                }
            }
        }
        public Tarifa(decimal precioHora, DateTime fechaDesde, DateTime? fechaHasta, int categoriaId)
        {
            SetPrecioHora(precioHora);
            SetFechaDesde(fechaDesde);
            SetFechaHasta(fechaHasta);
            SetCategoriaId(categoriaId);
        }
        public void SetId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor o igual a 0.", nameof(id));

            Id = id;
        }
        public static void ValidarPrecioHora(decimal precioHora)
        {
            if (precioHora <= 0 || precioHora > 1000000)
                throw new ArgumentException("El precio por hora debe ser mayor que 0 y no superar 1.000.000.", nameof(precioHora));
        }

        public void SetPrecioHora(decimal precioHora)
        {
            ValidarPrecioHora(precioHora);
            PrecioHora = precioHora;
        }

        public void SetFechaDesde(DateTime fechaDesde)
        {
            FechaDesde = fechaDesde;
        }

        public void SetFechaHasta(DateTime? fechaHasta)
        {
            if (fechaHasta.HasValue && fechaHasta < FechaDesde)
                throw new ArgumentException("La fecha hasta no puede ser anterior a la fecha desde.", nameof(fechaHasta));

            FechaHasta = fechaHasta;
        }

        public void SetCategoriaId(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("La categoría es obligatoria.", nameof(categoriaId));

            _categoriaId = categoriaId;

            if (_categoria != null && _categoria.Id != categoriaId)
            {
                _categoria = null;
            }
        }
    }
}
