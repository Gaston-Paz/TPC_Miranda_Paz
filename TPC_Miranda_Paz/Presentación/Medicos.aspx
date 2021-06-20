<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="Presentación.Medicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-4">
            <div class="card">
                <div class="card-header">Formulario: Médico</div>
                <div class="card-body">
                    <h5 class="card-title">Registrar Médico</h5>
                    <form>
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="nombre"
                                placeholder="Nombre" />
                        </div>
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="apellido"
                                placeholder="Apellido" />
                        </div>
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="dni"
                                placeholder="DNI" />
                        </div>
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="telefono"
                                placeholder="Telefono" />
                        </div>
                        <div class="form-group">
                            <input
                                type="email"
                                class="form-control"
                                id="email"
                                aria-describedby="emailHelp"
                                placeholder="Email" />
                        </div>
                        <div class="form-group">
                            <input
                                type="password"
                                class="form-control"
                                id="password"
                                placeholder="Contraseña" />
                        </div>
                        <div class="form-group">
                            <input
                                type="text"
                                class="form-control"
                                id="matricula"
                                placeholder="Matrícula" />
                        </div>
                        <div class="form-group">
                            <select class="form-control" id="exampleFormControlSelect1">
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                            </select>
                        </div>
                        <button type="submit" class="btn btn-primary">Enviar</button>
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
                    <div>Profesionales</div>
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

                                <% foreach (Dominio.Medico item in listaMedicos)
                                    { %>
                                <tr>

                                    <th><%= item.Id %> </th>
                                    <th><%= item.Nombre %> </th>
                                    <th><%= item.Apellido %> </th>
                                    <th><%= item.Especialidad.Nombre %> </th>
                                    <th>
                                        <a href="#" class=""><i class="fas fa-edit"></i></a>
                                    </th>

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
