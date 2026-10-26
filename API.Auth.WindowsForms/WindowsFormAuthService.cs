using API.Clients;
using Domain.Model;
using DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Auth.WindowsForms
{
    public class WindowsFormsAuthService : IAuthService
    {
        private static string? currentToken;
        private static string? currentUsername;
        private static DateTime tokenExpiration;

        public event Action<bool>? AuthenticationStateChanged;


        public async Task<bool> IsAuthenticatedAsync()
        {
            return !string.IsNullOrEmpty(currentToken) &&
                   DateTime.UtcNow < tokenExpiration;
        }

        public async Task<string?> GetUsernameAsync()
        {
            return await IsAuthenticatedAsync()
                ? currentUsername
                : null;
        }

        public async Task<string?> GetTokenAsync()
        {
            return await IsAuthenticatedAsync()
                ? currentToken
                : null;
        }
        public async Task<RolUsuario?> GetRolAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token)) return null;

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var claim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role || c.Type == "role");

                if (claim != null && Enum.TryParse<RolUsuario>(claim.Value, true, out var rol))
                    return rol;

                return null;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            var request = new LoginRequestDTO
            {
                Username = username,
                Password = password
            };

            var authClient = new AuthApiClient();
            var response = await authClient.LoginAsync(request);

            if (response != null)
            {
                currentToken = response.Token;
                currentUsername = response.Username;
                tokenExpiration = response.ExpiresAt;

                return true;
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            currentToken = null;
            currentUsername = null;
            tokenExpiration = default;

            await Task.CompletedTask;
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (!string.IsNullOrEmpty(currentToken) &&
                DateTime.UtcNow >= tokenExpiration)
            {
                await LogoutAsync();
            }
        }

        public async Task<bool> HasPermissionAsync(string permission)
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token)) return false;
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);
                var claims = jsonToken.Claims
                    .Where(c => c.Type == "permission")
                    .Select(c => c.Value);
                return claims.Contains(permission);
            }
            catch
            {
                return false;
            }
        }
    }
}