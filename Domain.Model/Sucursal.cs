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

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El id debe ser mayor que cero.", nameof(id));
            Id=id
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("La sucursal debe tener un nombre", nameof(nombre));
            if (nombre.Length < 2)
                throw new ArgumentException("El nombre de la sucursal debe tener al menos 2 caracteres.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
            {
                throw new ArgumentException("La sucursal debe tener una direccion.", nameof(direccion));
            }
            Direccion = direccion;
        }

        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El telefono no puede ser nulo o vacio", nameof(telefono));
            }

            if (!Regex.IsMatch(telefono, @"^[0-9\-]+$"))
                throw new ArgumentException("El telefono solo puede contener numero y guiones.", nameof(telefono));

            string soloNumeros = Regex.Replace(telefono, @"\D", "");
            if (soloNumeros.length != 10)
            {
                throw new ArgumentException("El telefono debe tener 10 digitos.", nameof(telefono));
            }
            Telefono = telefono;
        }

        public void SetCapacidad(int capacidad)
        {
            if(capacidad <= 0)
            {
                throw new ArgumentException("La capacidad debe ser mayor que 0.", nameof(capacidad));
            }
            Capacidad = capacidad;
        }
    }
}
