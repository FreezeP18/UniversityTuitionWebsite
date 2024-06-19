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
    public class LdMatricula
    {
        private SqlConnection _connection;

        public LdMatricula()
        {
            InitConnection();
        }

        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        public DataTable ObtenerMatriculaPorIdEstudiante (int idEstudiante)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spObtenerMatriculaPorIdEstudiante", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdEstudiante", idEstudiante);

                        DataTable resultado = new DataTable("Matriculas");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        _connection.Open();
                        adapter.Fill(resultado);
                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en LdMatricula, ObtenerMatriculaPorIdEstudiante: " + ex.Message);
            }
            finally { 
                _connection.Close(); 
            }
        }

        public DataTable ObtenerMateriasDisponiblesPorEstudiante(int idEstudiante) {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spListarMateriasParaMatricularPorEstudiante", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdEstudiante", idEstudiante);

                        DataTable resultado = new DataTable("Materias");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        _connection.Open();
                        adapter.Fill(resultado);
                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en LdMatricula, ObtenerMateriasDisponiblesPorEstudiante: " + ex.Message);
            }
        }

        public void MatricularEstudiante(int idEstudiante, int idGrupo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spMatricularEstudianteEnGrupo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                        command.Parameters.AddWithValue("@IdGrupo", idGrupo);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en LdMatricula, MatricularEstudiante: " + ex.Message);
            }
        }
    }
}
