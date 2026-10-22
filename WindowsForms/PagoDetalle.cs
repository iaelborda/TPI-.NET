using API.Clients;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PagoDetalle : Form
    {
        private PagoDTO pago;
        private FormMode mode;
        private List<AlquilerDTO> alquileresPendientes = new();

        public PagoDTO Pago
        {
            get { return pago; }
            set
            {
                pago = value;
                this.CargarPago();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set
            {
                SetFormMode(value);
            }
        }

        public PagoDetalle()
        {
            InitializeComponent();
            pago = new PagoDTO();
            CargarMetodosPago();
        }

        public PagoDetalle(FormMode mode, PagoDTO pago) : this()
        {
            this.Mode = mode;
            this.Pago = pago;
        }

        private void CargarMetodosPago()
        {
            metodoComboBox.DataSource = Enum.GetValues(typeof(MetodoPago));
        }

        private void CargarPago()
        {
            if (pago == null) return;
            this.idTextBox.Text = pago.IdPago.ToString();
            this.montoTextBox.Text = pago.Monto.ToString("C2");
            this.metodoComboBox.SelectedItem = pago.Metodo;

            if (pago.FechaPago != default)
            {
                this.fechaPagoTextBox.Text = pago.FechaPago.ToString("dd/MM/yyyy HH:mm");
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                fechaPagoLabel.Visible = false;
                fechaPagoTextBox.Visible = false;
                alquilerComboBox.Enabled = true;
                this.Text = "Registrar Pago";
            }

            if (mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
                fechaPagoLabel.Visible = true;
                fechaPagoTextBox.Visible = true;
                alquilerComboBox.Enabled = false;
                this.Text = "Actualizar Pago";
            }
        }

        private async void PagoDetalle_Load(object sender, EventArgs e)
        {
            if (mode == FormMode.Add)
            {
                await CargarAlquileresPendientes();
            }
            else
            {
                alquilerComboBox.Items.Clear();
                alquilerComboBox.Items.Add($"Alquiler #{pago.IdAlquiler} - {pago.ClienteNombre} {pago.ClienteApellido}");
                alquilerComboBox.SelectedIndex = 0;
            }
        }

        private async Task CargarAlquileresPendientes()
        {
            try
            {
                var todos = await AlquilerApiClient.GetAllAsync();
                alquileresPendientes = todos
                    .Where(a => a.EstadoAlquiler == EstadoDeAlquiler.Activo &&
                                a.Detalles != null &&
                                a.Detalles.Count > 0 &&
                                a.Detalles.All(d => d.HoraFin.HasValue))
                    .ToList();

                alquilerComboBox.DisplayMember = "DisplayText";
                alquilerComboBox.ValueMember = "Id";

                var listaCombo = alquileresPendientes.Select(a => new
                {
                    a.Id,
                    DisplayText = $"Alquiler #{a.Id} - {a.ClienteNombre} {a.ClienteApellido} - Total: {a.Detalles.Sum(d => d.Subtotal):C2}"
                }).ToList();

                alquilerComboBox.DataSource = listaCombo;

                if (listaCombo.Count == 0)
                {
                    MessageBox.Show("No hay alquileres activos con todas las bicicletas devueltas pendientes de cobro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    aceptarButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar alquileres pendientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void alquilerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mode == FormMode.Add && alquilerComboBox.SelectedValue is int alquilerId)
            {
                var seleccionado = alquileresPendientes.FirstOrDefault(a => a.Id == alquilerId);
                if (seleccionado != null)
                {
                    decimal total = seleccionado.Detalles.Sum(d => d.Subtotal);
                    montoTextBox.Text = total.ToString("C2");
                }
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidarPago())
            {
                try
                {
                    DeshabilitarControles();

                    this.pago.Metodo = (MetodoPago)metodoComboBox.SelectedItem;

                    if (this.Mode == FormMode.Update)
                    {
                        await PagoApiClient.UpdateAsync(this.pago);
                    }
                    else
                    {
                        this.pago.IdAlquiler = (int)alquilerComboBox.SelectedValue;
                        await PagoApiClient.AddAsync(this.pago);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HabilitarControles();
                }
            }
        }

        private bool ValidarPago()
        {
            bool isValid = true;
            errorProvider.SetError(alquilerComboBox, string.Empty);
            errorProvider.SetError(metodoComboBox, string.Empty);

            if (mode == FormMode.Add && (alquilerComboBox.SelectedValue == null || (int)alquilerComboBox.SelectedValue <= 0))
            {
                isValid = false;
                errorProvider.SetError(alquilerComboBox, "Debe seleccionar un alquiler válido");
            }

            if (metodoComboBox.SelectedItem == null)
            {
                isValid = false;
                errorProvider.SetError(metodoComboBox, "Debe seleccionar un método de pago");
            }

            return isValid;
        }

        private void DeshabilitarControles()
        {
            alquilerComboBox.Enabled = false;
            metodoComboBox.Enabled = false;
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
        }

        private void HabilitarControles()
        {
            if (mode == FormMode.Add) alquilerComboBox.Enabled = true;
            metodoComboBox.Enabled = true;
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
