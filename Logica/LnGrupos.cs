using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LnGrupos
    {

        public List<Grupo> CargarGrupos()
        {
            try
            {
                // Instancia para obtener los datos
                Datos.LdGrupos datos = new Datos.LdGrupos();

                // Obtener la tabla de grupos desde la capa de datos
                DataTable tabla = datos.ListarGrupos();

                // Crear una lista para almacenar los grupos
                List<Grupo> grupos = new List<Grupo>();

                // Iterar sobre las filas del DataTable para crear objetos Grupo y agregarlos a la lista
                foreach (DataRow row in tabla.Rows)
                {
                    Grupo grupo = new Grupo
                    {
                        IdGrupo = Convert.ToInt32(row["IdGrupo"]),
                        NombreMateria = Convert.ToString(row["NombreMateria"]),
                        NumeroGrupo = Convert.ToInt32(row["NumeroGrupo"]),
                        Horario = Convert.ToString(row["Horario"]),
                        Capacidad = Convert.ToInt32(row["Capacidad"]),
                        Estado = Convert.ToString(row["Estado"])  // Cambiado para ser un string
                    };

                    grupos.Add(grupo);
                }

                // Devolver la lista de grupos
                return grupos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones con un mensaje descriptivo
                throw new Exception("Error al cargar los grupos: " + ex.Message);
            }
        }

        



        public bool AgregarGrupo(int idMateria, int numeroGrupo, string horario, int capacidad, string estado)
        {
            try
            {
                // Verificar que el nombre de la carrera no sea nulo
                if (horario == null)
                {
                    throw new Exception("El nombre de la carrera no debe ser nulo.");
                }

                // Instanciar la clase de datos para acceder al método de inserción
                Datos.LdGrupos datos = new Datos.LdGrupos();

                // Llamar al método de la capa de datos para insertar la carrera
                datos.AgregarGrupo(idMateria, numeroGrupo, horario, capacidad, estado);

                // Si llegamos aquí, la inserción fue exitosa
                return true;
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y lanzarla nuevamente
                throw new Exception("Error al insertar la carrera: " + ex.Message);
            }
        }





    }//public class LnGrupos
}//namespace Logica
