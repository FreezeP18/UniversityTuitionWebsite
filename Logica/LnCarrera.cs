using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LnCarrera
    {
        public List<Carrera> CargarCarreras()
        {
            try
            {
                // Instanciar la entidad para hacer la llamada
                Datos.LdCarrera datos = new Datos.LdCarrera();

                // Obtener la tabla de carreras desde la capa de datos
                var tabla = datos.ListarCarreras();

                // Crear una lista para almacenar las carreras
                List<Carrera> carreras = new List<Carrera>();

                // Iterar sobre las filas de la tabla para crear objetos Carrera y agregarlos a la lista
                foreach (DataRow row in tabla.Rows)
                {
                    Carrera carrera = new Carrera
                    {
                        Id = Convert.ToInt32(row["IdCarrera"]),
                        NombreCarrera = Convert.ToString(row["Carrera"]),
                        Estado = Convert.ToInt32(row["Estado"]),
                        CantidadEstudiantes = Convert.ToInt32(row["CantidadEstudiantes"]),
                        CantidadMaterias = Convert.ToInt32(row["CantidadMaterias"])
                    };

                    carreras.Add(carrera);
                }

                // Retornar la lista de carreras
                return carreras;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y lanzar una nueva excepción con un mensaje descriptivo
                throw new Exception("Error al cargar las carreras: " + ex.Message);
            }
        }


        public bool InsertarCarrera(string nombreCarrera, int estado)
        {
            try
            {
                // Verificar que el nombre de la carrera no sea nulo
                if (nombreCarrera == null)
                {
                    throw new Exception("El nombre de la carrera no debe ser nulo.");
                }

                // Instanciar la clase de datos para acceder al método de inserción
                Datos.LdCarrera datos = new Datos.LdCarrera();

                // Llamar al método de la capa de datos para insertar la carrera
                datos.InsertarCarrera(nombreCarrera, estado);

                // Si llegamos aquí, la inserción fue exitosa
                return true;
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y lanzarla nuevamente
                throw new Exception("Error al insertar la carrera: " + ex.Message);
            }
        }

        public bool EditarCarrera(string nombreCarrera, int estado, int id)
        {
            try
            {
                // Verificar que el nombre de la carrera no sea nulo
                if (nombreCarrera == null)
                {
                    throw new Exception("El nombre de la carrera no debe ser nulo.");
                }

                // Instanciar la clase de datos para acceder al método de inserción
                Datos.LdCarrera datos = new Datos.LdCarrera();

                // Llamar al método de la capa de datos para insertar la carrera
                datos.EditarCarrera(nombreCarrera, estado, id);

                // Si llegamos aquí, la inserción fue exitosa
                return true;
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y lanzarla nuevamente
                throw new Exception("Error al insertar la carrera: " + ex.Message);
            }
        }


    }
}


  
