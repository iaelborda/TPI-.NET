using API.Clients;
using Domain.Model;
using DTOs;
using System.Diagnostics;

namespace WindowsForms
{
    public partial class BicicletaLista : Form
    {
        public BicicletaLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            this.bicicletasDataGridView.AutoGenerateColumns = false;

            this.bicicletasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 70
            });

            this.bicicletasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Marca",
                HeaderText = "Marca",
                DataPropertyName = "Marca",
                Width = 160
            });

            this.bicicletasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Modelo",
                HeaderText = "Modelo",
                DataPropertyName = "Modelo",
                Width = 170
            });

            this.bicicletasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 150
            });

            this.bicicletasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Categoria",
                HeaderText = "Categoría",
                DataPropertyName = "DescripcionCategoria",
                Width = 180
            });

            this.bicicletasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Sucursal",
                HeaderText = "Sucursal",
                DataPropertyName = "DireccionSucursal",
                Width = 250
            });
        }
        private async void Bicicletas_Load(object sender, EventArgs e)
        {
            await CargarCombos();
            await this.LoadBicicletas();
        }

        private async Task CargarCombos()
        {
            try
            {
                var categorias = (await CategoriaApiClient.GetAllAsync())?.ToList() ?? new();
                categorias.Insert(0, new CategoriaDTO { Id = 0, Descripcion = "Todas las categorias" });
                categoriaComboBox.DataSource = categorias;
                categoriaComboBox.DisplayMember = "Descripcion";
                categoriaComboBox.ValueMember = "Id";
                categoriaComboBox.SelectedIndex = 0;

                var sucursales = (await SucursalApiClient.GetAllAsync())?.ToList() ?? new();
                sucursales.Insert(0, new SucursalDTO { Id = 0, Direccion = "Todas las sucursales" });
                sucursalComboBox.DataSource = sucursales;
                sucursalComboBox.DisplayMember = "Direccion";
                sucursalComboBox.ValueMember = "Id";
                sucursalComboBox.SelectedIndex = 0;

                estadoComboBox.Items.Clear();
                estadoComboBox.Items.AddRange(new object[] { "Todos", "Disponible", "EnUso", "EnMantenimiento" });
                estadoComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar filtros: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task LoadBicicletas()
        {
            try
            {
                DeshabilitarControles();

                this.bicicletasDataGridView.DataSource = null;

                IEnumerable<BicicletaDTO> bicicletas;
                bicicletas = await BicicletaApiClient.GetAllAsync();

                this.bicicletasDataGridView.DataSource = bicicletas;

                if (this.bicicletasDataGridView.Rows.Count > 0)
                {
                    this.bicicletasDataGridView.Rows[0].Selected = true;

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
                MessageBox.Show($"Error al cargar bicicletas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            BicicletaDTO bicicletaNueva = new BicicletaDTO();
            BicicletaDetalle bicicletaDetalle = new BicicletaDetalle(FormMode.Add, bicicletaNueva);
            bicicletaDetalle.ShowDialog(this);
            await this.LoadBicicletas();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            BicicletaDTO? bicicleta = this.SelectedItem();
            if (bicicleta == null) return;
            try
            {
                DeshabilitarControles();
                BicicletaDTO bicicletaCompleta = await BicicletaApiClient.GetAsync(bicicleta.Id);
                BicicletaDetalle bicicletaDetalle = new BicicletaDetalle(FormMode.Update, bicicletaCompleta);
                bicicletaDetalle.ShowDialog(this);
                await this.LoadBicicletas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar bicicleta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            BicicletaDTO? bicicleta = this.SelectedItem();
            if (bicicleta == null) return;
            try
            {
                var result = MessageBox.Show($"¿Está seguro que desea eliminar la bicicleta {bicicleta.Marca}, {bicicleta.Modelo} (ubicada en: {bicicleta.DireccionSucursal})?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeshabilitarControles();
                    await BicicletaApiClient.DeleteAsync(bicicleta.Id);
                    await this.LoadBicicletas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar bicicleta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private BicicletaDTO? SelectedItem()
        {
            if (bicicletasDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una bicicleta.", "Seleccionar Bicicleta");
                return null;
            }
            return (BicicletaDTO)bicicletasDataGridView.SelectedRows[0].DataBoundItem;
        }
        private void DeshabilitarControles()
        {
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            eliminarButton.Enabled = false;
            bicicletasDataGridView.Enabled = false;
            generarReporteButton.Enabled = false;
        }

        private async void HabilitarControles()
        {
            bool esAdmin = await AuthServiceProvider.Instance.GetRolAsync() == RolUsuario.Administrador;

            agregarButton.Enabled = esAdmin;
            bicicletasDataGridView.Enabled = true;
            generarReporteButton.Enabled = esAdmin;
            if (bicicletasDataGridView.Rows.Count > 0)
            {
                eliminarButton.Enabled = esAdmin;
                actualizarButton.Enabled = esAdmin;
            }
        }

        private async void generarReporteButton_Click(object sender, EventArgs e)
        {
            try
            {
                generarReporteButton.Enabled = false;
                byte[] pdf = await ReporteApiClient.GetTop10BicicletasAnioAsync();
                using var dialogo = new SaveFileDialog
                {
                    Filter = "Archivos PDF|*.pdf",
                    FileName = $"Top10Bicicletas_{DateTime.Now:yyyyMMdd_HHmm}.pdf",
                    Title = "Guardar Top 10 Bicicletas"
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

        private async void limpiarButton_Click(object sender, EventArgs e)
        {
            buscarTextBox.Text = string.Empty;
            estadoComboBox.SelectedIndex = 0;
            sucursalComboBox.SelectedIndex = 0;
            categoriaComboBox.SelectedIndex = 0;
            await LoadBicicletas();
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarControles();
                this.bicicletasDataGridView.DataSource = null;
                string? texto = string.IsNullOrWhiteSpace(buscarTextBox.Text) ? null : buscarTextBox.Text.Trim();
                int? categoriaId = categoriaComboBox.SelectedValue is int cId && cId > 0 ? cId : null;
                int? sucursalId = sucursalComboBox.SelectedValue is int sId && sId > 0 ? sId : null;
                EstadoBicicleta? estado = null;
                string? estadoStr = estadoComboBox.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(estadoStr) && estadoStr != "Todos" && Enum.TryParse<EstadoBicicleta>(estadoStr, out var est))
                {
                    estado = est;
                }
                var criteria = new BicicletaCriteriaDTO
                {
                    Busqueda = texto,
                    CategoriaId = categoriaId,
                    SucursalId = sucursalId,
                    Estado = estado
                };

                var bicicletas = await BicicletaApiClient.GetByCriteriaAsync(criteria);
                this.bicicletasDataGridView.DataSource = bicicletas.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar bicicletas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }
    }
}