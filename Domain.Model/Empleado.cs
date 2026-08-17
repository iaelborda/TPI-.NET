using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Empleado : Persona
    {
        public int Legajo { get; private set; }

        private int _sucursalId;
        private Sucursal? _sucursal;

        public int SucursalId
        {
            get => _sucursal?.Id ?? _sucursalId;
            private set => _sucursalId = value;
        }

        public Sucursal? Sucursal
        {
            get => _sucursal;
            private set
            {
                _sucursal = value;
                if (value != null && _sucursalId != value.Id)
                {
                    _sucursalId = value.Id;
                }
            }
        }

        public Empleado(int id, string documento, TipoDocumento tipoDocumento, string nombre, string apellido, string telefono, int legajo, int sucursalId)
            : base(id, documento, tipoDocumento, nombre, apellido, telefono)
        {
            SetLegajo(legajo);
            SetSucursalId(sucursalId);
        }
        public void SetLegajo(int legajo)
        {
            if (legajo <= 0)
                throw new ArgumentException("El legajo debe ser mayor que 0.", nameof(legajo));
            Legajo = legajo;
        }

        public void SetSucursalId(int sucursalId)
        {
            if (sucursalId <= 0)
            {
                throw new ArgumentException("La sucursal es obligatoria. ", nameof(sucursalId));
            }
            _sucursalId = sucursalId;

            if (_sucursal != null && _sucursal.Id != sucursalId)
            {
                _sucursal = null;
            }
        }

        public void SetSucursal(Sucursal sucursal)
        {
            ArgumentNullException.ThrowIfNull(sucursal);

            _sucursal = sucursal;
            _sucursalId = sucursal.Id;
        }
    }
}
