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
    public class LdUsuario
    {

        private SqlConnection _connection;

        public LdUsuario()
        {
            InitConnection();
        }


        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        public DataTable Autentica(string user, string password)
        {
            //definir el comando y configurarlo
            SqlCommand cmdEjecutar = new SqlCommand();
            cmdEjecutar.CommandText = "[dbo].[spAutenticaUsuario]";
            cmdEjecutar.CommandType = CommandType.StoredProcedure;

            //si es tipo texto
            //cmdEjecutar.CommandText = "select * from EstadoCivil";
            //cmdEjecutar.CommandType = CommandType.Text;

            //se asigna el string de conexion a la bd
            cmdEjecutar.Connection = _connection;

            DataTable resultado = new DataTable("Usuarios");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdEjecutar);

            try
            {
                cmdEjecutar.Parameters.AddWithValue("@usuario", user);
                cmdEjecutar.Parameters.AddWithValue("@password", password);

                //abrir la conexion con la db
                _connection.Open();
                //ejecutar el commando
                adapter.Fill(resultado);

                //se debe cerrar la bd pero se va a cerrar en el Finally para el ejemplo
                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //preguntar si la conexion esta abierta
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
                cmdEjecutar.Dispose();
            }

        }


    }
}
