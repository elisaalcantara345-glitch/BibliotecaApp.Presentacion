using Microsoft.Data.SqlClient; // O System.Data.SqlClient según tu proyecto

namespace BibliotecaApp.Datos
{
    public class Conexion
    {
        // Ajusta la cadena de conexión con el nombre de tu servidor/instancia local
        private static readonly string cadena = "Server=localhost; Database=BibliotecaDB; Integrated Security=True; TrustServerCertificate=True;";

        // Propiedad pública estática para cuando se accede directamente via Conexion.Cadena
        public static string Cadena => cadena;

        // Método de instancia (sin static) para llamadas desde una instancia de Conexion
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}