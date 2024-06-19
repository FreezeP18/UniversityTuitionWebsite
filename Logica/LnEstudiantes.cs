using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;


namespace Logica
{
    public class LnEstudiantes
    {

        public List<Estudiante> CargarEstudiantes()
        {
            try
            {

                Datos.LdEstudiantes datos = new Datos.LdEstudiantes();


                var tabla = datos.ListarEstudiantes();


                List<Estudiante> estudiantes = new List<Estudiante>();

                foreach (DataRow row in tabla.Rows)
                {
                    Estudiante estudiante = new Estudiante
                    {
                        IdEstudiante = Convert.ToInt32(row["IdEstudiante"]),
                        Nombre = Convert.ToString(row["Nombre"]),
                        Apellidos = Convert.ToString(row["Apellidos"]),
                        Identificacion = Convert.ToString(row["Identificacion"]),
                        TipoIdentificacion = Convert.ToString(row["TipoIdentificacion"]),
                        FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                        IdCarrera = Convert.ToInt32(row["IdCarrera"]),
                        EstadoEstudiante = Convert.ToString(row["EstadoEstudiante"]),
                        IdMatricula = row["IdMatricula"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["IdMatricula"]),
                        IdGrupo = row["IdGrupo"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["IdGrupo"]),
                        FechaMatricula = row["FechaMatricula"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["FechaMatricula"])
                    };

                    estudiantes.Add(estudiante);
                }

                // Retornar la lista de carreras
                return estudiantes;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y lanzar una nueva excepción con un mensaje descriptivo
                throw new Exception("Error al cargar los estudiantes: " + ex.Message);
            }
        }

        public bool InsertarEstudiante(string nombre, string apellidos, string identificacion, string tipoIdentificacion, DateTime fechaNacimiento, int idCarrera, string estadoEstudiante)
        {
            try
            {
                // Verificar que los campos requeridos no sean nulos ni vacíos
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    throw new Exception("El nombre no debe ser nulo o vacío.");
                }
                if (string.IsNullOrWhiteSpace(apellidos))
                {
                    throw new Exception("Los apellidos no deben ser nulos o vacíos.");
                }
                if (string.IsNullOrWhiteSpace(identificacion))
                {
                    throw new Exception("La identificación no debe ser nula o vacía.");
                }

                // Instanciar la clase de datos para acceder al método de inserción de estudiantes
                Datos.LdEstudiantes datos = new Datos.LdEstudiantes();

                // Llamar al método de la capa de datos para insertar el estudiante
                datos.InsertarEstudiante(nombre, apellidos, identificacion, tipoIdentificacion, fechaNacimiento, idCarrera, estadoEstudiante);

                // Si la inserción fue exitosa, retornar true
                return true;
            }
            catch (Exception ex)
            {
                // Manejar excepciones y propagar un mensaje claro
                throw new Exception("Error al insertar el estudiante: " + ex.Message);
            }
        }

        public Estudiante ObtenerEstudiantePorIdUsuario(int idUsuario) {
            try
            {
                Datos.LdEstudiantes datos = new Datos.LdEstudiantes();
                DataTable tabla = datos.ObtenerEstudiantePorIdUsuario(idUsuario);

                if (tabla.Rows.Count > 0)
                {
                    DataRow row = tabla.Rows[0];
                    Estudiante estudiante = new Estudiante
                    {
                        IdEstudiante = Convert.ToInt32(row["IdEstudiante"]),
                        Nombre = Convert.ToString(row["Nombre"]),
                        Apellidos = Convert.ToString(row["Apellidos"]),
                        Identificacion = Convert.ToString(row["Identificacion"]),
                        TipoIdentificacion = Convert.ToString(row["TipoIdentificacion"]),
                        FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                        IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    };

                    return estudiante;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el estudiante por ID de usuario: " + ex.Message);
            }
        }
    }
}
