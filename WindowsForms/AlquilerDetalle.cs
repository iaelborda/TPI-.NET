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
            get { return mode; }
            set { SetFormMode(value); }
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
            this.detallesDataGridView.Columns.Clear();

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BicicletaId",
                HeaderText = "Id Bicicleta",
                DataPropertyName = "BicicletaId",
                Width = 90
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BicicletaMarca",
                HeaderText = "Bicicleta",
                DataPropertyName = "BicicletaMarca",
                Width = 180
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoriaDescripcion",
                HeaderText = "Categoría",
                DataPropertyName = "CategoriaDescripcion",
                Width = 150
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraInicio",
                HeaderText = "Hora Inicio",
                DataPropertyName = "HoraInicio",
                Width = 140,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraFin",
                HeaderText = "Hora Fin",
                DataPropertyName = "HoraFin",
                Width = 140,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm", NullValue = "-" }
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecioHora",
                HeaderText = "Tarifa/Hora",
                DataPropertyName = "PrecioHora",
                Width = 110,
                DefaultCellStyle = { Format = "C2" }
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                DataPropertyName = "Subtotal",
                Width = 110,
                DefaultCellStyle = { Format = "C2" }
            });

            this.detallesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 100
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
            if (!this.ValidateAlquiler())
            {
                return;
            }

            try
            {
                this.ActiveControl = null;
                DeshabilitarControles();

                this.Alquiler.ClienteId = (int)clienteComboBox.SelectedValue;
                this.Alquiler.EmpleadoId = (int)empleadoComboBox.SelectedValue;
                this.Alquiler.Detalles = detallesLocales.ToList();

                if (this.Mode == FormMode.Update)
                {
                    await AlquilerApiClient.UpdateAsync(this.Alquiler);
                }
                else
                {
                    this.Alquiler.EstadoAlquiler = EstadoDeAlquiler.Activo;
                    await AlquilerApiClient.AddAsync(this.Alquiler);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void cancelarAlquilerButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cancelar este alquiler?", "Cancelar alquiler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                this.Alquiler.EstadoAlquiler = EstadoDeAlquiler.Cancelado;
                DeshabilitarControles();
                await AlquilerApiClient.UpdateAsync(this.Alquiler);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cancelar el alquiler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }
        private async void finalizarAlquilerButton_Click(object sender, EventArgs e)
        {
            if (detallesLocales.Count == 0)
            {
                MessageBox.Show("No hay bicicletas registradas en este alquiler.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Desea registrar la devolución de las bicicletas y finalizar este alquiler?", "Finalizar Alquiler", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                DateTime fechaFin = DateTime.Now;

                foreach (var detalle in detallesLocales)
                {
                    if (detalle.Estado == EstadoDetalleAlquiler.Activo || !detalle.HoraFin.HasValue)
                    {
                        detalle.HoraFin = fechaFin;
                        detalle.Subtotal = CalcularSubtotal(detalle.HoraInicio, fechaFin, detalle.PrecioHora);
                        detalle.Estado = EstadoDetalleAlquiler.Devuelto;
                    }
                }

                this.Alquiler.EstadoAlquiler = EstadoDeAlquiler.Finalizado;
                this.Alquiler.ClienteId = (int)clienteComboBox.SelectedValue;
                this.Alquiler.EmpleadoId = (int)empleadoComboBox.SelectedValue;
                this.Alquiler.Detalles = detallesLocales.ToList();

                DeshabilitarControles();
                await AlquilerApiClient.UpdateAsync(this.Alquiler);

                RefreshDetallesGrid();
                MessageBox.Show("El alquiler se ha finalizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al finalizar alquiler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private decimal CalcularSubtotal(DateTime inicio, DateTime fin, decimal precioHora)
        {
            TimeSpan duracion = fin - inicio;
            double horas = Math.Ceiling(duracion.TotalHours);
            if (horas < 1) horas = 1;

            return (decimal)horas * precioHora;
        }

        private void SetAlquiler()
        {
            this.idTextBox.Text = this.Alquiler.Id.ToString();

            if (this.Mode == FormMode.Add)
            {
                this.Alquiler.FechaAlquiler = DateTime.Now;
                this.Alquiler.EstadoAlquiler = EstadoDeAlquiler.Activo;
            }

            this.fechaAlquilerTextBox.Text = this.Alquiler.FechaAlquiler.ToString("dd/MM/yyyy HH:mm");

            if (this.Alquiler.ClienteId > 0)
                this.clienteComboBox.SelectedValue = this.Alquiler.ClienteId;

            if (this.Alquiler.EmpleadoId > 0)
                this.empleadoComboBox.SelectedValue = this.Alquiler.EmpleadoId;

            detallesLocales = this.Alquiler.Detalles != null
                ? this.Alquiler.Detalles.Select(detalle => new DetalleAlquilerDTO
                {
                    AlquilerId = detalle.AlquilerId,
                    BicicletaId = detalle.BicicletaId,
                    BicicletaMarca = detalle.BicicletaMarca,
                    CategoriaDescripcion = detalle.CategoriaDescripcion,
                    HoraInicio = detalle.HoraInicio,
                    HoraFin = detalle.HoraFin,
                    Estado = detalle.Estado,
                    PrecioHora = detalle.PrecioHora,
                    Subtotal = detalle.Subtotal
                }).ToList()
                : new List<DetalleAlquilerDTO>();

            ActualizarEstadoBotones();
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
                cancelarAlquilerButton.Visible = false;
                finalizarAlquilerButton.Visible = false; 
            }
            else if (Mode == FormMode.Update)
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
                HoraFin = null,
                Estado = EstadoDetalleAlquiler.Activo,
                Subtotal = 0 
            };

            DetalleAlquilerDetalle detalleForm = new DetalleAlquilerDetalle(FormMode.Add, nuevoDetalle);

            if (detalleForm.ShowDialog() == DialogResult.OK)
            {
                detalleForm.Detalle.Subtotal = 0;
                detalleForm.Detalle.HoraFin = null;

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
                    PrecioHora = selectedDetalle.PrecioHora,
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

            if (detallesLocales.Count > 0 && detallesDataGridView.Rows.Count > 0)
            {
                detallesDataGridView.Rows[0].Selected = true;
            }

            ActualizarEstadoBotones();
            UpdateTotales();
        }

        private void UpdateTotales()
        {
            int totalBicicletas = detallesLocales.Count;
            decimal totalPrecio = detallesLocales.Sum(d => d.Subtotal);

            totalBicicletasLabel.Text = $"Total Bicicletas: {totalBicicletas}";
            totalPrecioLabel.Text = $"Total Precio: {totalPrecio:C2}";
        }

        private void ActualizarEstadoBotones()
        {
            bool alquilerActivo = this.Alquiler != null && this.Alquiler.EstadoAlquiler == EstadoDeAlquiler.Activo;
            bool esEdicion = this.Mode == FormMode.Update;
            bool hasDetalles = detallesLocales.Count > 0;

            finalizarAlquilerButton.Visible = esEdicion && alquilerActivo;
            finalizarAlquilerButton.Enabled = esEdicion && alquilerActivo && hasDetalles;

            cancelarAlquilerButton.Visible = esEdicion && alquilerActivo;
            cancelarAlquilerButton.Enabled = esEdicion && alquilerActivo;

            agregarButton.Enabled = alquilerActivo;
            modificarButton.Enabled = alquilerActivo && hasDetalles;
            eliminarButton.Enabled = alquilerActivo && hasDetalles;

            clienteComboBox.Enabled = alquilerActivo;
            empleadoComboBox.Enabled = alquilerActivo;
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            clienteComboBox.Enabled = false;
            empleadoComboBox.Enabled = false;
            fechaAlquilerTextBox.Enabled = false;
            agregarButton.Enabled = false;
            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;
            finalizarAlquilerButton.Enabled = false;
            cancelarAlquilerButton.Enabled = false;
        }

        private void HabilitarControles()
        {
            bool alquilerActivo = this.Mode == FormMode.Add || (this.Alquiler != null && this.Alquiler.EstadoAlquiler == EstadoDeAlquiler.Activo);

            aceptarButton.Enabled = alquilerActivo;
            cancelarButton.Enabled = true;
            fechaAlquilerTextBox.Enabled = false;

            ActualizarEstadoBotones();
        }
    }
}