using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaApp.Entidades
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Codigo { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int AnioPublicacion { get; set; }
        public int Cantidad { get; set; }
        public int CantidadDisponible { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
    }
}
