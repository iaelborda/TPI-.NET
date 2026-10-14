using API.Auth.WindowsForms;
using API.Clients;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace WindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var authService = new WindowsFormsAuthService();
            AuthServiceProvider.Register(authService);

            while (true)
            {
                using var loginForm = new LoginForm();
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    break;
                }
                var home = new Home();
                Application.Run(home);
                if (!home.VolverAlLogin)
                {
                    break;
                }
            }
        }
    }
}