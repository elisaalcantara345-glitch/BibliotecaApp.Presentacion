using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaApp.Entidades
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
