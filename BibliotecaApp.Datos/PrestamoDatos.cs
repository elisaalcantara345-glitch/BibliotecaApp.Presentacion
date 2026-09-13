using Microsoft.Data.SqlClient;
using BibliotecaApp.Entidades;

namespace BibliotecaApp.Datos
{
    public class PrestamoDatos
    {
        private readonly Conexion conexion = new Conexion();

        public void RegistrarPrestamo(Prestamo prestamo, DetallePrestamo detalle)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        string sqlPrestamo = @"INSERT INTO BibliotecaDB.dbo.Prestamos
                                       (IdUsuario, FechaPrestamo,
                                        FechaDevolucionEsperada,
                                        FechaDevolucionReal, Estado)
                                       VALUES
                                       (@IdUsuario, @FechaPrestamo,
                                        @FechaDevolucionEsperada,
                                        NULL, 'Prestado');

                                       SELECT SCOPE_IDENTITY();";

                        int idPrestamo;

                        using (SqlCommand cmd = new SqlCommand(sqlPrestamo, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@IdUsuario", prestamo.IdUsuario);
                            cmd.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
                            cmd.Parameters.AddWithValue("@FechaDevolucionEsperada",
                                prestamo.FechaDevolucionEsperada);

                            idPrestamo = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        string sqlDetalle = @"INSERT INTO BibliotecaDB.dbo.DetallePrestamos
                                      (IdPrestamo, IdLibro, Cantidad)
                                      VALUES
                                      (@IdPrestamo, @IdLibro, @Cantidad)";

                        using (SqlCommand cmd = new SqlCommand(sqlDetalle, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                            cmd.Parameters.AddWithValue("@IdLibro", detalle.IdLibro);
                            cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);

                            cmd.ExecuteNonQuery();
                        }

                        string sqlActualizarLibro = @"UPDATE BibliotecaDB.dbo.Libros
                                              SET CantidadDisponible =
                                                  CantidadDisponible - @Cantidad
                                              WHERE IdLibro = @IdLibro
                                                AND CantidadDisponible >= @Cantidad";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlActualizarLibro, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@IdLibro", detalle.IdLibro);
                            cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);

                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas == 0)
                            {
                                throw new Exception(
                                    "No hay suficientes ejemplares disponibles.");
                            }
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
        public void RegistrarDevolucion(int idPrestamo)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        string sqlDetalle = @"SELECT IdLibro, Cantidad
                                      FROM BibliotecaDB.dbo.DetallePrestamos
                                      WHERE IdPrestamo = @IdPrestamo";

                        int idLibro;
                        int cantidad;

                        using (SqlCommand cmd = new SqlCommand(
                            sqlDetalle, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new Exception(
                                        "No se encontró el detalle del préstamo.");
                                }

                                idLibro = Convert.ToInt32(reader["IdLibro"]);
                                cantidad = Convert.ToInt32(reader["Cantidad"]);
                            }
                        }

                        string sqlPrestamo = @"UPDATE BibliotecaDB.dbo.Prestamos
                                       SET FechaDevolucionReal = @Fecha,
                                           Estado = 'Devuelto'
                                       WHERE IdPrestamo = @IdPrestamo
                                         AND Estado = 'Prestado'";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlPrestamo, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                            cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);

                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas == 0)
                            {
                                throw new Exception(
                                    "El préstamo ya fue devuelto o no existe.");
                            }
                        }

                        string sqlLibro = @"UPDATE BibliotecaDB.dbo.Libros
                                    SET CantidadDisponible =
                                        CantidadDisponible + @Cantidad
                                    WHERE IdLibro = @IdLibro";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlLibro, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmd.Parameters.AddWithValue("@IdLibro", idLibro);

                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<Prestamo> ListarPrestamos()
        {
            List<Prestamo> prestamos = new List<Prestamo>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT IdPrestamo,
                              IdUsuario,
                              FechaPrestamo,
                              FechaDevolucionEsperada,
                              FechaDevolucionReal,
                              Estado
                       FROM BibliotecaDB.dbo.Prestamos
                       ORDER BY FechaPrestamo DESC";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prestamos.Add(new Prestamo
                        {
                            IdPrestamo = Convert.ToInt32(reader["IdPrestamo"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            FechaPrestamo = Convert.ToDateTime(reader["FechaPrestamo"]),
                            FechaDevolucionEsperada =
                                Convert.ToDateTime(reader["FechaDevolucionEsperada"]),
                            FechaDevolucionReal =
                                reader["FechaDevolucionReal"] == DBNull.Value
                                    ? null
                                    : Convert.ToDateTime(reader["FechaDevolucionReal"]),
                            Estado = reader["Estado"].ToString()
                        });
                    }
                }
            }

            return prestamos;
        }
        public void Actualizar(Prestamo prestamo)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"UPDATE BibliotecaDB.dbo.Prestamos
                       SET FechaDevolucionEsperada = @FechaDevolucionEsperada,
                           Estado = @Estado
                       WHERE IdPrestamo = @IdPrestamo";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue(
                        "@IdPrestamo", prestamo.IdPrestamo);

                    cmd.Parameters.AddWithValue(
                        "@FechaDevolucionEsperada",
                        prestamo.FechaDevolucionEsperada);

                    cmd.Parameters.AddWithValue(
                        "@Estado", prestamo.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int idPrestamo)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        string sqlDetalle = @"SELECT IdLibro, Cantidad
                                      FROM BibliotecaDB.dbo.DetallePrestamos
                                      WHERE IdPrestamo = @IdPrestamo";

                        int idLibro;
                        int cantidad;

                        using (SqlCommand cmd = new SqlCommand(
                            sqlDetalle, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue(
                                "@IdPrestamo", idPrestamo);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new Exception(
                                        "No se encontró el detalle del préstamo.");
                                }

                                idLibro = Convert.ToInt32(reader["IdLibro"]);
                                cantidad = Convert.ToInt32(reader["Cantidad"]);
                            }
                        }

                        string sqlEstado = @"SELECT Estado
                                     FROM BibliotecaDB.dbo.Prestamos
                                     WHERE IdPrestamo = @IdPrestamo";

                        string estado;

                        using (SqlCommand cmd = new SqlCommand(
                            sqlEstado, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue(
                                "@IdPrestamo", idPrestamo);

                            object resultado = cmd.ExecuteScalar();

                            if (resultado == null)
                            {
                                throw new Exception(
                                    "El préstamo no existe.");
                            }

                            estado = resultado.ToString();
                        }

                        if (estado == "Prestado")
                        {
                            string sqlLibro = @"UPDATE BibliotecaDB.dbo.Libros
                                        SET CantidadDisponible =
                                            CantidadDisponible + @Cantidad
                                        WHERE IdLibro = @IdLibro";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlLibro, cn, transaccion))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@Cantidad", cantidad);

                                cmd.Parameters.AddWithValue(
                                    "@IdLibro", idLibro);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        string sqlEliminarDetalle =
                            @"DELETE FROM BibliotecaDB.dbo.DetallePrestamos
                      WHERE IdPrestamo = @IdPrestamo";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlEliminarDetalle, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue(
                                "@IdPrestamo", idPrestamo);

                            cmd.ExecuteNonQuery();
                        }

                        string sqlEliminarPrestamo =
                            @"DELETE FROM BibliotecaDB.dbo.Prestamos
                      WHERE IdPrestamo = @IdPrestamo";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlEliminarPrestamo, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue(
                                "@IdPrestamo", idPrestamo);

                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}