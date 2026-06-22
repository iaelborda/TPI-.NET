using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Cliente : Persona
    {
        public string Email { get; set; }
        public DateOnly FechaAlta { get; set; }

        public Cliente(string dni, string tipoDni, string nombre, string apellido, string telefono, string email, DateOnly fechaAlta)
            :base(dni, tipoDni, nombre, apellido, telefono)
        {
            SetEmail(email);
            SetFechaAlta(fechaAlta);
        }

        public void SetEmail(string email)
        {

        }

        public void SetFechaAlta(DateOnly fechaAlta)
        {

        }

    }
}
