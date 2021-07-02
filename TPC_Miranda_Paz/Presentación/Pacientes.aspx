<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Presentación.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div class="row">
        <div class="col-4">
            <div class="card">
                <div class="card-header">Formulario: Paciente</div>
                <div class="card-body">
                    <h5 class="card-title">Registrar Paciente</h5>

                    <form action="Pacientes.aspx" >
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="nombre"
                                name="nombre"
                                placeholder="Nombre"
                                runat="server"/>
                                                  </div>
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="apellido"
                                name="apellido"
                                placeholder="Apellido"
                                runat="server"/>
                        </div>
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="dni"
                                name="dni"
                                placeholder="DNI"
                                runat="server"/>
                            <div class="invalid-feedback">
                                 DNI ya registrado
                            </div>
                        </div>
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="telefono"
                                name="telefono"
                                placeholder="Telefono"
                                runat="server"/>
                        </div>
                        <div class="form-group">
                            <input
                                type="email"
                                class="form-control"
                                id="email"
                                name="email"
                                aria-describedby="emailHelp"
                                placeholder="Email"
                                runat="server"/>
                            <div class="invalid-feedback">
                                 Email ya registrado
                            </div>
                        </div>
                        <div class="form-group">
                            <input
                                type="date"
                                class="form-control"
                                id="fechaNacimiento"
                                name="fechanacimiento"
                                placeholder="Fecha de nacimiento"
                                runat="server"/>
                         </div>
                        <asp:Button ID="Button1" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="Registar_Click"/>
                        
                    </form>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <div
                    class="
								card-header
								d-flex
								justify-content-between
								align-items-center
							">
                    <div>Pacientes</div>
                    <form class="form-inline my-2 my-lg-0">
                        <input
                            class="form-control mr-sm-2"
                            type="search"
                            placeholder="Buscar"
                            aria-label="Search" />
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
                                                           
                                    <% foreach (Dominio.Paciente item in listaPacientes)
                                
                                        { %>
                                        <tr>
                                            <th scope="col"> <%= item.Id %> </th>
                                            <th scope="col"> <%= item.Nombre %> </th>
                                            <th scope="col"> <%= item.Apellido %> </th>
                                            <th scope="col"> <%= item.Dni %> </th>
                                            <th><a href="#" class=""><i class="fas fa-edit"></i></a></th>
                                        </tr>

                                     <% } %>
                                

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>


