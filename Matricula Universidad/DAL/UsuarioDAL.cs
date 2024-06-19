using Matricula_Universidad.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Matricula_Universidad.DAL
{
    public class UsuarioDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;


        public Usuario Login(string nombreUsuario, string password)
        {
            try {
                Usuario usuario = null;
                string query = "SELECT IdUsuario, Usuario, IdRol FROM Usuarios WHERE Usuario = @Usuario AND Password = @Password";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", nombreUsuario);
                        command.Parameters.AddWithValue("@Password", password);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["IdUsuario"]),
                                NombreUsuario = Convert.ToString(reader["Usuario"]),
                                Rol = Convert.ToInt32(reader["IdRol"])
                            };
                        }
                    }
                }
                return usuario;
            } catch (Exception ex) {
                throw new Exception("Error en UsuarioDAL.Login: " + ex.Message);
            }
        }
    }
}