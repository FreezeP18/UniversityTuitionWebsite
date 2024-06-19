using Matricula_Universidad.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Matricula_Universidad.DAL
{
    public class CarreraDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public Boolean GuardarCarrera(Carrera carrera)
        {
            try
            {
                // Call the store procedure named spCrearCarrera with the parameters @NombreCarrera and @Estado
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("spCrearCarrera", connection);
                connection.Open();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Carrera", carrera.NombreCarrera);
                command.Parameters.AddWithValue("@Estado", carrera.Estado);

                command.ExecuteNonQuery();

                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Error en CarreraDAL.GuardarCarrera: " + ex.Message);
            }
        }

        public void ActualizarCarrera(Carrera carrera) {
            try {
                string query = "UPDATE Carreras SET Carrera = @NombreCarrera, Estado = @Estado WHERE IdCarrera = @IdCarrera";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreCarrera", carrera.NombreCarrera);
                        command.Parameters.AddWithValue("@Estado", carrera.Estado);
                        command.Parameters.AddWithValue("@IdCarrera", carrera.Id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex) {
                throw new Exception("Error en CarreraDAL.ActualizarCarrera: " + ex.Message);
            }
        }

        public Carrera ObtenerCarreraPorId(int idCarrera)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("spObtenerCarreraPorId", connection);
                connection.Open();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdCarrera", idCarrera);

                SqlDataReader reader = command.ExecuteReader();
                var NuevaCarrera = new Carrera();
                while (reader.Read())
                {
                    NuevaCarrera.Id = Convert.ToInt32(reader["IdCarrera"]);
                    NuevaCarrera.NombreCarrera = Convert.ToString(reader["Carrera"]);
                    NuevaCarrera.Estado = Convert.ToInt32(reader["Estado"]);
                }
                reader.Close();

                connection.Close();
                return NuevaCarrera;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error en CarreraDAL.ObtenerCarreras: " + ex.Message);
            }
        }

        public List<Carrera> ObtenerCarreras() {
            try {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("spListarCarreras", connection);
                connection.Open();

                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader(); 
                var listaCarreras = new List<Carrera>();
                while (reader.Read())
                {
                    
                    var carrera = new Carrera
                    {
                        Id = Convert.ToInt32(reader["IdCarrera"]),
                        NombreCarrera = Convert.ToString(reader["Carrera"]),
                        Estado = Convert.ToInt32(reader["Estado"]),
                        CantidadEstudiantes = Convert.ToInt32(reader["CantidadEstudiantes"]),
                        CantidadMaterias = Convert.ToInt32(reader["CantidadMaterias"])
                    };
                    listaCarreras.Add(carrera);
                }
                reader.Close();

                connection.Close();
                return listaCarreras;
            } catch (Exception ex) {
                return null;
                throw new Exception("Error en CarreraDAL.ObtenerCarreras: " + ex.Message);
            }
        }
    }
}