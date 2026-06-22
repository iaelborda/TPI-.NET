using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Empleado : Persona
    {
        public string Legajo { get; set; }

        public Empleado(string dni, string tipoDni, string nombre, string apellido, string telefono, string legajo)
            :base(dni, tipoDni, nombre, apellido, telefono)
        {
            SetLegajo(legajo);
        }
        public void SetLegajo(string legajo)
        {

        }
    }
}
