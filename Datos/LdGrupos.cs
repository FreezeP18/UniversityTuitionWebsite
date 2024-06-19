using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Datos
{
    public class LdGrupos
    {

        private SqlConnection _connection;

        public LdGrupos()
        {
            InitConnection();
        }


        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        public DataTable ListarGrupos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SpGruposConMateria", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        DataTable resultado = new DataTable("Grupos");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        connection.Open();
                        adapter.Fill(resultado);

                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en LdGrupos.ListarGrupos: " + ex.Message);
            }
            finally
            {
                //preguntar si la conexion esta abierta
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

            }
        }//public DataTable Listargrupos()


        public void AgregarGrupo(int idMateria, int numeroGrupo, string horario, int capacidad, string estado)
        {
            using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spAgregarGrupo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdMateria", idMateria);
                    command.Parameters.AddWithValue("@NumeroGrupo", numeroGrupo);
                    command.Parameters.AddWithValue("@Horario", horario);
                    command.Parameters.AddWithValue("@Capacidad", capacidad);
                    command.Parameters.AddWithValue("@Estado", estado);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error en LdGrupos.AgregarGrupo: {ex.Message}");
                    }
                }
            }
        }// public void AgregarGrupo



    }// public class LdGrupos
}//namespace Datos
