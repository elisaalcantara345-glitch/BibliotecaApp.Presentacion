using BibliotecaApp.Entidades;

namespace BibliotecaApp.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            FrmLibros formulario = new FrmLibros();
            formulario.ShowDialog();
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Autores");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.ShowDialog();
        }
        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            FrmPrestamos formulario = new FrmPrestamos();
            formulario.ShowDialog();
        }

        private void btnAutores_Click_1(object sender, EventArgs e)
        {
            FrmAutores frm = new FrmAutores();
            frm.ShowDialog();
        }

    }


}