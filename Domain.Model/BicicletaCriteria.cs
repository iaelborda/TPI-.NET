using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class BicicletaCriteria
    {
        public string? Texto { get; private set; }
        public int? CategoriaId { get; private set; }
        public int? SucursalId { get; private set; }
        public EstadoBicicleta? Estado { get; private set; }

        public BicicletaCriteria(string? texto, int? categoriaId, int? sucursalId, EstadoBicicleta? estado) {
            Texto = texto;
            CategoriaId = categoriaId; 
            SucursalId = sucursalId;
            Estado = estado;
        }
    }
}

