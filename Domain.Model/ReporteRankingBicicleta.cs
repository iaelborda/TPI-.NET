using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ReporteRankingBicicleta
    {
        public int Puesto { get; set; }
        public int IdBicicleta { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CantAlquileres { get; set; }
    }
}
