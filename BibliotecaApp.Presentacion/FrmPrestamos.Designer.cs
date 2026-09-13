namespace BibliotecaApp.Presentacion
{
    partial class FrmPrestamos
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
            lblUsuario = new Label();
            cmbUsuario = new ComboBox();
            lblLibro = new Label();
            cmbLibro = new ComboBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            lblFechaPrestamo = new Label();
            dtpFechaPrestamo = new DateTimePicker();
            lblFechaDevolucion = new Label();
            dtpFechaDevolucion = new DateTimePicker();
            btnPrestamo = new Button();
            btnDevolver = new Button();
            btnEliminar = new Button();
            dgvPrestamos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(22, 20);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(59, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // cmbUsuario
            // 
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(87, 17);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(151, 28);
            cmbUsuario.TabIndex = 1;
            // 
            // lblLibro
            // 
            lblLibro.AutoSize = true;
            lblLibro.Location = new Point(265, 23);
            lblLibro.Name = "lblLibro";
            lblLibro.Size = new Size(43, 20);
            lblLibro.TabIndex = 2;
            lblLibro.Text = "Libro";
            // 
            // cmbLibro
            // 
            cmbLibro.FormattingEnabled = true;
            cmbLibro.Location = new Point(324, 17);
            cmbLibro.Name = "cmbLibro";
            cmbLibro.Size = new Size(151, 28);
            cmbLibro.TabIndex = 3;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(502, 23);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(69, 20);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(592, 18);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(150, 27);
            nudCantidad.TabIndex = 0;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Location = new Point(7, 82);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Size = new Size(114, 20);
            lblFechaPrestamo.TabIndex = 5;
            lblFechaPrestamo.Text = "Fecha préstamo";
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Location = new Point(137, 77);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(250, 27);
            dtpFechaPrestamo.TabIndex = 6;
            // 
            // lblFechaDevolucion
            // 
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Location = new Point(409, 82);
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            lblFechaDevolucion.Size = new Size(124, 20);
            lblFechaDevolucion.TabIndex = 7;
            lblFechaDevolucion.Text = "Fecha devolución";
            // 
            // dtpFechaDevolucion
            // 
            dtpFechaDevolucion.Location = new Point(538, 82);
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.Size = new Size(250, 27);
            dtpFechaDevolucion.TabIndex = 8;
            // 
            // btnPrestamo
            // 
            btnPrestamo.Location = new Point(212, 125);
            btnPrestamo.Name = "btnPrestamo";
            btnPrestamo.Size = new Size(94, 29);
            btnPrestamo.TabIndex = 9;
            btnPrestamo.Text = " Préstamo";
            btnPrestamo.UseVisualStyleBackColor = true;
            btnPrestamo.Click += btnPrestamo_Click;
            // 
            // btnDevolver
            // 
            btnDevolver.Location = new Point(357, 125);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(94, 29);
            btnDevolver.TabIndex = 10;
            btnDevolver.Text = "Devolución";
            btnDevolver.UseVisualStyleBackColor = true;
            btnDevolver.Click += btnDevolucion_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(502, 125);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Location = new Point(56, 180);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.RowHeadersWidth = 51;
            dgvPrestamos.Size = new Size(686, 361);
            dgvPrestamos.TabIndex = 12;
            dgvPrestamos.CellClick += dgvPrestamos_CellClick;
            // 
            // FrmPrestamos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(dgvPrestamos);
            Controls.Add(btnEliminar);
            Controls.Add(btnDevolver);
            Controls.Add(btnPrestamo);
            Controls.Add(dtpFechaDevolucion);
            Controls.Add(lblFechaDevolucion);
            Controls.Add(dtpFechaPrestamo);
            Controls.Add(lblFechaPrestamo);
            Controls.Add(nudCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(cmbLibro);
            Controls.Add(lblLibro);
            Controls.Add(cmbUsuario);
            Controls.Add(lblUsuario);
            Name = "FrmPrestamos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Biblioteca";
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Label lblLibro;
        private ComboBox cmbLibro;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Label lblFechaPrestamo;
        private DateTimePicker dtpFechaPrestamo;
        private Label lblFechaDevolucion;
        private DateTimePicker dtpFechaDevolucion;
        private Button btnPrestamo;
        private Button btnDevolver;
        private Button btnEliminar;
        private DataGridView dgvPrestamos;
    }
}