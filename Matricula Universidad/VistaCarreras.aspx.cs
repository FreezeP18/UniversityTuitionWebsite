using Logica;
using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Matricula_Universidad
{
    public partial class VistaCarreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario == null || usuario.Rol == 2)
            {
                Response.Redirect("~/Default.aspx");
            }
            divAlerta.Visible = false;
            divSuccess.Visible = false;
            divError.Visible = false;
            CargarCarreras();

            
        }

        protected void GuardarCarrera(object sender, EventArgs e)
        {
            // Ocultar los divs de alerta
            divAlerta.Visible = false;
            divSuccess.Visible = false;
            divError.Visible = false;

            var nombreCarrera = txtCarrera.Value;
            var estado = ddlEstado.Value;

            if (nombreCarrera == "")
            {
                divAlerta.Visible = true;
                return;
            }

            try
            {
                LnCarrera lnCarrera = new LnCarrera();

                // Intentar insertar la carrera
                if (lnCarrera.InsertarCarrera(nombreCarrera, int.Parse(estado)))
                {
                    divSuccess.Visible = true;
                    Response.Redirect("VistaCarreras.aspx");
                    LimpiarCampos();
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


        private void LimpiarCampos()
        {
            txtID.Value = "";
            txtCarrera.Value = "";
            ddlEstado.Value = "1";
        }


        protected void EditarCarrera(object sender, EventArgs e)
        {
            // Ocultar los divs de alerta
            divAlerta.Visible = false;
            divSuccess.Visible = false;
            divError.Visible = false;

            var nombreCarrera = txtEditCarrera.Value;
            var estado = ddlEditEstado.Value;
            var id = txtEditId.Value;

            if (nombreCarrera == "")
            {
                divAlerta.Visible = true;
                return;
            }

            try
            {
                LnCarrera lnCarrera = new LnCarrera();

                // Intentar insertar la carrera
                if (lnCarrera.EditarCarrera(nombreCarrera, int.Parse(estado), int.Parse(id)))
                {
                    divSuccess.Visible = true;
                    Response.Redirect("VistaCarreras.aspx");
                    LimpiarCampos();
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

        protected void CargarCarreras()
        {
            LnCarrera lnCarreras = new LnCarrera();
            List<Carrera> carreras = lnCarreras.CargarCarreras();

            foreach (var carrera in carreras)
            {




                string row = $@"
                <tr>
                    <td>{carrera.Id}</td>
                    <td>{carrera.NombreCarrera}</td>
                    <td>{carrera.Estado}</td>
                    <td>{carrera.CantidadEstudiantes}</td>
                    <td>{carrera.CantidadMaterias}</td>
                    <td>
                        <button type='button' class='btn btn-primary' data-toggle='modal' data-target='#modalEditarCarrera' 
                        data-id='{carrera.Id}' data-nombre='{carrera.NombreCarrera}' data-estado='{carrera.Estado}'
                        onclick='cargarDatosModal(this)'>Editar</button>
                    </td>
                </tr>";

                tablaCarreras.InnerHtml += row;
            }
        }

        public void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}