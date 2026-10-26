using API.Clients;
using DTOs;

namespace WindowsForms
{
    public partial class TarifaDetalle : Form
    {
        private TarifaDTO tarifa;
        private FormMode mode;

        public TarifaDTO Tarifa
        {
            get { return tarifa; }
            set
            {
                tarifa = value;
                SetTarifa();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public TarifaDetalle()
        {
            InitializeComponent();
        }

        public TarifaDetalle(FormMode mode, TarifaDTO tarifa) : this()
        {
            Init(mode, tarifa);
        }

        private async void Init(FormMode mode, TarifaDTO tarifa)
        {
            try
            {
                DeshabilitarControles();
                Mode = mode;
                Tarifa = tarifa;
                await LoadCategorias();
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

        private async Task LoadCategorias()
        {
            var categorias = (await CategoriaApiClient.GetAllAsync()).ToList();

            categoriaComboBox.DataSource = categorias;
            categoriaComboBox.DisplayMember = "Descripcion";
            categoriaComboBox.ValueMember = "Id";

            if (Mode == FormMode.Update)
            {
                categoriaComboBox.SelectedValue = Tarifa.CategoriaId;
            }
            else if (categorias.Count == 0)
            {
                MessageBox.Show("No hay categorías disponibles para asignar una tarifa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                aceptarButton.Enabled = false;
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateTarifa()) return;

            try
            {
                DeshabilitarControles();

                Tarifa.CategoriaId = (int)categoriaComboBox.SelectedValue;
                Tarifa.PrecioHora = precioHoraNumericUpDown.Value;

                if (Mode == FormMode.Update)
                {
                    await TarifaApiClient.UpdateAsync(Tarifa);
                }
                else
                {
                    await TarifaApiClient.AddAsync(Tarifa);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar tarifa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetTarifa()
        {
            idTextBox.Text = Tarifa.Id.ToString();
            precioHoraNumericUpDown.Value = Math.Clamp(Tarifa.PrecioHora, precioHoraNumericUpDown.Minimum, precioHoraNumericUpDown.Maximum);
            fechaDesdeDateTimePicker.Value = Tarifa.FechaDesde == DateTime.MinValue ? DateTime.Now : Tarifa.FechaDesde;

            fechaHastaDateTimePicker.ShowCheckBox = true;
            fechaHastaDateTimePicker.Checked = Tarifa.FechaHasta.HasValue;

            if (Tarifa.FechaHasta.HasValue)
            {
                fechaHastaDateTimePicker.Value = Tarifa.FechaHasta.Value;
            }
            else
            {
                fechaHastaDateTimePicker.Value = DateTime.Today;
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            bool esAlta = Mode == FormMode.Add;

            idLabel.Visible = !esAlta;
            idTextBox.Visible = !esAlta;

            categoriaComboBox.Enabled = esAlta;
            fechaDesdeDateTimePicker.Enabled = false;
            fechaHastaDateTimePicker.Enabled = false;
            fechaHastaDateTimePicker.ShowCheckBox = true;

            if (esAlta)
            {
                fechaDesdeDateTimePicker.Value = DateTime.Now;
                fechaHastaDateTimePicker.Checked = false;
            }
        }

        private bool ValidateTarifa()
        {
            errorProvider.SetError(categoriaComboBox, string.Empty);
            errorProvider.SetError(precioHoraNumericUpDown, string.Empty);

            bool isValid = true;

            if (categoriaComboBox.SelectedValue == null)
            {
                isValid = false;
                errorProvider.SetError(categoriaComboBox, "La categoría es requerida.");
            }

            if (precioHoraNumericUpDown.Value <= 0)
            {
                isValid = false;
                errorProvider.SetError(precioHoraNumericUpDown, "El precio por hora debe ser mayor a 0.");
            }

            return isValid;
        }

        private void DeshabilitarControles()
        {
            aceptarButton.Enabled = false;
            cancelarButton.Enabled = false;
            categoriaComboBox.Enabled = false;
            precioHoraNumericUpDown.Enabled = false;
        }

        private void HabilitarControles()
        {
            aceptarButton.Enabled = true;
            cancelarButton.Enabled = true;
            categoriaComboBox.Enabled = Mode == FormMode.Add;
            precioHoraNumericUpDown.Enabled = true;
        }
    }
}