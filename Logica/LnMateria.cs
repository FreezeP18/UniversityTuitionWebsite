using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LnMateria
    {
        public List<Materia> CargarMaterias()
        {
            try
            {
                // Instanciar la entidad para hacer la llamada
                Datos.LdMateria datos = new Datos.LdMateria();

                // Obtener la tabla de materias desde la capa de datos
                var tabla = datos.ListarMaterias();

                // Crear una lista para almacenar las materias
                List<Materia> materias = new List<Materia>();

                // Iterar sobre las filas de la tabla para crear objetos Materia y agregarlos a la lista
                foreach (DataRow row in tabla.Rows)
                {
                    Materia materia = new Materia
                    {
                        IdMateria = Convert.ToInt32(row["IdMateria"]),
                        IdCarrera= Convert.ToInt32(row["IdCarrera"]),
                        NombreMateria = Convert.ToString(row["Materia"]),
                        Estado = Convert.ToInt32(row["Estado"]),
                        CantidadCreditos = Convert.ToInt32(row["CantidadCreditos"]),
                        //CantidadMaterias = Convert.ToInt32(row["CantidadMaterias"])
                    };

                    materias.Add(materia);
                }

                // Retornar la lista de carreras
                return materias;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y lanzar una nueva excepción con un mensaje descriptivo
                throw new Exception("Error al cargar las materias: " + ex.Message);
            }
        }


        public bool InsertarMateria(string nombreMateria, int estado)
        {
            try
            {
                // Verificar que el nombre de la carrera no sea nulo
                if (nombreMateria == null)
                {
                    throw new Exception("El nombre de la materia no debe ser nulo.");
                }

                // Instanciar la clase de datos para acceder al método de inserción
                Datos.LdMateria datos = new Datos.LdMateria();

                // Llamar al método de la capa de datos para insertar la carrera
                datos.InsertarMateria(nombreMateria, estado);

                // Si llegamos aquí, la inserción fue exitosa
                return true;
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y lanzarla nuevamente
                throw new Exception("Error al insertar la materia: " + ex.Message);
            }
        }

        public bool EditarMateria(string nombreMateria, int estado, int id)
        {
            try
            {
                // Verificar que el nombre de la carrera no sea nulo
                if (nombreMateria == null)
                {
                    throw new Exception("El nombre de la materia no debe ser nulo.");
                }

                // Instanciar la clase de datos para acceder al método de inserción
                Datos.LdMateria datos = new Datos.LdMateria();

                // Llamar al método de la capa de datos para insertar la materia
                datos.EditarMateria(nombreMateria, estado, id);

                // Si llegamos aquí, la inserción fue exitosa
                return true;
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y lanzarla nuevamente
                throw new Exception("Error al insertar la materia: " + ex.Message);
            }
        }

    }
}



