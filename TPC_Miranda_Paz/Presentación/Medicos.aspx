<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="Presentación.Medicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <div class="row">

                <div class="col-4">

                    <%--FORMULARIO DE REGISTRO--%>

                    <div class="card">
                        <div class="card-header">Formulario: Médico</div>
                        <div class="card-body">
                            <h5 class="card-title">Registrar Médico</h5>
                            <form>
                                <div class="form-group">
                                    <input type="text" class="form-control"  id="nombre" placeholder="Nombre" runat="server" />
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="apellido" placeholder="Apellido" runat="server" />
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="dni" placeholder="DNI" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="telefono" placeholder="Telefono" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <input type="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Email" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <input type="password" class="form-control" id="password" placeholder="Contraseña" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="matricula" placeholder="Matrícula" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ListEspecialidades" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="-1">Especialidad</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ListEspecialidades2" runat="server" CssClass="form-control" Visible="False">
                                        <asp:ListItem Value="-1">Especialidad</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ListEspecialidades3" runat="server" CssClass="form-control" Visible="False">

                                        <asp:ListItem Value="-1">Especialidad</asp:ListItem>
                                    </asp:DropDownList>
                                </div>


                                <asp:Button ID="BtnAgregarEspecialidad" runat="server" Text="Agregar Especialidad" OnClick="BtnAgregarEspecialidad_Click" CssClass="btn btn-success" />
                                <asp:Button ID="BtnRegistrar" runat="server" Text="Registar" OnClick="BtnRegistrar_Click" CssClass="btn btn-primary" />
                            </form>
                        </div>
                    </div>
                </div>


                <%--ENCABEZADO DE GRILLA CON MEDICOS CARGADOS--%>


                <div class="col">
                    <div class="card">
                        <div class="card-header d-flex justify-content-between align-items-center">
                            <div>Profesionales</div>
                            <asp:Label ID="LblEspecialidades" runat="server" Text="Especialidades"></asp:Label>
                            <asp:DropDownList ID="ListEspecialidadesGrid" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem Value="-1">Todos</asp:ListItem>
                            </asp:DropDownList>
                            <form class="form-inline my-2 my-lg-0">
                                <input class="form-control mr-sm-2" type="search" placeholder="Buscar" aria-label="Search" />
                            </form>
                        </div>

                        <%--GRILLA DE MEDICOS--%>

                        <div class="card-body">
                            <div class="test-overflow">
                                <asp:GridView ID="GridMedicos" runat="server" AutoGenerateColumns="False" OnLoad="GridMedicos_Load" OnSelectedIndexChanged="GridMedicos_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="50">
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
            </div>




     <!-- MODAL -->
            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        
                        <%--ENCABEZADO DE MODAL--%>

                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Datos del paciente</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>

                        <%--CONTENIDO DE MODAL--%>

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
                                <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtEmail" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-3">
                                <asp:Label ID="LblPass" runat="server" Text="Contraseña"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtPass" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-3">
                                <asp:Label ID="LblTelefono" runat="server" Text="Teléfono"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtTelefono" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-3">
                                <asp:Label ID="LblMatricula" runat="server" Text="Matrícula"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtMatricula" runat="server" CssClass="form-control disable" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-3">
                                <asp:Label ID="LblEspecialidad" runat="server" Text="Especialidad"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:DropDownList ID="DDModalEspecialidades" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-3">
                                <asp:Label ID="Label1" runat="server" Text="Especialidad" Visible="False"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:DropDownList ID="DDModalEspecialidades2" runat="server" Visible="False" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-3">
                                <asp:Label ID="Label2" runat="server" Text="Especialidad" Visible="False"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:DropDownList ID="DDModalEspecialidades3" runat="server" Visible="False" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="modal-body row">
                            <div class="col-3">
                                <asp:Label ID="LblNacimiento" runat="server" Text="Fecha de nacimiento"></asp:Label>
                            </div>
                            <div class="col">
                                <div class="form-group">
                                    <input type="date" class="form-control" id="Date1" name="fechanacimiento" placeholder="Fecha de nacimiento" runat="server" />
                                </div>
                            </div>
                        </div>

                        <%--PIE DE MODAL--%>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="Button1" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                            <asp:Button ID="BtnEditar" runat="server" Text="Editar" CssClass="btn btn-warning" OnClientClick="return habilitar()" OnClick="BtnEditarMedico_Click"/>
                            <asp:Button ID="BtnModificar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" />
                        </div>

                    </div>
                </div>
            </div>
</ContentTemplate>
    </asp:UpdatePanel>

    <script>
        function habilitar() {
            var TxtNombre = document.getElementById("<%=TxtNombre.ClientID%>");
            TxtNombre.removeAttribute("readonly", 0);

            var TxtApellido = document.getElementById("<%=TxtApellido.ClientID%>");
            TxtApellido.removeAttribute("readonly", 0);

            var TxtDNI = document.getElementById("<%=TxtDNI.ClientID%>");
            TxtDNI.removeAttribute("readonly", 0);

            var TxtDNI = document.getElementById("<%=TxtDNI.ClientID%>");
            TxtDNI.removeAttribute("readonly", 0);

            var TxtTelefono = document.getElementById("<%=TxtTelefono.ClientID%>");
            TxtTelefono.removeAttribute("readonly", 0);

            var TxtMatricula = document.getElementById("<%=TxtMatricula.ClientID%>");
            TxtMatricula.removeAttribute("readonly", 0);

            
            console.log("habilitar");
            return false;
        }

    </script>


</asp:Content>
