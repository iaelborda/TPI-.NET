using API.Clients;
using Domain.Model;
using DTOs;

namespace WindowsForms
{
    public partial class AlquilerDetalle : Form
    {
        private AlquilerDTO alquiler;
        private FormMode mode;
        private List<DetalleAlquilerDTO> detallesLocales;

        public AlquilerDTO Alquiler
        {
            get { return alquiler; }
            set
            {
                alquiler = value;
                this.SetAlquiler();
            }
        }

        public FormMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                SetFormMode(value);
            }
        }

        public AlquilerDetalle()
        {
            InitializeComponent();
        }

        public AlquilerDetalle(FormMode mode, AlquilerDTO alquiler) : this()
        {
            Init(mode, alquiler);
        }

        private async void Init(FormMode mode, AlquilerDTO alquiler)
        {
            try
            {
                DeshabilitarControles();
                ConfigurarColumnas();
                detallesLocales = new List<DetalleAlquilerDTO>();
                await LoadClientes();
                await LoadEmpleados();
                this.Mode = mode;
                this.Alquiler = alquiler;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private void ConfigurarColumnas()
        {
            this.detallesDataGridView.AutoGenerateColumns = false;

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BicicletaId",
                HeaderText = "Id Bicicleta",
                DataPropertyName = "BicicletaId",
                Width = 100
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BicicletaMarca",
                HeaderText = "Bicicleta",
                DataPropertyName = "BicicletaMarca",
                Width = 200
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoriaDescripcion",
                HeaderText = "Categoría",
                DataPropertyName = "CategoriaDescripcion",
                Width = 200
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraInicio",
                HeaderText = "Hora Inicio",
                DataPropertyName = "HoraInicio",
                Width = 180,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraFin",
                HeaderText = "Hora Fin",
                DataPropertyName = "HoraFin",
                Width = 180,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                DataPropertyName = "Subtotal",
                Width = 120,
                DefaultCellStyle = { Format = "C2" }
            });
        }

        private async Task LoadClientes()
        {
            var clientes = await ClienteApiClient.GetAllAsync();
            var clientesConNombre = clientes.Select(c => new
            {
                Id = c.Id,
                NombreCompleto = $"{c.Nombre} {c.Apellido}"
            }).ToList();

            clienteComboBox.DataSource = clientesConNombre;
            clienteComboBox.DisplayMember = "NombreCompleto";
            clienteComboBox.ValueMember = "Id";
            clienteComboBox.SelectedIndex = -1;
        }

        private async Task LoadEmpleados()
        {
            var empleados = await EmpleadoApiClient.GetAllAsync();
            var empleadosConNombre = empleados.Select(e => new
            {
                Id = e.Id,
                NombreCompleto = $"{e.Nombre} {e.Apellido} - Legajo: {e.Legajo}"
            }).ToList();

            empleadoComboBox.DataSource = empleadosConNombre;
            empleadoComboBox.DisplayMember = "NombreCompleto";
            empleadoComboBox.ValueMember = "Id";
            empleadoComboBox.SelectedIndex = -1;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateAlquiler())
            {
                try
                {
                    DeshabilitarControles();

                    if (clienteComboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("No hay un cliente seleccionado.");
                        return;
                    }

                    if (empleadoComboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("No hay un empleado seleccionado.");
                        return;
                    }

                    this.Alquiler.ClienteId = (int)clienteComboBox.SelectedValue;
                    this.Alquiler.EmpleadoId = (int)empleadoComboBox.SelectedValue;
                    this.Alquiler.Detalles = detallesLocales.ToList();

                    if (this.Mode == FormMode.Update)
                    {
                        await AlquilerApiClient.UpdateAsync(this.Alquiler);
                    }
                    else
                    {
                        await AlquilerApiClient.AddAsync(this.Alquiler);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HabilitarControles();
                }
            }
        }
        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetAlquiler()
        {
            this.idTextBox.Text = this.Alquiler.Id.ToString();

            if (this.Mode == FormMode.Add)
            {
                this.Alquiler.FechaAlquiler = DateTime.Now;
            }

            this.fechaAlquilerTextBox.Text = this.Alquiler.FechaAlquiler.ToString("dd/MM/yyyy");
            this.clienteComboBox.SelectedValue = this.Alquiler.ClienteId;
            this.empleadoComboBox.SelectedValue = this.Alquiler.EmpleadoId;

            detallesLocales = this.Alquiler.Detalles.Select(detalle => new DetalleAlquilerDTO
            {
                AlquilerId = detalle.AlquilerId,
                BicicletaId = detalle.BicicletaId,
                BicicletaMarca = detalle.BicicletaMarca,
                CategoriaDescripcion = detalle.CategoriaDescripcion,
                HoraInicio = detalle.HoraInicio,
                HoraFin = detalle.HoraFin,
                Estado = detalle.Estado,
                Subtotal = detalle.Subtotal
            }).ToList();

            RefreshDetallesGrid();
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                fechaAlquilerLabel.Visible = true;
                fechaAlquilerTextBox.Visible = true;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
                fechaAlquilerLabel.Visible = true;
                fechaAlquilerTextBox.Visible = true;
            }
        }

        private bool ValidateAlquiler()
        {
            bool isValid = true;

            errorProvider.SetError(clienteComboBox, string.Empty);
            errorProvider.SetError(empleadoComboBox, string.Empty);
            errorProvider.SetError(detallesDataGridView, string.Empty);

            if (clienteComboBox.SelectedIndex < 0)
            {
                isValid = false;
                errorProvider.SetError(clienteComboBox, "Debe seleccionar un cliente");
            }

            if (empleadoComboBox.SelectedIndex < 0)
            {
                isValid = false;
                errorProvider.SetError(empleadoComboBox, "Debe seleccionar un empleado");
            }

            if (detallesLocales.Count == 0)
            {
                isValid = false;
                errorProvider.SetError(detallesDataGridView, "Debe agregar al menos una bicicleta al alquiler");
            }

            return isValid;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            DetalleAlquilerDTO nuevoDetalle = new DetalleAlquilerDTO
            {
                HoraInicio = DateTime.Now,
                Estado = EstadoDetalleAlquiler.Activo,
                Subtotal = 0
            };
            DetalleAlquilerDetalle detalleForm = new DetalleAlquilerDetalle(FormMode.Add, nuevoDetalle);

            if (detalleForm.ShowDialog() == DialogResult.OK)
            {
                detallesLocales.Add(detalleForm.Detalle);
                RefreshDetallesGrid();
            }
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (detallesDataGridView.SelectedRows.Count > 0)
            {
                DetalleAlquilerDTO selectedDetalle = (DetalleAlquilerDTO)detallesDataGridView.SelectedRows[0].DataBoundItem;

                DetalleAlquilerDTO detalleCopia = new DetalleAlquilerDTO
                {
                    AlquilerId = selectedDetalle.AlquilerId,
                    BicicletaId = selectedDetalle.BicicletaId,
                    BicicletaMarca = selectedDetalle.BicicletaMarca,
                    CategoriaDescripcion = selectedDetalle.CategoriaDescripcion,
                    HoraInicio = selectedDetalle.HoraInicio,
                    HoraFin = selectedDetalle.HoraFin,
                    Estado = selectedDetalle.Estado,
                    Subtotal = selectedDetalle.Subtotal
                };

                DetalleAlquilerDetalle detalleForm = new DetalleAlquilerDetalle(FormMode.Update, detalleCopia);

                if (detalleForm.ShowDialog() == DialogResult.OK)
                {
                    int index = detallesLocales.FindIndex(d => d.BicicletaId == selectedDetalle.BicicletaId);

                    if (index >= 0)
                    {
                        detallesLocales[index] = detalleForm.Detalle;
                        RefreshDetallesGrid();
                    }
                }
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            if (detallesDataGridView.SelectedRows.Count > 0)
            {
                DetalleAlquilerDTO selectedDetalle = (DetalleAlquilerDTO)detallesDataGridView.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar la bicicleta {selectedDetalle.BicicletaMarca}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    detallesLocales.RemoveAll(d => d.BicicletaId == selectedDetalle.BicicletaId);
                    RefreshDetallesGrid();
                }
            }
        }

        private void RefreshDetallesGrid()
        {
            detallesDataGridView.DataSource = null;
            detallesDataGridView.DataSource = detallesLocales;

            bool hasDetalles = detallesLocales.Count > 0;
            modificarButton.Enabled = hasDetalles;
            eliminarButton.Enabled = hasDetalles;

            if (hasDetalles)
            {
                detallesDataGridView.Rows[0].Selected = true;
            }

            UpdateTotales();
        }

        private void UpdateTotales()
        {
            int totalBicicletas = detallesLocales.Count;
            decimal totalPrecio = detallesLocales.Sum(d => d.Subtotal);

            totalBicicletasLabel.Text = $"Total Bicicletas: {totalBicicletas}";
            totalPrecioLabel.Text = $"Total Precio: {totalPrecio:C2}";
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            clienteComboBox.Enabled = false;
            empleadoComboBox.Enabled = false;
            fechaAlquilerTextBox.Enabled = false;
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            clienteComboBox.Enabled = true;
            empleadoComboBox.Enabled = true;
            fechaAlquilerTextBox.Enabled = true;
            agregarButton.Enabled = true;
            modificarButton.Enabled = true;
            eliminarButton.Enabled = true;
        }
    }
}