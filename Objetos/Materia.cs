using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class Materia
    {

        public int IdMateria { get; set; }
        public string NombreMateria { get; set; }
        public int Estado { get; set; }
        public int CantidadEstudiantes { get; set; }
        public int CantidadCreditos { get; set; }
        public int IdCarrera { get; set; }

        public int IdGrupo { get; set; }
    }
}

