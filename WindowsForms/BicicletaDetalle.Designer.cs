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
            components = new System.ComponentModel.Container();
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
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(38, 47);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(22, 20);
            idLabel.TabIndex = 11;
            idLabel.Text = "Id";
            // 
            // idTextBox
            // 
            idTextBox.BackColor = SystemColors.Control;
            idTextBox.Location = new Point(146, 42);
            idTextBox.Margin = new Padding(2, 2, 2, 2);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(121, 27);
            idTextBox.TabIndex = 0;
            idTextBox.TabStop = false;
            // 
            // marcaLabel
            // 
            marcaLabel.AutoSize = true;
            marcaLabel.Location = new Point(38, 94);
            marcaLabel.Margin = new Padding(2, 0, 2, 0);
            marcaLabel.Name = "marcaLabel";
            marcaLabel.Size = new Size(50, 20);
            marcaLabel.TabIndex = 11;
            marcaLabel.Text = "Marca";
            // 
            // categoriaLabel
            // 
            categoriaLabel.AutoSize = true;
            categoriaLabel.Location = new Point(38, 144);
            categoriaLabel.Margin = new Padding(2, 0, 2, 0);
            categoriaLabel.Name = "categoriaLabel";
            categoriaLabel.Size = new Size(74, 20);
            categoriaLabel.TabIndex = 11;
            categoriaLabel.Text = "Categoría";
            // 
            // modeloLabel
            // 
            modeloLabel.AutoSize = true;
            modeloLabel.Location = new Point(38, 197);
            modeloLabel.Margin = new Padding(2, 0, 2, 0);
            modeloLabel.Name = "modeloLabel";
            modeloLabel.Size = new Size(61, 20);
            modeloLabel.TabIndex = 11;
            modeloLabel.Text = "Modelo";
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new Point(38, 245);
            estadoLabel.Margin = new Padding(2, 0, 2, 0);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new Size(54, 20);
            estadoLabel.TabIndex = 11;
            estadoLabel.Text = "Estado";
            // 
            // sucursalLabel
            // 
            sucursalLabel.AutoSize = true;
            sucursalLabel.Location = new Point(38, 292);
            sucursalLabel.Margin = new Padding(2, 0, 2, 0);
            sucursalLabel.Name = "sucursalLabel";
            sucursalLabel.Size = new Size(63, 20);
            sucursalLabel.TabIndex = 11;
            sucursalLabel.Text = "Sucursal";
            // 
            // marcaTextBox
            // 
            marcaTextBox.Location = new Point(146, 89);
            marcaTextBox.Margin = new Padding(2, 2, 2, 2);
            marcaTextBox.Name = "marcaTextBox";
            marcaTextBox.Size = new Size(174, 27);
            marcaTextBox.TabIndex = 0;
            // 
            // categoriaComboBox
            // 
            categoriaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoriaComboBox.FormattingEnabled = true;
            categoriaComboBox.Location = new Point(146, 142);
            categoriaComboBox.Margin = new Padding(2, 2, 2, 2);
            categoriaComboBox.Name = "categoriaComboBox";
            categoriaComboBox.Size = new Size(174, 28);
            categoriaComboBox.TabIndex = 1;
            // 
            // modeloTextBox
            // 
            modeloTextBox.Location = new Point(146, 194);
            modeloTextBox.Margin = new Padding(2, 2, 2, 2);
            modeloTextBox.Name = "modeloTextBox";
            modeloTextBox.Size = new Size(174, 27);
            modeloTextBox.TabIndex = 2;
            // 
            // estadoComboBox
            // 
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(146, 242);
            estadoComboBox.Margin = new Padding(2, 2, 2, 2);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(174, 28);
            estadoComboBox.TabIndex = 3;
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(146, 290);
            sucursalComboBox.Margin = new Padding(2, 2, 2, 2);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(174, 28);
            sucursalComboBox.TabIndex = 4;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(293, 339);
            aceptarButton.Margin = new Padding(2, 2, 2, 2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(90, 27);
            aceptarButton.TabIndex = 5;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(399, 339);
            cancelarButton.Margin = new Padding(2, 2, 2, 2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(90, 27);
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 398);
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
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BicicletaDetalle";
            StartPosition = FormStartPosition.CenterScreen;
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