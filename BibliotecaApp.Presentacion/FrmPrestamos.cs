using BibliotecaApp.Entidades;
using BibliotecaApp.Negocio;

namespace BibliotecaApp.Presentacion
{
    public partial class FrmPrestamos : Form
    {
        private PrestamoNegocio prestamoNegocio = new PrestamoNegocio();
        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private LibroNegocio libroNegocio = new LibroNegocio();

        private int idPrestamoSeleccionado = 0;
        public FrmPrestamos()
        {
            InitializeComponent();

            CargarUsuarios();
            CargarLibros();
            CargarPrestamos();
        }

        private void CargarUsuarios()
        {
            cmbUsuario.DataSource = usuarioNegocio.Listar();
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "IdUsuario";
        }

        private void CargarLibros()
        {
            cmbLibro.DataSource = libroNegocio.Listar();
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember = "IdLibro";
        }

        private void CargarPrestamos()
        {
            dgvPrestamos.DataSource = prestamoNegocio.Listar();
        }
        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                Prestamo prestamo = new Prestamo();

                prestamo.IdUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);
                prestamo.FechaPrestamo = dtpFechaPrestamo.Value;
                prestamo.FechaDevolucionEsperada = dtpFechaDevolucion.Value;
                prestamo.Estado = "Prestado";

                DetallePrestamo detalle = new DetallePrestamo();

                detalle.IdLibro = Convert.ToInt32(cmbLibro.SelectedValue);
                detalle.Cantidad = Convert.ToInt32(nudCantidad.Value);

                prestamoNegocio.Registrar(prestamo, detalle);

                MessageBox.Show(
                    "Préstamo registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarPrestamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo registrar el préstamo: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPrestamoSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un préstamo de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Desea registrar la devolución de este préstamo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    prestamoNegocio.RegistrarDevolucion(idPrestamoSeleccionado);
                    MessageBox.Show("Devolución registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPrestamos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la devolución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDevolucion(object sender, EventArgs e)
        {

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPrestamoSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un préstamo de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    prestamoNegocio.Eliminar(idPrestamoSeleccionado);
                    MessageBox.Show("Préstamo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPrestamos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPrestamos.Rows[e.RowIndex];

                // Obtiene el valor de la primera columna (columna 0), que corresponde al ID
                if (fila.Cells[0].Value != null)
                {
                    idPrestamoSeleccionado = Convert.ToInt32(fila.Cells[0].Value);
                }
            }
        }
    }

}
