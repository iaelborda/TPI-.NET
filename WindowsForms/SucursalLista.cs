using API.Clients;
using DTOs;
using Domain.Model;

namespace WindowsForms
{
    public partial class SucursalLista : Form
    {
        public SucursalLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
            AplicarPermisos();
        }

        private async Task AplicarPermisos()
        {
            var rol = await AuthServiceProvider.Instance.GetRolAsync();
            bool esAdmin = rol == RolUsuario.Administrador;

            agregarButton.Enabled = esAdmin;
            actualizarButton.Enabled = esAdmin;
            eliminarButton.Enabled = esAdmin;
        }

        private void ConfigurarColumnas()
        {
            this.sucursalesDataGridView.AutoGenerateColumns = false;

            this.sucursalesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 80
            });

            this.sucursalesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 200
            });

            this.sucursalesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Direccion",
                HeaderText = "Dirección",
                DataPropertyName = "Direccion",
                Width = 300
            });

            this.sucursalesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 200
            });

            this.sucursalesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Capacidad",
                HeaderText = "Capacidad",
                DataPropertyName = "Capacidad",
                Width = 150
            });
        }

        private async void Sucursales_Load(object sender, EventArgs e)
        {
            await this.LoadSucursales();
        }

        private async Task LoadSucursales()
        {
            try
            {
                DeshabilitarControles();
                this.sucursalesDataGridView.DataSource = null;
                IEnumerable<SucursalDTO> sucursales;
                sucursales = await SucursalApiClient.GetAllAsync();
                this.sucursalesDataGridView.DataSource = sucursales;
                if (this.sucursalesDataGridView.Rows.Count > 0)
                {
                    this.sucursalesDataGridView.Rows[0].Selected = true;
                    this.eliminarButton.Enabled = true;
                    this.actualizarButton.Enabled = true;
                }
                else
                {
                    this.eliminarButton.Enabled = false;
                    this.actualizarButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar sucursales: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            SucursalDTO sucursalNuevo = new SucursalDTO();
            SucursalDetalle sucursalDetalle = new SucursalDetalle(FormMode.Add, sucursalNuevo);
            sucursalDetalle.ShowDialog();
            await this.LoadSucursales();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarControles();
                int id = this.SelectedItem().Id;
                SucursalDTO sucursal = await SucursalApiClient.GetAsync(id);
                SucursalDetalle sucursalDetalle = new SucursalDetalle(FormMode.Update, sucursal);
                sucursalDetalle.ShowDialog();
                await this.LoadSucursales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar sucursal: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            SucursalDTO sucursal = this.SelectedItem();
            var result = MessageBox.Show($"¿Está seguro que desea eliminar la sucursal {sucursal.Nombre} ({sucursal.Direccion})?","Confirmar eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DeshabilitarControles();
                    await SucursalApiClient.DeleteAsync(sucursal.Id);
                    await this.LoadSucursales();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message,"No se puede eliminar",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar sucursal: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private SucursalDTO SelectedItem()
        {
            SucursalDTO sucursal;
            sucursal = (SucursalDTO)sucursalesDataGridView.SelectedRows[0].DataBoundItem;
            return sucursal;
        }

        private void DeshabilitarControles()
        {
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            eliminarButton.Enabled = false;
            sucursalesDataGridView.Enabled = false;
        }

        private void HabilitarControles()
        {
            bool esAdmin = AuthServiceProvider.Instance.GetRolAsync().Result == RolUsuario.Administrador;

            agregarButton.Enabled = esAdmin;
            sucursalesDataGridView.Enabled = true;

            if (sucursalesDataGridView.Rows.Count > 0)
            {
                eliminarButton.Enabled = esAdmin;
                actualizarButton.Enabled = esAdmin;
            }
        }
    }
}