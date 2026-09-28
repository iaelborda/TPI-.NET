using API.Auth.WindowsForms;
using API.Clients;
using System.Globalization;

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

            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Home());
            }
        }
    }
}