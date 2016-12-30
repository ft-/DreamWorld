Imports System
Imports IniParser
Imports System.IO
Imports System.ComponentModel

Public Class FormRegion

#Region "Declarations"

    Private Class Region_data
        Public RegionName As String
        Public UUID As String
        Public CoordX As Integer
        Public CoordY As String
        Public RegionPort As Integer
        Public SizeX As Integer
        Public SizeY As Integer
    End Class

    Dim gNum As Integer = 1 ' pointer to this Object
    Dim MyRegion As New Region_data
    Dim initted As Boolean = False
    Dim changed_value As Boolean
    Public Property changed() As Boolean
        Get
            Return changed_value
        End Get
        Set(ByVal Value As Boolean)
            changed_value = Value
        End Set
    End Property


#End Region

#Region "Functions"

    Public Sub Init(num As Integer)

        gNum = num

        MyRegion.RegionName = Form1.aRegion(num).RegionName
        MyRegion.UUID = Form1.aRegion(num).UUID
        MyRegion.CoordX = Form1.aRegion(num).CoordX
        MyRegion.CoordY = Form1.aRegion(num).CoordY
        MyRegion.RegionPort = Form1.aRegion(num).RegionPort
        MyRegion.SizeY = Form1.aRegion(num).SizeY
        MyRegion.SizeX = Form1.aRegion(num).SizeX


        If MyRegion.SizeX <> MyRegion.SizeY Then
            MyRegion.SizeY = MyRegion.SizeX
        End If

        ' make a new UUID if there is none
        If Len(MyRegion.UUID) <> 36 Then
            MyRegion.UUID = Convert.ToString(Guid.NewGuid())
        End If

        ' reasonable defaults
        If Len(MyRegion.RegionName) = 0 Then
            MyRegion.SizeY = 256
            MyRegion.SizeX = 256

            Dim MaxX As Integer
            Dim MaxY As Integer
            Dim MaxPort As Integer
            Dim counter As Integer = 1
            Dim L = Form1.aRegion.GetUpperBound(0)
            While counter <= L
                Dim port = Form1.aRegion(counter).RegionPort

                If port > MaxPort Then MaxPort = port

                Dim X = Form1.aRegion(counter).CoordX
                If X > MaxX Then MaxX = X

                Dim Y = Form1.aRegion(counter).CoordY
                If Y > MaxY Then MaxY = Y
                counter += 1
            End While
            MyRegion.RegionPort = MaxPort + 1
            MyRegion.CoordX = MaxX + 5
            MyRegion.CoordY = MaxY + 5
        End If

        Me.Text = MyRegion.RegionName
        RegionName.Text = MyRegion.RegionName
        UUID.Text = MyRegion.UUID

        Me.Show()
        Application.DoEvents()

        If MyRegion.SizeY = 256 And MyRegion.SizeX = 256 Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""
        ElseIf MyRegion.SizeY = 512 And MyRegion.SizeX = 512 Then
            RadioButton1.Checked = False
            RadioButton2.Checked = True
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""
        ElseIf MyRegion.SizeY = 768 And MyRegion.SizeX = 768 Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = True
            RadioButton4.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""
        ElseIf MyRegion.SizeY = 1024 And MyRegion.SizeX = 1024 Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = True
            SizeX.Text = ""
            SizeY.Text = ""
        Else
            RadioButton1.Checked = False
            RadioButton1.Checked = False
            RadioButton1.Checked = False
            SizeX.Text = Convert.ToString(MyRegion.SizeX)
            SizeY.Text = Convert.ToString(MyRegion.SizeY)
        End If

        If MyRegion.CoordX <> 0 Then
            CoordX.Text = MyRegion.CoordX
        End If

        If MyRegion.CoordY <> 0 Then
            CoordY.Text = MyRegion.CoordY
        End If

        If MyRegion.RegionPort <> 0 Then
            RegionPort.Text = MyRegion.RegionPort
        End If
        initted = True

    End Sub


    Private Function RegionValidate()

        Dim Message As String

        If Len(MyRegion.RegionName) = 0 Then
            Message = "Region Name must not be blank"
            Form1.Log(Message)
            Return Message
        End If

        ' UUID
        If Len(MyRegion.UUID) <> 36 Then
            Message = "Region UUID is invalid: " + MyRegion.UUID
            Form1.Log(Message)
            Return Message
        End If

        ' global coords
        If Convert.ToInt16(MyRegion.CoordX) = 0 Then
            Message = "Region CoordX is zero"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(MyRegion.CoordX) > 10000 Then
            Message = "Region CoordX is too big"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(MyRegion.CoordY) = 0 Then
            Message = "Region CoordY is zero"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(MyRegion.CoordY) > 10000 Then
            Message = "Region CoordY is too big"
            Form1.Log(Message)
            Return Message
        End If

        If Convert.ToInt16(MyRegion.RegionPort) = 0 Then
            Message = "Region Port cannot be zero or undefined"
            Form1.Log(Message)
            Return Message
        End If

        ' Size
        If Convert.ToInt16(MyRegion.SizeX) = 0 Then
            Message = ("Region Size X is zero")
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(MyRegion.SizeY) = 0 Then
            Message = "Region Size Y is zero"
            Form1.Log(Message)
            Return Message
        End If

        Dim result As Guid
        If Not Guid.TryParse(UUID.Text, result) Then
            Message = "Not a valid UUID"
            Form1.Log(Message)
            Return Message
        End If

        Return ""
    End Function

    Private Sub WriteRegion()

        Dim size As String

        If MyRegion.SizeX = 256 And MyRegion.SizeY = 256 Then
            size = "256,256"
        ElseIf MyRegion.SizeX = 512 And MyRegion.SizeY = 512 Then
            size = "512,512"
        ElseIf MyRegion.SizeX = 768 And MyRegion.SizeY = 768 Then
            size = "768,768"
        ElseIf MyRegion.SizeX = 1024 And MyRegion.SizeY = 1024 Then
            size = "1024,1024"
        Else
            size = Convert.ToString(MyRegion.SizeX) + "," + Convert.ToString(MyRegion.SizeY)
        End If

        Dim RegionText As String = "; * Regions configuration file " + vbCrLf _
    + "; * This Is Your World. Change This And It Will break. See Advance->[Region Settings] instead." + vbCrLf _
    + "; Automatically changed by Dreamworld - do Not change this file!" + vbCrLf _
    + "[" + MyRegion.RegionName + "]" + vbCrLf _
    + "RegionUUID = " + """" + MyRegion.UUID + """" + vbCrLf _
    + "Location = " + """" + Convert.ToString(MyRegion.CoordX) + "," + Convert.ToString(MyRegion.CoordY) + """" + vbCrLf _
    + "InternalAddress = " + """" + "0.0.0.0" + """" + vbCrLf _
    + "InternalPort = " + Convert.ToString(MyRegion.RegionPort) + vbCrLf _
    + "AllowAlternatePorts = False" + vbCrLf _
    + "ExternalHostName = " + My.Settings.PublicIP + vbCrLf _
    + "SizeX = " + Convert.ToString(MyRegion.SizeX) + vbCrLf _
    + "SizeY = " + Convert.ToString(MyRegion.SizeY) + vbCrLf

        ' save the Region File

        Try
            My.Computer.FileSystem.DeleteFile(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\" + MyRegion.RegionName + ".ini")
        Catch
        End Try

        Try
            Using outputFile As New StreamWriter(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\" + MyRegion.RegionName + ".ini", True)
                outputFile.WriteLine(RegionText)
            End Using
        Catch ex As Exception
            Form1.Log("Info:Region file did not exist")
        End Try

    End Sub

#End Region

#Region "Checkboxes"

    Private Sub SizeX_TextChanged(sender As Object, e As EventArgs) Handles SizeX.TextChanged
        If SizeX.Text <> "" Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            MyRegion.SizeX = Convert.ToInt16(SizeX.Text)
            changed = True
        End If

    End Sub

    Private Sub RegionPort_TextChanged(sender As Object, e As EventArgs) Handles RegionPort.TextChanged
        If initted Then
            MyRegion.RegionPort = Convert.ToInt16(RegionPort.Text)
            changed = True
        End If

    End Sub

    Private Sub RegionName_LostFocus(sender As Object, e As EventArgs) Handles RegionName.LostFocus

        If Len(RegionName.Text) > 0 And initted And MyRegion.RegionName <> RegionName.Text Then
            MyRegion.RegionName = RegionName.Text
            Try
                Dim oldname = Form1.aRegion(gNum).RegionName
                My.Computer.FileSystem.RenameFile(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\" + oldname + ".ini", RegionName.Text + ".ini")
            Catch ex As Exception
                Dim str = ex.Message
            End Try
            changed = True
        End If

    End Sub

    Private Sub Coordy_TextChanged(sender As Object, e As EventArgs) Handles CoordY.TextChanged
        If initted Then
            MyRegion.CoordY = Convert.ToInt16(CoordY.Text)
            changed = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If initted Then
            MyRegion.SizeX = 256
            MyRegion.SizeY = 256
            SizeX.Text = ""
            SizeY.Text = ""
            changed = True
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If initted Then
            MyRegion.SizeX = 512
            MyRegion.SizeY = 512
            SizeX.Text = ""
            SizeY.Text = ""
            changed = True
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If initted Then
            MyRegion.SizeX = 768
            MyRegion.SizeY = 768
            SizeX.Text = ""
            SizeY.Text = ""
            changed = True
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If initted Then
            MyRegion.SizeX = 1024
            MyRegion.SizeY = 1024
            SizeX.Text = ""
            SizeY.Text = ""
            changed = True
        End If

    End Sub

    Private Sub UUID_LostFocus(sender As Object, e As EventArgs) Handles UUID.LostFocus
        If UUID.Text <> MyRegion.UUID And initted Then
            Dim resp = MsgBox("Changing the UUID will lose all data in the old sim and create a new, empty sim. Are you sure you wish to change the UUID?", vbYesNo)
            If resp = vbYes Then
                changed = True
                Dim result As Guid
                If Guid.TryParse(UUID.Text, result) Then
                    MyRegion.UUID = UUID.Text
                Else
                    MsgBox("Not a valid UUID", vbInformation)
                End If
            End If
        End If
    End Sub

    Private Sub SizeX_LostFocus(sender As Object, e As EventArgs) Handles SizeX.LostFocus
        If initted Then
            If SizeX.Text <> SizeY.Text Then
                changed = True
                SizeY = SizeX
            End If
        End If

    End Sub

    Private Sub SizeY_LostFocus(sender As Object, e As EventArgs) Handles SizeY.LostFocus
        If initted Then
            If SizeX.Text <> SizeY.Text Then
                changed = True
                SizeX = SizeY
            End If
        End If

    End Sub

    Private Sub SizeX_TextChanged_1(sender As Object, e As EventArgs) Handles SizeX.TextChanged
        If initted Then
            If SizeX.Text <> "" Then
                changed = True
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = False
                MyRegion.CoordX = Convert.ToInt16(CoordX.Text)
            End If
        End If

    End Sub
    Private Sub SizeY_TextChanged(sender As Object, e As EventArgs) Handles SizeY.TextChanged
        If initted Then
            If SizeY.Text <> "" Then
                changed = True
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = False
                MyRegion.SizeY = Convert.ToInt16(SizeY.Text)
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.aRegion(gNum).RegionName = MyRegion.RegionName
        Form1.aRegion(gNum).UUID = MyRegion.UUID
        Form1.aRegion(gNum).CoordX = MyRegion.CoordX
        Form1.aRegion(gNum).CoordY = MyRegion.CoordY
        Form1.aRegion(gNum).RegionPort = MyRegion.RegionPort
        Form1.aRegion(gNum).SizeY = MyRegion.SizeY
        Form1.aRegion(gNum).SizeX = MyRegion.SizeX

        Dim message = RegionValidate()
        If Len(message) Then
            Dim v = MsgBox(message + vbCrLf + "Discard all changes and exit anyway?", vbYesNo)
            If v = vbYes Then
                Me.Close()
            End If
        Else
            WriteRegion()
        End If
    End Sub



    Private Sub FormRegion_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If changed Then
            Dim v = MsgBox("Save changes?", vbYesNo)
            If v = vbYes Then
                Dim message = RegionValidate()
                If Len(message) Then
                    v = MsgBox(message + vbCrLf + "Discard all changes and exit anyway?", vbYesNo)
                    If v = vbYes Then
                        Me.Close()
                    End If
                Else
                    WriteRegion()
                End If
            End If

        End If
    End Sub
#End Region

End Class