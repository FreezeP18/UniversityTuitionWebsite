using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LnEstudiante
    {

        public bool InsertarEstudiante(string nombre, string apellidos, string identificacion, string tipIdentificacion, DateTime fechaNacioniento)
        {
            try
            {
                // Verificar que el nombre de la carrera no sea nulo
                if (nombre == null)
                {
                    throw new Exception("El nombre del estudiante no debe ser nulo.");
                }

                // Instanciar la clase de datos para acceder al método de inserción
                Datos.LdEstudiante datos = new Datos.LdEstudiante();

                // Llamar al método de la capa de datos para insertar la carrera
                datos.InsertarEstudiante(nombre,apellidos,identificacion,tipIdentificacion,fechaNacioniento);

                // Si llegamos aquí, la inserción fue exitosa
                return true;
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y lanzarla nuevamente
                throw new Exception("Error al insertar el estudiante: " + ex.Message);
            }
        }//fin   public bool InsertarEstudiante

       
    }//fin public class LnEstudiante

}//fin namespace Logica
