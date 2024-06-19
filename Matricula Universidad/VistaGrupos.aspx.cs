using Logica;
using Objetos;
using System;
using System.Collections.Generic;


namespace Matricula_Universidad
{
    public partial class VistaGrupos : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            divAlerta.Visible = false;
            divSuccess.Visible = false;
            divError.Visible = false;
            CargarGrupos();
        }

        // Método para agregar un grupo
        protected void AgregarGrupo(object sender, EventArgs e)
        {

            // Ocultar los divs de alerta
            divAlerta.Visible = false;
            divSuccess.Visible = false;
            divError.Visible = false;

            //cambiar esto ***********
            var idMateria = txtIdMateria.Value;
            var numeroGrupo = txtNumeroGrupo.Value;
            var Horario = txtHorario.Value;
            var Capacidad = txtCapacidad.Value;
            var Estado = ddlEstado.Value;

            if (numeroGrupo == "")
            {
                divAlerta.Visible = true;
                return;
            }

            try
            {

                LnGrupos lnGrupos = new LnGrupos();
                lnGrupos.AgregarGrupo(int.Parse(idMateria), int.Parse(numeroGrupo), Horario, int.Parse(Capacidad), Estado);
                divSuccess.Visible = true;
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Manejar el error como sea necesario
                Response.Write($"Error al agregar grupo: {ex.Message}");
            }
        }


        private void LimpiarCampos()
        {
            txtIdMateria.Value = "";
            txtNumeroGrupo.Value = "";
            txtHorario.Value = "";
            txtCapacidad.Value = "";
            ddlEstado.Value = "";
        }





        protected void CargarGrupos()
        {
            LnGrupos lnGrupos = new LnGrupos();
            List<Grupo> grupos = lnGrupos.CargarGrupos();

            tablaGrupos.InnerHtml = "";  // Limpia las filas antes de agregar nuevas

            foreach (var grupo in grupos)
            {
                string row = $@"
            <tr>

            <td>{grupo.NombreMateria}</td>
            <td>{grupo.NumeroGrupo}</td>
            <td>{grupo.Horario}</td>
            <td>{grupo.Capacidad}</td>
            <td>{grupo.Estado}</td>

            </tr>";

                tablaGrupos.InnerHtml += row;
            }
        }

        public void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }

}