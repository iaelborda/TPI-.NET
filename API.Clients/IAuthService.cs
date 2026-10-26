using Domain.Model;

namespace API.Clients
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticatedAsync();
        Task<string?> GetUsernameAsync();
        Task<string?> GetTokenAsync();
        Task<RolUsuario?> GetRolAsync();
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task CheckTokenExpirationAsync();
        Task<bool> HasPermissionAsync(string permission);
        event Action<bool>? AuthenticationStateChanged;
    }
}