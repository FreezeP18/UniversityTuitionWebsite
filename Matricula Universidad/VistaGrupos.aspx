<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VistaGrupos.aspx.cs" Inherits="Matricula_Universidad.VistaGrupos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">

    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <!-- Page Wrapper -->
    <div id="wrapper">

    <!-- Sidebar -->
    <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
     <!-- Sidebar - Brand -->
     <a class="sidebar-brand d-flex align-items-center justify-content-center" href="Administracion.aspx">
         <div class="sidebar-brand-icon rotate-n-15">
             <i class="fas fa-laugh-wink"></i>
         </div>
         <div class="sidebar-brand-text mx-3">Matricula Universitaria</div>
     </a>

     <!-- Divider -->
     <hr class="sidebar-divider my-0">

     <!-- Nav Item - Administracion -->
     <li class="nav-item">
         <a class="nav-link" href="Administracion.aspx">
             <i class="fas fa-fw fa-tachometer-alt"></i>
             <span>Administracion</span></a>
     </li>
     <!-- Divider -->
     <li class="nav-item">
         <a class="nav-link active" href="VistaCarreras.aspx">
             <i class="fas fa-fw fa-tachometer-alt"></i>
             <span>Carreras</span></a>
     </li>

     <hr class="sidebar-divider">
     <li class="nav-item">
         <a class="nav-link" href="VistaMaterias.aspx">
             <i class="fas fa-fw fa-tachometer-alt"></i>
             <span>Materias</span></a>
     </li>

     <hr class="sidebar-divider">
     <li class="nav-item">
         <a class="nav-link" href="VistaEstudiantes.aspx">
             <i class="fas fa-fw fa-tachometer-alt"></i>
             <span>Estudiantes</span></a>
     </li>

     <hr class="sidebar-divider">
     <li class="nav-item">
         <a class="nav-link" href="VistaGrupos.aspx">
             <i class="fas fa-fw fa-tachometer-alt"></i>
             <span>Grupos</span></a>
     </li>
    <hr class="sidebar-divider">
     <li class="nav-item">
        <asp:Button class="btn btn-danger btn-block" id="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" />
    </li>
 </ul>
        <!-- End of Sidebar -->

        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">
                <div class="container-fluid">
                    <!-- Page Heading -->
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                        <h1 class="h3 mb-0 text-gray-800">Administración de Grupos</h1>
                    </div>
                </div>
                <div class="container">
                    <h2>Agregar Nuevo grupo</h2>
                    <form id="formCarrera" class="needs-validation" novalidate>
                        <div class="row">
                            <div class="col-md-12">
                                <input type="hidden" class="form-control" id="txtID" runat="server" />
                                <div class="form-group">
                                    <label for="txtIdMateria">Id de Materia:</label>
                                    <input type="text" class="form-control" id="txtIdMateria" runat="server" />
                                </div>
                                 <div class="form-group">
     <label for="txtNumeroGrupo">Numero de grupo:</label>
     <input type="text" class="form-control" id="txtNumeroGrupo" runat="server" />
 </div>
                                 <div class="form-group">
     <label for="txtHorario">Horario:</label>
     <input type="text" class="form-control" id="txtHorario" runat="server" />
 </div>
                                 <div class="form-group">
     <label for="txtCapacidad">Capacidad:</label>
     <input type="text" class="form-control" id="txtCapacidad" runat="server" />
 </div>
                                <div class="form-group">
                                    <label for="ddlEstado">Estado:</label>
                                    <select class="form-control" id="ddlEstado" runat="server">
                                         <option value=""></option>
                                        <option value="Abierto">Abierto</option>
                                        <option value="Cerrado">Cerrado</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary" onserverclick="AgregarGrupo" runat="server">Guardar Grupo</button>
                        
                        <div id="divAlerta" runat="server" class="alert alert-danger" style="display: none;">
                            Debe llenar todos los campos para agregar un grupo.
                        </div>
                        <div id="divError" runat="server" class="alert alert-danger" style="display: none;">
                            Ocurrio un error al guardar el grupo.
                        </div>
                        <div id="divSuccess" runat="server" class="alert alert-success" style="display: none;">
                            el grupo ha sido guardada con exito.
                        </div>
                    </form>

                </div>
                <!-- /.container-fluid -->
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Lista de Grupos</h6>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>                                       
                                        <th>Nombre de la Materia</th>
                                        <th>Numero de Grupo</th>
                                        <th>Horario</th>
                                        <th>Capacidad</th>
                                        <th>Estado</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>                                      
                                        <th>Nombre de la Materia</th>
                                        <th>Numero de Grupo</th>
                                        <th>Horario</th>
                                        <th>Capacidad</th>
                                        <th>Estado</th>
                                    </tr>
                                </tfoot>
                                <tbody runat="server" id="tablaGrupos">
                                    <!-- Aquí se agregarán las filas dinámicamente -->
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- End of Main Content -->
            </div>
            <!-- End of Content Wrapper -->

        </div>
    <!-- End of Page Wrapper -->


    <!-- Modal para editar grupos -->
    <div id="modalAgregarGrupo" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Contenido del modal -->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Guardar Carrera</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <!-- Formulario de edición de grupos -->
                    <div class="container">
                        <div class="form-group">

                            <input type="hidden" value="" class="form-control" id="txtEditId" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="txtEditCarrera">Carrera:</label>
                            <input type="text" class="form-control" id="txtEditCarrera" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="ddlEditEstado">Estado:</label>
                            <select class="form-control" id="ddlEditEstado" runat="server">
                                <option value="1">Activa</option>
                                <option value="0">Inactiva</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary" </button>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
