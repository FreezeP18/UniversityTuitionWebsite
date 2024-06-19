using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace Matricula_Universidad
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divAlerta.Visible = false;
        }

        protected void IniciarSesion(object sender, EventArgs e)
        {
            divAlerta.Visible = false;
            string nombreUsuario = txtUsuario.Text;
            string password = txtPassword.Text;

            LnUsuarios lnUsuarios = new LnUsuarios(); // Cambio de UsuarioDAL a LnUsuarios
            List<Usuario> usuarios = lnUsuarios.AutenticaUsuario(nombreUsuario, password); // Cambio de Login a AutenticaUsuario
            LnEstudiantes lnEstudiantes = new LnEstudiantes();

            if (usuarios.Count > 0)
            {
                Usuario usuario = usuarios[0]; // Tomamos el primer usuario de la lista
                HttpContext.Current.Session["Usuario"] = usuario;
                if (usuario.Rol == 1)
                {
                    Response.Redirect("Administracion.aspx");
                }
                else
                {
                    Estudiante estudiante = lnEstudiantes.ObtenerEstudiantePorIdUsuario(usuario.Id);
                    HttpContext.Current.Session["Estudiante"] = estudiante;
                    Response.Redirect("MatriculaEstudiante.aspx");
                }
            }
            else
            {
                divAlerta.Visible = true;
            }
        }
    }
}
