using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class LdEstudiantes
    {

        private SqlConnection _connection;

        public LdEstudiantes()
        {
            InitConnection();
        }

        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        public DataTable ListarEstudiantes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spListarEstudiantes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        DataTable resultado = new DataTable("Estudiantes");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        connection.Open();
                        adapter.Fill(resultado);

                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en LdEstudiantes, cargarEstudiantes: " + ex.Message);
            }
            finally
            {
                //preguntar si la conexion esta abierta
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

            }
        }

        public void InsertarEstudiante(string nombre, string apellidos, string identificacion, string tipoIdentificacion, DateTime fechaNacimiento, int idCarrera, string estadoEstudiante)
        {
            using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spCrearEstudiante", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al comando SQL para el procedimiento almacenado
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellidos", apellidos);
                    command.Parameters.AddWithValue("@Identificacion", identificacion);
                    command.Parameters.AddWithValue("@TipoIdentificacion", tipoIdentificacion);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@IdCarrera", idCarrera);
                    command.Parameters.AddWithValue("@EstadoEstudiante", estadoEstudiante);

                    try
                    {
                        connection.Open();  // Abrir la conexión a la base de datos
                        command.ExecuteNonQuery();  // Ejecutar el comando para insertar el estudiante
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        throw new Exception($"Error en LdEstudiante.InsertarEstudiante: {ex.Message}");
                    }
                    finally
                    {
                        // Cerrar la conexión si está abierta
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        public DataTable ObtenerEstudiantePorIdUsuario(int idUsuario) {
            using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spObtenerEstudiantePorIdUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    DataTable resultado = new DataTable("Estudiante");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    connection.Open();
                    adapter.Fill(resultado);

                    return resultado;
                }
            }
        }
    }

}

