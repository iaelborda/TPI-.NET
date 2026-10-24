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
            alquileresDataGridView.Location = new Point(30, 66);
            alquileresDataGridView.Margin = new Padding(2);
            alquileresDataGridView.MultiSelect = false;
            alquileresDataGridView.Name = "alquileresDataGridView";
            alquileresDataGridView.ReadOnly = true;
            alquileresDataGridView.RowHeadersWidth = 82;
            alquileresDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            alquileresDataGridView.Size = new Size(1072, 373);
            alquileresDataGridView.TabIndex = 0;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(722, 472);
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
            // cobrarButton
            // 
            cobrarButton.Location = new Point(578, 472);
            cobrarButton.Margin = new Padding(4);
            cobrarButton.Name = "cobrarButton";
            cobrarButton.Size = new Size(118, 36);
            cobrarButton.TabIndex = 4;
            cobrarButton.Text = "Cobrar";
            cobrarButton.UseVisualStyleBackColor = true;
            cobrarButton.Click += cobrarButton_Click;
            // 
            // fechaDesdeLabel
            // 
            fechaDesdeLabel.AutoSize = true;
            fechaDesdeLabel.Location = new Point(30, 23);
            fechaDesdeLabel.Name = "fechaDesdeLabel";
            fechaDesdeLabel.Size = new Size(110, 25);
            fechaDesdeLabel.TabIndex = 6;
            fechaDesdeLabel.Text = "Fecha desde";
            // 
            // fechaHastaLabel
            // 
            fechaHastaLabel.AutoSize = true;
            fechaHastaLabel.Location = new Point(310, 23);
            fechaHastaLabel.Name = "fechaHastaLabel";
            fechaHastaLabel.Size = new Size(104, 25);
            fechaHastaLabel.TabIndex = 7;
            fechaHastaLabel.Text = "Fecha hasta";
            // 
            // sucursalLabel
            // 
            sucursalLabel.AutoSize = true;
            sucursalLabel.Location = new Point(578, 23);
            sucursalLabel.Name = "sucursalLabel";
            sucursalLabel.Size = new Size(77, 25);
            sucursalLabel.TabIndex = 8;
            sucursalLabel.Text = "Sucursal";
            // 
            // fechaDesdeDateTimePicker
            // 
            fechaDesdeDateTimePicker.Format = DateTimePickerFormat.Short;
            fechaDesdeDateTimePicker.Location = new Point(146, 18);
            fechaDesdeDateTimePicker.Name = "fechaDesdeDateTimePicker";
            fechaDesdeDateTimePicker.Size = new Size(138, 31);
            fechaDesdeDateTimePicker.TabIndex = 9;
            // 
            // fechaHastaDateTimePicker
            // 
            fechaHastaDateTimePicker.Format = DateTimePickerFormat.Short;
            fechaHastaDateTimePicker.Location = new Point(420, 17);
            fechaHastaDateTimePicker.Name = "fechaHastaDateTimePicker";
            fechaHastaDateTimePicker.Size = new Size(138, 31);
            fechaHastaDateTimePicker.TabIndex = 10;
            fechaHastaDateTimePicker.Value = new DateTime(2026, 10, 23, 21, 28, 33, 0);
            // 
            // sucursalComboBox
            // 
            sucursalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sucursalComboBox.FormattingEnabled = true;
            sucursalComboBox.Location = new Point(661, 15);
            sucursalComboBox.Name = "sucursalComboBox";
            sucursalComboBox.Size = new Size(190, 33);
            sucursalComboBox.TabIndex = 11;
            // 
            // generarReporteButton
            // 
            generarReporteButton.BackColor = Color.YellowGreen;
            generarReporteButton.Location = new Point(30, 472);
            generarReporteButton.Name = "generarReporteButton";
            generarReporteButton.Size = new Size(174, 34);
            generarReporteButton.TabIndex = 12;
            generarReporteButton.Text = "Generar Reporte";
            generarReporteButton.UseVisualStyleBackColor = false;
            generarReporteButton.Click += generarReporteButton_Click;
            // 
            // AlquilerLista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 534);
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