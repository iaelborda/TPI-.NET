using API.Clients;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public enum FormMode
    {
        Add,
        Update,
    }
    public partial class ClienteDetalle : Form
    {
        private ClienteDTO cliente;
        private FormMode mode;
        public ClienteDTO Cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;
                this.CargarClientes();
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

        public ClienteDetalle()
        {
            InitializeComponent();
            cliente = new ClienteDTO();
            CargarTiposDocumento();
        }

        private void CargarTiposDocumento()
        {
            tipoDocumentoComboBox.DataSource = Enum.GetValues(typeof(TipoDocumento));
        }

        public ClienteDetalle(FormMode mode, ClienteDTO cliente) : this()
        {
            this.Mode = mode;
            this.Cliente = cliente;
        }

        private void CargarClientes()
        {
            if (cliente == null) return;
            this.idTextBox.Text = this.cliente.Id.ToString();
            this.documentoTextBox.Text = this.cliente.Documento ?? "";
            this.tipoDocumentoComboBox.SelectedItem = this.cliente.TipoDocumento;
            this.nombreTextBox.Text = this.cliente.Nombre ?? "";
            this.apellidoTextBox.Text = this.cliente.Apellido ?? "";
            this.emailTextBox.Text = this.cliente.Email ?? "";
            this.telefonoTextBox.Text = this.cliente.Telefono ?? "";
            if (this.cliente.FechaAlta.HasValue)
            {
                this.fechaAltaTextBox.Text = this.cliente.FechaAlta.Value.ToString("dd/MM/yyyy");
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            if (mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                fechaAltaLabel.Visible = false;
                fechaAltaTextBox.Visible = false;
                this.Text = "Agregar Cliente";
            }

            if (mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
                fechaAltaLabel.Visible = true;
                fechaAltaTextBox.Visible = true;
                this.Text = "Actualizar Cliente";
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidarCliente())
            {
                try
                {
                    DeshabilitarControles();

                    this.cliente.Documento = documentoTextBox.Text;
                    this.cliente.TipoDocumento = (TipoDocumento)tipoDocumentoComboBox.SelectedItem;
                    this.cliente.Nombre = nombreTextBox.Text;
                    this.cliente.Apellido = apellidoTextBox.Text;
                    this.cliente.Email = emailTextBox.Text;
                    this.cliente.Telefono = telefonoTextBox.Text;

                    if (this.Mode == FormMode.Update)
                    {
                        await ClienteApiClient.UpdateAsync(this.cliente);
                    }
                    else
                    {
                        await ClienteApiClient.AddAsync(this.cliente);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool ValidarCliente()
        {
            bool isValid = true;
            errorProvider.SetError(documentoTextBox, string.Empty);
            this.cliente.TipoDocumento = (TipoDocumento)tipoDocumentoComboBox.SelectedItem;
            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(apellidoTextBox, string.Empty);
            errorProvider.SetError(emailTextBox, string.Empty);
            errorProvider.SetError(telefonoTextBox, string.Empty);

            if (string.IsNullOrWhiteSpace(documentoTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(documentoTextBox, "El Documento es obligatorio");
            }
            if (tipoDocumentoComboBox.SelectedItem == null)
            {
                isValid = false;
                errorProvider.SetError(tipoDocumentoComboBox, "Debe seleccionar un Tipo de Documento");
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
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(emailTextBox, "El Email es obligatorio");
            }
            else if (!EsEmailValido(emailTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(emailTextBox, "El formato del Email no es válido");
            }
            if (string.IsNullOrWhiteSpace(telefonoTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(telefonoTextBox, "El Teléfono es obligatorio");
            }
            return isValid;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            documentoTextBox.Enabled = false;
            tipoDocumentoComboBox.Enabled = false; 
            nombreTextBox.Enabled = false;
            apellidoTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            telefonoTextBox.Enabled = false;
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            documentoTextBox.Enabled = true;
            tipoDocumentoComboBox.Enabled = true;
            nombreTextBox.Enabled = true;
            apellidoTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            telefonoTextBox.Enabled = true;
        }
    }
}
