using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pago
    {
        public int IdPago { get; set; }
        public DateOnly FechaPago { get; set; }
        public float Precio { get; set; }
        public string MetodoPago { get; set; }


        public Pago(string idPago, DateOnly fechaPago, float precio, string metodoPago)
        {
            SetIdPago(idPago);
            SetFechaPago(fechaPago);
            SetPrecio(precio);
            SetMetodoPago(metodoPago);
        }

        public void SetIdPago(string idPago) 
        {
            
        }
        public void SetFechaPago(DateOnly fechaPago)
        {

        }
        public void SetPrecio(float precio)
        {

        }
        public void SetMetodoPago(string metodoPago)
        {

        }
    }

}
