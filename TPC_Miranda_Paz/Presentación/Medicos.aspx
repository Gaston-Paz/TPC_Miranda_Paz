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
    

                            <asp:Button ID="Button3" runat="server" Text="Agregar Especialidad" OnClick="Button3_Click" CssClass="btn btn-success" />
                        <asp:Button ID="BtnRegistrar" runat="server" Text="Registar" OnClick="BtnRegistrar_Click" CssClass="btn btn-primary" />
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
							"
						>
							<div>Profesionales</div>
							<form class="form-inline my-2 my-lg-0">
								<input
									class="form-control mr-sm-2"
									type="search"
									placeholder="Buscar"
									aria-label="Search"
								/>
							</form>
						</div>
						<div class="card-body">
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
                                        { string especialidades = "";
                                            int aux = 0;%>
										<tr>

											<th> <%= item.Id %> </th>
											<th> <%= item.Nombre %> </th>
											<th> <%= item.Apellido %> </th>
											<% foreach (Dominio.Especialidad items in item.Especialidades)
                                                {
                                                    if(aux == 0) { especialidades = especialidades + items.Nombre; aux++; }
                                                    else { especialidades = especialidades + ", " + items.Nombre; }
                                                } %>
                                            <th> <%= especialidades %> </th>
											<th><a href="#" class="" data-toggle="modal" data-target="#exampleModal"><i class="fas fa-edit"></i></a></th>

										</tr>


                                       <% } %>

								</tbody>
							</table>
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
                    <div class="col-3">
                        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                    </div>
                    <div class="col">
                        <asp:TextBox ID="TxtNombre" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
            </div>
            <div class="modal-body row">
                <div class="col-3">
                    <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-body row">
                <div class="col-3">
                    <asp:Label ID="LblDni" runat="server" Text="DNI"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtDNI" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-body row">
                <div class="col-3">
                    <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-body row">
                <div class="col-3">
                    <asp:Label ID="LblTelefono" runat="server" Text="Teléfono"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                </div>
            </div>
             <div class="modal-body row">
                <div class="col-3">
                    <asp:Label ID="LblMatricula" runat="server" Text="Matrícula"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtMatricula" runat="server"></asp:TextBox>
                </div>
                 </div>
                     <div class="modal-body row">
                <div class="col-3">
                    <asp:Label ID="LblEspecialidad" runat="server" Text="Especialidad"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtEspecialidad" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="modal-body row">
                <div class="col-3">
                    <asp:Label ID="LblNacimiento" runat="server" Text="Fecha de nacimiento"></asp:Label>
                </div>
                <div class="col">
                    <div class="form-group">
                        <input
                            type="date"
                            class="form-control"
                            id="Date1"
                            name="fechanacimiento"
                            placeholder="Fecha de nacimiento"
                            runat="server" />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                <asp:Button ID="Button1" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                <asp:Button ID="Button2" runat="server" Text="Editar" CssClass="btn btn-warning" />
                <asp:Button ID="BtnModificar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
        </div>


</asp:Content>
