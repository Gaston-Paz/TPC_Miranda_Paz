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
                    <form>
                        <div class="form-group">
                            <div class="form-inline">
                                <input type="text" class="form-control" id="dni" placeholder="dni" runat="server"/>
                                 <button type="button" class="btn btn-primary ml-1" onserverclick="BtnBuscar_Click" runat="server">
                                    <i class="fas fa-search"></i>
                                </button>


                            </div>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name="" id="nombre" placeholder="pepe" visible="false" runat="server" readonly/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name="" id="apellido" visible="false" placeholder="mujica" runat="server" readonly/>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="DropEspecialidades" Visible="false" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropEspecialidades_SelectedIndexChanged" runat="server"></asp:DropDownList> 
                        </div>
                        <div class="form-group" visible="false">
                            <asp:DropDownList ID="DropMedicos" Visible="false" CssClass="form-control" OnSelectedIndexChanged="DropMedicos_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </select>
                        </div>
                        <div class="form-group" >

                            <asp:DropDownList ID="DropFechas" CssClass="form-control" Visible="false" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group" visible="false">
                            <select class="form-control">
                                <option>Horarios</option>
                                <option>1er turno 7am</option>
                            </select>
                        </div>

                        <button type="submit" class="btn btn-primary mt-2">
                            Agendar
                        </button>
                    </form>
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
