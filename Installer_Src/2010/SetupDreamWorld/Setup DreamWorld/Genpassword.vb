Imports System.Security.Cryptography
Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class PassGen
    Private randomBytes() As Byte
    Private randomInt32Value As Integer
    Private possibleChars As String
    Private len As Int32
    Private GetRandomInt32Value As New RandomInt32Value
    Private GetPasswordGenProfiler As New PasswordGenProfiler

    Public Function GeneratePass()
        possibleChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()"
        len = 6

        Try
            Dim cpossibleChars() As Char
            cpossibleChars = possibleChars.ToCharArray()

            Dim builder As New StringBuilder()

            For i As Integer = 0 To len - 1
                Dim randInt32 As Integer = GetRandomInt32Value.GetRandomInt()
                Dim r As New Random(randInt32)

                Dim nextInt As Integer = r.[Next](cpossibleChars.Length)
                Dim c As Char = cpossibleChars(nextInt)
                builder.Append(c)
            Next
            Return builder.ToString()
        Catch ex As Exception
            Form1.Log("exception on password:" + ex.Message)
        End Try
        Return "secret"
    End Function
End Class


Public Class PasswordGenProfiler
    Public Shared Function GetFrequencyDistributionOfChars(allowableChars As String, generatedPass As String) As Dictionary(Of Char, Integer)
        Dim distrib As New Dictionary(Of Char, Integer)()
        ' initialize all values to 0
        For Each c As Char In allowableChars
            ' If character is listed more than once, don't re-add it to our list.
            If Not distrib.ContainsKey(c) Then
                distrib.Add(c, 0)
            End If
        Next
        Dim val As Integer = 0
        For Each passChar As Char In generatedPass
            If distrib.TryGetValue(passChar, val) Then
                distrib(passChar) = System.Threading.Interlocked.Increment(val)
            End If
        Next

        Return distrib
    End Function
End Class

Public Class RandomInt32Value
    Public Function GetRandomInt() As Integer
        Dim randomBytes As Byte() = New Byte(3) {}
        Dim rng As New RNGCryptoServiceProvider()
        rng.GetBytes(randomBytes)
        Dim randomInt As Integer = BitConverter.ToInt32(randomBytes, 0)
        Return randomInt
    End Function
End Class
