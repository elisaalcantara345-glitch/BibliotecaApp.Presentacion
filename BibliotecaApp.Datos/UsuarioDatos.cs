using Microsoft.Data.SqlClient;
using BibliotecaApp.Entidades;

namespace BibliotecaApp.Datos
{
    public class UsuarioDatos
    {
        private readonly Conexion conexion = new Conexion();

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT IdUsuario, Documento, Nombre, Apellidos,
                              Telefono, Correo, ProgramaAcademico
                       FROM BibliotecaDB.dbo.Usuarios
                       ORDER BY Nombre";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Documento = reader["Documento"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            ProgramaAcademico = reader["ProgramaAcademico"].ToString()
                        });
                    }
                }
            }

            return usuarios;
        }
        public void Registrar(Usuario usuario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO BibliotecaDB.dbo.Usuarios
                       (Documento, Nombre, Apellidos, Telefono, Correo, ProgramaAcademico)
                       VALUES
                       (@Documento, @Nombre, @Apellidos, @Telefono, @Correo, @ProgramaAcademico)";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@ProgramaAcademico", usuario.ProgramaAcademico);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Actualizar(Usuario usuario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"UPDATE BibliotecaDB.dbo.Usuarios
                       SET Documento = @Documento,
                           Nombre = @Nombre,
                           Apellidos = @Apellidos,
                           Telefono = @Telefono,
                           Correo = @Correo,
                           ProgramaAcademico = @ProgramaAcademico
                       WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@ProgramaAcademico", usuario.ProgramaAcademico);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Eliminar(int idUsuario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"DELETE FROM BibliotecaDB.dbo.Usuarios
                       WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}