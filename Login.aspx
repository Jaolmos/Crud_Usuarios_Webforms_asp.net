<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="WebApplication_Usuario.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="assets/bootstrap/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="text-center mb-4">
                        <h2>Iniciar Sesión</h2>
                    </div>
                    <div class="mb-3">
                        <label for="username" class="form-label">Nombre de usuario:</label>
                        <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="password" class="form-label">Contraseña:</label>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="d-grid">
                        <asp:Button ID="loginButton" CssClass="btn btn-primary" runat="server" Text="Ingresar" OnClick="ValidarUsuario" />
                    </div>
                    <%--Mensaje de error--%> 
                     <div class="text-center mt-3">
                    <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
                </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
