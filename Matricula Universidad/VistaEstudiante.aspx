<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaEstudiante.aspx.cs" Inherits="Matricula_Universidad.VistaEstudiante" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Agregar al final del archivo -->
    <!-- Bootstrap CSS -->
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

        </ul>
        <!-- End of Sidebar -->

        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <!-- ESTUDIANTES -->
            <div id="content">
                <div class="container-fluid">
                    <!-- Page Heading -->
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                        <h1 class="h3 mb-0 text-gray-800">Administracion de Estudiantes</h1>
                    </div>
                </div>
                <div class="container">
                    <h2>Agregar Nuevo Estudiante</h2>
                    <form id="formEstudiante" class="needs-validation" novalidate>
                        <div class="row">
                            <div class="col-md-12">
                                <input type="hidden" class="form-control" id="txtID" runat="server" />
                                <div class="form-group">
                                    <label for="txtnombreEstudiante">Nombre:</label>
                                    <input type="text" class="form-control" id="txtNombreEstudiante" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtApelliEstudiante">Apellido:</label>
                                    <input type="text" class="form-control" id="txtApelliEstudiante" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtIdentificacion">Identificacion:</label>
                                    <input type="text" class="form-control" id="txtIdentificacion" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtTipoIdentificacion">Tipo de Identificacion:</label>
                                    <input type="text" class="form-control" id="txtTipoIdentificacion" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="FechaNacimiento">Fecha de Nacimiento:</label>
                                    <input type="date" class="form-control" id="FechaNacimiento" runat="server" />
                                </div>

                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary" onserverclick="GuardarEstudiante" runat="server">Guardar Estudiante</button>
                        <div id="divAlerta" runat="server" class="alert alert-danger">
                            Debe llenar todos los campos para crear un estudiante.
                        </div>
                        <div id="divError" runat="server" class="alert alert-danger">
                            Ocurrio un error al guardar al estudiante.
                        </div>
                        <div id="divSuccess" runat="server" class="alert alert-success">
                            el estudiante ha sido ingresado con exito.
                        </div>
                    </form>

                </div>
                <!-- /.container-fluid -->
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Lista de Carreras</h6>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Carrera</th>
                                        <th>Estado</th>
                                        <th>Cantidad de Estudiantes</th>
                                        <th>Cantidad de Materias</th>
                                        <th>Acciones</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>ID</th>
                                        <th>Carrera</th>
                                        <th>Estado</th>
                                        <th>Cantidad de Estudiantes</th>
                                        <th>Cantidad de Materias</th>
                                        <th>Acciones</th>
                                    </tr>
                                </tfoot>
                                <tbody runat="server" id="tablaCarreras">
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
</asp:Content>
