namespace WindowsForms
{
    partial class BicicletaLista
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
            bicicletasDataGridView = new DataGridView();
            agregarButton = new Button();
            actualizarButton = new Button();
            eliminarButton = new Button();
            buscarTextBox = new TextBox();
            buscarButton = new Button();

            ((System.ComponentModel.ISupportInitialize)bicicletasDataGridView).BeginInit();
            SuspendLayout();

            // 
            // bicicletasDataGridView
            // 
            bicicletasDataGridView.AllowUserToAddRows = false;
            bicicletasDataGridView.AllowUserToDeleteRows = false;
            bicicletasDataGridView.AllowUserToOrderColumns = true;
            bicicletasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bicicletasDataGridView.Location = new Point(37, 88);
            bicicletasDataGridView.MultiSelect = false;
            bicicletasDataGridView.Name = "bicicletasDataGridView";
            bicicletasDataGridView.ReadOnly = true;
            bicicletasDataGridView.RowHeadersWidth = 62;
            bicicletasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bicicletasDataGridView.Size = new Size(978, 393);
            bicicletasDataGridView.TabIndex = 0;

            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(903, 504);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(112, 34);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;

            // 
            // actualizarButton
            // 
            actualizarButton.Location = new Point(774, 504);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(112, 34);
            actualizarButton.TabIndex = 2;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;

            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(641, 504);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(112, 34);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;

            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(37, 35);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.PlaceholderText = "Buscar por marca, categoría o estado...";
            buscarTextBox.Size = new Size(319, 31);
            buscarTextBox.TabIndex = 4;

            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(362, 35);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(112, 34);
            buscarButton.TabIndex = 5;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;

            // 
            // BicicletaLista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 566);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Controls.Add(agregarButton);
            Controls.Add(eliminarButton);
            Controls.Add(actualizarButton);
            Controls.Add(bicicletasDataGridView);
            Name = "BicicletaLista";
            Text = "Bicicletas";
            Load += Bicicletas_Load;

            ((System.ComponentModel.ISupportInitialize)bicicletasDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView bicicletasDataGridView;
        private Button agregarButton;
        private Button actualizarButton;
        private Button eliminarButton;
        private TextBox buscarTextBox;
        private Button buscarButton;
    }
}