namespace Domain.Model
{
    public enum EstadoDeAlquiler
    {
        Activo,
        Finalizado,
        Cancelado
    }

    public class Alquiler
    {

        public int Id { get; private set; }
        public DateTime FechaAlquiler { get; private set; }
        public EstadoDeAlquiler EstadoAlquiler { get; private set; }
        
        private int _clienteId;
        private Cliente? _cliente;
        public int ClienteId 
        {
            get => _cliente?.Id ?? _clienteId; 
            private set => _clienteId = value; 
        }

        public Cliente? Cliente
        {
            get => _cliente;
            private set
            {
                _cliente = value;
                if(value != null && _clienteId != value.Id)
                {
                    _clienteId = value.Id;
                }
            }
        }

        private int _empleadoId;
        private Empleado? _empleado;
        public int EmpleadoId 
        { 
            get => _empleado?.Id ?? _empleadoId;
            private set => _empleadoId = value; 
        }
        public Empleado? Empleado
        {
            get => _empleado;
            private set
            {
                _empleado = value;
                if (value != null && _empleadoId != value.Id)
                {
                    _empleadoId = value.Id;
                }
            }
        }

        private readonly List<DetalleAlquiler> _detallesAlquiler = new();
        public IReadOnlyList<DetalleAlquiler> DetallesAlquiler => _detallesAlquiler.AsReadOnly();
        public Alquiler(int id, int clienteId, int empleadoId, DateTime fechaAlquiler)
        {
            SetId(id);
            SetClienteId(clienteId);
            SetEmpleadoId(empleadoId);
            EstadoAlquiler = EstadoDeAlquiler.Activo;
            FechaAlquiler = DateTime.Now;
      
        }

        public void SetId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El id del alquiler debe ser mayor que cero.", nameof(id));
            }
            Id = id;
        }
        public void SetClienteId(int clienteId)
        {
            if (clienteId <= 0)
                throw new ArgumentException("El id del cliente debe ser mayor que cero.", nameof(clienteId));

            _clienteId = clienteId;

            if(_cliente != null && _cliente.Id != clienteId)
            {
                _cliente = null;
            }
        }

        public void SetCliente(Cliente cliente)
        {
            ArgumentNullException.ThrowIfNull(cliente);
            _cliente = cliente;
            _clienteId = cliente.Id;
        }

        public void SetEmpleadoId(int empleadoId)
        {
            if(empleadoId <= 0)
                throw new ArgumentException("El id del empleado debe ser mayor que cero.", nameof(empleadoId));

            _empleadoId = empleadoId;

            if(_empleado != null && _empleado.Id != empleadoId)
            {
                _empleado = null;
            }
        }
        public void SetEmpleado(Empleado empleado)
        {
            ArgumentNullException.ThrowIfNull(empleado);
            _empleado = empleado;
            _empleadoId = empleado.Id;
        }
        public void SetFechaAlquiler(DateTime fechaAlquiler)
        {
            FechaAlquiler = fechaAlquiler;
        }

        public void SetEstadoAlquiler(EstadoDeAlquiler estado)
        {
            EstadoAlquiler = estado;
        }

        public void AddDetalle(DetalleAlquiler detalle)
        {
            ArgumentNullException.ThrowIfNull(detalle);
            _detallesAlquiler.Add(detalle);
        }

        public void RemoveDetalle(DetalleAlquiler detalle)
        {
            ArgumentNullException.ThrowIfNull(detalle);
            _detallesAlquiler.Remove(detalle);
        }

        public void ClearDetalles()
        {
            _detallesAlquiler.Clear();
        }

        public void CancelarAlquiler()
        {
            if (EstadoAlquiler != EstadoDeAlquiler.Activo)
            {
                throw new InvalidOperationException("Solo se puede cancelar un alquiler activo.");
            }

            EstadoAlquiler = EstadoDeAlquiler.Cancelado;
        }

        public void FinalizarAlquiler()
        {
            if (EstadoAlquiler == EstadoDeAlquiler.Finalizado)
            {
                throw new InvalidOperationException("El alquiler ya ha sido finalizado.");
            }

            if (EstadoAlquiler == EstadoDeAlquiler.Cancelado)
            {
                throw new InvalidOperationException("No se puede finalizar un alquiler que fue cancelado.");
            }

            if (_detallesAlquiler.Count == 0)
            {
                throw new InvalidOperationException("No se puede finalizar un alquiler sin detalles.");
            }

            if (_detallesAlquiler.Any(d => d.HoraFin == null))
            {
                throw new InvalidOperationException("No se puede finalizar el alquiler mientras haya bicicletas sin devolver.");
            }

            EstadoAlquiler = EstadoDeAlquiler.Finalizado;
        }

        public bool TieneBicicletasSinEntregar()
        {
            return _detallesAlquiler.Any(d => d.HoraFin == null);
        }
    }
}
