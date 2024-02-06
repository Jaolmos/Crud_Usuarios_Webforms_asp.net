<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebApplication_Usuario._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro usuarios</title>
    <link href="assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="assets/bootstrap/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <h1>Registro de Usuarios</h1>
                <div class="my-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" Width="240px"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" Width="240px"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" Width="240px"></asp:TextBox>
                </div>

                <div>
                    <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar Usuario" class="btn btn-primary" OnClick="btnAgregarUsuario_Click" />
                </div>
                <div>
                    <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red" Text=""></asp:Label>
                </div>
                </div>
            </div>


            <div>
                <div class="row justify-content-center">
                    <div class="col-md-8">
                        <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" class="mt-5"
                        OnRowDeleting="GridViewUsuarios_RowDeleting"
                        OnRowCancelingEdit="GridViewUsuarios_RowCancelingEdit"
                        OnRowEditing="GridViewUsuarios_RowEditing"
                        OnRowUpdating="GridViewUsuarios_RowUpdating">

                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNombreEdit" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmailEdit" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Teléfono" SortExpression="Telefono">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTelefonoEdit" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTelefono" runat="server" Text='<%# Eval("Telefono") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" HeaderText="Acciones" />
                        </Columns>
                    </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
