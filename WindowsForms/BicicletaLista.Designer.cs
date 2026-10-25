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
            generarReporteButton = new Button();
            categoriaComboBox = new ComboBox();
            sucursalComboBox = new ComboBox();
            estadoComboBox = new ComboBox();
            limpiarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)bicicletasDataGridView).BeginInit();
            SuspendLayout();
            // 
            // bicicletasDataGridView
            // 
            bicicletasDataGridView.AllowUserToAddRows = false;
            bicicletasDataGridView.AllowUserToDeleteRows = false;
            bicicletasDataGridView.AllowUserToOrderColumns = true;
            bicicletasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bicicletasDataGridView.Location = new Point(30, 70);
            bicicletasDataGridView.Margin = new Padding(2);
            bicicletasDataGridView.MultiSelect = false;
            bicicletasDataGridView.Name = "bicicletasDataGridView";
            bicicletasDataGridView.ReadOnly = true;
            bicicletasDataGridView.RowHeadersWidth = 62;
            bicicletasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bicicletasDataGridView.Size = new Size(936, 314);
            bicicletasDataGridView.TabIndex = 0;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(895, 403);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(90, 27);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // actualizarButton
            // 
            actualizarButton.Location = new Point(792, 403);
            actualizarButton.Margin = new Padding(2);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(90, 27);
            actualizarButton.TabIndex = 2;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(686, 403);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(90, 27);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(30, 28);
            buscarTextBox.Margin = new Padding(2);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.PlaceholderText = "Buscar por marca, categoría o estado...";
            buscarTextBox.Size = new Size(256, 27);
            buscarTextBox.TabIndex = 4;
            buscarTextBox.Text = "Buscar por marca o modelo...";
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(895, 28);
            buscarButton.Margin = new Padding(2);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(90, 27);
            buscarButton.TabIndex = 5;
            buscarButton.Text = "FIltrar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // generarReporteButton
            // 
            generarReporteButton.BackColor = Color.YellowGreen;
            generarReporteButton.Location = new Point(30, 403);
            generarReporteButton.Margin = new Padding(2);
            generarReporteButton.Name = "generarReporteButton";
            generarReporteButton.Size = new Size(139, 27);
            generarReporteButton.TabIndex = 13;
            generarReporteButton.Text = "Generar Reporte";
            generarReporteButton.UseVisualStyleBackColor = false;
            generarReporteButton.Click += generarReporteButton_Click;
            // 
            // categoriaComboBox
            // 
            categoriaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoriaComboBox.FormattingEnabled = true;
            categoriaComboBox.Location = new Point(311, 27);
            categoriaComboBox.Name = "categoriaComboBox";
            categoriaComboBox.Size = new Size(151, 28);
            categoriaComboBox.TabIndex = 14;
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(468, 27);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(151, 28);
            sucursalComboBox.TabIndex = 15;
            // 
            // estadoComboBox
            // 
            estadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Location = new Point(625, 27);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(151, 28);
            estadoComboBox.TabIndex = 16;
            // 
            // limpiarButton
            // 
            limpiarButton.Location = new Point(792, 28);
            limpiarButton.Margin = new Padding(2);
            limpiarButton.Name = "limpiarButton";
            limpiarButton.Size = new Size(90, 27);
            limpiarButton.TabIndex = 17;
            limpiarButton.Text = "Limpiar";
            limpiarButton.UseVisualStyleBackColor = true;
            limpiarButton.Click += limpiarButton_Click;
            // 
            // BicicletaLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 453);
            Controls.Add(limpiarButton);
            Controls.Add(estadoComboBox);
            Controls.Add(sucursalComboBox);
            Controls.Add(categoriaComboBox);
            Controls.Add(generarReporteButton);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Controls.Add(agregarButton);
            Controls.Add(eliminarButton);
            Controls.Add(actualizarButton);
            Controls.Add(bicicletasDataGridView);
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BicicletaLista";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button generarReporteButton;
        private ComboBox categoriaComboBox;
        private ComboBox sucursalComboBox;
        private ComboBox estadoComboBox;
        private Button limpiarButton;
    }
}