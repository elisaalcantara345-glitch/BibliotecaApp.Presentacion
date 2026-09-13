using BibliotecaApp.Entidades;
using BibliotecaApp.Negocio;

namespace BibliotecaApp.Presentacion
{
    public partial class FrmLibros : Form
    {
        private readonly LibroNegocio libroNegocio = new LibroNegocio();
        private readonly AutorNegocio autorNegocio = new AutorNegocio();
        private readonly CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

        private int idLibroSeleccionado = 0;


        public FrmLibros()
        {
            InitializeComponent();
            CargarAutores();
            CargarCategorias();
            CargarLibros();
        }
        private void CargarAutores()
        {
            cmbAutor.DataSource = autorNegocio.Listar();
            cmbAutor.DisplayMember = "Nombre";
            cmbAutor.ValueMember = "IdAutor";
        }

        private void CargarCategorias()
        {
            cmbCategoria.DataSource = categoriaNegocio.Listar();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";
        }
        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvLibros.Rows[e.RowIndex];

                idLibroSeleccionado = Convert.ToInt32(
                    fila.Cells["IdLibro"].Value);

                txtCodigo.Text = fila.Cells["Codigo"].Value.ToString();
                txtISBN.Text = fila.Cells["ISBN"].Value.ToString();
                txtTitulo.Text = fila.Cells["Titulo"].Value.ToString();

                int anio = Convert.ToInt32(fila.Cells["AnioPublicacion"].Value);

                if (anio >= nudAnio.Minimum && anio <= nudAnio.Maximum)
                {
                    nudAnio.Value = anio;
                }

                nudCantidad.Value = Convert.ToDecimal(
                    fila.Cells["Cantidad"].Value);

                cmbAutor.SelectedValue = fila.Cells["IdAutor"].Value;
                cmbCategoria.SelectedValue = fila.Cells["IdCategoria"].Value;
            }
        }
        private void CargarLibros()
        {
            try
            {
                dgvLibros.DataSource = null;
                dgvLibros.DataSource = libroNegocio.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los libros: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El botón funciona");
            try
            {
                Libro libro = new Libro
                {
                    Codigo = txtCodigo.Text.Trim(),
                    ISBN = txtISBN.Text.Trim(),
                    Titulo = txtTitulo.Text.Trim(),
                    AnioPublicacion = (int)nudAnio.Value,
                    Cantidad = (int)nudCantidad.Value,
                    IdAutor = Convert.ToInt32(cmbAutor.SelectedValue),
                    IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue)
                };

                libroNegocio.Registrar(libro);

                MessageBox.Show(
                    "Libro registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Libro libro = new Libro
                {
                    Codigo = txtCodigo.Text.Trim(),
                    ISBN = txtISBN.Text.Trim(),
                    Titulo = txtTitulo.Text.Trim(),
                    AnioPublicacion = (int)nudAnio.Value,
                    Cantidad = (int)nudCantidad.Value,
                    IdAutor = Convert.ToInt32(cmbAutor.SelectedValue),
                    IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue)
                };

                libroNegocio.Registrar(libro);

                MessageBox.Show(
                    "Libro registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void btnEditar_Click(object sender, EventArgs e)
        {
            // Código de editar (stub)
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idLibroSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un libro para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este libro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    libroNegocio.Eliminar(idLibroSeleccionado);

                    MessageBox.Show("Libro eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarLibros();

                    txtCodigo.Clear();
                    txtISBN.Clear();
                    txtTitulo.Clear();
                    nudAnio.Value = nudAnio.Minimum;
                    nudCantidad.Value = nudCantidad.Minimum;
                    cmbAutor.SelectedIndex = -1;
                    cmbCategoria.SelectedIndex = -1;

                    idLibroSeleccionado = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el libro: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            // Código de limpiar
        }

        private void dgvLibros_CellClick(object sender, EventArgs e)
        {
            // Tu código aquí
        }

        private void btnEditar_Clickk(object sender, EventArgs e)
        {

        }

        private void cmbAutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
