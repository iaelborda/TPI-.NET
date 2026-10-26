using API.Clients;
using Domain.Model;
using DTOs;


namespace WindowsForms
{
    public partial class EmpleadoLista : Form
    {
        public EmpleadoLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
            AplicarPermisos();
        }
        private async void AplicarPermisos()
        {
            var rol = await AuthServiceProvider.Instance.GetRolAsync();
            bool esAdmin = rol == RolUsuario.Administrador;
            agregarButton.Enabled = esAdmin;
            actualizarButton.Enabled = esAdmin;
            eliminarButton.Enabled = esAdmin;
        }
        private void ConfigurarColumnas()
        {
            this.empleadosDataGridView.AutoGenerateColumns = false;
            this.empleadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 60
            });
            this.empleadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Legajo",
                HeaderText = "Legajo",
                DataPropertyName = "Legajo",
                Width = 80
            });
            this.empleadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoDocumento",
                HeaderText = "Tipo Doc.",
                DataPropertyName = "TipoDocumento",
                Width = 100
            });
            this.empleadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Documento",
                HeaderText = "Documento",
                DataPropertyName = "Documento",
                Width = 120
            });
            this.empleadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 140
            });
            this.empleadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Apellido",
                HeaderText = "Apellido",
                DataPropertyName = "Apellido",
                Width = 140
            });
            this.empleadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 130
            });
            this.empleadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreSucursal",
                HeaderText = "Sucursal",
                DataPropertyName = "NombreSucursal",
                Width = 160
            });
        }

        private async void EmpleadoLista_Load(object sender, EventArgs e)
        {
            await this.CargarEmpleados();
        }

        private async Task CargarEmpleados()
        {
            try
            {
                DeshabilitarControles();
                this.empleadosDataGridView.DataSource = null;
                IEnumerable<EmpleadoDTO> empleados = await EmpleadoApiClient.GetAllAsync();
                this.empleadosDataGridView.DataSource = empleados.ToList();
                if (this.empleadosDataGridView.Rows.Count > 0)
                {
                    this.empleadosDataGridView.Rows[0].Selected = true;
                    this.actualizarButton.Enabled = true;
                    this.eliminarButton.Enabled = true;
                }
                else
                {
                    this.actualizarButton.Enabled = false;
                    this.eliminarButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            await this.CargarEmpleados();
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            EmpleadoDTO nuevo = new EmpleadoDTO();
            EmpleadoDetalle detalle = new EmpleadoDetalle(FormMode.Add, nuevo);
            detalle.ShowDialog(this);
            await this.CargarEmpleados();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            EmpleadoDTO? empleado = this.SelectedItem();
            if (empleado == null) return;
            try
            {
                DeshabilitarControles();
                EmpleadoDTO empleadoCompleto = await EmpleadoApiClient.GetAsync(empleado.Id);
                EmpleadoDetalle empleadoDetalle = new EmpleadoDetalle(FormMode.Update, empleadoCompleto);
                empleadoDetalle.ShowDialog(this);
                await this.CargarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            EmpleadoDTO? empleado = this.SelectedItem();
            if (empleado == null) return;
            try
            {
                var result = MessageBox.Show($"¿Está seguro que desea eliminar al empleado {empleado.Nombre} {empleado.Apellido}({empleado.Id})?", "Confirmación eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeshabilitarControles();
                    await EmpleadoApiClient.DeleteAsync(empleado.Id);
                    await this.CargarEmpleados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private EmpleadoDTO? SelectedItem()
        {
            if (empleadosDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un empleado.", "Seleccionar Empleado");
                return null;
            }
            return (EmpleadoDTO)empleadosDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void DeshabilitarControles()
        {
            empleadosDataGridView.Enabled = false;
            eliminarButton.Enabled = false;
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
        }

        private async void HabilitarControles()
        {
            bool esAdmin = await AuthServiceProvider.Instance.GetRolAsync() == RolUsuario.Administrador;

            empleadosDataGridView.Enabled = true;

            agregarButton.Enabled = esAdmin;

            if (empleadosDataGridView.Rows.Count > 0)
            {
                actualizarButton.Enabled = esAdmin;
                eliminarButton.Enabled = esAdmin;
            }
            else
            {
                actualizarButton.Enabled = false;
                eliminarButton.Enabled = false;
            }
        }





    }
}
