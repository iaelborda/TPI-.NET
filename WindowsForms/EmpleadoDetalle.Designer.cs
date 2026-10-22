namespace WindowsForms
{
    partial class EmpleadoDetalle
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
            idTextBox = new TextBox();
            tipoDocumentoLabel = new Label();
            tipoDocumentoComboBox = new ComboBox();
            documentoLabel = new Label();
            documentoTextBox = new TextBox();
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            apellidoLabel = new Label();
            apellidoTextBox = new TextBox();
            telefonoLabel = new Label();
            telefonoTextBox = new TextBox();
            legajoLabel = new Label();
            legajoTextBox = new TextBox();
            sucursalLabel = new Label();
            sucursalComboBox = new ComboBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(115, 30);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 20);
            idLabel.TabIndex = 0;
            idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            idTextBox.BackColor = Color.LightGray;
            idTextBox.Location = new Point(145, 30);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(180, 27);
            idTextBox.TabIndex = 1;
            // 
            // tipoDocumentoLabel
            // 
            tipoDocumentoLabel.AutoSize = true;
            tipoDocumentoLabel.Location = new Point(20, 70);
            tipoDocumentoLabel.Name = "tipoDocumentoLabel";
            tipoDocumentoLabel.Size = new Size(121, 20);
            tipoDocumentoLabel.TabIndex = 2;
            tipoDocumentoLabel.Text = "Tipo Documento";
            // 
            // tipoDocumentoComboBox
            // 
            tipoDocumentoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoDocumentoComboBox.FormattingEnabled = true;
            tipoDocumentoComboBox.Location = new Point(145, 70);
            tipoDocumentoComboBox.Name = "tipoDocumentoComboBox";
            tipoDocumentoComboBox.Size = new Size(180, 28);
            tipoDocumentoComboBox.TabIndex = 3;
            // 
            // documentoLabel
            // 
            documentoLabel.AutoSize = true;
            documentoLabel.Location = new Point(20, 110);
            documentoLabel.Margin = new Padding(2, 0, 2, 0);
            documentoLabel.Name = "documentoLabel";
            documentoLabel.Size = new Size(87, 20);
            documentoLabel.TabIndex = 4;
            documentoLabel.Text = "Documento";
            // 
            // documentoTextBox
            // 
            documentoTextBox.Location = new Point(145, 110);
            documentoTextBox.Name = "documentoTextBox";
            documentoTextBox.Size = new Size(180, 27);
            documentoTextBox.TabIndex = 5;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(20, 150);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(64, 20);
            nombreLabel.TabIndex = 6;
            nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(145, 150);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(180, 27);
            nombreTextBox.TabIndex = 7;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(20, 190);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(66, 20);
            apellidoLabel.TabIndex = 8;
            apellidoLabel.Text = "Apellido";
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(145, 190);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(180, 27);
            apellidoTextBox.TabIndex = 9;
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(20, 230);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(67, 20);
            telefonoLabel.TabIndex = 10;
            telefonoLabel.Text = "Telefono";
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Location = new Point(145, 230);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(180, 27);
            telefonoTextBox.TabIndex = 11;
            // 
            // legajoLabel
            // 
            legajoLabel.AutoSize = true;
            legajoLabel.Location = new Point(20, 270);
            legajoLabel.Name = "legajoLabel";
            legajoLabel.Size = new Size(54, 20);
            legajoLabel.TabIndex = 12;
            legajoLabel.Text = "Legajo";
            // 
            // legajoTextBox
            // 
            legajoTextBox.Location = new Point(145, 270);
            legajoTextBox.Name = "legajoTextBox";
            legajoTextBox.Size = new Size(180, 27);
            legajoTextBox.TabIndex = 13;
            // 
            // sucursalLabel
            // 
            sucursalLabel.AutoSize = true;
            sucursalLabel.Location = new Point(20, 310);
            sucursalLabel.Name = "sucursalLabel";
            sucursalLabel.Size = new Size(70, 20);
            sucursalLabel.TabIndex = 14;
            sucursalLabel.Text = "Sucursal";
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(145, 310);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(180, 28);
            sucursalComboBox.TabIndex = 15;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(195, 369);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(94, 29);
            aceptarButton.TabIndex = 16;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(315, 369);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(94, 29);
            cancelarButton.TabIndex = 17;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EmpleadoDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 418);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(sucursalComboBox);
            Controls.Add(sucursalLabel);
            Controls.Add(legajoTextBox);
            Controls.Add(legajoLabel);
            Controls.Add(telefonoTextBox);
            Controls.Add(telefonoLabel);
            Controls.Add(apellidoTextBox);
            Controls.Add(apellidoLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(nombreLabel);
            Controls.Add(documentoTextBox);
            Controls.Add(documentoLabel);
            Controls.Add(tipoDocumentoComboBox);
            Controls.Add(tipoDocumentoLabel);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmpleadoDetalle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Empleado";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private TextBox idTextBox;
        private Label tipoDocumentoLabel;
        private ComboBox tipoDocumentoComboBox;
        private Label documentoLabel;
        private TextBox documentoTextBox;
        private Label nombreLabel;
        private TextBox nombreTextBox;
        private Label apellidoLabel;
        private TextBox apellidoTextBox;
        private Label telefonoLabel;
        private TextBox telefonoTextBox;
        private Label legajoLabel;
        private TextBox legajoTextBox;
        private Label sucursalLabel;
        private ComboBox sucursalComboBox;
        private Button aceptarButton;
        private Button cancelarButton;
        private ErrorProvider errorProvider;
    }
}