using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace Datos
{
    public class LdEstudiante
    {
        private SqlConnection _connection;

        public LdEstudiante()
        {
            InitConnection();
        }


        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }


        public void InsertarEstudiante(string nombre, string apellidos, string identificacion, string tipIdentificacion, DateTime fechaNacioniento)
        {
            using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spCrearEstudiante", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellidos", apellidos);
                    command.Parameters.AddWithValue("@Identificacion", identificacion);
                    command.Parameters.AddWithValue("@TipoIdentificacion", tipIdentificacion);
                    command.Parameters.AddWithValue("@@FechaNacimiento", fechaNacioniento);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error en LdEstudiante.InsertarEstudiante: {ex.Message}");
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
            }
        }// fin InsertarEstudiant

        public DataTable BuscarEstudiante(string identificacion)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spBuscarEstudiantePorIdentificacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    command.Parameters.AddWithValue("@Identificacion", identificacion);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error en LdEstudiante.BuscarEstudiante: {ex.Message}");
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
            }

            return dataTable;
        

    

    }//Fin BuscarEstudiante
       
    }//fin public class LdEstudiante
}// fin namespace Datos
