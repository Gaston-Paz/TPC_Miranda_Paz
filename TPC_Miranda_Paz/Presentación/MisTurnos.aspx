<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Presentación.MisTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>




            <%--GRILLA DE MEDICOS--%>
            <div class="row">
                <div class="col">
                    <div class="card">

                        <div class="card-header d-flex justify-content-between align-items-center">
                            <div>Mis Turnos del día</div>

                        </div>

                        <div class="card-body">
                            <div class="test-overflow">

                                <asp:GridView ID="GridTurnosDia" AutoGenerateColumns="false" OnLoad="GridTurnosDia_Load" OnSelectedIndexChanged="GridTurnosDia_SelectedIndexChanged" runat="server">

                                    <Columns>
                                        <asp:BoundField DataField="Id" Visible="true" HeaderText="Id Turno" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Paciente.Apellido" HeaderText="Paciente" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Estado.Nombre" HeaderText="Estado Turno" SortExpression="Apellido" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="DNI" />
                                        <asp:BoundField DataField="Horario" HeaderText="Hora" SortExpression="DNI" />
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:TemplateField HeaderText="Observación" ItemStyle-Width="50">
                                            <ItemTemplate>
                                                <a id="modal" href="#" class="" data-toggle="modal" data-target="#exampleModal"><i class="fas fa-edit"></i></a>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField>

                                    </Columns>
                                    <SelectedRowStyle CssClass="bg-success" />

                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>



                <%--ENCABEZADO DE GRILLA CON MEDICOS CARGADOS--%>
                <div class="col">
                    <div class="card">

                        <div class="card-header d-flex justify-content-between align-items-center">
                            <div>Mis Turnos</div>
                            <div class="form-inline my-2 my-lg-0">
                                <asp:TextBox ID="TxtBuscar" runat="server" OnTextChanged="TxtBuscar_TextChanged" Text="Buscar" CssClass="form-control mr-sm-2" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="card-body">
                            <div class="test-overflow">

                                <asp:GridView ID="GridTodosTurnos" AutoGenerateColumns="false" OnLoad="GridTodosTurnos_Load" runat="server">

                                    <Columns>
                                        <asp:BoundField DataField="Id" Visible="true" HeaderText="Id Turno" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Paciente.Apellido" HeaderText="Paciente" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Estado.Nombre" HeaderText="Estado Turno" SortExpression="Apellido" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="DNI" />
                                        <asp:BoundField DataField="Horario" HeaderText="Hora" SortExpression="DNI" />
                                        <asp:BoundField DataField="Observacion" HeaderText="Observacion" SortExpression="DNI" />
                                    </Columns>


                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <!-- MODAL -->
            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-md">
                    <div class="modal-content">

                        <%--ENCABEZADO DE MODAL--%>

                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Datos del médico</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>

                        <%--CONTENIDO DE MODAL--%>
                        <div class="modal-body">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-12">

                                        <div class="modal-body row">
                                            <div class="col-3">
                                                <asp:Label ID="LblId" runat="server" Text="Id"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="TxtId" AutoPostBack="true" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="modal-body row">
                                            <div class="col-3">
                                                <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="TxtNombre" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="modal-body row">
                                            <div class="col-3">
                                                <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="TxtApellido" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="modal-body row">
                                            <div class="col-3">
                                                <asp:Label ID="LblDni" runat="server" Text="DNI"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="TxtDNI" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="modal-body row">
                                            <div class="col-3">
                                                <asp:Label ID="LblHora" runat="server" Text="Horario"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="TxTHora" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="modal-body row">
                                            <div class="col-3">
                                                <asp:Label ID="LblFecha" runat="server" Text="Fecha"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="TxtFecha" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="modal-body row">
                                            <div class="col-3">
                                                <asp:Label ID="LblEstado" runat="server" Text="Estado"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:DropDownList ID="DropEstado" AutoPostBack="false" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="modal-body row">
                                            <div class="col-3">
                                                <asp:Label ID="LblObersvación" runat="server" Text="Observación"></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="TxtObservación" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>



                                    </div>






                                </div>
                            </div>
                        </div>

                        <%--PIE DE MODAL--%>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BtnModificar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" OnClick="BtnModificar_Click" />
                        </div>

                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>





</asp:Content>
