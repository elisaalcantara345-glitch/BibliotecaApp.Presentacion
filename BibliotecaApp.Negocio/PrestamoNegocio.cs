using BibliotecaApp.Datos;
using BibliotecaApp.Entidades;

namespace BibliotecaApp.Negocio
{
    public class PrestamoNegocio
    {
        private readonly PrestamoDatos prestamoDatos = new PrestamoDatos();

        public List<Prestamo> Listar()
        {
            return prestamoDatos.ListarPrestamos();
        }

        public void Registrar(Prestamo prestamo, DetallePrestamo detalle)
        {
            ValidarPrestamo(prestamo);
            ValidarDetalle(detalle);

            prestamo.Estado = "Prestado";
            prestamo.FechaDevolucionReal = null;

            prestamoDatos.RegistrarPrestamo(prestamo, detalle);
        }

        public void Actualizar(Prestamo prestamo)
        {
            if (prestamo.IdPrestamo <= 0)
                throw new Exception(
                    "El préstamo seleccionado no es válido.");

            if (prestamo.FechaDevolucionEsperada.Date <
                prestamo.FechaPrestamo.Date)
                throw new Exception(
                    "La fecha de devolución no puede ser anterior a la fecha del préstamo.");

            if (prestamo.Estado != "Prestado" &&
                prestamo.Estado != "Devuelto" &&
                prestamo.Estado != "Atrasado")
                throw new Exception(
                    "El estado del préstamo no es válido.");

            prestamoDatos.Actualizar(prestamo);
        }

        public void Eliminar(int idPrestamo)
        {
            if (idPrestamo <= 0)
                throw new Exception(
                    "El préstamo seleccionado no es válido.");

            prestamoDatos.Eliminar(idPrestamo);
        }

        public void RegistrarDevolucion(int idPrestamo)
        {
            if (idPrestamo <= 0)
                throw new Exception(
                    "El préstamo seleccionado no es válido.");

            prestamoDatos.RegistrarDevolucion(idPrestamo);
        }

        private void ValidarPrestamo(Prestamo prestamo)
        {
            if (prestamo.IdUsuario <= 0)
                throw new Exception(
                    "Debe seleccionar un usuario válido.");

            if (prestamo.FechaPrestamo == default)
                throw new Exception(
                    "La fecha del préstamo es obligatoria.");

            if (prestamo.FechaDevolucionEsperada == default)
                throw new Exception(
                    "La fecha de devolución esperada es obligatoria.");

            if (prestamo.FechaDevolucionEsperada.Date <
                prestamo.FechaPrestamo.Date)
                throw new Exception(
                    "La fecha de devolución no puede ser anterior a la fecha del préstamo.");
        }

        private void ValidarDetalle(DetallePrestamo detalle)
        {
            if (detalle.IdLibro <= 0)
                throw new Exception(
                    "Debe seleccionar un libro válido.");

            if (detalle.Cantidad <= 0)
                throw new Exception(
                    "La cantidad a prestar debe ser mayor que cero.");
        }

  
    }
}