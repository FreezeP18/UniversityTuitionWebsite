using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Logica
{
    public class LnMatricula
    {
        public List<Matricula> ObtenerMatriculaPorIdEstudiante (int idEstudiante)
        {
            try
            {
                Datos.LdMatricula datos = new Datos.LdMatricula();
                var tabla = datos.ObtenerMatriculaPorIdEstudiante(idEstudiante);
                List<Matricula> matriculas = new List<Matricula>();
                foreach (DataRow row in tabla.Rows)
                {
                    Matricula matricula = new Matricula
                    {
                        NumeroGrupo = Convert.ToString(row["NumeroGrupo"]),
                        NombreMateria = Convert.ToString(row["Materia"]),
                        Horario = Convert.ToString(row["Horario"]),
                        CantidadCreditos = Convert.ToInt32(row["CantidadCreditos"]),
                        IdGrupo = Convert.ToInt32(row["IdGrupo"]),
                        FechaMatricula = Convert.ToString(row["FechaMatricula"]),
                    };
                    matriculas.Add(matricula);
                }
                return matriculas;
            }
            catch (Exception e)
            {
                throw new Exception("Error en LnMatricula, ObtenerMatriculaPorIdEstudiante: " + e.Message);
            }
        }

        public List<Matricula> ObtenerMateriasDisponiblesPorEstudiante(int idEstudiante)
        {
            try
            {
                Datos.LdMatricula datos = new Datos.LdMatricula();
                var tabla = datos.ObtenerMateriasDisponiblesPorEstudiante(idEstudiante);
                List<Matricula> matriculas = new List<Matricula>();
                foreach (DataRow row in tabla.Rows)
                {
                    Matricula matricula = new Matricula
                    {
                        NombreMateria = Convert.ToString(row["Materia"]),
                        CantidadCreditos = Convert.ToInt32(row["CantidadCreditos"]),
                        NumeroGrupo = Convert.ToString(row["NumeroGrupo"]),
                        Horario = Convert.ToString(row["Horario"]),
                        IdGrupo = Convert.ToInt32(row["IdGrupo"]),
                    };
                    matriculas.Add(matricula);
                }
                return matriculas;
            }
            catch (Exception e)
            {
                throw new Exception("Error en LnMatricula, ObtenerMateriasDisponiblesPorEstudiante: " + e.Message);
            }
        }

        public void MatricularEstudiante(int idEstudiante, int idGrupo)
        {
            try
            {
                Datos.LdMatricula datos = new Datos.LdMatricula();
                datos.MatricularEstudiante(idEstudiante, idGrupo);
            }
            catch (Exception e)
            {
                throw new Exception("Error en LnMatricula, MatricularEstudiante: " + e.Message);
            }
        }
    }
}
