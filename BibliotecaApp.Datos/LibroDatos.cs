using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient; // O System.Data.SqlClient según el paquete de tu proyecto
using System.Data;
using BibliotecaApp.Entidades;

namespace BibliotecaApp.Datos
{
    public class LibroDatos
    {
        private readonly string cadenaConexion = Conexion.Cadena;

        public List<Libro> Listar()
        {
            List<Libro> lista = new List<Libro>();
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT IdLibro, Codigo, ISBN, Titulo, AnioPublicacion, Cantidad, IdAutor, IdCategoria FROM Libros";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Libro
                        {
                            IdLibro = Convert.ToInt32(dr["IdLibro"]),
                            Codigo = dr["Codigo"]?.ToString() ?? "",
                            ISBN = dr["ISBN"]?.ToString() ?? "",
                            Titulo = dr["Titulo"]?.ToString() ?? "",
                            AnioPublicacion = Convert.ToInt32(dr["AnioPublicacion"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            IdAutor = Convert.ToInt32(dr["IdAutor"]),
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"])
                        });
                    }
                }
            }
            return lista;
        }

        public void Registrar(Libro libro)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO Libros (Codigo, ISBN, Titulo, AnioPublicacion, Cantidad, CantidadDisponible, IdAutor, IdCategoria) " +
               "VALUES (@Codigo, @ISBN, @Titulo, @AnioPublicacion, @Cantidad, @CantidadDisponible, @IdAutor, @IdCategoria)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Codigo", libro.Codigo);
                cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@AnioPublicacion", libro.AnioPublicacion);
                cmd.Parameters.AddWithValue("@Cantidad", libro.Cantidad);
                cmd.Parameters.AddWithValue("@CantidadDisponible", libro.Cantidad);
                cmd.Parameters.AddWithValue("@IdAutor", libro.IdAutor);
                cmd.Parameters.AddWithValue("@IdCategoria", libro.IdCategoria);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Editar(Libro libro)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = "UPDATE Libros SET Codigo = @Codigo, ISBN = @ISBN, Titulo = @Titulo, " +
                               "AnioPublicacion = @AnioPublicacion, Cantidad = @Cantidad, " +
                               "IdAutor = @IdAutor, IdCategoria = @IdCategoria WHERE IdLibro = @IdLibro";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdLibro", libro.IdLibro);
                cmd.Parameters.AddWithValue("@Codigo", libro.Codigo);
                cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@AnioPublicacion", libro.AnioPublicacion);
                cmd.Parameters.AddWithValue("@Cantidad", libro.Cantidad);
                cmd.Parameters.AddWithValue("@IdAutor", libro.IdAutor);
                cmd.Parameters.AddWithValue("@IdCategoria", libro.IdCategoria);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idLibro)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = "DELETE FROM Libros WHERE IdLibro = @IdLibro";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdLibro", idLibro);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Libro> Buscar(string criterio)
        {
            List<Libro> lista = new List<Libro>();
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT IdLibro, Codigo, ISBN, Titulo, AnioPublicacion, Cantidad, IdAutor, IdCategoria " +
                               "FROM Libros WHERE Codigo LIKE @Criterio OR Titulo LIKE @Criterio OR ISBN LIKE @Criterio";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Libro
                        {
                            IdLibro = Convert.ToInt32(dr["IdLibro"]),
                            Codigo = dr["Codigo"]?.ToString() ?? "",
                            ISBN = dr["ISBN"]?.ToString() ?? "",
                            Titulo = dr["Titulo"]?.ToString() ?? "",
                            AnioPublicacion = Convert.ToInt32(dr["AnioPublicacion"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            IdAutor = Convert.ToInt32(dr["IdAutor"]),
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}