using API.Clients;
using DTOs;
using System.IdentityModel.Tokens.Jwt;

namespace API.Auth.WindowsForms
{
    public class WindowsFormsAuthService : IAuthService
    {
        private static string? currentToken;
        private static string? currentUsername;
        private static RolUsuario? currentRol;
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
                currentRol = response.Rol;
                tokenExpiration = response.ExpiresAt;

                return true;
            }

            return false;
        }

        public async Task<RolUsuario?> GetRolAsync()
        {
            return await IsAuthenticatedAsync()
                ? currentRol
                : null;
        }

        public async Task LogoutAsync()
        {
            currentToken = null;
            currentUsername = null;
            currentRol = null;
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