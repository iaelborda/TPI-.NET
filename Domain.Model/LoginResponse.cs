using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class LoginResponse
    {
        public string UserName { get; set; } = string.Empty;
        public RolUsuario Rol { get; set; }
    }
     public enum RolUsuario
    {
        Administrador,
        Usuario
    }
}
