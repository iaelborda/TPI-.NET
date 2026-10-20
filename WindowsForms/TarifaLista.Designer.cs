namespace WindowsForms
{
    partial class TarifaLista
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
            tarifasDataGridView = new DataGridView();
            agregarButton = new Button();
            actualizarButton = new Button();
            eliminarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)tarifasDataGridView).BeginInit();
            SuspendLayout();
            // 
            // tarifasDataGridView
            // 
            tarifasDataGridView.AllowUserToAddRows = false;
            tarifasDataGridView.AllowUserToDeleteRows = false;
            tarifasDataGridView.AllowUserToOrderColumns = true;
            tarifasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tarifasDataGridView.Location = new Point(12, 60);
            tarifasDataGridView.MultiSelect = false;
            tarifasDataGridView.Name = "tarifasDataGridView";
            tarifasDataGridView.ReadOnly = true;
            tarifasDataGridView.RowHeadersWidth = 62;
            tarifasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tarifasDataGridView.Size = new Size(776, 319);
            tarifasDataGridView.TabIndex = 0;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(676, 394);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(112, 34);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // actualizarButton
            // 
            actualizarButton.Location = new Point(541, 394);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(112, 34);
            actualizarButton.TabIndex = 2;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(401, 394);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(112, 34);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // TarifaLista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(eliminarButton);
            Controls.Add(actualizarButton);
            Controls.Add(agregarButton);
            Controls.Add(tarifasDataGridView);
            Name = "TarifaLista";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tarifas";
            Load += Tarifas_Load;
            ((System.ComponentModel.ISupportInitialize)tarifasDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tarifasDataGridView;
        private Button agregarButton;
        private Button actualizarButton;
        private Button eliminarButton;
    }
}