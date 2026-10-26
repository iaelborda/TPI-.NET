namespace WindowsForms
{
    partial class TarifaDetalle
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
            components = new System.ComponentModel.Container();
            idLabel = new Label();
            precioHoraLabel = new Label();
            fechaDesdeLabel = new Label();
            fechaHastaLabel = new Label();
            categoriaLabel = new Label();
            errorProvider = new ErrorProvider(components);
            idTextBox = new TextBox();
            categoriaComboBox = new ComboBox();
            fechaDesdeDateTimePicker = new DateTimePicker();
            fechaHastaDateTimePicker = new DateTimePicker();
            precioHoraNumericUpDown = new NumericUpDown();
            aceptarButton = new Button();
            cancelarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)precioHoraNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(41, 38);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(22, 20);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id";
            // 
            // precioHoraLabel
            // 
            precioHoraLabel.AutoSize = true;
            precioHoraLabel.Location = new Point(41, 155);
            precioHoraLabel.Margin = new Padding(2, 0, 2, 0);
            precioHoraLabel.Name = "precioHoraLabel";
            precioHoraLabel.Size = new Size(89, 20);
            precioHoraLabel.TabIndex = 1;
            precioHoraLabel.Text = "Precio/Hora";
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new Point(41, 211);
            fechaDesdeLabel.Margin = new Padding(2, 0, 2, 0);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new Size(91, 20);
            fechaDesdeLabel.TabIndex = 2;
            fechaDesdeLabel.Text = "Fecha desde";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new Point(41, 264);
            fechaHastaLabel.Margin = new Padding(2, 0, 2, 0);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new Size(86, 20);
            fechaHastaLabel.TabIndex = 3;
            fechaHastaLabel.Text = "Fecha hasta";
            // 
            // categoriaLabel
            // 
            categoriaLabel.AutoSize = true;
            categoriaLabel.Location = new Point(41, 100);
            categoriaLabel.Margin = new Padding(2, 0, 2, 0);
            categoriaLabel.Name = "categoriaLabel";
            categoriaLabel.Size = new Size(74, 20);
            categoriaLabel.TabIndex = 4;
            categoriaLabel.Text = "Categoria";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(136, 35);
            idTextBox.Margin = new Padding(2, 2, 2, 2);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(121, 27);
            idTextBox.TabIndex = 5;
            // 
            // categoriaComboBox
            // 
            categoriaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoriaComboBox.Enabled = false;
            categoriaComboBox.FormattingEnabled = true;
            categoriaComboBox.Location = new Point(136, 98);
            categoriaComboBox.Margin = new Padding(2, 2, 2, 2);
            categoriaComboBox.Name = "categoriaComboBox";
            categoriaComboBox.Size = new Size(182, 28);
            categoriaComboBox.TabIndex = 6;
            // 
            // fechaDesdeDateTimePicker
            // 
            fechaDesdeDateTimePicker.Enabled = false;
            fechaDesdeDateTimePicker.Format = DateTimePickerFormat.Short;
            fechaDesdeDateTimePicker.Location = new Point(136, 211);
            fechaDesdeDateTimePicker.Margin = new Padding(2, 2, 2, 2);
            fechaDesdeDateTimePicker.Name = "fechaDesdeDateTimePicker";
            fechaDesdeDateTimePicker.Size = new Size(145, 27);
            fechaDesdeDateTimePicker.TabIndex = 7;
            fechaDesdeDateTimePicker.Value = new DateTime(2026, 10, 19, 13, 18, 25, 0);
            // 
            // fechaHastaDateTimePicker
            // 
            fechaHastaDateTimePicker.Format = DateTimePickerFormat.Short;
            fechaHastaDateTimePicker.Location = new Point(136, 264);
            fechaHastaDateTimePicker.Margin = new Padding(2, 2, 2, 2);
            fechaHastaDateTimePicker.Name = "fechaHastaDateTimePicker";
            fechaHastaDateTimePicker.Size = new Size(145, 27);
            fechaHastaDateTimePicker.TabIndex = 8;
            // 
            // precioHoraNumericUpDown
            // 
            precioHoraNumericUpDown.Location = new Point(136, 154);
            precioHoraNumericUpDown.Margin = new Padding(2, 2, 2, 2);
            precioHoraNumericUpDown.Maximum = new decimal(new int[] { -1486618624, 232830643, 0, 0 });
            precioHoraNumericUpDown.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            precioHoraNumericUpDown.Name = "precioHoraNumericUpDown";
            precioHoraNumericUpDown.Size = new Size(144, 27);
            precioHoraNumericUpDown.TabIndex = 9;
            precioHoraNumericUpDown.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(346, 310);
            aceptarButton.Margin = new Padding(2, 2, 2, 2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(90, 37);
            aceptarButton.TabIndex = 10;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(242, 310);
            cancelarButton.Margin = new Padding(2, 2, 2, 2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(90, 37);
            cancelarButton.TabIndex = 11;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // TarifaDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 366);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(precioHoraNumericUpDown);
            Controls.Add(fechaHastaDateTimePicker);
            Controls.Add(fechaDesdeDateTimePicker);
            Controls.Add(categoriaComboBox);
            Controls.Add(idTextBox);
            Controls.Add(categoriaLabel);
            Controls.Add(fechaHastaLabel);
            Controls.Add(fechaDesdeLabel);
            Controls.Add(precioHoraLabel);
            Controls.Add(idLabel);
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TarifaDetalle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tarifa";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)precioHoraNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private Label precioHoraLabel;
        private Label fechaDesdeLabel;
        private Label fechaHastaLabel;
        private Label categoriaLabel;
        private ErrorProvider errorProvider;
        private ComboBox categoriaComboBox;
        private TextBox idTextBox;
        private NumericUpDown precioHoraNumericUpDown;
        private DateTimePicker fechaHastaDateTimePicker;
        private DateTimePicker fechaDesdeDateTimePicker;
        private Button cancelarButton;
        private Button aceptarButton;
    }
}