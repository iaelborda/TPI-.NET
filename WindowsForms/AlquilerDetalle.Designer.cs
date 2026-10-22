namespace WindowsForms
{
    partial class AlquilerDetalle
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
            idLabel = new Label();
            clienteLabel = new Label();
            empleadoLabel = new Label();
            fechaAlquilerLabel = new Label();
            bicicletasLabel = new Label();
            totalBicicletasLabel = new Label();
            totalPrecioLabel = new Label();
            detallesDataGridView = new DataGridView();
            agregarButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            aceptarButton = new Button();
            cancelarButton = new Button();
            idTextBox = new TextBox();
            clienteComboBox = new ComboBox();
            empleadoComboBox = new ComboBox();
            fechaAlquilerTextBox = new TextBox();
            errorProvider = new ErrorProvider(components);
            cancelarAlquilerButton = new Button();
            finalizarAlquilerButton = new Button();
            sucursalLabel = new Label();
            sucursalComboBox = new ComboBox();
            devolverBicicletaButton = new Button();
            ((System.ComponentModel.ISupportInitialize)detallesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(43, 48);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(22, 20);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id";
            // 
            // clienteLabel
            // 
            clienteLabel.AutoSize = true;
            clienteLabel.Location = new Point(43, 99);
            clienteLabel.Margin = new Padding(2, 0, 2, 0);
            clienteLabel.Name = "clienteLabel";
            clienteLabel.Size = new Size(55, 20);
            clienteLabel.TabIndex = 1;
            clienteLabel.Text = "Cliente";
            // 
            // empleadoLabel
            // 
            empleadoLabel.AutoSize = true;
            empleadoLabel.Location = new Point(388, 99);
            empleadoLabel.Margin = new Padding(2, 0, 2, 0);
            empleadoLabel.Name = "empleadoLabel";
            empleadoLabel.Size = new Size(77, 20);
            empleadoLabel.TabIndex = 2;
            empleadoLabel.Text = "Empleado";
            // 
            // fechaAlquilerLabel
            // 
            fechaAlquilerLabel.AutoSize = true;
            fechaAlquilerLabel.Location = new Point(43, 146);
            fechaAlquilerLabel.Margin = new Padding(2, 0, 2, 0);
            fechaAlquilerLabel.Name = "fechaAlquilerLabel";
            fechaAlquilerLabel.Size = new Size(103, 20);
            fechaAlquilerLabel.TabIndex = 3;
            fechaAlquilerLabel.Text = "Fecha Alquiler";
            // 
            // bicicletasLabel
            // 
            bicicletasLabel.AutoSize = true;
            bicicletasLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bicicletasLabel.Location = new Point(43, 193);
            bicicletasLabel.Margin = new Padding(2, 0, 2, 0);
            bicicletasLabel.Name = "bicicletasLabel";
            bicicletasLabel.Size = new Size(74, 20);
            bicicletasLabel.TabIndex = 4;
            bicicletasLabel.Text = "Bicicletas";
            // 
            // totalBicicletasLabel
            // 
            totalBicicletasLabel.AutoSize = true;
            totalBicicletasLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            totalBicicletasLabel.Location = new Point(43, 535);
            totalBicicletasLabel.Margin = new Padding(2, 0, 2, 0);
            totalBicicletasLabel.Name = "totalBicicletasLabel";
            totalBicicletasLabel.Size = new Size(117, 20);
            totalBicicletasLabel.TabIndex = 5;
            totalBicicletasLabel.Text = "Total Bicicletas:";
            // 
            // totalPrecioLabel
            // 
            totalPrecioLabel.AutoSize = true;
            totalPrecioLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            totalPrecioLabel.Location = new Point(43, 566);
            totalPrecioLabel.Margin = new Padding(2, 0, 2, 0);
            totalPrecioLabel.Name = "totalPrecioLabel";
            totalPrecioLabel.Size = new Size(95, 20);
            totalPrecioLabel.TabIndex = 7;
            totalPrecioLabel.Text = "Total Precio:";
            // 
            // detallesDataGridView
            // 
            detallesDataGridView.AllowUserToAddRows = false;
            detallesDataGridView.AllowUserToDeleteRows = false;
            detallesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            detallesDataGridView.Location = new Point(43, 228);
            detallesDataGridView.Margin = new Padding(2);
            detallesDataGridView.MultiSelect = false;
            detallesDataGridView.Name = "detallesDataGridView";
            detallesDataGridView.ReadOnly = true;
            detallesDataGridView.RowHeadersWidth = 62;
            detallesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            detallesDataGridView.Size = new Size(661, 295);
            detallesDataGridView.TabIndex = 0;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(345, 529);
            agregarButton.Margin = new Padding(4);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(114, 26);
            agregarButton.TabIndex = 9;
            agregarButton.Text = "&Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(467, 529);
            modificarButton.Margin = new Padding(4);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(114, 26);
            modificarButton.TabIndex = 10;
            modificarButton.Text = "&Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(590, 529);
            eliminarButton.Margin = new Padding(4);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(114, 26);
            eliminarButton.TabIndex = 11;
            eliminarButton.Text = "&Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(502, 592);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(92, 40);
            aceptarButton.TabIndex = 12;
            aceptarButton.Text = "&Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(612, 592);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(92, 40);
            cancelarButton.TabIndex = 13;
            cancelarButton.Text = "&Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(146, 48);
            idTextBox.Margin = new Padding(2);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(121, 27);
            idTextBox.TabIndex = 14;
            // 
            // clienteComboBox
            // 
            clienteComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            clienteComboBox.FormattingEnabled = true;
            clienteComboBox.Location = new Point(146, 97);
            clienteComboBox.Margin = new Padding(2);
            clienteComboBox.Name = "clienteComboBox";
            clienteComboBox.Size = new Size(238, 28);
            clienteComboBox.TabIndex = 15;
            // 
            // empleadoComboBox
            // 
            empleadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            empleadoComboBox.FormattingEnabled = true;
            empleadoComboBox.Location = new Point(466, 97);
            empleadoComboBox.Margin = new Padding(2);
            empleadoComboBox.Name = "empleadoComboBox";
            empleadoComboBox.Size = new Size(238, 28);
            empleadoComboBox.TabIndex = 16;
            // 
            // fechaAlquilerTextBox
            // 
            fechaAlquilerTextBox.Location = new Point(146, 144);
            fechaAlquilerTextBox.Margin = new Padding(2);
            fechaAlquilerTextBox.Name = "fechaAlquilerTextBox";
            fechaAlquilerTextBox.ReadOnly = true;
            fechaAlquilerTextBox.Size = new Size(214, 27);
            fechaAlquilerTextBox.TabIndex = 17;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // cancelarAlquilerButton
            // 
            cancelarAlquilerButton.BackColor = Color.IndianRed;
            cancelarAlquilerButton.Location = new Point(204, 592);
            cancelarAlquilerButton.Margin = new Padding(2);
            cancelarAlquilerButton.Name = "cancelarAlquilerButton";
            cancelarAlquilerButton.Size = new Size(136, 40);
            cancelarAlquilerButton.TabIndex = 18;
            cancelarAlquilerButton.Text = "Cancelar Alquiler";
            cancelarAlquilerButton.UseVisualStyleBackColor = false;
            cancelarAlquilerButton.Click += cancelarAlquilerButton_Click;
            // 
            // finalizarAlquilerButton
            // 
            finalizarAlquilerButton.BackColor = Color.YellowGreen;
            finalizarAlquilerButton.Location = new Point(356, 592);
            finalizarAlquilerButton.Margin = new Padding(2);
            finalizarAlquilerButton.Name = "finalizarAlquilerButton";
            finalizarAlquilerButton.Size = new Size(129, 40);
            finalizarAlquilerButton.TabIndex = 19;
            finalizarAlquilerButton.Text = "Finalizar Alquiler";
            finalizarAlquilerButton.UseVisualStyleBackColor = false;
            finalizarAlquilerButton.Click += finalizarAlquilerButton_Click;
            // 
            // sucursalLabel
            // 
            sucursalLabel.AutoSize = true;
            sucursalLabel.Location = new Point(396, 51);
            sucursalLabel.Name = "sucursalLabel";
            sucursalLabel.Size = new Size(63, 20);
            sucursalLabel.TabIndex = 20;
            sucursalLabel.Text = "Sucursal";
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(466, 48);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(238, 28);
            sucursalComboBox.TabIndex = 21;
            sucursalComboBox.SelectedIndexChanged += sucursalComboBox_SelectedIndexChanged;
            // 
            // devolverBicicletaButton
            // 
            devolverBicicletaButton.Location = new Point(223, 529);
            devolverBicicletaButton.Margin = new Padding(4);
            devolverBicicletaButton.Name = "devolverBicicletaButton";
            devolverBicicletaButton.Size = new Size(114, 26);
            devolverBicicletaButton.TabIndex = 22;
            devolverBicicletaButton.Text = "&Devolver";
            devolverBicicletaButton.UseVisualStyleBackColor = true;
            devolverBicicletaButton.Click += devolverBicicletaButton_Click;
            // 
            // AlquilerDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 650);
            Controls.Add(devolverBicicletaButton);
            Controls.Add(sucursalComboBox);
            Controls.Add(sucursalLabel);
            Controls.Add(finalizarAlquilerButton);
            Controls.Add(cancelarAlquilerButton);
            Controls.Add(fechaAlquilerTextBox);
            Controls.Add(empleadoComboBox);
            Controls.Add(clienteComboBox);
            Controls.Add(idTextBox);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(eliminarButton);
            Controls.Add(modificarButton);
            Controls.Add(agregarButton);
            Controls.Add(detallesDataGridView);
            Controls.Add(totalPrecioLabel);
            Controls.Add(totalBicicletasLabel);
            Controls.Add(bicicletasLabel);
            Controls.Add(fechaAlquilerLabel);
            Controls.Add(empleadoLabel);
            Controls.Add(clienteLabel);
            Controls.Add(idLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AlquilerDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alquiler - Detalle";
            ((System.ComponentModel.ISupportInitialize)detallesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private Label clienteLabel;
        private Label empleadoLabel;
        private Label fechaAlquilerLabel;
        private Label bicicletasLabel;
        private Label totalBicicletasLabel;
        private Label totalPrecioLabel;
        private DataGridView detallesDataGridView;
        private Button agregarButton;
        private Button modificarButton;
        private Button eliminarButton;
        private Button aceptarButton;
        private Button cancelarButton;
        private TextBox idTextBox;
        private ComboBox clienteComboBox;
        private ComboBox empleadoComboBox;
        private TextBox fechaAlquilerTextBox;
        private ErrorProvider errorProvider;
        private Button cancelarAlquilerButton;
        private Button finalizarAlquilerButton;
        private ComboBox sucursalComboBox;
        private Label sucursalLabel;
        private Button devolverBicicletaButton;
    }
}