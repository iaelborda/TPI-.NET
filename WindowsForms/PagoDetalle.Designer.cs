namespace WindowsForms
{
    partial class PagoDetalle
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
            alquilerLabel = new Label();
            montoLabel = new Label();
            fechaPagoLabel = new Label();
            metodoLabel = new Label();
            idTextBox = new TextBox();
            alquilerComboBox = new ComboBox();
            montoTextBox = new TextBox();
            fechaPagoTextBox = new TextBox();
            metodoComboBox = new ComboBox();
            cancelarButton = new Button();
            aceptarButton = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(80, 58);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(22, 20);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id";
            // 
            // alquilerLabel
            // 
            alquilerLabel.AutoSize = true;
            alquilerLabel.Location = new Point(49, 113);
            alquilerLabel.Name = "alquilerLabel";
            alquilerLabel.Size = new Size(61, 20);
            alquilerLabel.TabIndex = 1;
            alquilerLabel.Text = "Alquiler";
            // 
            // montoLabel
            // 
            montoLabel.AutoSize = true;
            montoLabel.Location = new Point(49, 172);
            montoLabel.Name = "montoLabel";
            montoLabel.Size = new Size(53, 20);
            montoLabel.TabIndex = 2;
            montoLabel.Text = "Monto";
            // 
            // fechaPagoLabel
            // 
            fechaPagoLabel.AutoSize = true;
            fechaPagoLabel.Location = new Point(26, 225);
            fechaPagoLabel.Name = "fechaPagoLabel";
            fechaPagoLabel.Size = new Size(84, 20);
            fechaPagoLabel.TabIndex = 3;
            fechaPagoLabel.Text = "Fecha Pago";
            // 
            // metodoLabel
            // 
            metodoLabel.AutoSize = true;
            metodoLabel.Location = new Point(11, 285);
            metodoLabel.Name = "metodoLabel";
            metodoLabel.Size = new Size(99, 20);
            metodoLabel.TabIndex = 4;
            metodoLabel.Text = "Metodo Pago";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(123, 55);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(172, 27);
            idTextBox.TabIndex = 5;
            // 
            // alquilerComboBox
            // 
            alquilerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            alquilerComboBox.FormattingEnabled = true;
            alquilerComboBox.Location = new Point(123, 110);
            alquilerComboBox.Name = "alquilerComboBox";
            alquilerComboBox.Size = new Size(172, 28);
            alquilerComboBox.TabIndex = 6;
            // 
            // montoTextBox
            // 
            montoTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            montoTextBox.Location = new Point(123, 169);
            montoTextBox.Name = "montoTextBox";
            montoTextBox.ReadOnly = true;
            montoTextBox.Size = new Size(172, 27);
            montoTextBox.TabIndex = 7;
            // 
            // fechaPagoTextBox
            // 
            fechaPagoTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fechaPagoTextBox.Location = new Point(123, 222);
            fechaPagoTextBox.Name = "fechaPagoTextBox";
            fechaPagoTextBox.ReadOnly = true;
            fechaPagoTextBox.Size = new Size(172, 27);
            fechaPagoTextBox.TabIndex = 8;
            // 
            // metodoComboBox
            // 
            metodoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            metodoComboBox.FormattingEnabled = true;
            metodoComboBox.Location = new Point(123, 282);
            metodoComboBox.Name = "metodoComboBox";
            metodoComboBox.Size = new Size(172, 28);
            metodoComboBox.TabIndex = 9;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(123, 346);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(94, 29);
            cancelarButton.TabIndex = 10;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(242, 346);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(94, 29);
            aceptarButton.TabIndex = 11;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // PagoDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 387);
            Controls.Add(aceptarButton);
            Controls.Add(cancelarButton);
            Controls.Add(metodoComboBox);
            Controls.Add(fechaPagoTextBox);
            Controls.Add(montoTextBox);
            Controls.Add(alquilerComboBox);
            Controls.Add(idTextBox);
            Controls.Add(metodoLabel);
            Controls.Add(fechaPagoLabel);
            Controls.Add(montoLabel);
            Controls.Add(alquilerLabel);
            Controls.Add(idLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PagoDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Pago";
            Load += PagoDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private Label alquilerLabel;
        private Label montoLabel;
        private Label fechaPagoLabel;
        private Label metodoLabel;
        private TextBox idTextBox;
        private ComboBox alquilerComboBox;
        private TextBox montoTextBox;
        private TextBox fechaPagoTextBox;
        private ComboBox metodoComboBox;
        private Button cancelarButton;
        private Button aceptarButton;
        private ErrorProvider errorProvider;
    }
}