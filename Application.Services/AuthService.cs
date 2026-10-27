using Data;
using Domain.Model;
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
        private readonly UsuarioRepository usuarioRepository;
        private readonly IConfiguration configuration;

        public AuthService(UsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            this.usuarioRepository = usuarioRepository;
            this.configuration = configuration;
        }

        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return null;

            var usuario = await usuarioRepository.GetByUsernameAsync(request.Username);

            if (usuario == null || !usuario.ValidatePassword(request.Password))
                return null;

            var token = GenerateJwtToken(usuario);
            var expiresAt = DateTime.UtcNow.AddMinutes(GetExpirationMinutes());

            return new LoginResponseDTO
            {
                Token = token,
                ExpiresAt = expiresAt,
                Username = usuario.Username
            };
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol.ToString()),
                new Claim("jti", Guid.NewGuid().ToString())
            };

            claims.AddRange(ObtenerPermisos(usuario.Rol));

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(GetExpirationMinutes()),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Claim> ObtenerPermisos(RolUsuario rol)
        {
            var permisos = new List<string>
            {
                "clientes.leer", "clientes.agregar", "clientes.actualizar", "clientes.eliminar",
                "bicicletas.leer", "bicicletas.agregar", "bicicletas.actualizar", "bicicletas.eliminar",
                "sucursales.leer", "sucursales.agregar", "sucursales.actualizar", "sucursales.eliminar",
                "categorias.leer", "categorias.agregar", "categorias.actualizar", "categorias.eliminar",
                "empleados.leer", "empleados.agregar", "empleados.actualizar", "empleados.eliminar",
                "alquileres.leer", "alquileres.agregar", "alquileres.actualizar", "alquileres.eliminar",
                "tarifas.leer", "tarifas.agregar", "tarifas.actualizar", "tarifas.eliminar",
                "usuarios.leer", "usuarios.agregar", "usuarios.actualizar", "usuarios.eliminar",
                "pagos.leer", "pagos.agregar", "pagos.actualizar", "pagos.eliminar",
                "reportes.leer"
            };

            if (rol == RolUsuario.Usuario)
            {
                permisos.RemoveAll(p => p.EndsWith(".agregar") || p.EndsWith(".actualizar") || p.EndsWith(".eliminar"));

                permisos.Add("clientes.agregar");
                permisos.Add("clientes.actualizar");
                permisos.Add("alquileres.agregar");
                permisos.Add("alquileres.actualizar");
                permisos.Add("pagos.leer");
                permisos.Add("pagos.agregar");
                permisos.Add("pagos.actualizar");
                permisos.Remove("reportes.leer");
            }

            return permisos.Select(p => new Claim("permission", p)).ToList();
        }


        public bool ValidateToken(string token)
        {
            try
            {
                var jwtSettings = configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"];
                var issuer = jwtSettings["Issuer"];
                var audience = jwtSettings["Audience"];

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.Zero
                };

                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int? GetUserIdFromToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jsonToken = tokenHandler.ReadJwtToken(token);

                var userIdClaim = jsonToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        private int GetExpirationMinutes()
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            if (int.TryParse(jwtSettings["ExpirationMinutes"], out int minutes))
                return minutes;
            return 60; // Default 60 minutes
        }
    }
}