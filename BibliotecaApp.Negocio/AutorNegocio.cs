using BibliotecaApp.Datos;
using BibliotecaApp.Entidades;

namespace BibliotecaApp.Negocio
{
    public class AutorNegocio
    {
        private readonly AutorDatos autorDatos = new AutorDatos();
        public List<Autor> Listar()
        {
            return autorDatos.Listar();
        }
        public void Registrar(Autor autor)
        {
            if (string.IsNullOrWhiteSpace(autor.Codigo))
                throw new Exception("El código del autor es obligatorio.");

            if (string.IsNullOrWhiteSpace(autor.Nombre))
                throw new Exception("El nombre del autor es obligatorio.");

            if (string.IsNullOrWhiteSpace(autor.Apellidos))
                throw new Exception("Los apellidos del autor son obligatorios.");

            if (string.IsNullOrWhiteSpace(autor.Nacionalidad))
                throw new Exception("La nacionalidad del autor es obligatoria.");

            if (autor.FechaNacimiento == default)
                throw new Exception("La fecha de nacimiento es obligatoria.");

            autorDatos.Registrar(autor);
        }
        public void Actualizar(Autor autor)
        {
            if (autor.IdAutor <= 0)
                throw new Exception("El autor seleccionado no es válido.");

            if (string.IsNullOrWhiteSpace(autor.Codigo))
                throw new Exception("El código del autor es obligatorio.");

            if (string.IsNullOrWhiteSpace(autor.Nombre))
                throw new Exception("El nombre del autor es obligatorio.");

            if (string.IsNullOrWhiteSpace(autor.Apellidos))
                throw new Exception("Los apellidos del autor son obligatorios.");

            if (string.IsNullOrWhiteSpace(autor.Nacionalidad))
                throw new Exception("La nacionalidad del autor es obligatoria.");

            autorDatos.Actualizar(autor);
        }
        public void Eliminar(int idAutor)
        {
            if (idAutor <= 0)
                throw new Exception("El autor seleccionado no es válido.");

            autorDatos.Eliminar(idAutor);
        }
    }
}