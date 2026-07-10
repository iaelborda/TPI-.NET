using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Tarifa
    {
        public int Id { get; private set; }
        public float PrecioHora { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        private int _categoriaId;
        private Categoria? _categoria;
        public int CategoriaId
        {
            get => _categoria?.Id ?? _categoriaId;
            private set => _categoriaId = value;
        }
        public Categoria? Categoria
        {
            get => _categoria;
            private set
            {
                _categoria = value;

                if (value != null && _categoriaId != value.Id)
                {
                    _categoriaId = value.Id;
                }
            }
        }
        public Tarifa(float precioHora, DateTime fechaDesde, DateTime fechaHasta, int categoriaId)
        {
            SetPrecioHora(precioHora);
            SetFechaDesde(fechaDesde);
            SetFechaHasta(fechaHasta);
            SetCategoriaId(categoriaId);
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor o igual a 0.", nameof(id));

            Id = id;
        }

        public void SetPrecioHora(float precioHora)
        {
            if (precioHora <= 0)
                throw new ArgumentException("El precio por hora debe ser mayor que 0.", nameof(precioHora));

            PrecioHora = precioHora;
        }

        public void SetFechaDesde(DateTime fechaDesde)
        {
            FechaDesde = fechaDesde;
        }

        public void SetFechaHasta(DateTime fechaHasta)
        {
            if (fechaHasta < FechaDesde)
                throw new ArgumentException("La fecha hasta no puede ser anterior a la fecha desde.", nameof(fechaHasta));

            FechaHasta = fechaHasta;
        }

        public void SetCategoriaId(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("La categoría es obligatoria.", nameof(categoriaId));

            _categoriaId = categoriaId;

            if (_categoria != null && _categoria.Id != categoriaId)
            {
                _categoria = null;
            }
        }

        public void SetCategoria(Categoria categoria)
        {
            ArgumentNullException.ThrowIfNull(categoria);

            _categoria = categoria;
            _categoriaId = categoria.Id;
        }
    }
}
