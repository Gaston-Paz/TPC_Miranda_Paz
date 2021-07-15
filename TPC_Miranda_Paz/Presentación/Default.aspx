<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentación._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<!-- stats -->

            <div class="row">
                <div class="col-3">
                    <div class="card bg-warning text-light">
                        <div class="card-body">
                            <i class="far fa-calendar-alt"></i>
                            <span><%=DateTime.UtcNow.Date.ToString("dd/MM/yyyy") %></span>
                          <h5 class="card-title text-center">Turnos Ocupados</h5>
                          <p class="card-text text-center">50</p>
                        </div>
                      </div>
                </div>
                <div class="col-3">
                    <div class="card bg-success text-light">
                        <div class="card-body">
                            <i class="far fa-calendar-alt"></i>
                            <span><%=DateTime.UtcNow.Date.ToString("dd/MM/yyyy") %></span>
                          <h5 class="card-title text-center">Turnos Disponibles</h5>
                          <p class="card-text text-center">10</p>
                        </div>
                      </div>
                </div>
                <div class="col-3">
                    <div class="card bg-secondary text-light">
                        <div class="card-body">
                            <i class="far fa-calendar-alt"></i>
                            <span>Junio</span>
                          <h5 class="card-title text-center">Turnos Otorgados</h5>
                          <p class="card-text text-center">60</p>
                        </div>
                      </div>
                </div>
                <div class="col-3">
                    <div class="card bg-danger text-light">
                        <div class="card-body">
                            <i class="far fa-calendar-alt"></i>
                            <span>Junio</span>
                          <h5 class="card-title text-center">Turnos Cancelados</h5>
                          <p class="card-text text-center">30</p>
                        </div>
                      </div>
                </div>
            </div>

            <div class="my-5"></div>

            <div class="row">
                <div class="col-3">
                    <a href="#" class="btn btn-info btn-block p-2">
                        <i class="fas fa-user-injured"></i>
                        Pacientes <asp:Label ID="lblcantpacientes" runat="server" Text="Label" CssClass="badge badge-light"></asp:Label>
                    </a>
                </div>
                <div class="col-3">
                    <a href="#" class="btn btn-info btn-block p-2">
                        <i class="fas fa-user-md"></i>
                        Medicos <asp:Label ID="lblcantmedicos" runat="server" Text="Label" CssClass="badge badge-light"></asp:Label>
                    </a>
                </div>
                <div class="col-3">
                    <a href="#" class="btn btn-info btn-block p-2">
                        <i class="fas fa-user-tie"></i>
                        Recepcionista <asp:Label ID="lblcantrecepcionistas" runat="server" Text="Label" CssClass="badge badge-light"></asp:Label>
                    </a>
                </div>
                <div class="col-3">
                    <a href="#" class="btn btn-info btn-block p-2">
                        <i class="fas fa-notes-medical"></i>
                        Especialidades <asp:Label ID="lblcantespecialidades" runat="server" Text="Label" CssClass="badge badge-light"></asp:Label>
                    </a>
                </div>
            </div>



</asp:Content>
