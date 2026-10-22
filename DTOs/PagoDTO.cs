using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PagoDTO
    {
        public int IdPago { get; set; }
        public int IdAlquiler { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public MetodoPago Metodo { get; set; }
        public string? ClienteNombre { get; set; }
        public string? ClienteApellido { get; set; }
        public string? EmpleadoApellido { get; set; }
        public DateTime? FechaAlquiler { get; set; }
    }
}
