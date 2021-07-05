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
                        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="Button2_Click" />
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
                            aria-label="Search"
                            runat="server"/>
                    </form>
                </div>


                <div class="card-body ">
                    <div class="test-overflow">
                     <%--   <table class="table table-bordered table-hover">
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
                        </table>--%>


                        <%--ACA ESTA LA GRILLA CARGADA SOLAMENTE CON LOS PACIENTES CON ESTADO ACTIVO--%>
                        <%--TIENEN FUNCIONAMIENTO LOS BOTONES DE ELIMINAR Y GUARDAR CAMBIOS--%>


                        <asp:GridView ID="GridPacientes" runat="server" OnLoad="GridView1_Load" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoPostBack="true">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                                <asp:BoundField DataField="Dni" HeaderText="Dni" SortExpression="Dni" />
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <a id="modal" href="#" class="" data-toggle="modal" data-target="#exampleModal"  data-backdrop="static" runat="server"><i class="fas fa-edit"></i></a>
                                </ItemTemplate>

                            <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>

                            </Columns>
                            <HeaderStyle BackColor="Black" />
                                
                            <SelectedRowStyle CssClass="bg-success" />
                                
                        </asp:GridView>


                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_Miranda_PazConnectionString3 %>" SelectCommand="SELECT * FROM [Pacientes] WHERE ([Estado] = @Estado)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="true" Name="Estado" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    



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
                    <h5 class="modal-title" id="exampleModalLabel">Datos del paciente</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body row">
                    <div class="col-2">
                        <asp:Label ID="LblId" runat="server" Text="Id"></asp:Label>
                    </div>
                    <div class="col">
                        <asp:TextBox ID="TxtId" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
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
                    <asp:Label ID="LblTelefono" runat="server" Text="Teléfono"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-body row">
                <div class="col-2">
                    <asp:Label ID="LblNacimiento" runat="server" Text="Fecha de nacimiento"></asp:Label>
                </div>
                <div class="col">
                    <div class="form-group">
                        <input
                            type="date"
                            class="form-control"
                            id="fechaNac"
                            name="fechanacimiento"
                            placeholder="Fecha de nacimiento"
                            runat="server" />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminar_Click"/>
                <asp:Button ID="BtnEditar" runat="server" Text="Editar" CssClass="btn btn-warning" OnClick="BtnEditar_Click" />
                <asp:Button ID="BtnModificar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" OnClick="BtnModificar_Click"/>
            </div>
        </div>
    </div>
        </div>
            


</asp:Content>


