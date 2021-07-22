<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Presentación.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row justify-content-center">
        <div class="col-6">
            <div class="alert alert-warning text-center" role="alert">
                <i class="fas fa-times" style="font-size: 50px;"></i>
                <h3>Hubo un error, vuelve a iniciar sesion.</h3>

                <a href="Login.aspx" class="btn btn-sm btn-primary">Volver</a>
            </div>
        </div>
    </div>

</asp:Content>
