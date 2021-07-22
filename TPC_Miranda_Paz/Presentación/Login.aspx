<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentación.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link
			rel="stylesheet"
			href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css"
			integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l"
			crossorigin="anonymous"
		/>
    <title>Login</title>
</head>
<body>
    <section class="container">
        <div class="row justify-content-center vh-100 align-content-center">
            <div class="col-4">
                <form id="formLogin" runat="server">
                    <div class="text-center pb-3">
                        <img
                            src="https://laslomas.com.ar/wp-content/uploads/2020/10/logo_header.png"
                            alt=""
                            width="80%" />
                    </div>

                    <div class="text-center">
                        <h1 class="h3">Iniciar Sesion</h1>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        <div class="invalid-feedback">
                            El campo no puede estar vacio.
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <div class="invalid-feedback">
                            El campo no puede estar vacio.
                        </div>
                    </div>
                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar" autopostback="false" OnClientClick="return validar()" CssClass="btn btn-outline-primary btn-block" OnClick="btnLogin_Click" />
                </form>
            </div>
        </div>
    </section>

    <script>
        function validar() {
            console.log("validar in"); // se ejecuta

            var formLogin = document.getElementById("formLogin");
            console.log(formLogin); // trae el form

            var email = document.getElementById("txtEmail");
            var pass = document.getElementById("txtPass");
            console.log(email.value + pass.value); // trae inputs

            if (email.value == "" || pass.value == "") {

                if (email.value == "") {
                    email.classList.add("is-invalid");

                } else {
                    email.classList.remove("is-invalid");
                }

                if (pass.value == "") {
                    pass.classList.add("is-invalid");

                } else {
                    pass.classList.remove("is-invalid");
                }
                return false;
            }

            console.log("validar out"); // termina la funcion
            return true;
        }

        window.addEventListener("load", function (e) {
            var email = document.getElementById("txtEmail");
            var pass = document.getElementById("txtPass");

            email.addEventListener("keypress", function (e) {
                email.classList.remove("is-invalid");
            })

            pass.addEventListener("keypress", function (e) {
                pass.classList.remove("is-invalid");
            })

            console.log("load");
        })

    </script>
</body>
</html>
