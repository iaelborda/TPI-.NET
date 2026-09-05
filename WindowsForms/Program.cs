using API.Clients;
using API.Auth.WindowsForms;

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
                Application.Run(new SucursalLista());
            }
        }
    }
}