Imports System.Data.SqlClient

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarUsuarios()
        End If
    End Sub

    Private Sub CargarUsuarios()
        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()
                Dim consulta As String = "SELECT Id, Nombre, Email, Telefono FROM Usuarios"
                Using adaptador As New SqlDataAdapter(consulta, conexion)
                    Dim ds As New DataSet()
                    adaptador.Fill(ds, "Usuarios")

                    Dim listaUsuarios As New List(Of Usuario)()

                    For Each row As DataRow In ds.Tables("Usuarios").Rows
                        Dim id As Integer = If(row.Table.Columns.Contains("Id"), Convert.ToInt32(row("Id")), 0)
                        Dim usuario As New Usuario(
                                id,
                                row("Nombre").ToString(),
                                row("Email").ToString(),
                                row("Telefono").ToString()
                            )
                        listaUsuarios.Add(usuario)
                    Next

                    GridViewUsuarios.DataSource = listaUsuarios
                    GridViewUsuarios.DataBind()
                End Using
            End Using
        Catch ex As Exception
            Response.Write($"Error al cargar usuarios: {ex.Message}")
        End Try
    End Sub

    Protected Sub btnAgregarUsuario_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregarUsuario.Click
        Dim nombre As String = txtNombre.Text
        Dim email As String = txtEmail.Text
        Dim telefono As String = txtTelefono.Text

        If Not String.IsNullOrEmpty(nombre) AndAlso Not String.IsNullOrEmpty(email) Then
            AgregarUsuario(nombre, email, telefono)
            CargarUsuarios()

            txtNombre.Text = ""
            txtEmail.Text = ""
            txtTelefono.Text = ""

            lblMensajeError.Text = ""
        Else
            lblMensajeError.Text = "Por favor, completa todos los campos..."
        End If
    End Sub

    Private Sub AgregarUsuario(nombre As String, email As String, telefono As String)
        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()
                Dim consulta As String = "INSERT INTO Usuarios (Nombre, Email, Telefono) VALUES (@Nombre, @Email, @Telefono)"
                Using comando As New SqlCommand(consulta, conexion)
                    With comando
                        .Parameters.AddWithValue("@Nombre", nombre)
                        .Parameters.AddWithValue("@Email", email)
                        .Parameters.AddWithValue("@Telefono", telefono)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch ex As Exception
            Response.Write($"Error al agregar usuario: {ex.Message}")
        End Try
    End Sub

    Protected Sub GridViewUsuarios_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles GridViewUsuarios.RowDeleting
        Dim userId As Integer = Convert.ToInt32(GridViewUsuarios.DataKeys(e.RowIndex).Values("Id"))
        BorrarUsuario(userId)
        CargarUsuarios()
    End Sub

    Private Sub BorrarUsuario(userId As Integer)
        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()
                Dim consulta As String = "DELETE FROM Usuarios WHERE Id = @Id"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Id", userId)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Response.Write($"Error al borrar usuario: {ex.Message}")
        End Try
    End Sub

    Protected Sub GridViewUsuarios_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs) Handles GridViewUsuarios.RowCancelingEdit
        GridViewUsuarios.EditIndex = -1
        CargarUsuarios()
    End Sub

    Protected Sub GridViewUsuarios_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles GridViewUsuarios.RowEditing
        GridViewUsuarios.EditIndex = e.NewEditIndex
        CargarUsuarios()
    End Sub

    Protected Sub GridViewUsuarios_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridViewUsuarios.RowUpdating
        Dim userId As Integer = Convert.ToInt32(GridViewUsuarios.DataKeys(e.RowIndex).Values("Id"))
        Dim nuevoNombre As String = TryCast(GridViewUsuarios.Rows(e.RowIndex).FindControl("txtNombreEdit"), TextBox).Text
        Dim nuevoEmail As String = TryCast(GridViewUsuarios.Rows(e.RowIndex).FindControl("txtEmailEdit"), TextBox).Text
        ActualizarUsuario(userId, nuevoNombre, nuevoEmail)
        GridViewUsuarios.EditIndex = -1
        CargarUsuarios()
    End Sub

    Private Sub ActualizarUsuario(userId As Integer, nuevoNombre As String, nuevoEmail As String)
        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()
                Dim consulta As String = "UPDATE Usuarios SET Nombre = @Nombre, Email = @Email WHERE Id = @Id"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Id", userId)
                    comando.Parameters.AddWithValue("@Nombre", nuevoNombre)
                    comando.Parameters.AddWithValue("@Email", nuevoEmail)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Response.Write($"Error al actualizar usuario: {ex.Message}")
        End Try
    End Sub
End Class
