using DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class AuthService
    {
        private readonly IConfiguration configuration;

        private static readonly List<(string Username, string Password, RolUsuario Rol)> usuarios = new()
        {
            ("admin", "admin123", RolUsuario.Administrador),
            ("empleado", "empleado123", RolUsuario.Usuario)
        };

        public AuthService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
                return null;

            var usuario = usuarios.FirstOrDefault(u =>
                u.Username == request.Username &&
                u.Password == request.Password);

            if (usuario == default)
                return null;

            var token = GenerateJwtToken(usuario.Username, usuario.Rol);
            var expiresAt = DateTime.UtcNow.AddMinutes(GetExpirationMinutes());

            return new LoginResponseDTO
            {
                Username = usuario.Username,
                Rol = usuario.Rol,
                Token = token,
                ExpiresAt = expiresAt
            };
        }

        private string GenerateJwtToken(string username, RolUsuario rol)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey!));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, rol.ToString()),
                new Claim("jti", Guid.NewGuid().ToString())
            };

            foreach (var permiso in ObtenerPermisos(rol))
            {
                claims.Add(new Claim("permission", permiso));
            }

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(GetExpirationMinutes()),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<string> ObtenerPermisos(RolUsuario rol)
        {
            var permisos = new List<string>();

            if (rol == RolUsuario.Administrador)
            {
                var recursos = new List<string>
        {
            "clientes",
            "bicicletas",
            "sucursales",
            "categorias",
            "empleados",
            "alquileres"
        };

                var acciones = new List<string>
        {
            "leer",
            "agregar",
            "actualizar",
            "eliminar"
        };

                permisos.AddRange(
                    recursos.SelectMany(recurso =>
                        acciones.Select(accion => $"{recurso}.{accion}")));
            }
            else
            {
                permisos.Add("clientes.leer");
                permisos.Add("clientes.agregar");
                permisos.Add("clientes.actualizar");
                permisos.Add("bicicletas.leer");
                permisos.Add("categorias.leer");
                permisos.Add("sucursales.leer");
                permisos.Add("empleados.leer");
                permisos.Add("alquileres.leer");
                permisos.Add("alquileres.agregar");
                permisos.Add("alquileres.actualizar");
            }

            return permisos;
        }

        private int GetExpirationMinutes()
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            if (int.TryParse(jwtSettings["ExpirationMinutes"], out int minutes))
                return minutes;

            return 60;
        }
    }
}