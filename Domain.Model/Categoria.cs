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
        public string Descripcion { get; private set; }

        public List<Tarifa> tarifas { get; private set; }
        public IReadOnlyList<Tarifa> Tarifas => tarifas.AsReadOnly();

        public Categoria(string descripcion)
        {
            SetDescripcion(descripcion);
            tarifas = new List<Tarifa>();
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor o igual a 0.", nameof(id));

            Id = id;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripcion no puede ser nula o vacia.", nameof(descripcion));
            }
            Descripcion = descripcion;
        }
        public void AgregarTarifa(Tarifa tarifa)
        {
            ArgumentNullException.ThrowIfNull(tarifa);

            tarifas.Add(tarifa);
        }

        public void EliminarTarifa(Tarifa tarifa)
        {
            ArgumentNullException.ThrowIfNull(tarifa);

            tarifas.Remove(tarifa);
        }
    }
}