using System.Collections.Generic;
using BibliotecaApp.Entidades;
using BibliotecaApp.Datos;

namespace BibliotecaApp.Negocio
{
    public class LibroNegocio
    {
        private readonly LibroDatos libroDatos = new LibroDatos();

        public List<Libro> Listar()
        {
            return libroDatos.Listar();
        }

        public void Registrar(Libro libro)
        {
            // Validaciones requeridas por la guía (RF01 y Validaciones)
            if (string.IsNullOrWhiteSpace(libro.Codigo))
                throw new System.Exception("El código del libro es obligatorio.");

            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new System.Exception("El título del libro es obligatorio.");

            if (libro.Cantidad <= 0)
                throw new System.Exception("La cantidad debe ser mayor a cero.");

            libroDatos.Registrar(libro);
        }

        public void Editar(Libro libro)
        {
            if (libro.IdLibro <= 0)
                throw new System.Exception("Debe seleccionar un libro válido para editar.");

            if (string.IsNullOrWhiteSpace(libro.Codigo))
                throw new System.Exception("El código del libro es obligatorio.");

            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new System.Exception("El título del libro es obligatorio.");

            if (libro.Cantidad <= 0)
                throw new System.Exception("La cantidad debe ser mayor a cero.");

            libroDatos.Editar(libro);
        }

        public void Eliminar(int idLibro)
        {
            if (idLibro <= 0)
                throw new System.Exception("Debe seleccionar un libro válido para eliminar.");

            libroDatos.Eliminar(idLibro);
        }

        public List<Libro> Buscar(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
                return Listar();

            return libroDatos.Buscar(criterio);
        }
    }
}