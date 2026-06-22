using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Tarifa
    {
        public float PrecioHora { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Tarifa(float PrecioHora, DateTime fechaDesde, DateTime fechaHasta)
        {
            SetPrecioHora(PrecioHora);
            SetFechaDesde(FechaDesde);
            SetFechaHasta(FechaHasta);
        }
    }
}
