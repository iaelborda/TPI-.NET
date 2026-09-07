using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class LoginResponse
    {
        public string Username { get; private set; } = string.Empty;
        public RolUsuario Rol { get; private set; }
    }
    public enum RolUsuario
    {
        Administrador,
        Usuario
    }
}