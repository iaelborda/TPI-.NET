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
    public partial class ClienteLista : Form
    {
        public ClienteLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            this.clientesDataGridView.AutoGenerateColumns = false;

            this.clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 50
            });

            this.clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Documento",
                HeaderText = "Documento",
                DataPropertyName = "Documento",
                Width = 100
            });

            this.clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 150
            });

            this.clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Apellido",
                HeaderText = "Apellido",
                DataPropertyName = "Apellido",
                Width = 150
            });

            this.clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 200
            });

            this.clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 120
            });

            this.clientesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaAlta",
                HeaderText = "Fecha Alta",
                DataPropertyName = "FechaAlta",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteDTO cliente = this.SelectedItem();
                var result = MessageBox.Show($"¿Está seguro que desea eliminar al cliente {cliente.Nombre} {cliente.Apellido}({cliente.Id})?", "Confirmación eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeshabilitarControles();
                    await ClienteApiClient.DeleteAsync(cliente.Id);
                    await this.CargarClientes();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private ClienteDTO SelectedItem()
        {
            if (clientesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un cliente.", "Seleccionar Cliente");
                throw new Exception("No hay cliente seleccionado.");
            }
            return (ClienteDTO)clientesDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void DeshabilitarControles()
        {
            buscarButton.Enabled = false;
            buscarTextBox.Enabled = false;
            clientesDataGridView.Enabled = false;
            eliminarButton.Enabled = false;
            agregarButton.Enabled = false;
            actualizarButton.Enabled = false;
        }

        private void HabilitarControles()
        {
            buscarButton.Enabled = true;
            buscarTextBox.Enabled = true;
            agregarButton.Enabled = true;
            clientesDataGridView.Enabled = true;
        }

        private async Task CargarClientes()
        {
            try
            {
                DeshabilitarControles();
                this.clientesDataGridView.DataSource = null;
                IEnumerable<ClienteDTO> clientes = await ClienteApiClient.GetAllAsync();
                this.clientesDataGridView.DataSource = clientes.ToList();
                if (this.clientesDataGridView.Rows.Count > 0)
                {
                    this.clientesDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void buscarButton_Click(object sender, EventArgs e)
        {
            await this.CargarClientes();
        }

        private async void actualizarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarControles();
                int id = this.SelectedItem().Id;
                ClienteDTO cliente = await ClienteApiClient.GetAsync(id);
                ClienteDetalle clienteDetalle = new ClienteDetalle(FormMode.Update, cliente);
                clienteDetalle.ShowDialog();
                await this.CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            ClienteDTO clienteNuevo = new ClienteDTO();
            ClienteDetalle clienteDetalle = new ClienteDetalle(FormMode.Add, clienteNuevo);
            clienteDetalle.ShowDialog();
            await this.CargarClientes();
        }

        private async void ClienteLista_Load(object sender, EventArgs e)
        {
            await this.CargarClientes();
        }
    }
}
