<%@ Page Title="Dashboard de Opciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="Matricula_Universidad.Administracion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                <a class="nav-link" href="VistaCarreras.aspx">
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

                <!-- Begin Page Content -->
                <div class="container-fluid">
                    <!-- Page Heading -->
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                        <h1 class="h3 mb-0 text-gray-800">Administracion</h1>
                    </div>
                </div>
                <!-- /.container-fluid -->

                <div class="row">
                    <div class="col-md-3">
                        <div class="card" style="width: auto;">
                            <img src="/Imagenes/carreras.png" class="card-img-top" alt="Carreras">
                            <div class="card-body">
                                <h5 class="card-title">Carreras</h5>
                                <p class="card-text">Administracion de Carreras.</p>
                                <a href="VistaCarreras.aspx" class="btn btn-primary">Ir a modulo</a>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="card" style="width: auto;">
                            <img src="/Imagenes/materias.png" class="card-img-top" alt="Materias">
                            <div class="card-body">
                                <h5 class="card-title">Materias</h5>
                                <p class="card-text">Administracion de Materias.</p>
                                <a href="VistaMaterias.aspx" class="btn btn-primary">Ir a modulo</a>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="card" style="width: auto;">
                            <img src="/Imagenes/estudiantes.png" class="card-img-top" alt="Estudiantes">
                            <div class="card-body">
                                <h5 class="card-title">Estudiantes</h5>
                                <p class="card-text">Administracion de Estudiantes.</p>
                                <a href="VistaEstudiantes.aspx" class="btn btn-primary">Ir a modulo</a>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="card" style="width: auto;">
                            <img src="/Imagenes/grupos.png" class="card-img-top" alt="Grupos">
                            <div class="card-body">
                                <h5 class="card-title">Grupos</h5>
                                <p class="card-text">Administracion de Grupos.</p>
                                <a href="VistaGrupos.aspx" class="btn btn-primary">Ir a modulo</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End of Main Content -->
        </div>
        <!-- End of Content Wrapper -->

    </div>
    <!-- End of Page Wrapper -->
</asp:Content>