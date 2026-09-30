using API.Clients;
using Domain.Model;
using DTOs;

namespace WindowsForms
{
    public partial class DetalleAlquilerDetalle : Form
    {
        private DetalleAlquilerDTO detalle;
        private FormMode mode;

        public DetalleAlquilerDTO Detalle
        {
            get { return detalle; }
            set
            {
                detalle = value;
                this.SetDetalle();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public DetalleAlquilerDetalle()
        {
            InitializeComponent();
        }

        public DetalleAlquilerDetalle(FormMode mode, DetalleAlquilerDTO detalle) : this()
        {
            Init(mode, detalle);
        }

        private async void Init(FormMode mode, DetalleAlquilerDTO detalle)
        {
            try
            {
                DeshabilitarControles();
                CargarComboEstados();
                await LoadBicicletas();
                this.Mode = mode;
                this.Detalle = detalle;
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

        private void CargarComboEstados()
        {
            if (Controls.Find("estadoComboBox", true).FirstOrDefault() is ComboBox cbEstado)
            {
                cbEstado.DataSource = Enum.GetValues(typeof(EstadoDetalleAlquiler));
            }
        }

        private async Task LoadBicicletas()
        {
            var bicicletas = await BicicletaApiClient.GetAllAsync();

            bicicletaComboBox.SelectedIndexChanged -= bicicletaComboBox_SelectedIndexChanged;

            bicicletaComboBox.DataSource = bicicletas.ToList();
            bicicletaComboBox.DisplayMember = "BicicletaDescripcion";
            bicicletaComboBox.ValueMember = "Id";
            bicicletaComboBox.SelectedIndex = -1;

            bicicletaComboBox.SelectedIndexChanged += bicicletaComboBox_SelectedIndexChanged;
        }

        private async void bicicletaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bicicletaComboBox.SelectedItem is BicicletaDTO bicicleta)
            {
                try
                {
                    var tarifa = await TarifaApiClient.GetTarifaVigenteAsync(bicicleta.CategoriaId);

                    if (tarifa != null)
                    {
                        this.Detalle.PrecioHora = tarifa.PrecioHora;
                        this.precioPorHoraTextBox.Text = tarifa.PrecioHora.ToString("C2");
                    }
                    else
                    {
                        this.Detalle.PrecioHora = 0;
                        this.precioPorHoraTextBox.Text = 0.ToString("C2");
                        MessageBox.Show("La categoría de la bicicleta seleccionada no tiene una tarifa vigente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la tarifa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!this.ValidateDetalle()) return;

            try
            {
                DeshabilitarControles();

                var bicicleta = (BicicletaDTO)bicicletaComboBox.SelectedItem;
                var tarifa = await TarifaApiClient.GetTarifaVigenteAsync(bicicleta.CategoriaId);

                if (tarifa == null)
                {
                    MessageBox.Show("La categoría de la bicicleta seleccionada no tiene una tarifa vigente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Detalle.BicicletaId = bicicleta.Id;
                this.Detalle.BicicletaMarca = bicicleta.Marca;
                this.Detalle.CategoriaDescripcion = bicicleta.DescripcionCategoria;
                this.Detalle.PrecioHora = tarifa.PrecioHora;

                EstadoDetalleAlquiler estadoSeleccionado = EstadoDetalleAlquiler.Activo;
                if (Controls.Find("estadoComboBox", true).FirstOrDefault() is ComboBox cbEstado && cbEstado.SelectedItem != null)
                {
                    estadoSeleccionado = (EstadoDetalleAlquiler)cbEstado.SelectedItem;
                }

                this.Detalle.Estado = estadoSeleccionado;

                if (this.Mode == FormMode.Add)
                {
                    this.Detalle.HoraInicio = DateTime.Now;
                    this.Detalle.Estado = EstadoDetalleAlquiler.Activo;
                    this.Detalle.HoraFin = null;
                    this.Detalle.Subtotal = 0;
                }
                else
                {
                    if (estadoSeleccionado == EstadoDetalleAlquiler.Devuelto)
                    {
                        if (!this.Detalle.HoraFin.HasValue)
                        {
                            this.Detalle.HoraFin = DateTime.Now;
                        }

                        this.Detalle.Subtotal = CalcularSubtotal(this.Detalle.HoraInicio, this.Detalle.HoraFin.Value, this.Detalle.PrecioHora);
                    }
                    else if (estadoSeleccionado == EstadoDetalleAlquiler.Activo)
                    {
                        this.Detalle.HoraFin = null;
                        this.Detalle.Subtotal = 0;
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetDetalle()
        {
            if (this.Detalle == null) return;

            if (this.Detalle.BicicletaId > 0)
            {
                this.bicicletaComboBox.SelectedValue = this.Detalle.BicicletaId;
            }

            this.horaInicioTextBox.Text = this.Detalle.HoraInicio == default ? DateTime.Now.ToString("HH:mm") : this.Detalle.HoraInicio.ToString("HH:mm");
            this.horaFinTextBox.Text = this.Detalle.HoraFin?.ToString("HH:mm") ?? "";
            this.precioPorHoraTextBox.Text = this.Detalle.PrecioHora.ToString("C2");

            if (Controls.Find("estadoComboBox", true).FirstOrDefault() is ComboBox cbEstado)
            {
                cbEstado.SelectedItem = this.Detalle.Estado;
            }
            else if (this.estadoComboBox != null)
            {
                this.estadoComboBox.Text = this.Detalle.Estado.ToString();
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            bicicletaComboBox.Enabled = true;

            if (Controls.Find("estadoComboBox", true).FirstOrDefault() is ComboBox cbEstado)
            {
                cbEstado.Enabled = Mode == FormMode.Update;
            }
        }

        private bool ValidateDetalle()
        {
            bool isValid = true;
            errorProvider.SetError(bicicletaComboBox, string.Empty);

            if (bicicletaComboBox.SelectedIndex < 0)
            {
                isValid = false;
                errorProvider.SetError(bicicletaComboBox, "Debe seleccionar una bicicleta");
            }

            return isValid;
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            bicicletaComboBox.Enabled = false;

            if (Controls.Find("estadoComboBox", true).FirstOrDefault() is ComboBox cbEstado)
            {
                cbEstado.Enabled = false;
            }
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            bicicletaComboBox.Enabled = true;

            if (Controls.Find("estadoComboBox", true).FirstOrDefault() is ComboBox cbEstado)
            {
                cbEstado.Enabled = Mode == FormMode.Update;
            }
        }
    }
}