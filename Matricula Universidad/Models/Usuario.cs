using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matricula_Universidad.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int Rol { get; set; }
    }
}