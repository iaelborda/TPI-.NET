using API.Clients;
using Domain.Model;
using DTOs;

namespace WindowsForms
{
    public partial class PagoLista : Form
    {
        public PagoLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            this.pagosDataGridView.AutoGenerateColumns = false;

            this.pagosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdPago",
                HeaderText = "Id",
                DataPropertyName = "IdPago",
                Width = 60
            });

            this.pagosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdAlquiler",
                HeaderText = "N° Alquiler",
                DataPropertyName = "IdAlquiler",
                Width = 100
            });

            this.pagosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cliente",
                HeaderText = "Cliente",
                DataPropertyName = "ClienteNombre",
                Width = 180
            });

            this.pagosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaPago",
                HeaderText = "Fecha Pago",
                DataPropertyName = "FechaPago",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            this.pagosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Monto",
                HeaderText = "Monto",
                DataPropertyName = "Monto",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            this.pagosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Metodo",
                HeaderText = "Método de Pago",
                DataPropertyName = "Metodo",
                Width = 150
            });
        }

        private async void PagoLista_Load(object sender, EventArgs e)
        {
            await ConfigureButtonPermissions();
            await this.CargarPagos();
        }

        private async Task ConfigureButtonPermissions()
        {
            var authService = AuthServiceProvider.Instance;
            var rol = await authService.GetRolAsync();

            bool esAdministrador = rol == RolUsuario.Administrador;

            agregarButton.Visible = true;
            actualizarButton.Visible = true;
            eliminarButton.Visible = esAdministrador;

            agregarButton.Tag = true;
            actualizarButton.Tag = true;
            eliminarButton.Tag = esAdministrador;
        }

        private PagoDTO? SelectedItem()
        {
            if (pagosDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un pago.", "Seleccionar Pago");
                return null;
            }
            return (PagoDTO)pagosDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void DeshabilitarControles()
        {
            pagosDataGridView.Enabled = false;
            eliminarButton.Enabled = false;
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
        }

        private void HabilitarControles()
        {
            pagosDataGridView.Enabled = true;
            agregarButton.Enabled = true;
            actualizarButton.Enabled = pagosDataGridView.Rows.Count > 0;

            bool canDelete = eliminarButton.Tag is bool deletePermission && deletePermission;
            eliminarButton.Enabled = canDelete && pagosDataGridView.Rows.Count > 0;
        }

        private async Task CargarPagos()
        {
            try
            {
                DeshabilitarControles();
                this.pagosDataGridView.DataSource = null;

                IEnumerable<PagoDTO> pagos = await PagoApiClient.GetAllAsync();
                this.pagosDataGridView.DataSource = pagos.ToList();

                if (this.pagosDataGridView.Rows.Count > 0)
                {
                    this.pagosDataGridView.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            PagoDTO pagoNuevo = new PagoDTO();
            PagoDetalle pagoDetalle = new PagoDetalle(FormMode.Add, pagoNuevo);
            pagoDetalle.ShowDialog(this);

            await this.CargarPagos();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            PagoDTO? pago = this.SelectedItem();
            if (pago == null) return;

            try
            {
                DeshabilitarControles();
                PagoDTO? pagoCompleto = await PagoApiClient.GetAsync(pago.IdPago);
                if (pagoCompleto == null) return;

                PagoDetalle pagoDetalle = new PagoDetalle(FormMode.Update, pagoCompleto);
                pagoDetalle.ShowDialog(this);

                await this.CargarPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            PagoDTO? pago = this.SelectedItem();
            if (pago == null) return;

            var result = MessageBox.Show(
                $"¿Está seguro de anular el pago #{pago.IdPago}? El alquiler #{pago.IdAlquiler} volverá a estado Activo.",
                "Confirmar anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeshabilitarControles();
                    await PagoApiClient.DeleteAsync(pago.IdPago);
                    await this.CargarPagos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al anular pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HabilitarControles();
                }
            }
        }
    }
}
