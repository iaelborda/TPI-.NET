namespace WindowsForms
{
    partial class EmpleadoLista
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
            empleadosDataGridView = new DataGridView();
            agregarButton = new Button();
            actualizarButton = new Button();
            eliminarButton = new Button();
            buscarTextBox = new TextBox();
            buscarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)empleadosDataGridView).BeginInit();
            SuspendLayout();
            // 
            // empleadosDataGridView
            // 
            empleadosDataGridView.AllowUserToAddRows = false;
            empleadosDataGridView.AllowUserToDeleteRows = false;
            empleadosDataGridView.AllowUserToOrderColumns = true;
            empleadosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            empleadosDataGridView.Location = new Point(26, 62);
            empleadosDataGridView.Margin = new Padding(2);
            empleadosDataGridView.MultiSelect = false;
            empleadosDataGridView.Name = "empleadosDataGridView";
            empleadosDataGridView.ReadOnly = true;
            empleadosDataGridView.RowHeadersWidth = 82;
            empleadosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            empleadosDataGridView.Size = new Size(858, 325);
            empleadosDataGridView.TabIndex = 4;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(790, 401);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(92, 29);
            agregarButton.TabIndex = 5;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // actualizarButton
            // 
            actualizarButton.Location = new Point(684, 401);
            actualizarButton.Margin = new Padding(2);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(92, 29);
            actualizarButton.TabIndex = 6;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(578, 401);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(92, 29);
            eliminarButton.TabIndex = 7;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(24, 24);
            buscarTextBox.Margin = new Padding(2);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.PlaceholderText = "Buscar por nombre, apellido o email...";
            buscarTextBox.Size = new Size(248, 27);
            buscarTextBox.TabIndex = 8;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(277, 24);
            buscarButton.Margin = new Padding(2);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(74, 27);
            buscarButton.TabIndex = 9;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            // 
            // EmpleadoLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 448);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Controls.Add(eliminarButton);
            Controls.Add(actualizarButton);
            Controls.Add(agregarButton);
            Controls.Add(empleadosDataGridView);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmpleadoLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empleados";
            Load += EmpleadoLista_Load;
            ((System.ComponentModel.ISupportInitialize)empleadosDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView empleadosDataGridView;
        private Button agregarButton;
        private Button actualizarButton;
        private Button eliminarButton;
        private TextBox buscarTextBox;
        private Button buscarButton;
    }
}