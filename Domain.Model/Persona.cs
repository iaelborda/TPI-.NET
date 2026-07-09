using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Model
{
    public enum TipoDocumento
    {
        DNI,
        Pasaporte,
        LC,
        LE,
        CI
    }
    public abstract class Persona
    {
        public string Documento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        public Persona(string documento, TipoDocumento tipoDocumento, string nombre, string apellido, string telefono)
        {
            SetDocumento(documento);
            SetTipoDocumento(tipoDocumento);
            SetNombre(nombre);
            SetApellido(apellido);
            SetTelefono(telefono);
        }

        public void SetDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                throw new ArgumentException("El documento no puede ser nulo o vacío", nameof(documento));
            Documento = documento;
        }
        public void SetTipoDocumento(TipoDocumento tipoDocumento)
        {
            TipoDocumento = tipoDocumento;
        }
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío", nameof(nombre));
            Nombre = nombre;
        }
        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío", nameof(apellido));
            Apellido = apellido;
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
            if (soloNumeros.Length != 10)
            {
                throw new ArgumentException("El telefono debe tener 10 digitos.", nameof(telefono));
            }
            Telefono = telefono;
        }
    }
}
