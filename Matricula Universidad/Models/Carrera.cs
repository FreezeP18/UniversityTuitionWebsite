using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matricula_Universidad.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string NombreCarrera { get; set; }
        public int Estado { get; set; }
        public int CantidadEstudiantes { get; set; }
        public int CantidadMaterias { get; set; }
    }
}