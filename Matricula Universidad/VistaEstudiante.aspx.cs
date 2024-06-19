using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Matricula_Universidad
{
    public partial class VistaEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void GuardarEstudiante(object sender, EventArgs e)
        {
            // Ocultar los divs de alerta
            divAlerta.Visible = false;
            divSuccess.Visible = false;
            divError.Visible = false;

            var nombre = txtNombreEstudiante.Value;
            var apellidos = txtApelliEstudiante.Value;
            var identificacion = txtIdentificacion.Value;
            var tipoIdentificacion = txtTipoIdentificacion.Value;
            var fechaNacimiento = DateTime.Parse(FechaNacimiento.Value);




            if (nombre == "")
            {
                divAlerta.Visible = true;
                return;
            }

            try
            {
                LnEstudiante lnEstudiante = new LnEstudiante();

                // Intentar insertar la carrera
                if (lnEstudiante.InsertarEstudiante(nombre,apellidos,identificacion,tipoIdentificacion,fechaNacimiento))
                {
                    divSuccess.Visible = true;
                    Response.Redirect("VistaEstudiante.aspx");
                    
                }
                else
                {
                    divError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y mostrar un mensaje de error
                divError.Visible = true;

            }
        }



    }
}