<%@ Page Title="Vista Estudiantes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VistaEstudiantes.aspx.cs" Inherits="Matricula_Universidad.WebForm1" %>

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
                        <h1 class="h3 mb-0 text-gray-800">Administracion de Estudiantes</h1>
                    </div>
                </div>
                <div class="container">
                    <h2>Agregar Nuevo Estudiante</h2>
                    <form id="formCrearEstudiante" class="needs-validation" novalidate >
                        <div class="form-group">
                            <label for="txtNombre">Nombre:</label>
                            <input type="text" class="form-control" id="txtNombre" name="Nombre" required runat="server"/>
                        </div>
                        <div class="form-group">
                            <label for="txtApellidos">Apellidos:</label>
                            <input type="text" class="form-control" id="txtApellidos" name="Apellidos" required runat="server"/>
                        </div>
                        <div class="form-group">
                            <label for="txtIdentificacion">Identificación:</label>
                            <input type="text" class="form-control" id="txtIdentificacion" name="Identificacion" required runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="ddlTipoIdentificacion">Tipo de Identificación:</label>
                            <select class="form-control" id="ddlTipoIdentificacion" name="TipoIdentificacion" required runat="server">
                                <option value="Cédula">Cédula</option>
                                <option value="Pasaporte">Pasaporte</option>
                              
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
                            <input type="date" class="form-control" id="txtFechaNacimiento" name="FechaNacimiento" required runat="server"/>
                        </div>
                        <div class="form-group">
                            <label for="ddlCarrera">Carrera:</label>
                             <input type="text" class="form-control" id="ddlCarrera" name="ddlCarrera" required runat="server"/>
                             
                         
                        </div>
                        <div class="form-group">
                            <label for="ddlEstadoEstudiante">Estado del Estudiante:</label>
                            <select class="form-control" id="ddlEstadoEstudiante" name="EstadoEstudiante" required runat="server">
                                <option value="Activo">Activo</option>
                                <option value="Inactivo">Inactivo</option>
                                <option value="Matriculado">Matriculado</option>
                                <option value="Graduado">Graduado</option>
                            </select>
                        </div>
                        <button type="submit" class="btn btn-primary" onserverclick="GuardarEstudiante" runat="server">Guardar Estudiante</button>
                        <div id="divAlerta" runat="server" class="alert alert-danger">
                            Debe llenar todos los campos para crear un estudiante.
                        </div>
                        <div id="divError" runat="server" class="alert alert-danger">
                            Ocurrio un error al guardar al estudiante.
                        </div>
                        <div id="divSuccess" runat="server" class="alert alert-success">
                            El estudiante ha sido guardada con exito.
                        </div>
                    </form>

                </div>
                <!-- Tabla para mostrar estudiantes -->
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Lista de Estudiantes</h6>
                        <!-- Cambiar el título -->
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Nombre</th>
                                        <th>Identificación</th>
                                        <th>Tipo de Identificación</th>
                                        <th>Fecha de Nacimiento</th>
                                        <th>Estado del Estudiante</th>
                                        <th>ID Carrera</th>
                                        <th>ID Matricula</th>
                                        <th>ID Grupo</th>
                                        <th>Fecha de Matrícula</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="tablaEstudiantes">
                                    <!-- Aquí se agregarán las filas dinámicamente -->
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- End of Main Content -->
            </div>
        </div>
        <!-- End of Content Wrapper -->
    </div>
    <!-- End of Page Wrapper -->
    </div>
</asp:Content>
