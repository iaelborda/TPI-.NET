using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Capacidad { get; set; }
        public Sucursal (int id, string nombre, string direccion, string telefono, int capacidad)
        {
            SetId(id);
            SetNombre(nombre);
            SetDireccion(direccion);
            SetTelefono(telefono);
            SetCapacidad(capacidad);
        }
    }
}
