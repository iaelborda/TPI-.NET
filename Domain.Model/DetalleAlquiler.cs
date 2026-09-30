namespace Domain.Model
{
    public enum EstadoDetalleAlquiler
    {
        Activo,
        Devuelto
    }
    public class DetalleAlquiler
    {
        public int AlquilerId { get; private set; }

        private int _bicicletaId;
        private Bicicleta? _bicicleta;

        public int BicicletaId 
        {
            get => _bicicleta?.Id ?? _bicicletaId; 
            private set => _bicicletaId = value; 
        }

        public Bicicleta? Bicicleta
        {
            get => _bicicleta;
            private set
            {
                _bicicleta = value;
                if(value != null && _bicicletaId != value.Id)
                {
                    _bicicletaId = value.Id;
                }
            }
        }

        public DateTime HoraInicio { get; private set; }
        public DateTime? HoraFin { get; private set; }
        public EstadoDetalleAlquiler Estado { get; private set; }
        public decimal Subtotal { get; private set; }

        public DetalleAlquiler(int AlquilerId, int BicicletaId)
        {
            SetAlquilerId(AlquilerId);
            SetBicicletaId(BicicletaId);
            HoraInicio = DateTime.Now;
            HoraFin = null;
            Estado = EstadoDetalleAlquiler.Activo;
            Subtotal = 0;
        }
   
        public void SetAlquilerId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El id del alquiler debe ser mayor o igual que 0", nameof(id));
            }
            AlquilerId = id;
        }

        public void SetBicicletaId(int bicicletaId)
        {
            if (bicicletaId <= 0)
            {
                throw new ArgumentException("El id de la bicicleta debe ser mayor que 0", nameof(bicicletaId));
            }

            _bicicletaId = bicicletaId;
            if(_bicicleta != null && _bicicleta.Id != bicicletaId)
            {
                _bicicleta = null;
            }
        }
        public void SetBicicleta(Bicicleta bicicleta)
        {
            ArgumentNullException.ThrowIfNull(bicicleta);
            _bicicleta = bicicleta;
            _bicicletaId = bicicleta.Id;
        }

        public void DevolverBicicleta()
        {
            if (HoraFin != null)
            {
                throw new InvalidOperationException("La bicicleta ya fue devuelta.");
            }

            if (Estado == EstadoDetalleAlquiler.Devuelto)
            {
                throw new InvalidOperationException("El detalle indica que la bicicleta ya fue devuelta.");
            }

            HoraFin = DateTime.Now;
            Estado = EstadoDetalleAlquiler.Devuelto;
        }

        public void CalcularSubTotal(Bicicleta bicicleta)
        {
            if (bicicleta == null)
            {
                throw new ArgumentNullException(nameof(bicicleta));
            }

            if (HoraFin == null)
            {
                throw new InvalidOperationException("No se puede calcular el subtotal si la bicicleta no ha sido devuelta.");
            }

            if (bicicleta.Categoria == null)
            {
                throw new InvalidOperationException("La bicicleta no tiene una categoría asociada.");
            }

            if (!bicicleta.Categoria.Tarifas.Any())
            {
                throw new InvalidOperationException("La bicicleta no tiene tarifas asociadas.");
            }

            var tarifaVigente = bicicleta.Categoria.Tarifas
                .Where(t => t.FechaDesde <= HoraInicio &&
                       (t.FechaHasta == null || t.FechaHasta >= HoraInicio))
                .OrderByDescending(t => t.FechaDesde)
                .FirstOrDefault();


            if (tarifaVigente == null)
            {
                throw new InvalidOperationException("No hay una tarifa vigente para esta bicicleta.");
            }

            decimal precioHora = tarifaVigente.PrecioHora;
            TimeSpan duracion = HoraFin.Value - HoraInicio;
            decimal horas = (decimal)duracion.TotalHours;
            horas = Math.Ceiling(horas);
            Subtotal = horas * precioHora;
        }
    }

}