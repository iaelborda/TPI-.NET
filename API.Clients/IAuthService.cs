using DTOs;

namespace API.Clients
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticatedAsync();
        Task<string?> GetUsernameAsync();
        Task<string?> GetTokenAsync();
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task<RolUsuario?> GetRolAsync();
        Task CheckTokenExpirationAsync();
    }
}