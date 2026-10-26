using API.Clients;

namespace WindowsForms
{
    public partial class Home : Form
    {

        public bool VolverAlLogin { get; private set; } = false;
        public Home()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(1280, 800);
        }



        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ClienteLista());
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new CategoriaLista());
        }

        private void bicicletasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new BicicletaLista());
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new SucursalLista());

        }
        private void alquileresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AbrirFormulario(new AlquilerLista());

        }
        private void tarifasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new TarifaLista());
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            var username = await AuthServiceProvider.Instance.GetUsernameAsync();
            var rol = await AuthServiceProvider.Instance.GetRolAsync();
            usuarioTextBox.Text = $"Usuario: {username} ({rol})";
        }

        private async void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await AuthServiceProvider.Instance.LogoutAsync();
            VolverAlLogin = true;
            this.Close();
        }

        private void AbrirFormulario(Form newForm)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == newForm.GetType())
                {
                    form.BringToFront();
                    newForm.Dispose();
                    return;
                }
            }
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new EmpleadoLista());
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PagoLista());
        }
    }
}
