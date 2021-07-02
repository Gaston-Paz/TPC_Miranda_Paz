<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrativos.aspx.cs" Inherits="Presentación.Administrativos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div class="col-4">
            <div class="card">
                <div class="card-header">Formulario: Recepcionista</div>
                <div class="card-body">
                    <h5 class="card-title">Registrar Recepcionista</h5>

                    <form action="Administrativos.aspx" >
                        <div class="form-group">
                            <input type="text" class="form-control" id="nombre_recep" name="nombre_recep" placeholder="Nombre" runat="server"/>
                         </div>
                        <div class="form-group">
                            <input type="text" class="form-control" id="apellido_recep" name="apellido_recep" placeholder="Apellido" runat="server"/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" id="dni_recep" name="dni_recep" placeholder="DNI" runat="server"/>
                            <div class="invalid-feedback">
                                 DNI ya registrado
                            </div>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" id="telefono_recep" name="telefono_recep" placeholder="Telefono" runat="server"/>
                        </div>
                        <div class="form-group">
                            <input type="email" class="form-control" id="email_recep" name="email_recep" aria-describedby="emailHelp" placeholder="Email" runat="server"/>
                            <div class="invalid-feedback">
                                 Email ya registrado
                            </div>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" id="pass_recep" name="pass_recep" placeholder="Contraseña" runat="server"/>
                        </div>
                        <asp:Button ID="BtnRegistrar_Recepcionista" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="BtnRegistrar_Recepcionista_Click" />
                    </form>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <div>Recepcionistas</div>
                    <form class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" type="search"  placeholder="Buscar" aria-label="Search" runat="server"/>
                    </form>
                </div>
                <div class="card-body ">
                    <div class="test-overflow">
                        <table class="table table-bordered table-hover">
                            <thead class="thead-dark">
                                <tr>
                                    <th scope="col">Id</th>
                                    <th scope="col">Nombre</th>
                                    <th scope="col">Apellido</th>
                                    <th scope="col">Dni</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                                           
                                    <% foreach (Dominio.Recepcionista item in listaRecepcionista)
                                       {  %>
                                        <tr>
                                            <th scope="col"> <%= item.Id %> </th>
                                            <th scope="col"> <%= item.Nombre %> </th>
                                            <th scope="col"> <%= item.Apellido %> </th>
                                            <th scope="col"> <%= item.Dni %> </th>
                                            <th><a href="#" class="" data-toggle="modal" data-target="#exampleModal" runat="server"><i class="fas fa-edit"></i></a></th>
                                        </tr>

                                     <% } %>
                                        
                                

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
<div class="row mt-4">
        <div class="col-4">
            <div class="card">
                <div class="card-header">Formulario: Administrador</div>
                <div class="card-body">
                    <h5 class="card-title">Registrar Administrador</h5>

                    <form action="Administrativos.aspx">
                        <div class="form-group">
                            <input type="text" class="form-control" id="nombre_admin" name="nombre_admin" placeholder="Nombre" runat="server" />
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" id="apellido_admin" name="apellido_admin" placeholder="Apellido" runat="server" />
                        </div>
                        <div class="form-group">
                            <input type="text"  class="form-control" id="dni_admin" name="dni_admin" placeholder="DNI" runat="server" />
                            <div class="invalid-feedback">
                                DNI ya registrado
                            </div>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" id="telefono_admin" name="telefono_admin" placeholder="Telefono" runat="server" />
                        </div>
                        <div class="form-group">
                            <input
                                type="email" class="form-control"  id="email_admin"  name="email_admin"  aria-describedby="emailHelp" placeholder="Email" runat="server" />
                            <div class="invalid-feedback">
                                Email ya registrado
                            </div>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" id="pass_admin" name="pass_admin" placeholder="Contraseña" runat="server" />
                        </div>
                        <asp:Button ID="Btn_Registar_admin" runat="server" Text="Button" CssClass="btn btn-primary" OnClick="Btn_Registar_admin_Click" />
                    </form>
                </div>
            </div>

        </div>
        <div class="col">
            <div class="card">
                <div class="card-header d-flex justify-content-between align-items-center ">
                    <div>Administradores</div>
                    <form class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" type="search" placeholder="Buscar" aria-label="Search" runat="server" />
                    </form>
                </div>
                <div class="card-body ">
                    <div class="test-overflow">
                        <table class="table table-bordered table-hover">
                            <thead class="thead-dark">
                                <tr>
                                    <th scope="col">Id</th>
                                    <th scope="col">Nombre</th>
                                    <th scope="col">Apellido</th>
                                    <th scope="col">Dni</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>

                                <% foreach (Dominio.Administrador items in listaAdmin)
                                    {  %>
                                <tr>
                                    <th scope="col"><%= items.Id %> </th>
                                    <th scope="col"><%= items.Nombre %> </th>
                                    <th scope="col"><%= items.Apellido %> </th>
                                    <th scope="col"><%= items.Dni %> </th>
                                    <th><a href="#" class="" data-toggle="modal" data-target="#exampleModal" runat="server"><i class="fas fa-edit"></i></a></th>
                                </tr>

                                <% } %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Datos del recepcionista</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>



                <div class="modal-body row">
                    <div class="col-2">
                        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                    </div>
                    <div class="col">
                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                    </div>
            </div>
            <div class="modal-body row">
                <div class="col-2">
                    <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-body row">
                <div class="col-2">
                    <asp:Label ID="LblDni" runat="server" Text="DNI"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtDNI" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-body row">
                <div class="col-2">
                    <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-body row">
                <div class="col-2">
                    <asp:Label ID="LblPass" runat="server" Text="Contraseña"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-body row">
                <div class="col-2">
                    <asp:Label ID="LblTelefono" runat="server" Text="Teléfono"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                <asp:Button ID="Button1" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                <asp:Button ID="Button2" runat="server" Text="Editar" CssClass="btn btn-warning" />
                <asp:Button ID="BtnModificar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" />
            </div>
                        
        </div>
    </div>
        </div>



</asp:Content>
