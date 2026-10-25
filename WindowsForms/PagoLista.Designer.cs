namespace WindowsForms
{
    partial class PagoLista
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
            pagosDataGridView = new DataGridView();
            agregarButton = new Button();
            actualizarButton = new Button();
            eliminarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pagosDataGridView).BeginInit();
            SuspendLayout();
            // 
            // pagosDataGridView
            // 
            pagosDataGridView.AllowUserToAddRows = false;
            pagosDataGridView.AllowUserToDeleteRows = false;
            pagosDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pagosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pagosDataGridView.Location = new Point(30, 30);
            pagosDataGridView.MultiSelect = false;
            pagosDataGridView.Name = "pagosDataGridView";
            pagosDataGridView.ReadOnly = true;
            pagosDataGridView.RowHeadersWidth = 51;
            pagosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pagosDataGridView.Size = new Size(782, 355);
            pagosDataGridView.TabIndex = 0;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(739, 412);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(94, 29);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Registrar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // actualizarButton
            // 
            actualizarButton.Location = new Point(630, 412);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(94, 29);
            actualizarButton.TabIndex = 2;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(521, 412);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Anular";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // PagoLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 453);
            Controls.Add(eliminarButton);
            Controls.Add(actualizarButton);
            Controls.Add(agregarButton);
            Controls.Add(pagosDataGridView);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PagoLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagos";
            Load += PagoLista_Load;
            ((System.ComponentModel.ISupportInitialize)pagosDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView pagosDataGridView;
        private Button agregarButton;
        private Button actualizarButton;
        private Button eliminarButton;
    }
}