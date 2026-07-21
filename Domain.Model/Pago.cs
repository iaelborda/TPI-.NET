using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pago
    {

        public int IdAlquiler { get; private set; }
        public int IdPago { get; private set; }
        public DateTime FechaPago { get; private set; }
        public float Monto { get; private set; }
        public MetodoPago Metodo { get; private set; }

        public Pago(int idAlquiler, MetodoPago metodo)
        {
            SetAlquilerId(idAlquiler);
            SetFechaPago();
            Monto = 0;
            SetMetodoPago(metodo);
        }

        public void SetId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id del pago debe ser mayor que 0", nameof(id));
            }
            IdPago = id;
        }

        public void SetAlquilerId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id del alquiler debe ser mayor que 0", nameof(id));
            }
            IdAlquiler = id;
        }

        public void SetFechaPago()
        {
            FechaPago = DateTime.Now;
        }

        public void SetMetodoPago(MetodoPago metodo)
        {
            if (!Enum.IsDefined(typeof(MetodoPago), metodo))
            {
                throw new ArgumentException("El metodo de pago no es valido", nameof(metodo));
            }
            Metodo = metodo;
        }

        public void CalcularMonto(List<DetalleAlquiler> detalles)
        {
            if (detalles == null || detalles.Count == 0)
            {
                throw new ArgumentException("La lista de detalles no puede ser nula o vacia", nameof(detalles));
            }

            if (detalles.Any(d => d.HoraFin == null))
            {
                throw new InvalidOperationException("No se puede calcular el monto a pagar si hay bicicletas sin devolver");
            }

            Monto = detalles.Sum(d => d.SubTotal);
            if (Monto <= 0)
            {
                throw new ArgumentException("El monto a pagar debe ser mayor que 0", nameof(Monto));
            }
        }
    }


}
