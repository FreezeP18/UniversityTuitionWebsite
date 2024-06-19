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
    public partial class MatriculaEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario == null)
            {
                Response.Redirect("~/Default.aspx");
            } else if(usuario.Rol == 1) {
                Response.Redirect("~/Administracion.aspx");
            }

            Estudiante estudiante = (Estudiante)Session["Estudiante"];
            nombreEstudiante.Text = estudiante.Nombre + " " + estudiante.Apellidos;
            verMatricula.Visible = false;
            listaMateriasDisponibles.Visible = false;
            listaMateriasMatriculadas.Visible = false;
            divFinalizarMatricula.Visible = false;
            cargarMatricula();
            if (Session["Matricula"] != null)
            {
                List<string> materiasMatriculadas;
                materiasMatriculadas = (List<string>)Session["Matricula"];
                MostrarMateriasEnSesion(materiasMatriculadas);
            }
        }


        public void cargarMatricula()
        {
            Estudiante estudiante = (Estudiante)Session["Estudiante"];
            LnMatricula lnMatricula = new LnMatricula();
            List<Matricula> matriculas = lnMatricula.ObtenerMatriculaPorIdEstudiante(estudiante.IdEstudiante);
            if (matriculas.Count > 0) {
                verMatricula.Visible = true;
                informacionMatricula.Text = "El estudiante ha matriculado " + matriculas.Count + " materia(s).";
                foreach (var matricula in matriculas)
                {
                    string row = $@"
                    <tr>
                        <td>{matricula.NumeroGrupo}</td>
                        <td>{matricula.FechaMatricula.ToString()}</td>
                        <td>{matricula.NombreMateria}</td>
                        <td>{matricula.Horario}</td>
                        <td>{matricula.CantidadCreditos}</td>
                    </tr>";

                    tableMatricula.InnerHtml += row;
                }
            }
            else {
                informacionMatricula.Text = "El estudiante no ha matriculado ninguna materia.";
                List<Matricula> materiasDisponibles = lnMatricula.ObtenerMateriasDisponiblesPorEstudiante(estudiante.IdEstudiante);
                listaMateriasDisponibles.Visible = true;
                if (materiasDisponibles != null && materiasDisponibles.Count > 0)
                {
                    // Recorrer la lista de materias disponibles
                    foreach (var materia in materiasDisponibles)
                    {
                        // Crear una nueva fila para la tabla
                        TableRow row = new TableRow();

                        // Crear celdas para los datos de la materia
                        TableCell cellNombreMateria = new TableCell();
                        cellNombreMateria.Text = materia.NombreMateria;
                        row.Cells.Add(cellNombreMateria);

                        TableCell cellCreditos = new TableCell();
                        cellCreditos.Text = materia.CantidadCreditos.ToString();
                        row.Cells.Add(cellCreditos);

                        TableCell cellHorario = new TableCell();
                        cellHorario.Text = materia.Horario;
                        row.Cells.Add(cellHorario);

                        TableCell cellMatricular = new TableCell();
                        Button btnMatricular = new Button();
                        btnMatricular.Text = "Matricular";
                        btnMatricular.CommandArgument = materia.NombreMateria;
                        btnMatricular.Command += BtnMatricular_Click;
                        btnMatricular.CssClass = "btn btn-primary";
                        // Verificar si la materia ya está matriculada
                        if (buscarMateriaEnSesion(materia.NombreMateria))
                        {
                            btnMatricular.Enabled = false;
                        }
                        cellMatricular.Controls.Add(btnMatricular);
                        row.Cells.Add(cellMatricular);

                        // Agregar la fila a la tabla
                        tablaMateriasDisponibles.Rows.Add(row);
                    }
                    // Crear sesion con materias disponibles
                    HttpContext.Current.Session["MateriasDisponibles"] = materiasDisponibles;
                }
            }
        }

        protected void BtnMatricular_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de la materia seleccionada
            Button btnMatricular = (Button)sender;
            string nombreMateria = btnMatricular.CommandArgument;

            // Guardar la materia en sesión
            List<string> materiasMatriculadas;
            if (Session["Matricula"] != null)
            {
                materiasMatriculadas = (List<string>)Session["Matricula"];
            }
            else
            {
                materiasMatriculadas = new List<string>();
            }
            materiasMatriculadas.Add(nombreMateria);
            Session["Matricula"] = materiasMatriculadas;
            Response.Redirect("MatriculaEstudiante.aspx");
        }

        protected Boolean buscarMateriaEnSesion(String nombreMateria) {             
            List<string> materiasMatriculadas;
            if (Session["Matricula"] != null)
            {
                materiasMatriculadas = (List<string>)Session["Matricula"];
                if (materiasMatriculadas.Contains(nombreMateria))
                {
                    return true;
                }
            }
            return false;
        }

        protected void MostrarMateriasEnSesion(List<String> materiasMatriculadas) {
            
            if (materiasMatriculadas.Count > 0)
            {
                listaMateriasMatriculadas.Visible = true;
                divFinalizarMatricula.Visible = true;
                foreach (var materia in materiasMatriculadas)
                {
                    // Crear una nueva fila para la tabla
                    TableRow row = new TableRow();

                    // Crear celdas para los datos de la materia
                    TableCell cellNombreMateria = new TableCell();
                    cellNombreMateria.Text = materia;
                    row.Cells.Add(cellNombreMateria);

                    TableCell cellMatricular = new TableCell();
                    Button btnMatricular = new Button();
                    btnMatricular.Text = "Desmatricular";
                    btnMatricular.CommandArgument = materia;
                    btnMatricular.Command += DesmatricularMateria_Click;
                    btnMatricular.CssClass = "btn btn-primary";
                    cellMatricular.Controls.Add(btnMatricular);
                    row.Cells.Add(cellMatricular);

                    // Agregar la fila a la tabla
                    tablaMateriasMatriculadas.Rows.Add(row);
                }
            }
        }

        protected void DesmatricularMateria_Click(object sender, EventArgs e) {
            Button btnDesmatricular = (Button)sender;
            string nombreMateria = btnDesmatricular.CommandArgument;
            List<string> materiasMatriculadas;
            if (Session["Matricula"] != null)
            {
                materiasMatriculadas = (List<string>)Session["Matricula"];
                materiasMatriculadas.Remove(nombreMateria);
                Session["Matricula"] = materiasMatriculadas;
            }
            Response.Redirect("MatriculaEstudiante.aspx");
        }

        public void FinalizarMatricula_Click(object sender, EventArgs e)
        {
            List<string> materiasMatriculadas;
            if (Session["Matricula"] != null)
            {
                materiasMatriculadas = (List<string>)Session["Matricula"];
                LnMatricula lnMatricula = new LnMatricula();
                Estudiante estudiante = (Estudiante)Session["Estudiante"];
                foreach (var materia in materiasMatriculadas) {
                    lnMatricula.MatricularEstudiante(estudiante.IdEstudiante, ObtenerGrupoDeMateria(materia));
                }
                Session["Matricula"] = null;
                Response.Redirect("MatriculaEstudiante.aspx");
            }
        }

        protected int ObtenerGrupoDeMateria(string materia) {
            List<Matricula> materias;
            materias = (List<Matricula>)Session["MateriasDisponibles"];
            var idGrupo = 0;
            foreach (var m in materias)
            {
                if (m.NombreMateria == materia)
                {
                    idGrupo = m.IdGrupo;
                }
            }
            return idGrupo;
        }

        public void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}