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
            cobrarButton = new Button();
            fechaDesdeLabel = new Label();
            fechaHastaLabel = new Label();
            sucursalLabel = new Label();
            fechaDesdeDateTimePicker = new DateTimePicker();
            fechaHastaDateTimePicker = new DateTimePicker();
            sucursalComboBox = new ComboBox();
            generarReporteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)alquileresDataGridView).BeginInit();
            SuspendLayout();
            // 
            // alquileresDataGridView
            // 
            alquileresDataGridView.AllowUserToAddRows = false;
            alquileresDataGridView.AllowUserToDeleteRows = false;
            alquileresDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            alquileresDataGridView.Location = new Point(24, 53);
            alquileresDataGridView.Margin = new Padding(2);
            alquileresDataGridView.MultiSelect = false;
            alquileresDataGridView.Name = "alquileresDataGridView";
            alquileresDataGridView.ReadOnly = true;
            alquileresDataGridView.RowHeadersWidth = 82;
            alquileresDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            alquileresDataGridView.Size = new Size(858, 298);
            alquileresDataGridView.TabIndex = 0;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(578, 378);
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
            actualizarButton.Location = new Point(684, 378);
            actualizarButton.Margin = new Padding(2);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(92, 29);
            actualizarButton.TabIndex = 3;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(790, 378);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(92, 29);
            agregarButton.TabIndex = 3;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // cobrarButton
            // 
            cobrarButton.Location = new Point(462, 378);
            cobrarButton.Name = "cobrarButton";
            cobrarButton.Size = new Size(94, 29);
            cobrarButton.TabIndex = 4;
            cobrarButton.Text = "Cobrar";
            cobrarButton.UseVisualStyleBackColor = true;
            cobrarButton.Click += cobrarButton_Click;
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new Point(24, 18);
            fechaDesdeLabel.Margin = new Padding(2, 0, 2, 0);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new Size(91, 20);
            fechaDesdeLabel.TabIndex = 6;
            fechaDesdeLabel.Text = "Fecha desde";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new Point(248, 18);
            fechaHastaLabel.Margin = new Padding(2, 0, 2, 0);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new Size(86, 20);
            fechaHastaLabel.TabIndex = 7;
            fechaHastaLabel.Text = "Fecha hasta";
            // 
            // sucursalLabel
            // 
            sucursalLabel.AutoSize = true;
            sucursalLabel.Location = new Point(462, 18);
            sucursalLabel.Margin = new Padding(2, 0, 2, 0);
            sucursalLabel.Name = "sucursalLabel";
            sucursalLabel.Size = new Size(63, 20);
            sucursalLabel.TabIndex = 8;
            sucursalLabel.Text = "Sucursal";
            // 
            // fechaDesdeDateTimePicker
            // 
            fechaDesdeDateTimePicker.Format = DateTimePickerFormat.Short;
            fechaDesdeDateTimePicker.Location = new Point(117, 14);
            fechaDesdeDateTimePicker.Margin = new Padding(2, 2, 2, 2);
            fechaDesdeDateTimePicker.Name = "fechaDesdeDateTimePicker";
            fechaDesdeDateTimePicker.Size = new Size(111, 27);
            fechaDesdeDateTimePicker.TabIndex = 9;
            // 
            // fechaHastaDateTimePicker
            // 
            fechaHastaDateTimePicker.Format = DateTimePickerFormat.Short;
            fechaHastaDateTimePicker.Location = new Point(336, 14);
            fechaHastaDateTimePicker.Margin = new Padding(2, 2, 2, 2);
            fechaHastaDateTimePicker.Name = "fechaHastaDateTimePicker";
            fechaHastaDateTimePicker.Size = new Size(111, 27);
            fechaHastaDateTimePicker.TabIndex = 10;
            fechaHastaDateTimePicker.Value = new DateTime(2026, 10, 23, 21, 28, 33, 0);
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(529, 12);
            sucursalComboBox.Margin = new Padding(2, 2, 2, 2);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(153, 28);
            sucursalComboBox.TabIndex = 11;
            // 
            // generarReporteButton
            // 
            generarReporteButton.BackColor = Color.YellowGreen;
            generarReporteButton.Location = new Point(24, 378);
            generarReporteButton.Margin = new Padding(2, 2, 2, 2);
            generarReporteButton.Name = "generarReporteButton";
            generarReporteButton.Size = new Size(139, 27);
            generarReporteButton.TabIndex = 12;
            generarReporteButton.Text = "Generar Reporte";
            generarReporteButton.UseVisualStyleBackColor = false;
            generarReporteButton.Click += generarReporteButton_Click;
            // 
            // AlquilerLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 427);
            Controls.Add(generarReporteButton);
            Controls.Add(sucursalComboBox);
            Controls.Add(fechaHastaDateTimePicker);
            Controls.Add(fechaDesdeDateTimePicker);
            Controls.Add(sucursalLabel);
            Controls.Add(fechaHastaLabel);
            Controls.Add(fechaDesdeLabel);
            Controls.Add(cobrarButton);
            Controls.Add(agregarButton);
            Controls.Add(actualizarButton);
            Controls.Add(eliminarButton);
            Controls.Add(alquileresDataGridView);
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AlquilerLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alquileres";
            Load += Alquileres_Load;
            ((System.ComponentModel.ISupportInitialize)alquileresDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView alquileresDataGridView;
        private Button eliminarButton;
        private Button actualizarButton;
        private Button agregarButton;
        private Button cobrarButton;
        private Label fechaDesdeLabel;
        private Label fechaHastaLabel;
        private Label sucursalLabel;
        private DateTimePicker fechaDesdeDateTimePicker;
        private DateTimePicker fechaHastaDateTimePicker;
        private ComboBox sucursalComboBox;
        private Button generarReporteButton;
    }
}