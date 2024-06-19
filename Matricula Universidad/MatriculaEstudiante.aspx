<%@ Page Title="Matricula en linea" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MatriculaEstudiante.aspx.cs" Inherits="Matricula_Universidad.MatriculaEstudiante" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Wrapper -->
    <div id="wrapper">

        <!-- Sidebar -->
        <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
            <!-- Sidebar - Brand -->
            <a class="sidebar-brand d-flex align-items-center justify-content-center" href="Matricula.aspx">
                <div class="sidebar-brand-icon rotate-n-15">
                    <i class="fas fa-laugh-wink"></i>
                </div>
                <div class="sidebar-brand-text mx-3">Matricula Universitaria</div>
            </a>

            <!-- Divider -->
            <hr class="sidebar-divider my-0">

            <!-- Nav Item - Administracion -->
            <li class="nav-item">
                <a class="nav-link" href="Matricula.aspx">
                    <i class="fas fa-fw fa-tachometer-alt"></i>
                    <span>Matricula en Linea</span></a>
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

                <!-- Begin Page Content -->
                <div class="container-fluid">
                    <!-- Page Heading -->
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                        <h1 class="h3 mb-0 text-gray-800">Matricula en Linea</h1>
                    </div>
                </div>
                <!-- /.container-fluid -->
                <div class="jumbotron mt-3">
                    <h1>Bienvenido: <asp:Label id="nombreEstudiante" runat="server" /></h1>
                    <div class="alert alert-info" role="alert">
                      <asp:Label id="informacionMatricula" runat="server" />
                    </div>
                    <hr class="my-4">
                </div>
                <div class="container-fluid">
                    <div class="row" id="verMatricula" runat="server">
                        <h1>Lista de materias matriculadas.</h1>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">Numero de Grupo</th>
                                    <th scope="col">Fecha Matricula</th>
                                    <th scope="col">Materia</th>
                                    <th scope="col">Horario</th>
                                    <th scope="col">Creditos</th>
                                </tr>
                            </thead>
                            <tbody id="tableMatricula" runat="server"></tbody>
                        </table>
                    </div>
                    <div class="row" id="listaMateriasDisponibles" runat="server">
                        <div class="col-md-12">
                            <h1>Lista de materias disponibles para matricular.</h1>
                        </div>
                        <asp:Table id="tablaMateriasDisponibles" runat="server">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>Materia</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Creditos</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Horario</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Matricular</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                    <div class="row" id="listaMateriasMatriculadas" runat="server">
                        <h1>Lista de materias matriculadas.</h1>
                        <asp:Table id="tablaMateriasMatriculadas" runat="server">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>Materia matriculada</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Desmatricular</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                    <div class="row" id="divFinalizarMatricula" runat="server">
                        <asp:Button id="btnFinalizarMatricula" runat="server" Text="Finalizar Matricula" CssClass="btn btn-primary" OnClick="FinalizarMatricula_Click" />
                    </div>
                </div>
            </div>
            <!-- End of Main Content -->
        </div>
        <!-- End of Content Wrapper -->

    </div>
    <!-- End of Page Wrapper -->
</asp:Content>