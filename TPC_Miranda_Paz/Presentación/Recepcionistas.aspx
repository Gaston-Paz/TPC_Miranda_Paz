<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recepcionistas.aspx.cs" Inherits="Presentación.Recepcionistas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
 <div class="row">
                <div class="col-3">

                    <%--FORMULARIO DE REGISTRO RECEPCIONISTA--%>

                    <div class="card">
                        <div class="card-header">Formulario: Recepcionista</div>
                        <div class="card-body">
                            <h5 class="card-title">Registrar Recepcionista</h5>
                            <p class="card-text text-muted">Los campos * son obligatorios</p>
                            <form>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="nombre_recep" name="nombre_recep" placeholder="*Nombre" runat="server" />
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="apellido_recep" name="apellido_recep" placeholder="*Apellido" runat="server" />
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="dni_recep" name="dni_recep" placeholder="*DNI" runat="server" />
                                    <div class="invalid-feedback">
                                        DNI ya registrado
                                    </div>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="telefono_recep" name="telefono_recep" placeholder="*Telefono" runat="server" />
                                </div>
                                <div class="form-group">
                                    <input type="email" class="form-control" id="email_recep" name="email_recep" aria-describedby="emailHelp" placeholder="*Email" runat="server" />
                                    <div class="invalid-feedback">
                                        Email ya registrado
                                    </div>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="pass_recep" name="pass_recep" placeholder="*Contraseña" runat="server" />
                                </div>
                                <asp:Button ID="BtnRegistrar_Recepcionista" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClientClick="return validarVacioRecep()" OnClick="BtnRegistrar_Recepcionista_Click" />
                            </form>
                        </div>
                    </div>
                </div>

                <div class="col">
                    <div class="card">

                        <%--ENCABEZADO DE GRILLA CON RECEPCIONISTAS CARGADOS--%>

                        <div class="card-header d-flex justify-content-between align-items-center">
                            <div>Recepcionistas</div>
                            <div class="form-inline my-2 my-lg-0">
                                <asp:TextBox ID="TxtBuscarRecepcionista" Text="Buscar" CssClass="form-control mr-sm-2" OnTextChanged="TxtBuscarRecepcionista_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <%--GRILLA DE RECEPCIONISTAS--%>

                        <div class="card-body ">
                            <div class="test-overflow">

                                <asp:GridView ID="GridRecepcionista" OnLoad="GridRecepcionista_Load1" AutoGenerateColumns="false" OnSelectedIndexChanged="GridRecepcionista_SelectedIndexChanged" runat="server">
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
                            <h5 class="modal-title" id="exampleModalLabel" runat="server">Datos del recepcionista</h5>
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
                                <asp:TextBox ID="TxtId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtApellido" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblDni" runat="server" Text="DNI"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtDNI" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblPass" runat="server" Text="Contraseña"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtPass" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-body row">
                            <div class="col-2">
                                <asp:Label ID="LblTelefono" runat="server" Text="Teléfono"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <%--PIE DE MODAL--%>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminar_Click"/>
                            <asp:Button ID="BtnEditar" runat="server" Text="Editar" CssClass="btn btn-warning" OnClientClick="return habilitar()" />
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


        function validarVacioRecep() {
            var verificado = true;

            let nombre = document.getElementById("<%=nombre_recep.ClientID%>");
            let apellido = document.getElementById("<%=apellido_recep.ClientID%>");
            let dni = document.getElementById("<%=dni_recep.ClientID%>");
            let email = document.getElementById("<%=email_recep.ClientID%>");
            let tel = document.getElementById("<%=telefono_recep.ClientID%>");
            let nac = document.getElementById("<%=pass_recep.ClientID%>");

            /*var array = [nombre, apellido]*/

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
