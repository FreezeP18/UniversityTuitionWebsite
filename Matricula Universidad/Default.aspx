<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Matricula_Universidad._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <!-- Outer Row -->
        <div class="row justify-content-center">

            <div class="col-xl-10 col-lg-12 col-md-9">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Bienvenido</h1>
                                    </div>
                                    <form class="user">
                                        <div class="form-group">
                                            <asp:TextBox runat="server" class="form-control form-control-user" ID="txtUsuario" name="usuario" placeholder="Usuario"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" type="password" class="form-control form-control-use" ID="txtPassword" name="password" placeholder="Password"></asp:TextBox>
                                        </div>
                                        
                                        <asp:Button ID="BtnLogin" runat="server" Text="Iniciar Sesion" class="btn btn-primary btn-user btn-block" OnClick="IniciarSesion" />
                                    </form>
                                    <div id="divAlerta" runat="server" class="alert alert-danger">
                                        Usuario no válido. Por favor, verifique sus credenciales.
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

 
</asp:Content>
