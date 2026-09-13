using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaApp.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string ProgramaAcademico { get; set; }
    }
}