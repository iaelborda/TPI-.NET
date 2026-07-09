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
        public DateOnly FechaAlta { get; private set; }

        public Cliente(string documento, TipoDocumento tipoDocumento, string nombre, string apellido, string telefono, string email, DateOnly fechaAlta)
            :base(documento, tipoDocumento, nombre, apellido, telefono)
        {
            SetEmail(email);
            SetFechaAlta(fechaAlta);
        }

        public void SetEmail(string email)
        {
            if(!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void SetFechaAlta(DateOnly fechaAlta)
        {
            if(fechaAlta == default)
                throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            FechaAlta = fechaAlta;
        }

    }
}
