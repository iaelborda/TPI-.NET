using API.Clients;
using Domain.Model;
using DTOs;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class BicicletaDetalle : Form
    {
        private BicicletaDTO bicicleta;
        private FormMode mode;

        public BicicletaDTO Bicicleta
        {
            get { return bicicleta; }
            set
            {
                bicicleta = value;
                this.SetBicicleta();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public BicicletaDetalle()
        {
            InitializeComponent();
        }

        public BicicletaDetalle(FormMode mode, BicicletaDTO bicicleta) : this()
        {
            Init(mode, bicicleta);
        }

        private async void Init(FormMode mode, BicicletaDTO bicicleta)
        {
            try
            {
                DeshabilitarControles();
                await LoadCategorias();
                await LoadSucursales();
                LoadEstados();
                this.Mode = mode;
                this.Bicicleta = bicicleta;
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
        private async Task LoadSucursales()
        {
            var sucursales = await SucursalApiClient.GetAllAsync();
            sucursalComboBox.DataSource = sucursales.ToList();
            sucursalComboBox.DisplayMember = "Direccion";
            sucursalComboBox.ValueMember = "Id";
            sucursalComboBox.SelectedIndex = -1;
        }
        private async Task LoadCategorias()
        {
            var categorias = await CategoriaApiClient.GetAllAsync();
            categoriaComboBox.DataSource = categorias.ToList();
            categoriaComboBox.DisplayMember = "Descripcion";
            categoriaComboBox.ValueMember = "Id";
            categoriaComboBox.SelectedIndex = -1;
        }
        private void LoadEstados()
        {
            estadoComboBox.DataSource = Enum.GetValues(typeof(EstadoBicicleta));
            estadoComboBox.SelectedIndex = -1;
        }
        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateBicicleta())
            {
                try
                {
                    DeshabilitarControles();

                    this.Bicicleta.Marca = marcaTextBox.Text;
                    this.Bicicleta.CategoriaId = (int)categoriaComboBox.SelectedValue;
                    this.Bicicleta.Modelo = modeloTextBox.Text;
                    this.Bicicleta.Estado = (EstadoBicicleta)estadoComboBox.SelectedItem;
                    this.Bicicleta.SucursalId = (int)sucursalComboBox.SelectedValue;

                    if (this.Mode == FormMode.Update)
                    {
                        await BicicletaApiClient.UpdateAsync(this.Bicicleta);
                    }
                    else
                    {
                        await BicicletaApiClient.AddAsync(this.Bicicleta);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar bicicleta: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void SetBicicleta()
        {
            this.idTextBox.Text = this.Bicicleta.Id.ToString();
            this.marcaTextBox.Text = this.Bicicleta.Marca;
            this.categoriaComboBox.SelectedValue = this.Bicicleta.CategoriaId;
            this.modeloTextBox.Text = this.Bicicleta.Modelo;
            this.estadoComboBox.SelectedItem = this.Bicicleta.Estado;
            this.sucursalComboBox.SelectedValue = this.Bicicleta.SucursalId;
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

        private bool ValidateBicicleta()
        {
            bool isValid = true;

            errorProvider.SetError(marcaTextBox, string.Empty);
            errorProvider.SetError(categoriaComboBox, string.Empty);
            errorProvider.SetError(modeloTextBox, string.Empty);
            errorProvider.SetError(estadoComboBox, string.Empty);
            errorProvider.SetError(sucursalComboBox, string.Empty);

            if (string.IsNullOrWhiteSpace(marcaTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(marcaTextBox, "La marca es requerida");
            }

            if (categoriaComboBox.SelectedIndex == -1)
            {
                isValid = false;
                errorProvider.SetError(categoriaComboBox, "Debe seleccionar una Categoría");
            }

            if (string.IsNullOrWhiteSpace(modeloTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(modeloTextBox, "El modelo es requerido");
            }

            if (estadoComboBox.SelectedIndex == -1)
            {
                isValid = false;
                errorProvider.SetError(estadoComboBox, "Debe seleccionar un Estado");
            }

            if (sucursalComboBox.SelectedIndex == -1)
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
            marcaTextBox.Enabled = false;
            categoriaComboBox.Enabled = false;
            modeloTextBox.Enabled = false;
            estadoComboBox.Enabled = false;
            sucursalComboBox.Enabled = false;
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            marcaTextBox.Enabled = true;
            categoriaComboBox.Enabled = true;
            modeloTextBox.Enabled = true;
            estadoComboBox.Enabled = true;
            sucursalComboBox.Enabled = true;
        }
    }
}