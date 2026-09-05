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
            idLabel = new Label();
            marcaLabel = new Label();
            modeloLabel = new Label();
            estadoLabel = new Label();
            categoriaLabel = new Label();
            sucursalLabel = new Label();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(47, 59);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(28, 25);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id";
            idLabel.Click += this.label1_Click;
            // 
            // marcaLabel
            // 
            marcaLabel.AutoSize = true;
            marcaLabel.Location = new Point(47, 117);
            marcaLabel.Name = "marcaLabel";
            marcaLabel.Size = new Size(60, 25);
            marcaLabel.TabIndex = 1;
            marcaLabel.Text = "Marca";
            // 
            // modeloLabel
            // 
            modeloLabel.AutoSize = true;
            modeloLabel.Location = new Point(47, 180);
            modeloLabel.Name = "modeloLabel";
            modeloLabel.Size = new Size(74, 25);
            modeloLabel.TabIndex = 2;
            modeloLabel.Text = "Modelo";
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new Point(47, 298);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new Size(66, 25);
            estadoLabel.TabIndex = 3;
            estadoLabel.Text = "Estado";
            // 
            // categoriaLabel
            // 
            categoriaLabel.AutoSize = true;
            categoriaLabel.Location = new Point(47, 241);
            categoriaLabel.Name = "categoriaLabel";
            categoriaLabel.Size = new Size(88, 25);
            categoriaLabel.TabIndex = 4;
            categoriaLabel.Text = "Categoría";
            // 
            // sucursalLabel
            // 
            sucursalLabel.AutoSize = true;
            sucursalLabel.Location = new Point(47, 352);
            sucursalLabel.Name = "sucursalLabel";
            sucursalLabel.Size = new Size(77, 25);
            sucursalLabel.TabIndex = 5;
            sucursalLabel.Text = "Sucursal";
            // 
            // BicicletaDetalle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 476);
            Controls.Add(sucursalLabel);
            Controls.Add(categoriaLabel);
            Controls.Add(estadoLabel);
            Controls.Add(modeloLabel);
            Controls.Add(marcaLabel);
            Controls.Add(idLabel);
            Name = "BicicletaDetalle";
            Text = "Bicicleta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private Label marcaLabel;
        private Label modeloLabel;
        private Label estadoLabel;
        private Label categoriaLabel;
        private Label sucursalLabel;
    }
}