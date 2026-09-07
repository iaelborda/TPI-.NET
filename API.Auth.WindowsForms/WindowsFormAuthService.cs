using API.Clients;
using DTOs;

namespace API.Auth.WindowsForms
{
    public class WindowsFormsAuthService : IAuthService
    {
        private static readonly List<(string Username, string Password, RolUsuario Rol)> usuarios = new()
        {
            ("admin", "admin123", RolUsuario.Administrador),
            ("empleado", "empleado123", RolUsuario.Usuario)
        };
        private static string? currentUsername;
        private static RolUsuario? currentRol;
        private static bool isAuthenticated;

        public async Task<bool> IsAuthenticatedAsync()
        {
            return await Task.Run(() => isAuthenticated);
        }

        public async Task<string?> GetUsernameAsync()
        {
            return await Task.Run(() => isAuthenticated ? currentUsername : null);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var usuario = usuarios.FirstOrDefault(u =>
            u.Username == username && u.Password == password);
            if(usuario != default)
            {
                currentUsername = usuario.Username;
                currentRol = usuario.Rol;
                isAuthenticated = true;
                return true;
            }
            return false;
        }
        public async Task<RolUsuario?> GetRolAsync()
        {
            return await Task.Run(() => isAuthenticated ? currentRol : null);
        }
        public async Task LogoutAsync()
        {
            await Task.Run(() =>
            {
                currentUsername = null;
                currentRol = null;
                isAuthenticated = false;
            });
        }
    }
}