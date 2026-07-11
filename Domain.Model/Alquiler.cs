using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{

    public class Alquiler
    {

        public int IdAlquiler { get; private set; }
        public DateTime FechaAlquiler { get; private set; }
        public DateTime FechaDevolucion { get; private set; }
        public EstadoDeAlquiler EstadoAlquiler { get; private set; }
        public int ClienteId { get; private set; }
        public int EmpleadoId { get; private set; }

        private List<DetalleAlquiler> detalles = new List<DetalleAlquiler>();
        public IReadOnlyList<DetalleAlquiler> Detalles => detalles.AsReadOnly();
        public Alquiler(int clienteId, int EmpleadoId)
        {
            SetClienteId(clienteId);
            SetEmpleadoId(EmpleadoId);
            EstadoAlquiler = EstadoDeAlquiler.Activo;
            FechaAlquiler = DateTime.Now;
        }

        public void SetClienteId(int clienteId)
        {
            if (clienteId <= 0)
            {
                throw new ArgumentException("El id del cliente debe ser mayor que cero.", nameof(clienteId));
            }
            ClienteId = clienteId;
        }

        public void SetEmpleadoId(int empleadoId)
        {
            if(empleadoId <= 0)
            {
                throw new ArgumentException("El id del empleado debe ser mayor que cero.", nameof(empleadoId));
            }
            EmpleadoId = empleadoId;
        }

        public void AgregarDetalle(DetalleAlquiler detalle)
        {
            if (detalle == null)
            {
                throw new ArgumentNullException(nameof(detalle));
            }
            
            if(EstadoAlquiler != EstadoDeAlquiler.Activo)
            {
                throw new InvalidOperationException("No se pueden agregar detalles a un alquiler que no está activo.");
            }

            detalles.Add(detalle);
        }

        public void FinalizarAlquiler()
        {
            if (EstadoAlquiler == EstadoDeAlquiler.Finalizado)
            {
                throw new InvalidOperationException("El alquiler ya ha sido finalizado.");
            }

            if (detalles.Any(d => d.HoraFin == null))
            {
                throw new InvalidOperationException("No se puede finalizar el alquiler mientras haya bicicletas sin devolver.");
            }

            EstadoAlquiler = EstadoDeAlquiler.Finalizado;
        }

        public bool TieneBicicletasSinEntregar()
        {
            return detalles.Any(d => d.HoraFin == null);
        }
    }
}
