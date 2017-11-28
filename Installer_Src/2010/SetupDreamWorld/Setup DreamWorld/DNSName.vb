Imports System.Text.RegularExpressions
Imports System.Net

Public Class DNSName

#Region "Functions"

    Public Function Random() As String
        Dim value As Integer = CInt(Int((600000000 * Rnd()) + 1))
        Random = System.Convert.ToString(value)
    End Function
#End Region

End Class