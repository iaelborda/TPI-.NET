using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string TipoBicicleta { get; private set; }

        public List<Tarifa> Tarifas { get; private set; }
        public Categoria(int id, string nombre, string tipoBicicleta)
        {
            SetId(id);
            SetNombre(nombre);
            SetTipoBicicleta(tipoBicicleta);
            Tarifas = new List<Tarifa>();
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor o igual a 0.", nameof(id));

            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));

            Nombre = nombre;
        }

        public void SetTipoBicicleta(string tipoBicicleta)
        {
            if (string.IsNullOrWhiteSpace(tipoBicicleta))
                throw new ArgumentException("El tipo de bicicleta no puede ser nulo o vacío.", nameof(tipoBicicleta));

            TipoBicicleta = tipoBicicleta;
        }
        public void AgregarTarifa(Tarifa tarifa)
        {
            ArgumentNullException.ThrowIfNull(tarifa);

            Tarifas.Add(tarifa);
        }

        public void EliminarTarifa(Tarifa tarifa)
        {
            ArgumentNullException.ThrowIfNull(tarifa);

            Tarifas.Remove(tarifa);
        }
    }
}