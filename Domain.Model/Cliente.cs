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
        public int Id { get; private set; }
        public string Email { get; private set; }
        public DateOnly FechaAlta { get; private set; }

        public Cliente(int id, string documento, TipoDocumento tipoDocumento, string nombre, string apellido, string telefono, string email, DateOnly fechaAlta)
            :base(documento, tipoDocumento, nombre, apellido, telefono)
        {
            SetId(id);
            SetEmail(email);
            SetFechaAlta(fechaAlta);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El id debe ser mayor que cero.", nameof(id));
            Id = id;
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
