namespace WindowsForms
{
    partial class AlquilerLista
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
            alquileresDataGridView = new DataGridView();
            eliminarButton = new Button();
            actualizarButton = new Button();
            agregarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)alquileresDataGridView).BeginInit();
            SuspendLayout();
            // 
            // alquileresDataGridView
            // 
            alquileresDataGridView.AllowUserToAddRows = false;
            alquileresDataGridView.AllowUserToDeleteRows = false;
            alquileresDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            alquileresDataGridView.Location = new Point(30, 34);
            alquileresDataGridView.Margin = new Padding(2);
            alquileresDataGridView.MultiSelect = false;
            alquileresDataGridView.Name = "alquileresDataGridView";
            alquileresDataGridView.ReadOnly = true;
            alquileresDataGridView.RowHeadersWidth = 82;
            alquileresDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            alquileresDataGridView.Size = new Size(1073, 405);
            alquileresDataGridView.TabIndex = 0;
            // 
            // eliminarButton
            // 
            eliminarButton.Enabled = false;
            eliminarButton.Location = new Point(723, 472);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(115, 36);
            eliminarButton.TabIndex = 2;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // actualizarButton
            // 
            actualizarButton.Enabled = false;
            actualizarButton.Location = new Point(855, 472);
            actualizarButton.Margin = new Padding(2);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(115, 36);
            actualizarButton.TabIndex = 3;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(988, 472);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(115, 36);
            agregarButton.TabIndex = 3;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // AlquilerLista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 534);
            Controls.Add(agregarButton);
            Controls.Add(actualizarButton);
            Controls.Add(eliminarButton);
            Controls.Add(alquileresDataGridView);
            Name = "AlquilerLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alquileres";
            Load += Alquileres_Load;
            ((System.ComponentModel.ISupportInitialize)alquileresDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView alquileresDataGridView;
        private Button eliminarButton;
        private Button actualizarButton;
        private Button agregarButton;
    }
}