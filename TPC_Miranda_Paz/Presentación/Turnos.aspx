<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Presentación.Turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div class="row">
        <div class="col-3">
            <div class="card">
                <div class="card-header">Formulario: Turnos</div>
                <div class="card-body">
                    <h5 class="card-title">Registrar Turno</h5>
                    <div>
                        <div class="form-group">
                            <div class="form-inline">
                                <input type="text" class="form-control" id="dni" placeholder="DNI Paciente" runat="server"/>
                                <%--<asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-primary fas fa-search" Text="Buscar" OnClick="BtnBuscar_Click" />--%>                        
                               <button ID="BtnBuscar" runat="server" class="btn btn-primary ml-2" Text="Buscar" onserverclick="BtnBuscar_Click"><i class=" fas fa-search"></i></button> 

                            </div>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name="" id="nombre" readonly visible="false" runat="server"/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name="" id="apellido" visible="false" readonly runat="server"/>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="DropEspecialidades" Visible="false" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropEspecialidades_SelectedIndexChanged" runat="server"></asp:DropDownList> 
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="DropMedicos" Visible="false" CssClass="form-control" OnSelectedIndexChanged="DropMedicos_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group" >

                            <asp:DropDownList ID="DropFechas" CssClass="form-control" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="DropFechas_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </div>
                        <asp:DropDownList ID="DropHorarios" Visible="false" CssClass="form-control" runat="server"></asp:DropDownList>

                        <asp:Button ID="BtnAgendar" runat="server" Text="Agendar turno" CssClass="btn btn-primary mt-2" OnClick="BtnAgendar_Click" />
                        
                    </div>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <div
                    class="card-header d-flex justify-content-between align-items-center ">
                    <div>Turnos disponibles</div>
                    <form class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" type="search" placeholder="Buscar" aria-label="Search" />
                    </form>
                </div>
                <div class="card-body ">
                    <div class="test-overflow">
                        <table class="table table-bordered table-hover">
                            <asp:GridView ID="GridTurnosPredictivo" runat="server">
                            </asp:GridView>
                        </table>
                    </div>
                </div>

            </div>
        </div>
         <div class="col">
            <div class="card">
                <div
                    class="card-header d-flex justify-content-between align-items-center ">
                    <div>Turnos registrados</div>
                    <form class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" type="search" placeholder="Buscar" aria-label="Search" />
                    </form>
                </div>
                <div class="card-body ">
                    <div class="test-overflow">
                        <table class="table table-bordered table-hover">
                            <asp:GridView ID="GridTurnos" runat="server">
                            </asp:GridView>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>



</ContentTemplate>
    </asp:UpdatePanel>
            </asp:Content>
