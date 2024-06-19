using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class Estudiante
    {

        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdCarrera { get; set; }
        public string EstadoEstudiante { get; set; }


        public int? IdMatricula { get; set; }
        public int? IdGrupo { get; set; }
        public DateTime? FechaMatricula { get; set; }

        public string NombreEst { get; set; }

        public string identificacion { get; set; }

        public DateTime Fechanacimiento { get; set; }
        public DateTime AnoIngreso { get; set; }
        public string CarreraPertenece { get; set; }

        public int IdUsuario { get; set; }

    }
}