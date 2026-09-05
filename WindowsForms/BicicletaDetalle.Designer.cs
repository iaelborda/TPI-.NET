namespace WindowsForms
{
    partial class BicicletaDetalle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.
        /// </param>
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
            idLabel = new Label();
            idTextBox = new TextBox();
            marcaLabel = new Label();
            categoriaLabel = new Label();
            modeloLabel = new Label();
            estadoLabel = new Label();
            sucursalLabel = new Label();
            marcaTextBox = new TextBox();
            categoriaComboBox = new ComboBox();
            modeloTextBox = new TextBox();
            estadoComboBox = new ComboBox();
            sucursalComboBox = new ComboBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            errorProvider = new ErrorProvider();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(47, 59);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(28, 25);
            idLabel.TabIndex = 11;
            idLabel.Text = "Id";
            // 
            // idTextBox
            // 
            idTextBox.BackColor = SystemColors.Control;
            idTextBox.Location = new Point(182, 53);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(150, 31);
            idTextBox.TabIndex = 0;
            idTextBox.TabStop = false;
            // 
            // marcaLabel
            // 
            marcaLabel.AutoSize = true;
            marcaLabel.Location = new Point(47, 117);
            marcaLabel.Name = "marcaLabel";
            marcaLabel.Size = new Size(60, 25);
            marcaLabel.TabIndex = 11;
            marcaLabel.Text = "Marca";
            // 
            // categoriaLabel
            // 
            categoriaLabel.AutoSize = true;
            categoriaLabel.Location = new Point(47, 180);
            categoriaLabel.Name = "categoriaLabel";
            categoriaLabel.Size = new Size(88, 25);
            categoriaLabel.TabIndex = 11;
            categoriaLabel.Text = "Categoría";
            // 
            // modeloLabel
            // 
            modeloLabel.AutoSize = true;
            modeloLabel.Location = new Point(47, 246);
            modeloLabel.Name = "modeloLabel";
            modeloLabel.Size = new Size(74, 25);
            modeloLabel.TabIndex = 11;
            modeloLabel.Text = "Modelo";
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new Point(47, 306);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new Size(66, 25);
            estadoLabel.TabIndex = 11;
            estadoLabel.Text = "Estado";
            // 
            // sucursalLabel
            // 
            sucursalLabel.AutoSize = true;
            sucursalLabel.Location = new Point(47, 365);
            sucursalLabel.Name = "sucursalLabel";
            sucursalLabel.Size = new Size(77, 25);
            sucursalLabel.TabIndex = 11;
            sucursalLabel.Text = "Sucursal";
            // 
            // marcaTextBox
            // 
            marcaTextBox.Location = new Point(182, 111);
            marcaTextBox.Name = "marcaTextBox";
            marcaTextBox.Size = new Size(217, 31);
            marcaTextBox.TabIndex = 0;
            // 
            // categoriaComboBox
            // 
            categoriaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoriaComboBox.FormattingEnabled = true;
            categoriaComboBox.Location = new Point(182, 177);
            categoriaComboBox.Name = "categoriaComboBox";
            categoriaComboBox.Size = new Size(217, 33);
            categoriaComboBox.TabIndex = 1;
            // 
            // modeloTextBox
            // 
            modeloTextBox.Location = new Point(182, 243);
            modeloTextBox.Name = "modeloTextBox";
            modeloTextBox.Size = new Size(217, 31);
            modeloTextBox.TabIndex = 2;
            // 
            // estadoComboBox
            // 
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(182, 303);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(217, 33);
            estadoComboBox.TabIndex = 3;
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(182, 362);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(217, 33);
            sucursalComboBox.TabIndex = 4;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(366, 424);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(112, 34);
            aceptarButton.TabIndex = 5;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(499, 424);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(112, 34);
            cancelarButton.TabIndex = 6;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // BicicletaDetalle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 497);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(sucursalComboBox);
            Controls.Add(estadoComboBox);
            Controls.Add(modeloTextBox);
            Controls.Add(categoriaComboBox);
            Controls.Add(marcaTextBox);
            Controls.Add(idTextBox);
            Controls.Add(sucursalLabel);
            Controls.Add(estadoLabel);
            Controls.Add(modeloLabel);
            Controls.Add(categoriaLabel);
            Controls.Add(marcaLabel);
            Controls.Add(idLabel);
            Name = "BicicletaDetalle";
            Text = "Bicicleta";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private TextBox idTextBox;
        private Label marcaLabel;
        private Label categoriaLabel;
        private Label modeloLabel;
        private Label estadoLabel;
        private Label sucursalLabel;
        private TextBox marcaTextBox;
        private ComboBox categoriaComboBox;
        private TextBox modeloTextBox;
        private ComboBox estadoComboBox;
        private ComboBox sucursalComboBox;
        private Button aceptarButton;
        private Button cancelarButton;
        private ErrorProvider errorProvider;
    }
}