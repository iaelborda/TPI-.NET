using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public enum RolUsuario
    {
        Administrador,
        Usuario
    }
    public class LoginResponseDTO
    {
        public string Username { get; set; } = string.Empty;
        public RolUsuario Rol { get; set; }

    }
}
