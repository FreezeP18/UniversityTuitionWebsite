using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Datos
{
    public class LdCarrera
    {
        private SqlConnection _connection;

        public LdCarrera()
        {
            InitConnection();
        }


        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        public DataTable ListarCarreras()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spListarCarreras", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        DataTable resultado = new DataTable("Carreras");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        connection.Open();
                        adapter.Fill(resultado);

                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en LdCarrera.ListarCarreras: " + ex.Message);
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



        public void InsertarCarrera(string nombreCarrera, int estado)
        {
            using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spCrearCarrera", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    command.Parameters.AddWithValue("@Carrera", nombreCarrera);
                    command.Parameters.AddWithValue("@Estado", estado);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error en LdCarrera.InsertarCarrera: {ex.Message}");
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



        }


        public void EditarCarrera(string nombreCarrera, int estado, int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spActualizarCarrera", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    command.Parameters.AddWithValue("@IdCarrera", id);
                    command.Parameters.AddWithValue("@NuevoNombre", nombreCarrera);
                    command.Parameters.AddWithValue("@NuevoEstado", estado);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error en LdCarrera.InsertarCarrera: {ex.Message}");
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
        }
    }
}
