using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaApp.Entidades
{
    public class DetallePrestamo
    {
        public int IdDetalle { get; set; }
        public int IdPrestamo { get; set; }
        public int IdLibro { get; set; }
        public int Cantidad { get; set; }
    }
}