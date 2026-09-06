namespace WindowsForms
{
    partial class ClienteDetalle
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
            documentoLabel = new Label();
            documentoTextBox = new TextBox();
            nombreLabel = new Label();
            apellidoLabel = new Label();
            emailLabel = new Label();
            telefonoLabel = new Label();
            fechaAltaLabel = new Label();
            tipoDocumentoLabel = new Label();
            nombreTextBox = new TextBox();
            apellidoTextBox = new TextBox();
            emailTextBox = new TextBox();
            telefonoTextBox = new TextBox();
            fechaAltaTextBox = new TextBox();
            tipoDocumentoComboBox = new ComboBox();
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
            // documentoLabel
            // 
            documentoLabel.AutoSize = true;
            documentoLabel.Location = new Point(20, 110);
            documentoLabel.Margin = new Padding(2, 0, 2, 0);
            documentoLabel.Name = "documentoLabel";
            documentoLabel.Size = new Size(87, 20);
            documentoLabel.TabIndex = 2;
            documentoLabel.Text = "Documento";
            // 
            // documentoTextBox
            // 
            documentoTextBox.Location = new Point(145, 110);
            documentoTextBox.Name = "documentoTextBox";
            documentoTextBox.Size = new Size(180, 27);
            documentoTextBox.TabIndex = 3;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(20, 150);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(64, 20);
            nombreLabel.TabIndex = 4;
            nombreLabel.Text = "Nombre";
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(20, 190);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(66, 20);
            apellidoLabel.TabIndex = 5;
            apellidoLabel.Text = "Apellido";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(20, 230);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 6;
            emailLabel.Text = "Email";
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(20, 270);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(67, 20);
            telefonoLabel.TabIndex = 7;
            telefonoLabel.Text = "Telefono";
            // 
            // fechaAltaLabel
            // 
            fechaAltaLabel.AutoSize = true;
            fechaAltaLabel.Location = new Point(20, 310);
            fechaAltaLabel.Name = "fechaAltaLabel";
            fechaAltaLabel.Size = new Size(78, 20);
            fechaAltaLabel.TabIndex = 8;
            fechaAltaLabel.Text = "Fecha Alta";
            // 
            // tipoDocumentoLabel
            // 
            tipoDocumentoLabel.AutoSize = true;
            tipoDocumentoLabel.Location = new Point(20, 70);
            tipoDocumentoLabel.Name = "tipoDocumentoLabel";
            tipoDocumentoLabel.Size = new Size(121, 20);
            tipoDocumentoLabel.TabIndex = 9;
            tipoDocumentoLabel.Text = "Tipo Documento";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(145, 150);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(180, 27);
            nombreTextBox.TabIndex = 10;
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(145, 190);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(180, 27);
            apellidoTextBox.TabIndex = 11;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(145, 230);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(180, 27);
            emailTextBox.TabIndex = 12;
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Location = new Point(145, 270);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(180, 27);
            telefonoTextBox.TabIndex = 13;
            // 
            // fechaAltaTextBox
            // 
            fechaAltaTextBox.BackColor = Color.LightGray;
            fechaAltaTextBox.Location = new Point(145, 310);
            fechaAltaTextBox.Name = "fechaAltaTextBox";
            fechaAltaTextBox.ReadOnly = true;
            fechaAltaTextBox.Size = new Size(180, 27);
            fechaAltaTextBox.TabIndex = 14;
            // 
            // tipoDocumentoComboBox
            // 
            tipoDocumentoComboBox.FormattingEnabled = true;
            tipoDocumentoComboBox.Location = new Point(145, 70);
            tipoDocumentoComboBox.Name = "tipoDocumentoComboBox";
            tipoDocumentoComboBox.Size = new Size(180, 28);
            tipoDocumentoComboBox.TabIndex = 15;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(195, 399);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(94, 29);
            aceptarButton.TabIndex = 16;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(315, 399);
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
            // ClienteDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 438);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(tipoDocumentoComboBox);
            Controls.Add(fechaAltaTextBox);
            Controls.Add(telefonoTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(apellidoTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(tipoDocumentoLabel);
            Controls.Add(fechaAltaLabel);
            Controls.Add(telefonoLabel);
            Controls.Add(emailLabel);
            Controls.Add(apellidoLabel);
            Controls.Add(nombreLabel);
            Controls.Add(documentoTextBox);
            Controls.Add(documentoLabel);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ClienteDetalle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Cliente";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private TextBox idTextBox;
        private Label documentoLabel;
        private TextBox documentoTextBox;
        private Label nombreLabel;
        private Label apellidoLabel;
        private Label emailLabel;
        private Label telefonoLabel;
        private Label fechaAltaLabel;
        private Label tipoDocumentoLabel;
        private TextBox nombreTextBox;
        private TextBox apellidoTextBox;
        private TextBox emailTextBox;
        private TextBox telefonoTextBox;
        private TextBox fechaAltaTextBox;
        private ComboBox tipoDocumentoComboBox;
        private Button aceptarButton;
        private Button cancelarButton;
        private ErrorProvider errorProvider;
    }
}