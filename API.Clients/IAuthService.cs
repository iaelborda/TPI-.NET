using Domain.Model;

namespace API.Clients
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticatedAsync();
        Task<string?> GetUsernameAsync();
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task<RolUsuario?> GetRolAsync();

    }
}