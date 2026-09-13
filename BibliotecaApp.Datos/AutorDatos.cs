using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.SqlClient;
using BibliotecaApp.Entidades;

namespace BibliotecaApp.Datos
{
    public class AutorDatos
    {
        private readonly Conexion conexion = new Conexion();

        public List<Autor> Listar()
        {
            List<Autor> autores = new List<Autor>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT IdAutor, Codigo, Nombre, Apellidos,
                                      Nacionalidad, FechaNacimiento
                               FROM BibliotecaDB.dbo.Autores
                               ORDER BY Nombre";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        autores.Add(new Autor
                        {
                            IdAutor = Convert.ToInt32(reader["IdAutor"]),
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Nacionalidad = reader["Nacionalidad"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"])
                        });
                    }
                }
            }

            return autores;
        }
        public void Registrar(Autor autor)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO BibliotecaDB.dbo.Autores
                       (Codigo, Nombre, Apellidos, Nacionalidad, FechaNacimiento)
                       VALUES
                       (@Codigo, @Nombre, @Apellidos, @Nacionalidad, @FechaNacimiento)";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Codigo", autor.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre", autor.Nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", autor.Apellidos);
                    cmd.Parameters.AddWithValue("@Nacionalidad", autor.Nacionalidad);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", autor.FechaNacimiento);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Actualizar(Autor autor)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"UPDATE BibliotecaDB.dbo.Autores
                       SET Codigo = @Codigo,
                           Nombre = @Nombre,
                           Apellidos = @Apellidos,
                           Nacionalidad = @Nacionalidad,
                           FechaNacimiento = @FechaNacimiento
                       WHERE IdAutor = @IdAutor";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdAutor", autor.IdAutor);
                    cmd.Parameters.AddWithValue("@Codigo", autor.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre", autor.Nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", autor.Apellidos);
                    cmd.Parameters.AddWithValue("@Nacionalidad", autor.Nacionalidad);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", autor.FechaNacimiento);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Eliminar(int idAutor)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"DELETE FROM BibliotecaDB.dbo.Autores
                       WHERE IdAutor = @IdAutor";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdAutor", idAutor);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}