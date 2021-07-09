<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Presentación.Turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div class="col-3">
            <div class="card">
                <div class="card-header">Formulario: Turnos</div>
                <div class="card-body">
                    <h5 class="card-title">Registrar Turno</h5>
                    <form>
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="Dni"
                                placeholder="Dni" />
                        </div>
                        <div class="form-group">
                            <select class="form-control" id="exampleFormControlSelect1">
                                <option>Clinico Medico</option>
                                <option>Alergia</option>
                                <option>Otorrinolaringologo</option>
                                <option>Oftalmologo</option>
                                <option>Neumonologo</option>
                            </select>
                        </div>
                        
                        <button type="submit" class="btn btn-primary">Registrar
                        </button>
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
                    <div>Turnos disponibles</div>
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
                                    <th scope="col">Especialidad</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>

                               <%-- <% foreach (Dominio.Paciente item in listaPacientes)
                                    { %>
                                <tr>

                                    <th><%= item.Id %> </th>
                                    <th><%= item.Nombre %> </th>
                                    <th><%= item.Apellido %> </th>
                                    <th><%= item.Dni %> </th>
                                    <th>
                                        <a href="#" class=""><i class="fas fa-edit"></i></a>
                                    </th>

                                </tr>


                                <% } %>--%>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>





</asp:Content>
