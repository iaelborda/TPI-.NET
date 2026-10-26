using API.Clients;
using Domain.Model;
using DTOs;
using System.Text.RegularExpressions;

namespace WindowsForms
{
    public partial class EmpleadoDetalle : Form
    {
        private EmpleadoDTO empleado;
        private FormMode mode;

        public EmpleadoDTO Empleado
        {
            get { return empleado; }
            set
            {
                empleado = value;
                this.SetEmpleado();
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

        public EmpleadoDetalle()
        {
            InitializeComponent();
        }
        public EmpleadoDetalle(FormMode mode, EmpleadoDTO empleado) : this()
        {
            Init(mode, empleado);
        }
        private void CargarTiposDocumento()
        {
            tipoDocumentoComboBox.DataSource = Enum.GetValues(typeof(TipoDocumento));
        }

        private async Task LoadSucursales()
        {
            var sucursales = await SucursalApiClient.GetAllAsync();
            sucursalComboBox.DataSource = sucursales.ToList();
            sucursalComboBox.DisplayMember = "Nombre";
            sucursalComboBox.ValueMember = "Id";
            sucursalComboBox.SelectedIndex = -1;
        }

        private void SetEmpleado()
        {
            if (this.empleado == null) return;
            this.idTextBox.Text = this.empleado.Id.ToString();
            this.legajoTextBox.Text = this.empleado.Legajo > 0 ? this.empleado.Legajo.ToString() : string.Empty;
            this.tipoDocumentoComboBox.SelectedItem = this.empleado.TipoDocumento;
            this.documentoTextBox.Text = this.empleado.Documento ?? string.Empty;
            this.nombreTextBox.Text = this.empleado.Nombre ?? string.Empty;
            this.apellidoTextBox.Text = this.empleado.Apellido ?? string.Empty;
            this.telefonoTextBox.Text = this.empleado.Telefono ?? string.Empty;
            if (this.empleado.SucursalId > 0)
            {
                this.sucursalComboBox.SelectedValue = this.empleado.SucursalId;
            }
        }

        private async void Init(FormMode mode, EmpleadoDTO empleado)
        {
            try
            {
                DeshabilitarControles();
                CargarTiposDocumento();
                await LoadSucursales();
                this.Mode = mode;
                this.Empleado = empleado;
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
        private void SetFormMode(FormMode value)
        {
            mode = value;
            if (mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                documentoTextBox.ReadOnly = false;
                documentoTextBox.BackColor = SystemColors.Window;
                legajoTextBox.ReadOnly = false;
                legajoTextBox.BackColor = SystemColors.Window;
                this.Text = "Agregar Empleado";
            }
            else if (mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
                // Documento y Legajo son inmutables en la actualización según la regla de negocio
                documentoTextBox.ReadOnly = true;
                documentoTextBox.BackColor = Color.LightGray;
                legajoTextBox.ReadOnly = true;
                legajoTextBox.BackColor = Color.LightGray;
                this.Text = "Actualizar Empleado";
            }
        }

        private bool ValidarEmpleado()
        {
            bool isValid = true;
            errorProvider.SetError(legajoTextBox, string.Empty);
            errorProvider.SetError(tipoDocumentoComboBox, string.Empty);
            errorProvider.SetError(documentoTextBox, string.Empty);
            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(apellidoTextBox, string.Empty);
            errorProvider.SetError(telefonoTextBox, string.Empty);
            errorProvider.SetError(sucursalComboBox, string.Empty);
            if (string.IsNullOrWhiteSpace(legajoTextBox.Text) || !int.TryParse(legajoTextBox.Text, out int legajo) || legajo <= 0)
            {
                isValid = false;
                errorProvider.SetError(legajoTextBox, "El Legajo debe ser un número entero mayor que 0");
            }
            if (tipoDocumentoComboBox.SelectedItem == null)
            {
                isValid = false;
                errorProvider.SetError(tipoDocumentoComboBox, "Debe seleccionar un Tipo de Documento");
            }
            if (string.IsNullOrWhiteSpace(documentoTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(documentoTextBox, "El Documento es obligatorio");
            }
            else if (!Regex.IsMatch(documentoTextBox.Text, @"^\d+$"))
            {
                isValid = false;
                errorProvider.SetError(documentoTextBox, "El documento solo puede contener números");
            }
            else if (documentoTextBox.Text.Length < 8)
            {
                isValid = false;
                errorProvider.SetError(documentoTextBox, "El documento debe tener al menos 8 dígitos");
            }
            else if (documentoTextBox.Text.Length > 20)
            {
                isValid = false;
                errorProvider.SetError(documentoTextBox, "El documento debe tener menos de 20 caracteres");
            }
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El Nombre es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(apellidoTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(apellidoTextBox, "El Apellido es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(telefonoTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(telefonoTextBox, "El Teléfono es obligatorio");
            }
            else if (!Regex.IsMatch(telefonoTextBox.Text, @"^[0-9\-]+$"))
            {
                isValid = false;
                errorProvider.SetError(telefonoTextBox, "El teléfono solo puede contener números y guiones");
            }
            else
            {
                string soloNumeros = Regex.Replace(telefonoTextBox.Text, @"\D", "");
                if (soloNumeros.Length != 10)
                {
                    isValid = false;
                    errorProvider.SetError(telefonoTextBox, "El teléfono debe tener 10 dígitos");
                }
            }
            if (sucursalComboBox.SelectedValue == null || (int)sucursalComboBox.SelectedValue <= 0)
            {
                isValid = false;
                errorProvider.SetError(sucursalComboBox, "Debe seleccionar una Sucursal");
            }
            return isValid;
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            legajoTextBox.Enabled = false;
            tipoDocumentoComboBox.Enabled = false;
            documentoTextBox.Enabled = false;
            nombreTextBox.Enabled = false;
            apellidoTextBox.Enabled = false;
            telefonoTextBox.Enabled = false;
            sucursalComboBox.Enabled = false;
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            legajoTextBox.Enabled = true;
            tipoDocumentoComboBox.Enabled = true;
            documentoTextBox.Enabled = true;
            nombreTextBox.Enabled = true;
            apellidoTextBox.Enabled = true;
            telefonoTextBox.Enabled = true;
            sucursalComboBox.Enabled = true;
        }



        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidarEmpleado())
            {
                try
                {
                    DeshabilitarControles();
                    this.empleado.Legajo = int.Parse(legajoTextBox.Text.Trim());
                    this.empleado.TipoDocumento = (TipoDocumento)tipoDocumentoComboBox.SelectedItem;
                    this.empleado.Documento = documentoTextBox.Text.Trim();
                    this.empleado.Nombre = nombreTextBox.Text.Trim();
                    this.empleado.Apellido = apellidoTextBox.Text.Trim();
                    this.empleado.Telefono = telefonoTextBox.Text.Trim();
                    this.empleado.SucursalId = (int)sucursalComboBox.SelectedValue;
                    if (this.Mode == FormMode.Update)
                    {
                        await EmpleadoApiClient.UpdateAsync(this.empleado);
                    }
                    else
                    {
                        await EmpleadoApiClient.AddAsync(this.empleado);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    HabilitarControles();
                }
            }
        }




    }
}
