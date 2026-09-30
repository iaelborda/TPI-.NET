namespace WindowsForms
{
    partial class DetalleAlquilerDetalle
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
            bicicletaLabel = new Label();
            horaInicioLabel = new Label();
            horaFinLabel = new Label();
            precioPorHoraLabel = new Label();
            bicicletaComboBox = new ComboBox();
            horaInicioTextBox = new TextBox();
            horaFinTextBox = new TextBox();
            precioPorHoraTextBox = new TextBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            estadoLabel = new Label();
            errorProvider = new ErrorProvider(components);
            estadoComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // bicicletaLabel
            // 
            bicicletaLabel.AutoSize = true;
            bicicletaLabel.Location = new Point(66, 58);
            bicicletaLabel.Margin = new Padding(4, 0, 4, 0);
            bicicletaLabel.Name = "bicicletaLabel";
            bicicletaLabel.Size = new Size(74, 25);
            bicicletaLabel.TabIndex = 0;
            bicicletaLabel.Text = "Bicicleta";
            // 
            // horaInicioLabel
            // 
            horaInicioLabel.AutoSize = true;
            horaInicioLabel.Location = new Point(66, 121);
            horaInicioLabel.Name = "horaInicioLabel";
            horaInicioLabel.Size = new Size(98, 25);
            horaInicioLabel.TabIndex = 1;
            horaInicioLabel.Text = "Hora Inicio";
            // 
            // horaFinLabel
            // 
            horaFinLabel.AutoSize = true;
            horaFinLabel.Location = new Point(66, 182);
            horaFinLabel.Name = "horaFinLabel";
            horaFinLabel.Size = new Size(79, 25);
            horaFinLabel.TabIndex = 2;
            horaFinLabel.Text = "Hora Fin";
            // 
            // precioPorHoraLabel
            // 
            precioPorHoraLabel.AutoSize = true;
            precioPorHoraLabel.Location = new Point(66, 310);
            precioPorHoraLabel.Name = "precioPorHoraLabel";
            precioPorHoraLabel.Size = new Size(134, 25);
            precioPorHoraLabel.TabIndex = 3;
            precioPorHoraLabel.Text = "Precio por hora";
            // 
            // bicicletaComboBox
            // 
            bicicletaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bicicletaComboBox.FormattingEnabled = true;
            bicicletaComboBox.Location = new Point(219, 55);
            bicicletaComboBox.Margin = new Padding(4, 5, 4, 5);
            bicicletaComboBox.Name = "bicicletaComboBox";
            bicicletaComboBox.Size = new Size(440, 33);
            bicicletaComboBox.TabIndex = 1;
            // 
            // horaInicioTextBox
            // 
            horaInicioTextBox.Location = new Point(219, 115);
            horaInicioTextBox.Name = "horaInicioTextBox";
            horaInicioTextBox.ReadOnly = true;
            horaInicioTextBox.Size = new Size(255, 31);
            horaInicioTextBox.TabIndex = 0;
            horaInicioTextBox.TabStop = false;
            // 
            // horaFinTextBox
            // 
            horaFinTextBox.Location = new Point(219, 179);
            horaFinTextBox.Name = "horaFinTextBox";
            horaFinTextBox.ReadOnly = true;
            horaFinTextBox.Size = new Size(255, 31);
            horaFinTextBox.TabIndex = 0;
            horaFinTextBox.TabStop = false;
            // 
            // precioPorHoraTextBox
            // 
            precioPorHoraTextBox.Location = new Point(219, 304);
            precioPorHoraTextBox.Name = "precioPorHoraTextBox";
            precioPorHoraTextBox.ReadOnly = true;
            precioPorHoraTextBox.Size = new Size(255, 31);
            precioPorHoraTextBox.TabIndex = 0;
            precioPorHoraTextBox.TabStop = false;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(513, 373);
            aceptarButton.Margin = new Padding(4, 5, 4, 5);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(114, 50);
            aceptarButton.TabIndex = 6;
            aceptarButton.Text = "&Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(647, 373);
            cancelarButton.Margin = new Padding(4, 5, 4, 5);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(114, 50);
            cancelarButton.TabIndex = 9;
            cancelarButton.Text = "&Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new Point(66, 246);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new Size(66, 25);
            estadoLabel.TabIndex = 10;
            estadoLabel.Text = "Estado";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // estadoComboBox
            // 
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(219, 246);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(255, 33);
            estadoComboBox.TabIndex = 11;
            // 
            // DetalleAlquilerDetalle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(estadoComboBox);
            Controls.Add(estadoLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(precioPorHoraTextBox);
            Controls.Add(horaFinTextBox);
            Controls.Add(horaInicioTextBox);
            Controls.Add(bicicletaComboBox);
            Controls.Add(precioPorHoraLabel);
            Controls.Add(horaFinLabel);
            Controls.Add(horaInicioLabel);
            Controls.Add(bicicletaLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DetalleAlquilerDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle Alquiler - Detalle";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label bicicletaLabel;
        private Label horaInicioLabel;
        private Label horaFinLabel;
        private Label precioPorHoraLabel;
        private ComboBox bicicletaComboBox;
        private TextBox horaInicioTextBox;
        private TextBox horaFinTextBox;
        private TextBox precioPorHoraTextBox;
        private Button aceptarButton;
        private Button cancelarButton;
        private Label estadoLabel;
        private ErrorProvider errorProvider;
        private ComboBox estadoComboBox;
    }
}