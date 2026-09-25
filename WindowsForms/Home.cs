using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Auth.WindowsForms;
using DTOs;
using API.Clients;

namespace WindowsForms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }



        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteLista clientesForm = new ClienteLista();
            clientesForm.MdiParent = this;
            clientesForm.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaLista categoriasForm = new CategoriaLista();
            categoriasForm.ShowDialog();
        }

        private void bicicletasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BicicletaLista bicicletasForm = new BicicletaLista();
            bicicletasForm.MdiParent = this;  
            bicicletasForm.Show();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SucursalLista sucursalesForm = new SucursalLista();
            sucursalesForm.MdiParent = this; 
            sucursalesForm.Show();

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
            this.Close();
        }
    }
}
