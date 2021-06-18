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
					<form>
						<div class="text-center pb-3">
							<img
								src="https://laslomas.com.ar/wp-content/uploads/2020/10/logo_header.png"
								alt=""
								width="80%"
							/>
						</div>
						<div class="text-center">
							<h1 class="h3">Iniciar Sesion</h1>
						</div>
						<div class="form-group">
							<input
								type="email"
								class="form-control"
								id="exampleInputEmail1"
								aria-describedby="emailHelp"
								placeholder="Email"
							/>
						</div>
						<div class="form-group">
							<input
								type="password"
								class="form-control"
								id="exampleInputPassword1"
								placeholder="Password"
							/>
						</div>
						<button type="submit" class="btn btn-outline-primary btn-block">
							Iniciar
						</button>
					</form>
				</div>
			</div>
		</section>
</body>
</html>
