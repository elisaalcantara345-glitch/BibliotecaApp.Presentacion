using BibliotecaApp.Datos;
using BibliotecaApp.Entidades;

namespace BibliotecaApp.Negocio
{
    public class CategoriaNegocio
    {
        private readonly CategoriaDatos categoriaDatos = new CategoriaDatos();

        public List<Categoria> Listar()
        {
            return categoriaDatos.Listar();
        }

        public void Registrar(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new Exception("El nombre de la categoría es obligatorio.");

            if (categoria.Nombre.Length > 50)
                throw new Exception(
                    "El nombre de la categoría no puede superar los 50 caracteres.");

            if (!string.IsNullOrWhiteSpace(categoria.Descripcion) &&
                categoria.Descripcion.Length > 150)
                throw new Exception(
                    "La descripción no puede superar los 150 caracteres.");

            categoriaDatos.Registrar(categoria);
        }

        public void Actualizar(Categoria categoria)
        {
            if (categoria.IdCategoria <= 0)
                throw new Exception("La categoría seleccionada no es válida.");

            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new Exception("El nombre de la categoría es obligatorio.");

            if (categoria.Nombre.Length > 50)
                throw new Exception(
                    "El nombre de la categoría no puede superar los 50 caracteres.");

            if (!string.IsNullOrWhiteSpace(categoria.Descripcion) &&
                categoria.Descripcion.Length > 150)
                throw new Exception(
                    "La descripción no puede superar los 150 caracteres.");

            categoriaDatos.Actualizar(categoria);
        }

        public void Eliminar(int idCategoria)
        {
            if (idCategoria <= 0)
                throw new Exception("La categoría seleccionada no es válida.");

            categoriaDatos.Eliminar(idCategoria);
        }
    }
}