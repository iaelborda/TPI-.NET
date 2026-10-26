using API.Clients;
using System;
using System.Diagnostics;
using Domain.Model;
using DTOs;

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
        private bool FechasValidas()
        {
            DateTime desde = fechaDesdeDateTimePicker.Value.Date;
            DateTime hasta = fechaHastaDateTimePicker.Value.Date;

            if (desde > DateTime.Today || hasta > DateTime.Today)
            {
                MessageBox.Show("Las fechas no pueden ser futuras.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (desde > hasta)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private async void Alquileres_Load(object sender, EventArgs e)
        {
            await ConfigureButtonPermissions();
            await CargarSucursales();

            fechaDesdeDateTimePicker.MaxDate = DateTime.Today.AddDays(1).AddTicks(-1);
            fechaHastaDateTimePicker.MaxDate = DateTime.Today.AddDays(1).AddTicks(-1);
            fechaDesdeDateTimePicker.Value = DateTime.Today.AddMonths(-2);
            fechaHastaDateTimePicker.Value = DateTime.Today;

            await this.LoadAlquileres();

            fechaDesdeDateTimePicker.ValueChanged += async (s, ev) => await LoadAlquileres();
            fechaHastaDateTimePicker.ValueChanged += async (s, ev) => await LoadAlquileres();
            sucursalComboBox.SelectionChangeCommitted += async (s, ev) => await LoadAlquileres();
        }

        private async Task CargarSucursales()
        {
            try
            {
                var sucursales = (await SucursalApiClient.GetAllAsync()).ToList();

                sucursales.Insert(0, new SucursalDTO { Id = 0, Nombre = "Todas" });

                sucursalComboBox.DisplayMember = "Nombre";
                sucursalComboBox.ValueMember = "Id";
                sucursalComboBox.DataSource = sucursales;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar sucursales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? ObtenerSucursalSeleccionada()
        {
            return sucursalComboBox.SelectedValue is int id && id > 0 ? id : null;
        }

        private async void generarReporteButton_Click(object? sender, EventArgs e)
        {
            if (generarReporteButton.Tag is not bool esAdministrador || !esAdministrador)
                return;

            DateTime desde = fechaDesdeDateTimePicker.Value.Date;
            DateTime hasta = fechaHastaDateTimePicker.Value.Date;

            if (!FechasValidas())
                return;

            try
            {
                generarReporteButton.Enabled = false;

                var criteria = new ReporteAlquileresCriteriaDTO
                {
                    FechaDesde = desde,
                    FechaHasta = hasta,
                    SucursalId = ObtenerSucursalSeleccionada()
                };

                byte[] pdf = await ReporteApiClient.GetReporteAlquileresAsync(criteria);

                using var dialogo = new SaveFileDialog
                {
                    Filter = "PDF|*.pdf",
                    FileName = $"ReporteAlquileres_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
                };

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    await File.WriteAllBytesAsync(dialogo.FileName, pdf);
                    Process.Start(new ProcessStartInfo(dialogo.FileName) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                generarReporteButton.Enabled = true;
            }
        }

        private async Task ConfigureButtonPermissions()
        {
            var authService = AuthServiceProvider.Instance;
            var rol = await authService.GetRolAsync();

            bool esAdministrador = rol == RolUsuario.Administrador;

            agregarButton.Visible = true;
            actualizarButton.Visible = true;
            cobrarButton.Visible = true;
            eliminarButton.Visible = esAdministrador;
            generarReporteButton.Visible = esAdministrador;

            agregarButton.Tag = true;
            actualizarButton.Tag = true;
            cobrarButton.Tag = true;
            eliminarButton.Tag = esAdministrador;
            generarReporteButton.Tag = esAdministrador;
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            AlquilerDTO alquilerNuevo = new AlquilerDTO();

            AlquilerDetalle alquilerDetalle =
                new AlquilerDetalle(FormMode.Add, alquilerNuevo);

            alquilerDetalle.ShowDialog(this);

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
                alquilerDetalle.ShowDialog(this);

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
            if (!FechasValidas())
                return;

            try
            {
                DeshabilitarControles();

                this.alquileresDataGridView.DataSource = null;

                IEnumerable<AlquilerDTO> alquileres = await AlquilerApiClient.GetByCriteriaAsync(
                    fechaDesdeDateTimePicker.Value.Date,
                    fechaHastaDateTimePicker.Value.Date,
                    ObtenerSucursalSeleccionada());

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
                MessageBox.Show($"Error al cargar alquileres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            alquileresDataGridView.Enabled = false;
            eliminarButton.Enabled = false;
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            cobrarButton.Enabled = false;
        }

        private void HabilitarControles()
        {
            alquileresDataGridView.Enabled = true;
            agregarButton.Enabled = true;
            actualizarButton.Enabled = alquileresDataGridView.Rows.Count > 0;
            cobrarButton.Enabled = alquileresDataGridView.Rows.Count > 0;

            bool canDelete = eliminarButton.Tag is bool deletePermission && deletePermission;
            eliminarButton.Enabled = canDelete && alquileresDataGridView.Rows.Count > 0;
        }

        private async void cobrarButton_Click(object sender, EventArgs e)
        {
            AlquilerDTO? alquiler = this.SelectedItem();
            if (alquiler == null) return;

            if (alquiler.EstadoAlquiler == EstadoDeAlquiler.Cancelado)
            {
                MessageBox.Show("No se pueden cobrar alquileres cancelados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DeshabilitarControles();

                var pagoExistente = await PagoApiClient.GetByAlquilerIdAsync(alquiler.Id);
                if (pagoExistente != null)
                {
                    MessageBox.Show($"El alquiler #{alquiler.Id} ya cuenta con un pago registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                AlquilerDTO? alquilerCompleto = await AlquilerApiClient.GetAsync(alquiler.Id);
                if (alquilerCompleto == null) return;

                if (alquilerCompleto.Detalles == null || !alquilerCompleto.Detalles.Any() || alquilerCompleto.Detalles.Any(d => d.HoraFin == null))
                {
                    MessageBox.Show("No se puede cobrar el alquiler porque aún hay bicicletas pendientes de devolución.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PagoDTO nuevoPago = new PagoDTO
                {
                    IdAlquiler = alquilerCompleto.Id,
                    ClienteNombre = alquilerCompleto.ClienteNombre,
                    ClienteApellido = alquilerCompleto.ClienteApellido,
                    Monto = alquilerCompleto.Detalles != null ? alquilerCompleto.Detalles.Sum(d => d.Subtotal) : 0m
                };
                PagoDetalle pagoDetalle = new PagoDetalle(FormMode.Add, nuevoPago);
                pagoDetalle.ShowDialog(this);

                await this.LoadAlquileres();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el cobro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

    }
}