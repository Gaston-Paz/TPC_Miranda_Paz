<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="Presentación.Medicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
				<div class="col-12">
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
							<table class="table table-bordered table-hover">
								<thead class="thead-dark">
									<tr>
										<th scope="col">Id</th>
										<th scope="col">Nombre</th>
										<th scope="col">Apellido</th>
										<th scope="col">Especialidad</th>
										<th scope="col">Matricula</th>
										<th scope="col">Email</th>
									</tr>
								</thead>
								<tbody>

                                    <% foreach (Dominio.Medico item in listaMedicos)
                                        { %>
										<tr>

											<th> <%= item.Id %> </th>
											<th> <%= item.Nombre %> </th>
											<th> <%= item.Apellido %> </th>
											<th> <%= item.Especialidad.Nombre %> </th>
											<th> <%= item.Martricula %> </th>
											<th> <%= item.Email %> </th>

										</tr>


                                       <% } %>

								</tbody>
							</table>
						</div>
					</div>
				</div>
			</div>

</asp:Content>
