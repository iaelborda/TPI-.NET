namespace WindowsForms
{
    partial class CategoriaDetalle
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
            idTextBox = new TextBox();
            idLabel = new Label();
            descripcionTextBox = new TextBox();
            descripcionLabel = new Label();
            aceptarButton = new Button();
            cancelarButton = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idTextBox
            // 
            idTextBox.BackColor = Color.LightGray;
            idTextBox.Location = new Point(129, 112);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(188, 27);
            idTextBox.TabIndex = 0;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(76, 115);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 20);
            idLabel.TabIndex = 1;
            idLabel.Text = "ID";
            // 
            // descripcionTextBox
            // 
            descripcionTextBox.Location = new Point(129, 181);
            descripcionTextBox.Name = "descripcionTextBox";
            descripcionTextBox.Size = new Size(188, 27);
            descripcionTextBox.TabIndex = 2;
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(16, 184);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(87, 20);
            descripcionLabel.TabIndex = 3;
            descripcionLabel.Text = "Descripcion";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(121, 347);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(94, 29);
            aceptarButton.TabIndex = 4;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(237, 347);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(94, 29);
            cancelarButton.TabIndex = 5;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // CategoriaDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 388);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(descripcionLabel);
            Controls.Add(descripcionTextBox);
            Controls.Add(idLabel);
            Controls.Add(idTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoriaDetalle";
            Text = "Detalle de Categoria";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextBox;
        private Label idLabel;
        private TextBox descripcionTextBox;
        private Label descripcionLabel;
        private Button aceptarButton;
        private Button cancelarButton;
        private ErrorProvider errorProvider;
    }
}