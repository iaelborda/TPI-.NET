using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoBicicleta { get; set; }
        public Tarifa Tarifa { get; set; }//revisar si queremos mantener el historial de tarifas
    }
}
