<%@ Page Title="Vista Materias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VistaMaterias.aspx.cs" Inherits="Matricula_Universidad.VistaMaterias" %>

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
                        <h1 class="h3 mb-0 text-gray-800">Administracion de Materias</h1>
                    </div>
                </div>
                <div class="container">
                    <h2>Agregar Nueva Materia</h2>
                    <form id="formCarrera" class="needs-validation" novalidate>
                        <div class="row">
                            <div class="col-md-12">
                                <input type="hidden" class="form-control" id="txtID" runat="server" />
                                <div class="form-group">
                                    <label for="txtMateria">Nombre de la Materia:</label>
                                    <input type="text" class="form-control" id="txtMateria" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtCreditos">Cantida de Creditos:</label>
                                    <input type="text" class="form-control" id="Text1" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="ddlEstado">Estado:</label>
                                    <select class="form-control" id="ddlEstado" runat="server">
                                        <option value="1">Activa</option>
                                        <option value="0">Inactiva</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary" onserverclick="GuardarMateria" runat="server">Guardar Materia</button>
                        <div id="divAlerta" runat="server" class="alert alert-danger">
                            Debe llenar todos los campos para crear una materia.
                        </div>
                        <div id="divError" runat="server" class="alert alert-danger">
                            Ocurrio un error al guardar la materia.
                        </div>
                        <div id="divSuccess" runat="server" class="alert alert-success">
                            La materia ha sido guardada con exito.
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
                                        <th>Materia</th>
                                        <th>Estado</th>
                                        <th>Cantidad de Creditos</th>
                                        <!-- Content Wrapper <th>Cantidad de Materias</th> -->
                                        <th>Acciones</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>ID</th>
                                        <th>Materia</th>
                                        <th>Estado</th>
                                        <th>Cantidad de Creditos</th>
                                        <!-- Content Wrapper <th>Cantidad de Materias</th> -->
                                        <th>Acciones</th>
                                    </tr>
                                </tfoot>
                                <tbody runat="server" id="tablaMaterias">
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

        <script>
            function cargarDatosModal(btn) {
                var materiaId = btn.getAttribute('data-id');
                var materiaNombre = btn.getAttribute('data-nombre');
                var materiaEstado = btn.getAttribute('data-estado');
                var txtId = document.getElementById('<%= txtEditId.ClientID %>');
                var txtEditMateria = document.getElementById('<%= txtEditMateria.ClientID %>');
                var ddlEditEstado = document.getElementById('<%= ddlEditEstado.ClientID %>');

                txtId.value = materiaId;
                txtEditMateria.value = materiaNombre;
                ddlEditEstado.value = materiaEstado;
            }
        </script>






        <!-- Modal para editar materia -->
        <div id="modalEditarMateria" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Contenido del modal -->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Editar Materia</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <!-- Formulario de edición de materia -->
                        <div class="container">
                            <div class="form-group">

                                <input type="hidden" value="" class="form-control" id="txtEditId" runat="server" />
                            </div>
                            <div class="form-group">
                                <label for="txtEditMateria">Materia:</label>
                                <input type="text" class="form-control" id="txtEditMateria" runat="server" />
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
                        <button type="submit" class="btn btn-primary" onserverclick="EditarMateria" runat="server">Editar Materia</button>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>