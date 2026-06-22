using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class DetalleAlquiler
    {
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }

        public DetalleAlquiler(TimeOnly horaInicio, TimeOnly horaFin)
        {
            SetHoraInicio(horaInicio);
            SetHoraFin(horaFin);
        }
        public void SetHoraInicio(TimeOnly horaInicio)
        {

        }
        public void SetHoraFin(TimeOnly horaFin)
        {

        }
    }
}
