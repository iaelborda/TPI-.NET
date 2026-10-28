namespace WindowsForms
{
    partial class BicicletaLista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bicicletasDataGridView = new DataGridView();
            agregarButton = new Button();
            actualizarButton = new Button();
            eliminarButton = new Button();
            buscarTextBox = new TextBox();
            buscarButton = new Button();
            generarReporteButton = new Button();
            categoriaComboBox = new ComboBox();
            sucursalComboBox = new ComboBox();
            estadoComboBox = new ComboBox();
            limpiarButton = new Button();
            anioDateTimePicker = new DateTimePicker();
            anioReporte = new Label();
            ((System.ComponentModel.ISupportInitialize)bicicletasDataGridView).BeginInit();
            SuspendLayout();
            // 
            // bicicletasDataGridView
            // 
            bicicletasDataGridView.AllowUserToAddRows = false;
            bicicletasDataGridView.AllowUserToDeleteRows = false;
            bicicletasDataGridView.AllowUserToOrderColumns = true;
            bicicletasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bicicletasDataGridView.Location = new Point(38, 88);
            bicicletasDataGridView.Margin = new Padding(2);
            bicicletasDataGridView.MultiSelect = false;
            bicicletasDataGridView.Name = "bicicletasDataGridView";
            bicicletasDataGridView.ReadOnly = true;
            bicicletasDataGridView.RowHeadersWidth = 62;
            bicicletasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bicicletasDataGridView.Size = new Size(1170, 392);
            bicicletasDataGridView.TabIndex = 0;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(1119, 504);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(112, 34);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // actualizarButton
            // 
            actualizarButton.Location = new Point(990, 504);
            actualizarButton.Margin = new Padding(2);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(112, 34);
            actualizarButton.TabIndex = 2;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(858, 504);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(112, 34);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(38, 35);
            buscarTextBox.Margin = new Padding(2);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.PlaceholderText = "Buscar por marca o modelo...";
            buscarTextBox.Size = new Size(319, 31);
            buscarTextBox.TabIndex = 4;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(1119, 35);
            buscarButton.Margin = new Padding(2);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(112, 34);
            buscarButton.TabIndex = 5;
            buscarButton.Text = "FIltrar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // generarReporteButton
            // 
            generarReporteButton.BackColor = Color.YellowGreen;
            generarReporteButton.Location = new Point(355, 504);
            generarReporteButton.Margin = new Padding(2);
            generarReporteButton.Name = "generarReporteButton";
            generarReporteButton.Size = new Size(174, 34);
            generarReporteButton.TabIndex = 13;
            generarReporteButton.Text = "Generar Reporte";
            generarReporteButton.UseVisualStyleBackColor = false;
            generarReporteButton.Click += generarReporteButton_Click;
            // 
            // categoriaComboBox
            // 
            categoriaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoriaComboBox.FormattingEnabled = true;
            categoriaComboBox.Location = new Point(389, 34);
            categoriaComboBox.Margin = new Padding(4);
            categoriaComboBox.Name = "categoriaComboBox";
            categoriaComboBox.Size = new Size(188, 33);
            categoriaComboBox.TabIndex = 14;
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(585, 34);
            sucursalComboBox.Margin = new Padding(4);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(188, 33);
            sucursalComboBox.TabIndex = 15;
            // 
            // estadoComboBox
            // 
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(781, 34);
            estadoComboBox.Margin = new Padding(4);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(188, 33);
            estadoComboBox.TabIndex = 16;
            // 
            // limpiarButton
            // 
            limpiarButton.Location = new Point(990, 35);
            limpiarButton.Margin = new Padding(2);
            limpiarButton.Name = "limpiarButton";
            limpiarButton.Size = new Size(112, 34);
            limpiarButton.TabIndex = 17;
            limpiarButton.Text = "Limpiar";
            limpiarButton.UseVisualStyleBackColor = true;
            limpiarButton.Click += limpiarButton_Click;
            // 
            // anioDateTimePicker
            // 
            anioDateTimePicker.Format = DateTimePickerFormat.Custom;
            anioDateTimePicker.Location = new Point(156, 505);
            anioDateTimePicker.Name = "anioDateTimePicker";
            anioDateTimePicker.Size = new Size(171, 31);
            anioDateTimePicker.TabIndex = 18;
            anioDateTimePicker.CustomFormat = "yyyy";
            anioDateTimePicker.ShowUpDown = true;
            anioDateTimePicker.Value = DateTime.Today;
            anioDateTimePicker.MinDate = new DateTime(2000, 1, 1);
            anioDateTimePicker.MaxDate = DateTime.Today;
            // 
            // anioReporte
            // 
            anioReporte.AutoSize = true;
            anioReporte.Location = new Point(38, 505);
            anioReporte.Name = "anioReporte";
            anioReporte.Size = new Size(112, 25);
            anioReporte.TabIndex = 19;
            anioReporte.Text = "Año Reporte";
            // 
            // BicicletaLista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 566);
            Controls.Add(anioReporte);
            Controls.Add(anioDateTimePicker);
            Controls.Add(limpiarButton);
            Controls.Add(estadoComboBox);
            Controls.Add(sucursalComboBox);
            Controls.Add(categoriaComboBox);
            Controls.Add(generarReporteButton);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Controls.Add(agregarButton);
            Controls.Add(eliminarButton);
            Controls.Add(actualizarButton);
            Controls.Add(bicicletasDataGridView);
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BicicletaLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bicicletas";
            Load += Bicicletas_Load;
            ((System.ComponentModel.ISupportInitialize)bicicletasDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView bicicletasDataGridView;
        private Button agregarButton;
        private Button actualizarButton;
        private Button eliminarButton;
        private TextBox buscarTextBox;
        private Button buscarButton;
        private Button generarReporteButton;
        private ComboBox categoriaComboBox;
        private ComboBox sucursalComboBox;
        private ComboBox estadoComboBox;
        private Button limpiarButton;
        private DateTimePicker anioDateTimePicker;
        private Label anioReporte;
    }
}