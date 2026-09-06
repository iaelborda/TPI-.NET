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
                this.Text = "Agregar Categoria";
            }

            if(mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
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
                    this.categoria.Descripcion = descripcionTextBox.Text;

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
                    MessageBox.Show($"Error al guardar categoria: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                errorProvider.SetError(descripcionTextBox, "La descripcion es obligatoria");
            }
            return isValid;
        }

        private void DeshabilitarControles()
        {
            this.descripcionTextBox.Enabled = false;
            this.aceptarButton.Enabled = false;
            this.cancelarButton.Enabled = false;
        }

        private void HabilitarControles()
        {
            this.descripcionTextBox.Enabled = true;
            this.aceptarButton.Enabled = true;
            this.cancelarButton.Enabled = true;
        }
    }
}
