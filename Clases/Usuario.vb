Public Class Usuario
    Public Property Id As Integer
    Public Property Nombre As String
    Public Property Email As String
    Public Property Telefono As String

    Public Sub New(id As Integer, nombre As String, email As String, telefono As String)
        Me.Id = id
        Me.Nombre = nombre
        Me.Email = email
        Me.Telefono = telefono
    End Sub

End Class
