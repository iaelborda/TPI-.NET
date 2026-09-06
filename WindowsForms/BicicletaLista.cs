using API.Clients;
using DTOs;

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
            await this.LoadBicicletas();
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

            bicicletaDetalle.ShowDialog();

            await this.LoadBicicletas();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarControles();

                int id = this.SelectedItem().Id;

                BicicletaDTO bicicleta = await BicicletaApiClient.GetAsync(id);

                BicicletaDetalle bicicletaDetalle = new BicicletaDetalle(FormMode.Update, bicicleta);

                bicicletaDetalle.ShowDialog();

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
            BicicletaDTO bicicleta = this.SelectedItem();

            var result = MessageBox.Show($"¿Está seguro que desea eliminar la bicicleta {bicicleta.Marca}, {bicicleta.Modelo} (ubicada en: {bicicleta.DireccionSucursal})?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeshabilitarControles();

                    await BicicletaApiClient.DeleteAsync(bicicleta.Id);

                    await this.LoadBicicletas();
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
        }

        private BicicletaDTO SelectedItem()
        {
            BicicletaDTO bicicleta;

            bicicleta = (BicicletaDTO)bicicletasDataGridView.SelectedRows[0].DataBoundItem;

            return bicicleta;
        }

        private void DeshabilitarControles()
        {
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
            eliminarButton.Enabled = false;
            bicicletasDataGridView.Enabled = false;
        }

        private void HabilitarControles()
        {
            agregarButton.Enabled = true;
            bicicletasDataGridView.Enabled = true;
        }
    }
}