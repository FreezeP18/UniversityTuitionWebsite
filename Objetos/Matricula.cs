using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class Matricula
    {
        public int IdMatricula { get; set; }
        public int IdEstudiante { get; set; }
        public int IdGrupo { get; set; }
        public String FechaMatricula { get; set; }
        public string NombreMateria { get; set; }
        public string Horario { get; set; }
        public int CantidadCreditos { get; set; }
        public string NumeroGrupo { get; set; }
    }
}
