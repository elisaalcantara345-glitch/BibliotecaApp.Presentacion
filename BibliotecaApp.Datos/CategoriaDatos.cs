using Microsoft.Data.SqlClient;
using BibliotecaApp.Entidades;

namespace BibliotecaApp.Datos
{
    public class CategoriaDatos
    {
        private readonly Conexion conexion = new Conexion();

        public List<Categoria> Listar()
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT IdCategoria, Nombre, Descripcion
                       FROM BibliotecaDB.dbo.Categorias
                       ORDER BY Nombre";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString()
                        });
                    }
                }
            }

            return categorias;
        }
        public void Registrar(Categoria categoria)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO BibliotecaDB.dbo.Categorias
                       (Nombre, Descripcion)
                       VALUES
                       (@Nombre, @Descripcion)";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Actualizar(Categoria categoria)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"UPDATE BibliotecaDB.dbo.Categorias
                       SET Nombre = @Nombre,
                           Descripcion = @Descripcion
                       WHERE IdCategoria = @IdCategoria";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCategoria", categoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Eliminar(int idCategoria)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"DELETE FROM BibliotecaDB.dbo.Categorias
                       WHERE IdCategoria = @IdCategoria";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}