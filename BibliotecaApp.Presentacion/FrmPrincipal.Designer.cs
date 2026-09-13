namespace BibliotecaApp.Presentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnLibros = new Button();
            btnAutores = new Button();
            btnUsuarios = new Button();
            btnPrestamos = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F);
            lblTitulo.Location = new Point(163, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(581, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "SISTEMA DE GESTIÓN DE BIBLIOTECA";
            // 
            // btnLibros
            // 
            btnLibros.Location = new Point(216, 133);
            btnLibros.Name = "btnLibros";
            btnLibros.Size = new Size(150, 70);
            btnLibros.TabIndex = 1;
            btnLibros.Text = "Libros";
            btnLibros.UseVisualStyleBackColor = true;
            btnLibros.Click += btnLibros_Click;
            // 
            // btnAutores
            // 
            btnAutores.Location = new Point(504, 133);
            btnAutores.Name = "btnAutores";
            btnAutores.Size = new Size(150, 70);
            btnAutores.TabIndex = 2;
            btnAutores.Text = "Autores";
            btnAutores.UseVisualStyleBackColor = true;
            btnAutores.Click += btnAutores_Click_1;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(216, 263);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(150, 70);
            btnUsuarios.TabIndex = 3;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnPrestamos
            // 
            btnPrestamos.Location = new Point(504, 263);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Size = new Size(150, 70);
            btnPrestamos.TabIndex = 4;
            btnPrestamos.Text = "Préstamos";
            btnPrestamos.UseVisualStyleBackColor = true;
            btnPrestamos.Click += btnPrestamos_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(btnPrestamos);
            Controls.Add(btnUsuarios);
            Controls.Add(btnAutores);
            Controls.Add(btnLibros);
            Controls.Add(lblTitulo);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Biblioteca";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnLibros;
        private Button btnAutores;
        private Button btnUsuarios;
        private Button btnPrestamos;
    }
}
