using DTOs;
using API.Clients;
using System;

namespace WindowsForms
{
    public partial class AlquilerLista : Form
    {
        public AlquilerLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            this.alquileresDataGridView.AutoGenerateColumns = false;

            this.alquileresDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 60
            });

            this.alquileresDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ClienteNombre",
                HeaderText = "Nombre Cliente",
                DataPropertyName = "ClienteNombre",
                Width = 150
            });

            this.alquileresDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ClienteApellido",
                HeaderText = "Apellido Cliente",
                DataPropertyName = "ClienteApellido",
                Width = 150
            });

            this.alquileresDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmpleadoLegajo",
                HeaderText = "Legajo Empleado",
                DataPropertyName = "EmpleadoLegajo",
                Width = 120
            });

            this.alquileresDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmpleadoApellido",
                HeaderText = "Apellido Empleado",
                DataPropertyName = "EmpleadoApellido",
                Width = 150
            });

            this.alquileresDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaAlquiler",
                HeaderText = "Fecha Alquiler",
                DataPropertyName = "FechaAlquiler",
                Width = 200,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            this.alquileresDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EstadoAlquiler",
                HeaderText = "Estado",
                DataPropertyName = "EstadoAlquiler",
                Width = 120
            });
        }

        private async void Alquileres_Load(object sender, EventArgs e)
        {
            //await ConfigureButtonPermissions();
            await this.LoadAlquileres();
        }

        /*private async Task ConfigureButtonPermissions()
        {
            var authService = AuthServiceProvider.Instance;

            bool canAdd = await authService.HasPermissionAsync("alquileres.agregar");
            bool canUpdate = await authService.HasPermissionAsync("alquileres.actualizar");
            bool canDelete = await authService.HasPermissionAsync("alquileres.eliminar");

            agregarButton.Visible = canAdd;
            actualizarButton.Visible = canUpdate;
            eliminarButton.Visible = canDelete;

            agregarButton.Tag = canAdd;
            actualizarButton.Tag = canUpdate;
            eliminarButton.Tag = canDelete;
        }*/

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            AlquilerDTO alquilerNuevo = new AlquilerDTO();

            AlquilerDetalle alquilerDetalle =
                new AlquilerDetalle(FormMode.Add, alquilerNuevo);

            alquilerDetalle.ShowDialog();

            await this.LoadAlquileres();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            AlquilerDTO? alquiler = this.SelectedItem();
            if (alquiler == null) return;

            try
            {
                DeshabilitarControles();

                AlquilerDTO alquilerCompleto = await AlquilerApiClient.GetAsync(alquiler.Id);
                AlquilerDetalle alquilerDetalle = new AlquilerDetalle(FormMode.Update, alquilerCompleto);
                alquilerDetalle.ShowDialog();

                await this.LoadAlquileres();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar alquiler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            AlquilerDTO? alquiler = this.SelectedItem();
            if (alquiler == null) return;

            var result = MessageBox.Show($"¿Está seguro que desea eliminar el alquiler #{alquiler.Id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeshabilitarControles();
                    await AlquilerApiClient.DeleteAsync(alquiler.Id);
                    await this.LoadAlquileres();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar alquiler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HabilitarControles();
                }
            }
        }

        private async Task LoadAlquileres()
        {
            try
            {
                DeshabilitarControles();

                this.alquileresDataGridView.DataSource = null;

                IEnumerable<AlquilerDTO> alquileres = await AlquilerApiClient.GetAllAsync();

                this.alquileresDataGridView.DataSource = alquileres;

                bool canUpdate =
                    actualizarButton.Tag is bool updatePermission &&
                    updatePermission;

                bool canDelete =
                    eliminarButton.Tag is bool deletePermission &&
                    deletePermission;

                if (this.alquileresDataGridView.Rows.Count > 0)
                {
                    this.alquileresDataGridView.Rows[0].Selected = true;

                    if (canDelete)
                        this.eliminarButton.Enabled = true;

                    if (canUpdate)
                        this.actualizarButton.Enabled = true;
                }
                else
                {
                    if (canDelete)
                        this.eliminarButton.Enabled = false;

                    if (canUpdate)
                        this.actualizarButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar alquileres: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private AlquilerDTO? SelectedItem()
        {
            if (alquileresDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un alquiler.", "Seleccionar Alquiler");
                return null;
            }

            return (AlquilerDTO)alquileresDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void DeshabilitarControles()
        {
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            eliminarButton.Enabled = false;
            alquileresDataGridView.Enabled = false;
        }

        private void HabilitarControles()
        {
            agregarButton.Enabled = true;
            alquileresDataGridView.Enabled = true;
        }
    }
}