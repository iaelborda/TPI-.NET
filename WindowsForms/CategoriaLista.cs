using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace WindowsForms
{
    public partial class CategoriaLista : Form
    {
        public CategoriaLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            this.categoriasDataGridView.AutoGenerateColumns = false;

            this.categoriasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 50
            });
            this.categoriasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripcion",
                DataPropertyName = "Descripcion",
                Width = 100
            });
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            CategoriaDTO categoriaNueva = new CategoriaDTO();
            CategoriaDetalle categoriaDetalle = new CategoriaDetalle(FormMode.Add, categoriaNueva);
            categoriaDetalle.ShowDialog();
            await this.CargarCategorias();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarControles();
                int id = this.SelectedItem().Id;
                CategoriaDTO categoria = CategoriaApiClient.GetAsync(id).Result;
                CategoriaDetalle categoriaDetalle = new CategoriaDetalle(FormMode.Update, categoria);
                categoriaDetalle.ShowDialog();
                await this.CargarCategorias();
            }
            catch (Exception ex) {
                MessageBox.Show($"Error al actualizar categoria: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaDTO categoria = this.SelectedItem();
                var result = MessageBox.Show($"¿Está seguro que desea eliminar la categoría {categoria.Descripcion}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeshabilitarControles();
                    await CategoriaApiClient.DeleteAsync(categoria.Id);
                    await this.CargarCategorias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();

            }
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            await this.CargarCategorias();
        }

        private async void CategoriaLista_Load(object sender, EventArgs e)
        {
            await this.CargarCategorias();
        }

        private CategoriaDTO SelectedItem()
        {
            if (categoriasDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una categoría.", "Seleccionar Categoría");
                throw new Exception("No hay categoría seleccionada.");
            }
            return (CategoriaDTO)categoriasDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void DeshabilitarControles()
        {
            buscarButton.Enabled = false;
            buscarTextBox.Enabled = false;
            categoriasDataGridView.Enabled = false;
            eliminarButton.Enabled = false;
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
        }

        private void HabilitarControles()
        {
            buscarButton.Enabled = true;
            buscarTextBox.Enabled = true;
            categoriasDataGridView.Enabled = true;
            agregarButton.Enabled = true;
        }

        private async Task CargarCategorias()
        {
            try
            {
                DeshabilitarControles();
                this.categoriasDataGridView.DataSource = null;
                IEnumerable<CategoriaDTO> categorias = await CategoriaApiClient.GetAllAsync();
                this.categoriasDataGridView.DataSource = categorias.ToList();
                if (this.categoriasDataGridView.Rows.Count > 0)
                {
                    this.categoriasDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }
    }
}
