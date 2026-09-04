using API.Clients;

namespace API.Auth.WindowsForms
{
    public class WindowsFormsAuthService : IAuthService
    {
        private static string? _currentUsername;
        private static bool _isAuthenticated;

        public async Task<bool> IsAuthenticatedAsync()
        {
            return _isAuthenticated && !string.IsNullOrEmpty(_currentUsername);
        }

        public async Task<string?> GetUsernameAsync()
        {
            if (await IsAuthenticatedAsync())
            {
                return _currentUsername;
            }
            return null;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (username == "admin" && password == "admin")
            {
                _currentUsername = username;
                _isAuthenticated = true;
                return true;
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            _currentUsername = null;
            _isAuthenticated = false;
        }
    }
}