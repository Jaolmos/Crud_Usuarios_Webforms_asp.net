Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ValidarUsuario(sender As Object, e As EventArgs)
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Dim count As Integer = 0

        Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
            conexion.Open()
            Dim consulta As String = "SELECT COUNT(*) FROM Login WHERE nombreusuario = @username AND contrasena = @password"
            Using comando As New SqlCommand(consulta, conexion)
                With comando
                    .Parameters.AddWithValue("@username", username)
                    .Parameters.AddWithValue("@password", password)
                    count = Convert.ToInt32(comando.ExecuteScalar())
                End With
            End Using
            If count > 0 Then
                Session("Usuario") = username
                Response.Redirect("Default.aspx")
            Else
                lblMensajeError.Text = "Nombre de usuario o contraseña incorrecta."
            End If
        End Using

    End Sub
End Class