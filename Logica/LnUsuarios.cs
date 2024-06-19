using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;
using Datos;
using System.Data;
namespace Logica
{
    public class LnUsuarios
    {

        public List<Usuario> AutenticaUsuario(string user, string password)
        {
            try
            {
                //instanciar la entidad para hacer la llamada

                Datos.LdUsuario datos = new Datos.LdUsuario();

                var tabla = datos.Autentica(user, password);

                //List<oArticulo> listado = util.ConvertDataTableToList<oArticulo>(tabla);


                List<Usuario> listado = tabla.AsEnumerable()
             .Select(row => new Usuario
             {
                 Id = row.Field<int>("IdUsuario"),
                 NombreUsuario = row.Field<string>("Usuario"),
                 Rol = row.Field<int>("IdRol")
             })
            .ToList();

                return listado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
    

