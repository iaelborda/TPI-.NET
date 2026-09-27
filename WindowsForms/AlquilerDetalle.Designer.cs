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
            ((System.ComponentModel.ISupportInitialize)detallesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(54, 60);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(28, 25);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id";
            // 
            // clienteLabel
            // 
            clienteLabel.AutoSize = true;
            clienteLabel.Location = new Point(54, 124);
            clienteLabel.Name = "clienteLabel";
            clienteLabel.Size = new Size(65, 25);
            clienteLabel.TabIndex = 1;
            clienteLabel.Text = "Cliente";
            // 
            // empleadoLabel
            // 
            empleadoLabel.AutoSize = true;
            empleadoLabel.Location = new Point(485, 124);
            empleadoLabel.Name = "empleadoLabel";
            empleadoLabel.Size = new Size(92, 25);
            empleadoLabel.TabIndex = 2;
            empleadoLabel.Text = "Empleado";
            // 
            // fechaAlquilerLabel
            // 
            fechaAlquilerLabel.AutoSize = true;
            fechaAlquilerLabel.Location = new Point(54, 183);
            fechaAlquilerLabel.Name = "fechaAlquilerLabel";
            fechaAlquilerLabel.Size = new Size(122, 25);
            fechaAlquilerLabel.TabIndex = 3;
            fechaAlquilerLabel.Text = "Fecha Alquiler";
            // 
            // bicicletasLabel
            // 
            bicicletasLabel.AutoSize = true;
            bicicletasLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bicicletasLabel.Location = new Point(54, 241);
            bicicletasLabel.Name = "bicicletasLabel";
            bicicletasLabel.Size = new Size(92, 25);
            bicicletasLabel.TabIndex = 4;
            bicicletasLabel.Text = "Bicicletas";
            // 
            // totalBicicletasLabel
            // 
            totalBicicletasLabel.AutoSize = true;
            totalBicicletasLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            totalBicicletasLabel.Location = new Point(54, 669);
            totalBicicletasLabel.Name = "totalBicicletasLabel";
            totalBicicletasLabel.Size = new Size(144, 25);
            totalBicicletasLabel.TabIndex = 5;
            totalBicicletasLabel.Text = "Total Bicicletas:";
            // 
            // totalPrecioLabel
            // 
            totalPrecioLabel.AutoSize = true;
            totalPrecioLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            totalPrecioLabel.Location = new Point(54, 707);
            totalPrecioLabel.Name = "totalPrecioLabel";
            totalPrecioLabel.Size = new Size(117, 25);
            totalPrecioLabel.TabIndex = 7;
            totalPrecioLabel.Text = "Total Precio:";
            // 
            // detallesDataGridView
            // 
            detallesDataGridView.AllowUserToAddRows = false;
            detallesDataGridView.AllowUserToDeleteRows = false;
            detallesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            detallesDataGridView.Location = new Point(54, 285);
            detallesDataGridView.MultiSelect = false;
            detallesDataGridView.Name = "detallesDataGridView";
            detallesDataGridView.ReadOnly = true;
            detallesDataGridView.RowHeadersWidth = 62;
            detallesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            detallesDataGridView.Size = new Size(826, 369);
            detallesDataGridView.TabIndex = 8;
            // 
            // agregarButton
            //
            agregarButton.Location = new Point(431, 661);
            agregarButton.Margin = new Padding(5);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(143, 33);
            agregarButton.TabIndex = 9;
            agregarButton.Text = "&Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(584, 661);
            modificarButton.Margin = new Padding(5);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(143, 33);
            modificarButton.TabIndex = 10;
            modificarButton.Text = "&Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(737, 661);
            eliminarButton.Margin = new Padding(5);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(143, 33);
            eliminarButton.TabIndex = 11;
            eliminarButton.Text = "&Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(628, 740);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(115, 50);
            aceptarButton.TabIndex = 12;
            aceptarButton.Text = "&Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(765, 740);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(115, 50);
            cancelarButton.TabIndex = 13;
            cancelarButton.Text = "&Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(182, 60);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(150, 31);
            idTextBox.TabIndex = 14;
            // 
            // clienteComboBox
            // 
            clienteComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            clienteComboBox.FormattingEnabled = true;
            clienteComboBox.Location = new Point(182, 121);
            clienteComboBox.Name = "clienteComboBox";
            clienteComboBox.Size = new Size(297, 33);
            clienteComboBox.TabIndex = 15;
            // 
            // empleadoComboBox
            // 
            empleadoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            empleadoComboBox.FormattingEnabled = true;
            empleadoComboBox.Location = new Point(583, 121);
            empleadoComboBox.Name = "empleadoComboBox";
            empleadoComboBox.Size = new Size(297, 33);
            empleadoComboBox.TabIndex = 16;
            // 
            // fechaAlquilerTextBox
            // 
            fechaAlquilerTextBox.Location = new Point(182, 180);
            fechaAlquilerTextBox.Name = "fechaAlquilerTextBox";
            fechaAlquilerTextBox.ReadOnly = true;
            fechaAlquilerTextBox.Size = new Size(266, 31);
            fechaAlquilerTextBox.TabIndex = 17;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // AlquilerDetalle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 813);
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
    }
}