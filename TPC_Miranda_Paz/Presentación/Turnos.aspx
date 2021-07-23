<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Presentación.Turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row flex-nowrap">

                <div class="col-2">
                    <div class="card">
                        <div class="card-header">Formulario: Turnos</div>
                        <div class="card-body">
                            <h5 class="card-title">Registrar Turno</h5>
                            <div>
                                <div class="form-group">
                                    <div class="form-inline">
                                        <input type="text" class="form-control" id="dni" placeholder="DNI Paciente" runat="server" />
                                        <%--<asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-primary fas fa-search" Text="Buscar" OnClick="BtnBuscar_Click" />--%>
                                        <button id="BtnBuscar" runat="server" class="btn btn-primary" text="Buscar" onserverclick="BtnBuscar_Click"><i class=" fas fa-search"></i></button>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" name="" id="nombre" readonly visible="false" runat="server" />
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" name="" id="apellido" visible="false" readonly runat="server" />
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropEspecialidades" Visible="false" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropEspecialidades_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropMedicos" Visible="false" CssClass="form-control" OnSelectedIndexChanged="DropMedicos_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                </div>
                                <div class="form-group">

                                    <asp:DropDownList ID="DropFechas" CssClass="form-control" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="DropFechas_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                </div>
                                <asp:DropDownList ID="DropHorarios" OnSelectedIndexChanged="DropHorarios_SelectedIndexChanged" AutoPostBack="true" Visible="false" CssClass="form-control" runat="server"></asp:DropDownList>

                                <asp:Button ID="BtnAgendar" runat="server" Enabled="false" Text="Agendar turno" CssClass="btn btn-primary mt-2" OnClick="BtnAgendar_Click" />

                            </div>
                        </div>
                    </div>
                </div>

                  <div class="col-5">
                        <div class="card">
                            <div
                                class="card-header d-flex justify-content-between align-items-center ">
                                <div>Turnos disponibles</div>
                            </div>
                            <div class="card-body ">
                                <div class="test-overflow">
                                    <table class="table table-bordered table-hover">
                                        <asp:GridView ID="GridTurnosPredictivo" AutoGenerateColumns="false" OnLoad="GridTurnosPredictivo_Load" OnSelectedIndexChanged="GridTurnosPredictivo_SelectedIndexChanged" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="Medico.Id" Visible="true" HeaderText="Medico" SortExpression="Nombre" />
                                                <asp:BoundField DataField="Medico.Apellido" HeaderText="Medico" SortExpression="Nombre" />
                                                <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" SortExpression="Apellido" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="DNI" />
                                                <asp:BoundField DataField="Horario" HeaderText="Hora" SortExpression="DNI" />
                                                <asp:CommandField ShowSelectButton="True" />

                                            </Columns>
                                            <SelectedRowStyle CssClass="bg-success" />
                                        </asp:GridView>
                                    </table>
                                </div>
                            </div>

                        </div>
                    </div>


                <div class="col-5">
                        <div class="card">
                            <div
                                class="card-header d-flex justify-content-between align-items-center ">
                                <div>Turnos registrados</div>
                                <div class="form-inline my-2 my-lg-0">
                                    <asp:TextBox ID="TxtBuscar" CssClass="form-control mr-sm-2" AutoPostBack="true" runat="server" Text="Buscar" OnTextChanged="TxtBuscar_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="test-overflow">
                                    <table class="table table-bordered table-hover">
                                        <asp:GridView ID="GridTurnos" AutoGenerateColumns="false" OnLoad="GridTurnos_Load" OnSelectedIndexChanged="GridTurnos_SelectedIndexChanged" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="Id" Visible="true" HeaderText="Id" SortExpression="IdTurno" />
                                                <asp:BoundField DataField="Medico.Apellido" HeaderText="Médico" SortExpression="ApellidoMedico" />
                                                <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" SortExpression="Especialidad" />
                                                <asp:BoundField DataField="Paciente.Apellido" HeaderText="Paciente" SortExpression="ApellidoPaciente" />
                                                <asp:BoundField DataField="Fechas" HeaderText="Fecha" SortExpression="Fecha" />
                                                <asp:BoundField DataField="Horario" HeaderText="Hora" SortExpression="Hora" />
                                                <asp:CommandField ShowSelectButton="True" />
                                                <asp:TemplateField HeaderText="Cambiar estado" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <a id="modal" href="#" class="" data-toggle="modal" data-target="#exampleModal"><i class="fas fa-edit"></i></a>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle CssClass="bg-success" />
                                        </asp:GridView>
                                    </table>
                                </div>
                            </div>

                        </div>
                    </div>


              



            </div>
    


<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Cambiar estado de turno</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body text-center">
       <div class="mb-2">
           <asp:Label ID="LblTurno" runat="server" Text="Turno N°"></asp:Label>
          </div>
      <div class="row justify-content-around">
          <asp:Label ID="LblEstado" runat="server" CssClass="col-form-label" Text="Estado: "></asp:Label>
          <asp:DropDownList ID="DropEstados" CssClass="form-control" runat="server"></asp:DropDownList>
      </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          <asp:Button ID="BtnEditar" CssClass="btn btn-primary" runat="server" OnClick="BtnEditar_Click" Text="Guardar cambios" />
      </div>
    </div>
  </div>
</div>


</ContentTemplate>
    </asp:UpdatePanel>







            </asp:Content>
