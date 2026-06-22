using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public enum Estado
    {
        Activo,
        Finalizado,
        Cancelado
    }
    public class Alquiler
    {
        public string IdAlquiler {  get; set; }
        public DateOnly FechaAlquiler { get; set; }
        public DateOnly FechaDevolucion {  get; set; }
        public Estado Estado { get; set; }
    }
}
