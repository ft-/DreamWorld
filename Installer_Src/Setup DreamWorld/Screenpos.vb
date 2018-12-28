
Imports System.IO
Imports IniParser

Public Class ScreenPos
    Dim myINI As String
    Dim parser As FileIniDataParser
    Dim Data As IniParser.Model.IniData
    Dim Name As String

    Public Sub New(aName As String)
        Name = aName ' save name for this form
        parser = New FileIniDataParser()
        parser.Parser.Configuration.SkipInvalidLines = True
        parser.Parser.Configuration.AssigmentSpacer = ""
        parser.Parser.Configuration.CommentString = ";" ' Opensim uses semicolons
        myINI = Form1.MyFolder + "\OutworldzFiles\XYSettings.ini"

        If File.Exists(myINI) Then
            LoadXYIni()
        Else
            Dim contents = "[Data]" + vbCrLf
            Using outputFile As New StreamWriter(myINI, True)
                outputFile.WriteLine(contents)
            End Using
            LoadXYIni()
        End If

    End Sub

    Public Sub SaveXY(ValueX As Integer, ValueY As Integer)


        Dim ValueXOld = CType(Data("Data")(Name + "_X"), Integer)
        Dim ValueYOld = CType(Data("Data")(Name + "_Y"), Integer)


        If ValueX < 0 Then
            ValueX = 100
        End If

        If ValueY < 0 Then
            ValueY = 100
        End If

        LoadXYIni()
        SetXYIni("Data", Name + "_X", ValueX.ToString)
        SetXYIni("Data", Name + "_Y", ValueY.ToString)
        SaveXYSettings()
        Debug.Print("X>" + ValueX.ToString)
        Debug.Print("Y>" + ValueY.ToString)

    End Sub

    Public Function GetXY() As List(Of Integer)

        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        Dim ValueXOld = CType(Data("Data")(Name + "_X"), Integer)
        Dim ValueYOld = CType(Data("Data")(Name + "_Y"), Integer)
        If ValueXOld <= 0 Then
            ValueXOld = 100
        End If
        If ValueYOld <= 0 Then
            ValueYOld = 100
        End If
        Dim r As New List(Of Integer)
        r.Add(ValueXOld)
        r.Add(ValueYOld)
        Debug.Print("X<" + ValueXOld.ToString)
        Debug.Print("Y<" + ValueYOld.ToString)
        Return r

    End Function

    Private Sub SetXYIni(section As String, key As String, value As String)

        ' sets values into any INI file
        Try
            Form1.Log("Info:Writing section [" + section + "] " + key + "=" + value)
            Data(section)(key) = value ' replace it 
        Catch ex As Exception
            Form1.Log(ex.Message)
        End Try

    End Sub

    Public Sub LoadXYIni()

        Try
            Form1.Log("Loading " + myINI)
            Data = parser.ReadFile(myINI, System.Text.Encoding.ASCII)
        Catch ex As Exception
            Form1.Log(ex.Message)
        End Try

    End Sub

    Public Sub SaveXYSettings()

        Try
            parser.WriteFile(myINI, Data, System.Text.Encoding.ASCII)
        Catch ex As Exception
            Form1.Log("Error:" + ex.Message)
        End Try

    End Sub
End Class
