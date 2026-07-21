using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class DetalleAlquiler
    {
        public int DetalleId { get; private set; }
        public int AlquilerId { get; private set; }
        public int BicicletaId { get; private set; }
        public DateTime HoraInicio { get; private set; }
        public DateTime? HoraFin { get; private set; }
        public EstadoDetalleAlquiler Estado { get; private set; }
        public decimal SubTotal { get; private set; }

        public DetalleAlquiler(int AlquilerId, int BicicletaId)
        {
            SetAlquilerId(AlquilerId);
            SetBicicletaId(BicicletaId);
            SetHoraInicio();
            SetHoraFin();
            SetEstado();
            SetSubTotal();
        }

        public void SetDetalleId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id del detalle debe ser mayor que 0", nameof(id));
            }
            DetalleId  = id;
        }
        public void SetAlquilerId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id del alquiler debe ser mayor que 0", nameof(id));
            }
            AlquilerId = id;
        }

        public void SetBicicletaId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id de la bicicleta debe ser mayor que 0", nameof(id));
            }
            BicicletaId = id;
        }

        public void SetHoraInicio()
        {
            HoraInicio = DateTime.Now;
        }

        public void SetHoraFin()
        {
            HoraFin = null;
        }

        public void SetEstado()
        {
            Estado = EstadoDetalleAlquiler.Activo;
        }

        public void SetSubTotal()
        {
            SubTotal = 0;
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

            if (!bicicleta.Categoria.Tarifas.Any())
            {
                throw new InvalidOperationException("La bicicleta no tiene tarifas asociadas.");
            }

            var tarifaVigente = bicicleta.Categoria.Tarifas
                .Where(t => t.FechaDesde <= HoraInicio &&
                (t.FechaHasta == null || t.FechaHasta >= DateTime.Now))
                .OrderByDescending(t => t.FechaDesde)
                .FirstOrDefault();

            if (tarifaVigente == null)
            {
                throw new InvalidOperationException("No hay una tarifa vigente para esta bicicleta.");
            }

            decimal precioHora = tarifaVigente.PrecioHora;
            TimeSpan duracion = HoraFin.Value - HoraInicio;
            decimal horas = (decimal)duracion.TotalHours;
            horas = (decimal)Math.Ceiling(horas);
            SubTotal = horas * precioHora;
        }
    }

}