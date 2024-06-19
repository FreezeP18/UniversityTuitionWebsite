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
    public partial class VistaMaterias : System.Web.UI.Page
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
            CargarMaterias();
        }

        protected void GuardarMateria(object sender, EventArgs e)
        {
            // Ocultar los divs de alerta
            divAlerta.Visible = false;
            divSuccess.Visible = false;
            divError.Visible = false;

            var nombreMateria = txtMateria.Value;
            var estado = ddlEstado.Value;

            if (nombreMateria == "")
            {
                divAlerta.Visible = true;
                return;
            }

            try
            {
                LnMateria lnMateria = new LnMateria();

                // Intentar insertar la materia
                if (lnMateria.InsertarMateria(nombreMateria, int.Parse(estado)))
                {
                    divSuccess.Visible = true;
                    Response.Redirect("VistaMaterias.aspx");
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
            txtMateria.Value = "";
            ddlEstado.Value = "1";
        }


        protected void EditarMateria(object sender, EventArgs e)
        {
            // Ocultar los divs de alerta
            divAlerta.Visible = false;
            divSuccess.Visible = false;
            divError.Visible = false;

            var nombreMateria = txtEditMateria.Value;
            var estado = ddlEditEstado.Value;
            var id = txtEditId.Value;

            if (nombreMateria == "")
            {
                divAlerta.Visible = true;
                return;
            }

            try
            {
                LnMateria lnMateria = new LnMateria();

                // Intentar insertar la materia
                if (lnMateria.EditarMateria(nombreMateria, int.Parse(estado), int.Parse(id)))
                {
                    divSuccess.Visible = true;
                    Response.Redirect("VistaMaterias.aspx");
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

        protected void CargarMaterias()
        {
            LnMateria lnMaterias = new LnMateria();
            List<Materia> materias = lnMaterias.CargarMaterias();

            foreach (var materia in materias)
            {




                string row = $@"
                <tr>
                    <td>{materia.IdMateria}</td>
                    <td>{materia.NombreMateria}</td>
                    <td>{materia.Estado}</td>
                    <td>{materia.CantidadCreditos}</td>
                    <td>{materia.CantidadEstudiantes}</td>
                    <td>
                        <button type='button' class='btn btn-primary' data-toggle='modal' data-target='#modalEditarMateria' 
                        data-id='{materia.IdMateria}' data-nombre='{materia.NombreMateria}' data-estado='{materia.Estado}'
                        onclick='cargarDatosModal(this)'>Editar</button>
                    </td>
                </tr>";

                tablaMaterias.InnerHtml += row;
            }
        }

        public void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}