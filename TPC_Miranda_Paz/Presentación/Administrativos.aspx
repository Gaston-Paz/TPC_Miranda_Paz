<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrativos.aspx.cs" Inherits="Presentación.Administrativos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UPAdmin" runat="server">
        <ContentTemplate>



           

            <div class="row mt-4">
                <div class="col-3">

                    <%--FORMULARIO DE REGISTRO ADMINISTRADORES--%>

                    <div class="card">
                        <div class="card-header">Formulario: Administrador</div>
                        <div class="card-body">
                            <h5 class="card-title">Registrar Administrador</h5>
                            <p class="card-text text-muted">Los campos * son obligatorios</p>
                            <form>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="nombre_admin" name="nombre_admin" placeholder="*Nombre" runat="server" />
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="apellido_admin" name="apellido_admin" placeholder="*Apellido" runat="server" />
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="dni_admin" name="dni_admin" placeholder="*DNI" runat="server" />
                                    <div class="invalid-feedback">
                                        DNI ya registrado
                                    </div>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="telefono_admin" name="telefono_admin" placeholder="*Telefono" runat="server" />
                                </div>
                                <div class="form-group">
                                    <input
                                        type="email" class="form-control" id="email_admin" name="email_admin" aria-describedby="emailHelp" placeholder="*Email" runat="server" />
                                    <div class="invalid-feedback">
                                        Email ya registrado
                                    </div>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="pass_admin" name="pass_admin" placeholder="*Contraseña" runat="server" />
                                </div>
                            </form>
                            <asp:Button ID="Btn_Registar_admin" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClientClick="return validarVacioAdmin()" OnClick="Btn_Registar_admin_Click" />
                        </div>
                    </div>

                </div>
                <div class="col">
                    <div class="card">

                        <%--ENCABEZADO DE GRILLA CON ADMINISTRADORES CARGADOS--%>

                        <div class="card-header d-flex justify-content-between align-items-center ">
                            <div>Administradores</div>
                            <div class="form-inline my-2 my-lg-0">
                                <asp:TextBox ID="TxtBuscar" Text="Buscar" CssClass="form-control mr-sm-2" OnTextChanged="TxtBuscar_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <%--GRILLA DE ADMINISTRADORES--%>

                        <div class="card-body ">
                            <div class="test-overflow">

                                <asp:GridView ID="GridAdministradores" AutoGenerateColumns="false" OnLoad="GridAdministradores_Load" OnSelectedIndexChanged="GridAdmin_SelectedIndexChanged" runat="server">
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
                            <h5 class="modal-title" id="exampleModalLabel" runat="server">Datos del administrador</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>

                        <%--CONTENIDO DE MODAL--%>

                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblId" runat="server" Text="Id"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtId" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtApellido" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblDni" runat="server" Text="DNI"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtDNI" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblPass" runat="server" Text="Contraseña"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtPass" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblTelefono" runat="server" Text="Teléfono"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>

                        <%--PIE DE MODAL--%>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminar_Click" />
                           <%-- <asp:Button ID="BtnEditar" runat="server" Text="Editar" CssClass="btn btn-warning" OnClientClick="return habilitar()" />--%>
                            <asp:Button ID="BtnModificar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" OnClick="BtnModificar_Click" />
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

            var TxtEmail = document.getElementById("<%=TxtEmail.ClientID%>");
            TxtEmail.removeAttribute("readonly", 0);

            var TxtPass = document.getElementById("<%=TxtPass.ClientID%>");
            TxtPass.removeAttribute("readonly", 0);

                var TxtTelefono = document.getElementById("<%=TxtTelefono.ClientID%>");
                TxtTelefono.removeAttribute("readonly", 0);


                console.log("habilitar");
                return false;
            }
        


           function validarVacioAdmin() {
               var verificado = true;

               let nombre = document.getElementById("<%=nombre_admin.ClientID%>");
            let apellido = document.getElementById("<%=apellido_admin.ClientID%>");
            let dni = document.getElementById("<%=dni_admin.ClientID%>");
            let email = document.getElementById("<%=email_admin.ClientID%>");
            let tel = document.getElementById("<%=telefono_admin.ClientID%>");
            let nac = document.getElementById("<%=pass_admin.ClientID%>");


            if (nombre.value == "") {
                nombre.classList.add("is-invalid");
                verificado = false;
            }

            if (apellido.value == "") {
                apellido.classList.add("is-invalid");
                verificado = false;
            }

            if (dni.value == "") {
                dni.classList.add("is-invalid");
                verificado = false;
            }

            if (email.value == "") {
                email.classList.add("is-invalid");
                verificado = false;
            }

            if (tel.value == "") {
                tel.classList.add("is-invalid");
                verificado = false;
            }
            if (nac.value == "") {
                nac.classList.add("is-invalid");
                verificado = false;
            }
            console.log(nac.value);
            let invalid = document.getElementsByClassName("invalid-feedback");
            for (let i = 0; i < invalid.length; i++) {
                invalid[i].textContent = "";
            }
            console.log(invalid);

            return verificado;
        }
       </script>


</asp:Content>
