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
    public class LdMateria
    {
        private SqlConnection _connection;

        public LdMateria()
        {
            InitConnection();
        }


        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        public DataTable ListarMaterias()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spListarMaterias", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        DataTable resultado = new DataTable("Materias");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        connection.Open();
                        adapter.Fill(resultado);

                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en LdMateria.ListarMaterias: " + ex.Message);
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



        public void InsertarMateria(string nombreMateria, int estado)
        {
            using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spCrearMateria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    command.Parameters.AddWithValue("@Materia", nombreMateria);
                    command.Parameters.AddWithValue("@Estado", estado);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error en LdMateria.InsertarMateria: {ex.Message}");
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


        public void EditarMateria(string nombreMateria, int estado, int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spActualizarMateria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    command.Parameters.AddWithValue("@IdMateria", id);
                    command.Parameters.AddWithValue("@NuevoNombre", nombreMateria);
                    command.Parameters.AddWithValue("@NuevoEstado", estado);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error en LdMateria.InsertarMateria: {ex.Message}");
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
