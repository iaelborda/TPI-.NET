namespace Domain.Model
{
    public enum EstadoBicicleta
    {
        Disponible,
        EnUso,
        EnMantenimiento
    }
    public class Bicicleta
    {
        public int Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public EstadoBicicleta Estado {  get; private set; }

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

                if(value != null && _categoriaId != value.Id)
                {
                    _categoriaId = value.Id;
                }
            }
        }
        public Bicicleta(int id, string marca, string modelo, EstadoBicicleta estado, int categoriaId)
        {
            SetId(id);
            SetMarca(marca);
            SetModelo(modelo);
            SetEstado(estado);
            SetCategoriaId(categoriaId);
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetMarca(string marca)
        {
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca no puede ser nula o vacía.", nameof(marca));
            Marca = marca;
        }

        public void SetModelo(string modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("El modelo no puede ser nulo o vacío.", nameof(modelo));
            Modelo = modelo;
        }

        public void SetEstado(EstadoBicicleta estado)
        {
            if (!Enum.IsDefined(typeof(EstadoBicicleta), estado))
                throw new ArgumentException("El estado de la bicicleta no es válido.", nameof(estado));
            Estado = estado;
        }

        public void SetCategoriaId(int categoriaId)
        {
            if(categoriaId <= 0)
                throw new ArgumentException("La categoria es obligatoria. ", nameof(categoriaId));

            _categoriaId = categoriaId;

            if(_categoria != null && _categoria.Id != categoriaId)
            {
                _categoria = null;
            }
        }

        public void SetCategoria(Categoria categoria)
        {
            ArgumentNullException.ThrowIfNull(categoria);
            _categoria = categoria;
            _categoriaId = categoria.Id;
        }
    }
}
