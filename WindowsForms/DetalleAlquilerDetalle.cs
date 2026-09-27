using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

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
            get
            {
                return mode;
            }
            set
            {
                SetFormMode(value);
            }
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
                await LoadBicicletas();
                this.Mode = mode;
                this.Detalle = detalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private async Task LoadBicicletas()
        {
            var bicicletas = await BicicletaApiClient.GetAllAsync();

            bicicletaComboBox.DataSource = bicicletas.ToList();
            bicicletaComboBox.DisplayMember = "BicicletaDescripcion";
            bicicletaComboBox.ValueMember = "Id";
            bicicletaComboBox.SelectedIndex = -1;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateDetalle())
            {
                var bicicleta = (BicicletaDTO)bicicletaComboBox.SelectedItem;

                this.Detalle.BicicletaId = bicicleta.Id;
                this.Detalle.BicicletaMarca = bicicleta.Marca;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetDetalle()
        {
            if (this.Detalle == null)
                return;

            this.bicicletaComboBox.SelectedValue = this.Detalle.BicicletaId;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Update)
            {
                bicicletaComboBox.Enabled = false;
            }
            else
            {
                bicicletaComboBox.Enabled = true;
            }
        }

        private bool ValidateDetalle()
        {
            bool isValid = true;

            errorProvider.SetError(bicicletaComboBox, string.Empty);

            if (this.bicicletaComboBox.SelectedValue == null)
            {
                isValid = false;
                errorProvider.SetError(bicicletaComboBox,"Debe seleccionar una bicicleta");
            }

            return isValid;
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            bicicletaComboBox.Enabled = false;
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            bicicletaComboBox.Enabled = true;
        }
    }
}