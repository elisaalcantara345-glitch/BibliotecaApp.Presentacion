namespace BibliotecaApp.Presentacion
{
    partial class FrmLibros
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
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblCantidad = new Label();
            lblISBN = new Label();
            lblTitulo = new Label();
            lblAnio = new Label();
            lblAutor = new Label();
            txtISBN = new TextBox();
            txtTitulo = new TextBox();
            nudAnio = new NumericUpDown();
            nudCantidad = new NumericUpDown();
            cmbAutor = new ComboBox();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            btnRegistrar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            dgvLibros = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(32, 24);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(58, 20);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Código";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(149, 17);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(125, 27);
            txtCodigo.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(31, 121);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(69, 20);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Cantidad";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(405, 29);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(41, 20);
            lblISBN.TabIndex = 3;
            lblISBN.Text = "ISBN";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(31, 74);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(47, 20);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Título";
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(405, 75);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(117, 20);
            lblAnio.TabIndex = 5;
            lblAnio.Text = "Año publicación";
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(405, 122);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(46, 20);
            lblAutor.TabIndex = 6;
            lblAutor.Text = "Autor";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(542, 17);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(125, 27);
            txtISBN.TabIndex = 7;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(149, 67);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(125, 27);
            txtTitulo.TabIndex = 8;
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(542, 68);
            nudAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudAnio.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(150, 27);
            nudAnio.TabIndex = 9;
            nudAnio.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(149, 114);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(150, 27);
            nudCantidad.TabIndex = 10;
            // 
            // cmbAutor
            // 
            cmbAutor.FormattingEnabled = true;
            cmbAutor.Location = new Point(541, 114);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(151, 28);
            cmbAutor.TabIndex = 11;
            cmbAutor.SelectedIndexChanged += cmbAutor_SelectedIndexChanged;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(858, 16);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(151, 28);
            cmbCategoria.TabIndex = 12;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(741, 24);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(74, 20);
            lblCategoria.TabIndex = 13;
            lblCategoria.Text = "Categoría";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(140, 186);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(94, 46);
            btnRegistrar.TabIndex = 14;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(573, 186);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 46);
            btnEditar.TabIndex = 15;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Clickk;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(357, 186);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 46);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(788, 186);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 46);
            btnLimpiar.TabIndex = 17;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click_1;
            // 
            // dgvLibros
            // 
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(140, 264);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.RowHeadersWidth = 51;
            dgvLibros.Size = new Size(742, 326);
            dgvLibros.TabIndex = 18;
            dgvLibros.CellClick += dgvLibros_CellClick;
            dgvLibros.Click += dgvLibros_CellClick;
            // 
            // FrmLibros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 602);
            Controls.Add(dgvLibros);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnRegistrar);
            Controls.Add(lblCategoria);
            Controls.Add(cmbCategoria);
            Controls.Add(cmbAutor);
            Controls.Add(nudCantidad);
            Controls.Add(nudAnio);
            Controls.Add(txtTitulo);
            Controls.Add(txtISBN);
            Controls.Add(lblAutor);
            Controls.Add(lblAnio);
            Controls.Add(lblTitulo);
            Controls.Add(lblISBN);
            Controls.Add(lblCantidad);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Name = "FrmLibros";
            Text = "FrmLibros";
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblCantidad;
        private Label lblISBN;
        private Label lblTitulo;
        private Label lblAnio;
        private Label lblAutor;
        private TextBox txtISBN;
        private TextBox txtTitulo;
        private NumericUpDown nudAnio;
        private NumericUpDown nudCantidad;
        private ComboBox cmbAutor;
        private ComboBox cmbCategoria;
        private Label lblCategoria;
        private Button btnRegistrar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridView dgvLibros;
    }
}