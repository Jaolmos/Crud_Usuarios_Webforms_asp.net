Imports System.Data.SqlClient
Imports System.Configuration

Public Class ConexionBD

    Public Shared ReadOnly Property CadenaConexion() As String
        Get
            Return ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString
        End Get
    End Property

    Public Shared Function ObtenerConexion() As SqlConnection
        Return New SqlConnection(CadenaConexion)
    End Function

End Class
