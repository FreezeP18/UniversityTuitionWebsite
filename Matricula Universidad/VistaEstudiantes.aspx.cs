using Logica;
using Objetos;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Matricula_Universidad
{
    public partial class WebForm1 : System.Web.UI.Page
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
            CargarEstudiantes();
           
        }
        protected void GuardarEstudiante(object sender, EventArgs e)
        {
            // Ocultar los divs de alerta para evitar que se muestren mensajes anteriores
            divAlerta.Visible = false;
            divSuccess.Visible = false;
            divError.Visible = false;
     
            // Recuperar los valores de los campos del formulario
            var nombre = txtNombre.Value;
            var apellidos = txtApellidos.Value;
            var identificacion = txtIdentificacion.Value;
            var tipoIdentificacion = ddlTipoIdentificacion.Value;
            var fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Value);
            var idCarrera = ddlCarrera.Value;
            var estadoEstudiante = ddlEstadoEstudiante.Value;

            // Validar campos requeridos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos) || string.IsNullOrWhiteSpace(identificacion))
            {
                divAlerta.Visible = true;
                return; // Si falta algún campo requerido, mostrar alerta y salir
            }

            try
            {
                // Instanciar la lógica de negocio para estudiantes
                LnEstudiantes lnEstudiantes = new LnEstudiantes();

                // Intentar insertar el estudiante
                if (lnEstudiantes.InsertarEstudiante(nombre, apellidos, identificacion, tipoIdentificacion, fechaNacimiento, int.Parse(idCarrera), estadoEstudiante))
                {
                    divSuccess.Visible = true; // Indicar éxito
                    LimpiarCampos(); // Limpiar campos después de una inserción exitosa
                    Response.Redirect("VistaEstudiantes.aspx");
                }
                else
                {
                    divError.Visible = true; // Indicar error
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y mostrar un mensaje de error
                divError.Visible = true; // Indicar error
                divError.InnerText = $"Error al guardar el estudiante: {ex.Message}"; // Mostrar mensaje de error
            }
        }

        // Método para limpiar campos del formulario
        protected void LimpiarCampos()
        {
            txtNombre.Value = string.Empty;
            txtApellidos.Value = string.Empty;
            txtIdentificacion.Value = string.Empty;
            txtFechaNacimiento.Value = string.Empty;
            ddlEstadoEstudiante.SelectedIndex = 0; 
        }

       



        protected void CargarEstudiantes()
        {
            // Instanciar la capa de lógica de negocios para estudiantes
            LnEstudiantes lnEstudiantes = new LnEstudiantes();
            // Cargar la lista de estudiantes desde la base de datos
            List<Estudiante> estudiantes = lnEstudiantes.CargarEstudiantes();

            // Limpiar la tabla antes de agregar nuevas filas
            tablaEstudiantes.InnerHtml = string.Empty;

            // Iterar sobre la lista de estudiantes para crear filas HTML
            foreach (var estudiante in estudiantes)
            {
                // Formatear fecha de nacimiento para presentación
                string fechaNacimiento = estudiante.FechaNacimiento.ToShortDateString();

                // Formatear fecha de matrícula, si está disponible
                string fechaMatricula = estudiante.FechaMatricula.HasValue ?
                                        estudiante.FechaMatricula.Value.ToShortDateString() : "N/A";

                string row = $@"
        <tr>
            <td>{estudiante.IdEstudiante}</td>  <!-- ID del estudiante -->
            <td>{estudiante.Nombre} {estudiante.Apellidos}</td>  <!-- Nombre completo -->
            <td>{estudiante.Identificacion}</td>  <!-- Número de identificación -->
            <td>{estudiante.TipoIdentificacion}</td>  <!-- Tipo de identificación -->
            <td>{fechaNacimiento}</td>  <!-- Fecha de nacimiento -->
            <td>{estudiante.EstadoEstudiante}</td>  <!-- Estado del estudiante -->
            <td>{estudiante.IdCarrera}</td>  <!-- ID de la carrera -->
            <td>{estudiante.IdMatricula?.ToString() ?? "N/A"}</td>  <!-- ID de la matrícula -->
            <td>{estudiante.IdGrupo?.ToString() ?? "N/A"}</td>  <!-- ID del grupo -->
            <td>{fechaMatricula}</td>  <!-- Fecha de matrícula -->
        </tr>";

                // Agregar la fila al contenedor de la tabla
                tablaEstudiantes.InnerHtml += row;
            }
        }

        public void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Default.aspx");
        }

    }
}
