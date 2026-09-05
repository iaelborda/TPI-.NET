namespace WindowsForms
{
    partial class SucursalLista
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
            sucursalesDataGridView = new DataGridView();
            agregarButton = new Button();
            actualizarButton = new Button();
            eliminarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)sucursalesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // sucursalesDataGridView
            // 
            sucursalesDataGridView.AllowUserToAddRows = false;
            sucursalesDataGridView.AllowUserToDeleteRows = false;
            sucursalesDataGridView.AllowUserToOrderColumns = true;
            sucursalesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sucursalesDataGridView.Location = new Point(37, 37);
            sucursalesDataGridView.MultiSelect = false;
            sucursalesDataGridView.Name = "sucursalesDataGridView";
            sucursalesDataGridView.ReadOnly = true;
            sucursalesDataGridView.RowHeadersWidth = 62;
            sucursalesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sucursalesDataGridView.Size = new Size(978, 444);
            sucursalesDataGridView.TabIndex = 0;
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
            // SucursalLista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 566);
            Controls.Add(eliminarButton);
            Controls.Add(actualizarButton);
            Controls.Add(agregarButton);
            Controls.Add(sucursalesDataGridView);
            Name = "SucursalLista";
            Text = "Sucursales";
            Load += Sucursales_Load;
            ((System.ComponentModel.ISupportInitialize)sucursalesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView sucursalesDataGridView;
        private Button agregarButton;
        private Button actualizarButton;
        private Button eliminarButton;
    }
}