using API.Clients;
using Domain.Model;
using DTOs;

namespace WindowsForms
{
    public partial class TarifaLista : Form
    {
        public TarifaLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
            AplicarPermisos();
        }

        private async void AplicarPermisos()
        {
            bool esAdmin = await AuthServiceProvider.Instance.GetRolAsync() == RolUsuario.Administrador;

            agregarButton.Enabled = esAdmin;
            actualizarButton.Enabled = esAdmin;
            eliminarButton.Enabled = esAdmin;
        }

        private void ConfigurarColumnas()
        {
            tarifasDataGridView.AutoGenerateColumns = false;
            tarifasDataGridView.Columns.Clear();

            tarifasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 80
            });

            tarifasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Categoria",
                HeaderText = "Categoría",
                DataPropertyName = "DescripcionCategoria",
                Width = 200
            });

            tarifasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecioHora",
                HeaderText = "Precio/Hora",
                DataPropertyName = "PrecioHora",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 150
            });

            tarifasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaDesde",
                HeaderText = "Fecha Desde",
                DataPropertyName = "FechaDesde",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 150
            });

            tarifasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaHasta",
                HeaderText = "Fecha Hasta",
                DataPropertyName = "FechaHasta",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy",
                    NullValue = "Vigente"
                },
                Width = 150
            });
        }

        private async void Tarifas_Load(object sender, EventArgs e)
        {
            await LoadTarifas();
        }

        private async Task LoadTarifas()
        {
            try
            {
                DeshabilitarControles();
                tarifasDataGridView.DataSource = null;
                tarifasDataGridView.DataSource = (await TarifaApiClient.GetAllAsync()).ToList();

                if (tarifasDataGridView.Rows.Count > 0)
                {
                    tarifasDataGridView.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tarifas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            TarifaDTO tarifaNueva = new TarifaDTO();
            TarifaDetalle tarifaDetalle = new TarifaDetalle(FormMode.Add, tarifaNueva);
            tarifaDetalle.ShowDialog();
            await LoadTarifas();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            TarifaDTO? tarifa = SelectedItem();
            if (tarifa == null) return;

            try
            {
                DeshabilitarControles();
                TarifaDTO? tarifaCompleta = await TarifaApiClient.GetAsync(tarifa.Id);

                if (tarifaCompleta == null)
                {
                    MessageBox.Show("No se encontró la tarifa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TarifaDetalle tarifaDetalle = new TarifaDetalle(FormMode.Update, tarifaCompleta);
                tarifaDetalle.ShowDialog();
                await LoadTarifas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar tarifa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            TarifaDTO? tarifa = SelectedItem();
            if (tarifa == null) return;

            var result = MessageBox.Show("¿Está seguro de que desea eliminar la tarifa seleccionada?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeshabilitarControles();
                    bool eliminada = await TarifaApiClient.DeleteAsync(tarifa.Id);

                    if (!eliminada)
                    {
                        MessageBox.Show("No se encontró la tarifa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    await LoadTarifas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar tarifa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HabilitarControles();
                }
            }
        }

        private TarifaDTO? SelectedItem()
        {
            if (tarifasDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una tarifa.", "Seleccionar tarifa");
                return null;
            }

            return tarifasDataGridView.SelectedRows[0].DataBoundItem as TarifaDTO;
        }

        private void DeshabilitarControles()
        {
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            eliminarButton.Enabled = false;
            tarifasDataGridView.Enabled = false;
        }

        private async void HabilitarControles()
        {
            bool esAdmin = await AuthServiceProvider.Instance.GetRolAsync() == RolUsuario.Administrador;

            agregarButton.Enabled = esAdmin;
            tarifasDataGridView.Enabled = true;
            actualizarButton.Enabled = esAdmin && tarifasDataGridView.Rows.Count > 0;
            eliminarButton.Enabled = esAdmin && tarifasDataGridView.Rows.Count > 0;
        }
    }
}
