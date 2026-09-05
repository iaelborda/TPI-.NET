using API.Clients;
using DTOs;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsForms
{
    public enum FormMode
    {
        Add,
        Update
    }

    public partial class SucursalDetalle : Form
    {
        private SucursalDTO sucursal;
        private FormMode mode;

        public SucursalDTO Sucursal
        {
            get { return sucursal; }
            set
            {
                sucursal = value;
                this.SetSucursal();
            }
        }

        public FormMode Mode
        {
            get{return mode;}
            set{SetFormMode(value);}
        }

        public SucursalDetalle()
        {
            InitializeComponent();
        }

        public SucursalDetalle(FormMode mode, SucursalDTO sucursal) : this()
        {
            Init(mode, sucursal);
        }

        private async void Init(FormMode mode, SucursalDTO sucursal)
        {
            try
            {
                DeshabilitarControles();
                this.Mode = mode;
                this.Sucursal = sucursal;
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

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateSucursal())
            {
                try
                {
                    DeshabilitarControles();

                    this.Sucursal.Nombre = nombreTextBox.Text;
                    this.Sucursal.Direccion = direccionTextBox.Text;
                    this.Sucursal.Telefono = telefonoTextBox.Text;
                    this.Sucursal.Capacidad = (int)capacidadNumericUpDown.Value;

                    if (this.Mode == FormMode.Update)
                    {
                        await SucursalApiClient.UpdateAsync(this.Sucursal);
                    }
                    else
                    {
                        await SucursalApiClient.AddAsync(this.Sucursal);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar sucursal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HabilitarControles();
                }
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetSucursal()
        {
            this.idTextBox.Text = this.Sucursal.Id.ToString();
            this.nombreTextBox.Text = this.Sucursal.Nombre;
            this.direccionTextBox.Text = this.Sucursal.Direccion;
            this.telefonoTextBox.Text = this.Sucursal.Telefono;

            if (this.Sucursal.Capacidad >= capacidadNumericUpDown.Minimum)
            {
                this.capacidadNumericUpDown.Value = this.Sucursal.Capacidad;
            }
            else
            {
                this.capacidadNumericUpDown.Value = capacidadNumericUpDown.Minimum;
            }
        }
   

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

        private bool ValidateSucursal()
        {
            bool isValid = true;

            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(direccionTextBox, string.Empty);
            errorProvider.SetError(telefonoTextBox, string.Empty);
            errorProvider.SetError(capacidadNumericUpDown, string.Empty);

            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El Nombre es requerido");
            }

            if (this.direccionTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(direccionTextBox, "La Dirección es requerida");
            }

            if (string.IsNullOrWhiteSpace(telefonoTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(telefonoTextBox,"El Teléfono es requerido");
            }
            else
            {
                string soloNumeros = Regex.Replace(telefonoTextBox.Text, @"\D", "");

                if (!Regex.IsMatch(telefonoTextBox.Text, @"^[0-9\-]+$"))
                {
                    isValid = false;
                    errorProvider.SetError(telefonoTextBox,"El teléfono solo puede contener números y guiones");
                }
                else if (soloNumeros.Length != 10)
                {
                    isValid = false;
                    errorProvider.SetError(telefonoTextBox,"El teléfono debe tener 10 dígitos");
                }
            }

            if (this.capacidadNumericUpDown.Value <= 0)
            {
                isValid = false;
                errorProvider.SetError(capacidadNumericUpDown, "La Capacidad debe ser mayor a 0");
            }

            return isValid;
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            nombreTextBox.Enabled = false;
            direccionTextBox.Enabled = false;
            telefonoTextBox.Enabled = false;
            capacidadNumericUpDown.Enabled = false;
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            nombreTextBox.Enabled = true;
            direccionTextBox.Enabled = true;
            telefonoTextBox.Enabled = true;
            capacidadNumericUpDown.Enabled = true;
        }
    }
}