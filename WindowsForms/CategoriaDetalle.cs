using DTOs;
using API.Clients;

namespace WindowsForms
{
    public partial class CategoriaDetalle : Form
    {
        private CategoriaDTO categoria;
        private FormMode mode;

        public CategoriaDTO Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                this.CargarCategoria();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                SetFormMode(value);
            }
        }
        public CategoriaDetalle()
        {
            InitializeComponent();
            categoria = new CategoriaDTO();
        }

        public CategoriaDetalle(FormMode mode, CategoriaDTO categoria) : this()
        {
            this.Mode = mode;
            this.Categoria = categoria;
        }   

        public void CargarCategoria()
        {
            if (categoria == null) return;
            this.idTextBox.Text = categoria.Id.ToString();
            this.descripcionTextBox.Text = categoria.Descripcion;
        }

        private void SetFormMode(FormMode mode)
        {
            if(mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                precioHoraLabel.Visible = true;
                precioHoraTextBox.Visible = true;
                this.Text = "Agregar Categoria";
            }

            if(mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
                precioHoraLabel.Visible = false;
                precioHoraTextBox.Visible = false;
                this.Text = "Actualizar Categoria";
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidarCategoria())
            {
                try
                {
                    DeshabilitarControles();
                    this.categoria.Descripcion = descripcionTextBox.Text.Trim();
                    if (this.Mode == FormMode.Add && decimal.TryParse(precioHoraTextBox.Text, out decimal precio))
                    {
                        this.categoria.PrecioHoraInicial = precio;
                    }
                    if (this.Mode == FormMode.Update)
                    {
                        await CategoriaApiClient.UpdateAsync(this.categoria);
                    }
                    else
                    {
                        await CategoriaApiClient.AddAsync(this.categoria);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool ValidarCategoria()
        {
            bool isValid = true;

            errorProvider.SetError(descripcionTextBox, string.Empty);
            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(descripcionTextBox, "La descripción es obligatoria.");
            }
            if (this.Mode == FormMode.Add)
            {
                errorProvider.SetError(precioHoraTextBox, string.Empty);
                if (string.IsNullOrWhiteSpace(precioHoraTextBox.Text))
                {
                    isValid = false;
                    errorProvider.SetError(precioHoraTextBox, "La tarifa inicial es obligatoria.");
                }
                else if (!decimal.TryParse(precioHoraTextBox.Text, out decimal precio) || precio <= 0)
                {
                    isValid = false;
                    errorProvider.SetError(precioHoraTextBox, "Debe ingresar una tarifa válida mayor a 0.");
                }
            }
            return isValid;
        }


        private void DeshabilitarControles()
        {
            this.descripcionTextBox.Enabled = false;
            this.precioHoraTextBox.Enabled = false;
            this.aceptarButton.Enabled = false;
            this.cancelarButton.Enabled = false;
        }

        private void HabilitarControles()
        {
            this.descripcionTextBox.Enabled = true;
            this.precioHoraTextBox.Enabled = true;
            this.aceptarButton.Enabled = true;
            this.cancelarButton.Enabled = true;
        }

    }
}
