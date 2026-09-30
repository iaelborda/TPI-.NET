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
                if (value != null && _bicicletaId != value.Id)
                {
                    _bicicletaId = value.Id;
                }
            }
        }

        public DateTime HoraInicio { get; private set; }
        public DateTime? HoraFin { get; private set; }
        public EstadoDetalleAlquiler Estado { get; private set; }
        public decimal PrecioHora { get; private set; }
        public decimal Subtotal { get; private set; }

        public DetalleAlquiler(int AlquilerId, int BicicletaId)
        {
            SetAlquilerId(AlquilerId);
            SetBicicletaId(BicicletaId);
            HoraInicio = DateTime.Now;
            HoraFin = null;
            Estado = EstadoDetalleAlquiler.Activo;
            PrecioHora = 0;
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

            if (_bicicleta != null && _bicicleta.Id != bicicletaId)
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

        public void SetHoraInicio(DateTime horaInicio)
        {
            HoraInicio = horaInicio;
        }

        public void SetHoraFin(DateTime? horaFin)
        {
            HoraFin = horaFin;
        }

        public void SetEstado(EstadoDetalleAlquiler estado)
        {
            Estado = estado;
        }

        public void SetPrecioHora(decimal precioHora)
        {
            if (precioHora <= 0)
            {
                throw new ArgumentException("El precio por hora debe ser mayor que 0", nameof(precioHora));
            }

            PrecioHora = precioHora;
        }

        public void SetSubtotal(decimal subtotal)
        {
            if (subtotal < 0)
            {
                throw new ArgumentException("El subtotal no puede ser menor que 0", nameof(subtotal));
            }

            Subtotal = subtotal;
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

        public void CalcularSubTotal(decimal precioHora)
        {
            if (HoraFin == null)
            {
                throw new InvalidOperationException("No se puede calcular el subtotal si la bicicleta no ha sido devuelta.");
            }

            if (precioHora <= 0)
            {
                throw new InvalidOperationException("La tarifa debe tener un precio por hora válido.");
            }

            SetPrecioHora(precioHora);

            TimeSpan duracion = HoraFin.Value - HoraInicio;
            decimal horas = (decimal)duracion.TotalHours;
            horas = Math.Ceiling(horas);

            Subtotal = horas * PrecioHora;
        }
    }
}