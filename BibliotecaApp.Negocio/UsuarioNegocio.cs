using BibliotecaApp.Datos;
using BibliotecaApp.Entidades;
using System.Text.RegularExpressions;

namespace BibliotecaApp.Negocio
{
    public class UsuarioNegocio
    {
        private readonly UsuarioDatos usuarioDatos = new UsuarioDatos();

        public List<Usuario> Listar()
        {
            return usuarioDatos.Listar();
        }

        public void Registrar(Usuario usuario)
        {
            ValidarUsuario(usuario);

            usuarioDatos.Registrar(usuario);
        }

        public void Actualizar(Usuario usuario)
        {
            if (usuario.IdUsuario <= 0)
                throw new Exception("El usuario seleccionado no es válido.");

            ValidarUsuario(usuario);

            usuarioDatos.Actualizar(usuario);
        }

        public void Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("El usuario seleccionado no es válido.");

            usuarioDatos.Eliminar(idUsuario);
        }

        private void ValidarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Documento))
                throw new Exception("El documento es obligatorio.");

            if (usuario.Documento.Length > 20)
                throw new Exception(
                    "El documento no puede superar los 20 caracteres.");

            if (!Regex.IsMatch(usuario.Documento, @"^[0-9]+$"))
                throw new Exception(
                    "El documento solo debe contener números.");

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Apellidos))
                throw new Exception("Los apellidos son obligatorios.");

            if (string.IsNullOrWhiteSpace(usuario.Telefono))
                throw new Exception("El teléfono es obligatorio.");

            if (usuario.Telefono.Length > 20)
                throw new Exception(
                    "El teléfono no puede superar los 20 caracteres.");

            if (!Regex.IsMatch(usuario.Telefono, @"^[0-9]+$"))
                throw new Exception(
                    "El teléfono solo debe contener números.");

            if (string.IsNullOrWhiteSpace(usuario.Correo))
                throw new Exception("El correo electrónico es obligatorio.");

            if (usuario.Correo.Length > 100)
                throw new Exception(
                    "El correo no puede superar los 100 caracteres.");

            if (!Regex.IsMatch(
                    usuario.Correo,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception(
                    "El correo electrónico no tiene un formato válido.");

            if (string.IsNullOrWhiteSpace(usuario.ProgramaAcademico))
                throw new Exception("El programa académico es obligatorio.");
        }
    }
}