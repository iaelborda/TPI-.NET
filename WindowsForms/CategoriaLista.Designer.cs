namespace WindowsForms
{
    partial class CategoriaLista
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
            categoriasDataGridView = new DataGridView();
            buscarTextBox = new TextBox();
            buscarButton = new Button();
            eliminarButton = new Button();
            actualizarButton = new Button();
            agregarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)categoriasDataGridView).BeginInit();
            SuspendLayout();
            // 
            // categoriasDataGridView
            // 
            categoriasDataGridView.AllowUserToAddRows = false;
            categoriasDataGridView.AllowUserToDeleteRows = false;
            categoriasDataGridView.AllowUserToOrderColumns = true;
            categoriasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            categoriasDataGridView.Location = new Point(24, 56);
            categoriasDataGridView.Margin = new Padding(2);
            categoriasDataGridView.MultiSelect = false;
            categoriasDataGridView.Name = "categoriasDataGridView";
            categoriasDataGridView.ReadOnly = true;
            categoriasDataGridView.RowHeadersWidth = 82;
            categoriasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            categoriasDataGridView.Size = new Size(858, 325);
            categoriasDataGridView.TabIndex = 0;
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(24, 24);
            buscarTextBox.Margin = new Padding(2);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.PlaceholderText = "Buscar por descripcion";
            buscarTextBox.Size = new Size(248, 27);
            buscarTextBox.TabIndex = 4;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(277, 24);
            buscarButton.Margin = new Padding(2);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(74, 27);
            buscarButton.TabIndex = 5;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(578, 401);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(92, 29);
            eliminarButton.TabIndex = 2;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // actualizarButton
            // 
            actualizarButton.Location = new Point(684, 401);
            actualizarButton.Margin = new Padding(2);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(92, 29);
            actualizarButton.TabIndex = 7;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(790, 401);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(92, 29);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // CategoriaLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 448);
            Controls.Add(agregarButton);
            Controls.Add(actualizarButton);
            Controls.Add(eliminarButton);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Controls.Add(categoriasDataGridView);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoriaLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categorias";
            Load += CategoriaLista_Load;
            ((System.ComponentModel.ISupportInitialize)categoriasDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView categoriasDataGridView;
        private TextBox buscarTextBox;
        private Button buscarButton;
        private Button eliminarButton;
        private Button actualizarButton;
        private Button agregarButton;
    }
}