namespace WindowsForms
{
    partial class SucursalDetalle
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
            nombreLabel = new Label();
            direccionLabel = new Label();
            telefonoLabel = new Label();
            capacidadLabel = new Label();
            nombreTextBox = new TextBox();
            direccionTextBox = new TextBox();
            telefonoTextBox = new TextBox();
            capacidadNumericUpDown = new NumericUpDown();
            aceptarButton = new Button();
            cancelarButton = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)capacidadNumericUpDown).BeginInit();
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
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(47, 117);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(78, 25);
            nombreLabel.TabIndex = 11;
            nombreLabel.Text = "Nombre";
            // 
            // direccionLabel
            // 
            direccionLabel.AutoSize = true;
            direccionLabel.Location = new Point(47, 180);
            direccionLabel.Name = "direccionLabel";
            direccionLabel.Size = new Size(85, 25);
            direccionLabel.TabIndex = 11;
            direccionLabel.Text = "Dirección";
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(47, 246);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(79, 25);
            telefonoLabel.TabIndex = 11;
            telefonoLabel.Text = "Teléfono";
            // 
            // capacidadLabel
            // 
            capacidadLabel.AutoSize = true;
            capacidadLabel.Location = new Point(47, 306);
            capacidadLabel.Name = "capacidadLabel";
            capacidadLabel.Size = new Size(95, 25);
            capacidadLabel.TabIndex = 11;
            capacidadLabel.Text = "Capacidad";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(182, 111);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(150, 31);
            nombreTextBox.TabIndex = 0;
            // 
            // direccionTextBox
            // 
            direccionTextBox.Location = new Point(182, 177);
            direccionTextBox.Name = "direccionTextBox";
            direccionTextBox.Size = new Size(217, 31);
            direccionTextBox.TabIndex = 0;
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Location = new Point(182, 243);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(217, 31);
            telefonoTextBox.TabIndex = 0;
            // 
            // capacidadNumericUpDown
            // 
            capacidadNumericUpDown.Location = new Point(182, 304);
            capacidadNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            capacidadNumericUpDown.Name = "capacidadNumericUpDown";
            capacidadNumericUpDown.Size = new Size(150, 31);
            capacidadNumericUpDown.TabIndex = 0;
            capacidadNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(366, 401);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(112, 34);
            aceptarButton.TabIndex = 2;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(499, 401);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(112, 34);
            cancelarButton.TabIndex = 2;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // SucursalDetalle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 476);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(capacidadNumericUpDown);
            Controls.Add(telefonoTextBox);
            Controls.Add(direccionTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(capacidadLabel);
            Controls.Add(telefonoLabel);
            Controls.Add(direccionLabel);
            Controls.Add(nombreLabel);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            Name = "SucursalDetalle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sucursal";
            ((System.ComponentModel.ISupportInitialize)capacidadNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private TextBox idTextBox;
        private Label nombreLabel;
        private Label direccionLabel;
        private ErrorProvider errorProvider;
        private Label telefonoLabel;
        private Label capacidadLabel;
        private TextBox nombreTextBox;
        private TextBox direccionTextBox;
        private TextBox telefonoTextBox;
        private NumericUpDown capacidadNumericUpDown;
        private Button aceptarButton;
        private Button cancelarButton;
    }
}