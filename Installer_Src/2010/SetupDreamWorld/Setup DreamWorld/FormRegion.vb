Imports System
Imports IniParser
Imports System.IO
Imports System.ComponentModel

Public Class FormRegion

#Region "Declarations"

    Dim oldname As String = ""
    Dim MyRegion As RegionMaker
    Dim gNum As Integer ' pointer to this region in RegionMake
    Dim initted As Boolean = False ' needed a flag to see if we are initted as the dialogs change on start.
    Dim changed As Boolean    ' true if we need to save a form

#End Region

#Region "Functions"

    Public Sub Init(num As Integer)

        MyRegion = Form1.RegionClass
        MyRegion.CurRegionNum = num
        gNum = num
        oldname = MyRegion.RegionName
        EnabledCheckBox.Checked = MyRegion.RegionEnabled
        '''''''''''''''''''''''''''''''
        ' reasonable default section 

        Dim result As Guid
        ' make a new UUID if there is none or invalid
        If Not Guid.TryParse(MyRegion.UUID, result) Then
            MyRegion.UUID = Convert.ToString(Guid.NewGuid())
        End If

        ' gack, no region, must be an Add button
        If Len(MyRegion.RegionName) = 0 Then
            MyRegion.SizeY = 256
            MyRegion.SizeX = 256

            ' locate largest X and Y global coords, and Region Port
            ' Add something to make sure we do not intersect
            MyRegion.RegionPort = MyRegion.LargestPort + 1
            MyRegion.CoordX = MyRegion.LargestX + 10
            MyRegion.CoordY = MyRegion.LargestY + 10
        End If

        ' save them
        Me.Text = MyRegion.RegionName ' on screen
        RegionName.Text = MyRegion.RegionName ' on form
        UUID.Text = MyRegion.UUID   ' on screen


        Me.Show() ' time to show the results
        Application.DoEvents()

        ' Size buttons
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
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            SizeX.Text = Convert.ToString(MyRegion.SizeX)
            SizeY.Text = Convert.ToString(MyRegion.SizeY)
        End If


        ' global coords
        If MyRegion.CoordX <> 0 Then
            CoordX.Text = MyRegion.CoordX
        End If

        If MyRegion.CoordY <> 0 Then
            CoordY.Text = MyRegion.CoordY
        End If

        ' and port
        If MyRegion.RegionPort <> 0 Then
            RegionPort.Text = MyRegion.RegionPort
        End If
        initted = True

    End Sub

    Public Shared Function FilenameIsOK(ByVal fileName As String) As Boolean
        ' check for invalid chars in file name for INI file
        Dim file As String = Path.GetFileName(fileName)
        Dim directory As String = Path.GetDirectoryName(fileName)

        Return Not (file.Intersect(Path.GetInvalidFileNameChars()).Any() _
                OrElse
                directory.Intersect(Path.GetInvalidPathChars()).Any())
    End Function

    Private Function RegionValidate()

        Dim Message As String

        If Len(MyRegion.RegionName) = 0 Then
            Message = "Region name must not be blank"
            Form1.Log(Message)
            Return Message
        End If

        ' UUID
        Dim result As Guid
        If Not Guid.TryParse(MyRegion.UUID, result) Then
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
            Message = "Region CoordX is too large"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(MyRegion.CoordY) = 0 Then
            Message = "Region CoordY is zero"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(MyRegion.CoordY) > 10000 Then
            Message = "Region CoordY is too large"
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
            Message = ("Region Size X cannot be zero")
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(MyRegion.SizeY) = 0 Then
            Message = "Region Size Y cannot be zero"
            Form1.Log(Message)
            Return Message
        End If

        Dim aresult As Guid
        If Not Guid.TryParse(UUID.Text, aresult) Then
            Message = "Not a valid UUID"
            Form1.Log(Message)
            Return Message
        End If

        Return ""
    End Function

    Private Sub WriteRegion()

        Dim sEnabled As String
        If MyRegion.RegionEnabled Then
            sEnabled = "true"
        Else
            sEnabled = False
        End If

        ' save the Region File
        Dim oldfile = Form1.prefix + "\Regions\" + oldname + "\Region\" + oldname + ".ini"
        Try
            My.Computer.FileSystem.DeleteFile(oldfile)
        Catch ex As Exception
        End Try

        If Not Directory.Exists(Form1.prefix & "\Regions\" + MyRegion.RegionName) Then
            Directory.CreateDirectory(Form1.prefix & "\Regions\" + MyRegion.RegionName)
        End If

        If Not Directory.Exists(Form1.prefix & "\Regions\" + MyRegion.RegionName + "\Region") Then
            Directory.CreateDirectory(Form1.prefix & "\Regions\" + MyRegion.RegionName + "\Region")
        End If

        File.Copy(Form1.prefix & "\bin\Regions.proto", Form1.prefix & "\Regions\" & MyRegion.RegionName & "\" & MyRegion.RegionName & ".ini")

        Form1.LoadIni(Form1.prefix & "\bin\Regions\" & MyRegion.RegionName & "\" & MyRegion.RegionName & ".ini", ";")
        Form1.SetIni(Name, "RegionUUID", MyRegion.UUID)
        Form1.SetIni(Name, "Location", MyRegion.CoordX & "," & MyRegion.CoordY)
        Form1.SetIni(Name, "InternalPort", MyRegion.RegionPort)
        Form1.SetIni(Name, "ExternalHostName", My.Settings.PublicIP)
        Form1.SetIni(Name, "SizeX", MyRegion.SizeX)
        Form1.SetIni(Name, "SizeY", MyRegion.SizeY)
        Form1.SetIni(Name, "Enabled", sEnabled)

        Form1.SaveINI()

        oldname = MyRegion.RegionName

    End Sub

#End Region

#Region "Checkboxes"

    Private Sub Coordy_TextChanged(sender As Object, e As EventArgs) Handles CoordY.TextChanged
        If initted And CoordY.Text <> "" Then
            MyRegion.CoordY = Convert.ToInt16(CoordY.Text)
            changed = True
        End If
    End Sub

    Private Sub CoordX_TextChanged(sender As Object, e As EventArgs) Handles CoordX.TextChanged
        If initted And CoordX.Text <> "" Then
            MyRegion.CoordX = Convert.ToInt16(CoordX.Text)
            changed = True
        End If
    End Sub

    Private Sub RegionPort_TextChanged(sender As Object, e As EventArgs) Handles RegionPort.TextChanged
        If initted Then
            Try
                MyRegion.RegionPort = Convert.ToInt16(RegionPort.Text)
            Catch
            End Try
            changed = True
        End If
    End Sub

    Private Sub RLostFocus(sender As Object, e As EventArgs) Handles RegionName.TextChanged

        If Len(RegionName.Text) > 0 And initted Then
            If Not FilenameIsOK(RegionName.Text) Then
                MsgBox("Region name can't use special characters such as < > : """" / \ | ? *", vbInformation)
                Return
            End If

            MyRegion.RegionName = RegionName.Text
            Me.Text = MyRegion.RegionName
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
                    Dim ok = MsgBox("Not a valid UUID. Do you want a new, Random UUID?", vbOKCancel)
                    If ok = vbOK Then
                        UUID.Text = System.Guid.NewGuid.ToString
                    End If
                End If
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
                Try
                    MyRegion.SizeX = Convert.ToInt16(SizeX.Text)
                Catch
                End Try
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
                Try
                    MyRegion.SizeY = Convert.ToInt16(SizeY.Text)
                Catch
                End Try

            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Form1.RegionClass.RegionName = MyRegion.RegionName
        Form1.RegionClass.UUID = MyRegion.UUID
        Form1.RegionClass.CoordX = MyRegion.CoordX
        Form1.RegionClass.CoordY = MyRegion.CoordY
        Form1.RegionClass.RegionPort = MyRegion.RegionPort
        Form1.RegionClass.SizeY = MyRegion.SizeY
        Form1.RegionClass.SizeX = MyRegion.SizeX

        Dim message = RegionValidate()
        If Len(message) Then
            Dim v = MsgBox(message + vbCrLf + "Discard all changes and exit anyway?", vbYesNo)
            If v = vbYes Then
                Me.Close()
            End If
        Else
            WriteRegion()
            Form1.Sleep(100)
            changed = False
            Me.Close()
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

    Private Sub SizeX_Changed(sender As Object, e As EventArgs) Handles SizeX.LostFocus
        If initted And SizeX.Text <> "" Then
            If Not IsPowerOf256(Convert.ToSingle(SizeX.Text)) Then
                MsgBox("Must be a multiple of 256: 256,512,768,1024,1280,1536,1792,2048,2304,2560, ...", vbInformation)
            Else
                SizeY.Text = SizeX.Text
                changed = True
            End If
        End If
    End Sub


    Private Function IsPowerOf256(x As Integer)
        Dim y As Single = Convert.ToSingle(x)
        While y > 0
            y = y - 256
        End While
        If y = 0 Then
            Return True
        End If
        Return False

    End Function

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        Dim msg = MsgBox("Are you sure you want to delete this region? ", vbYesNo)
        If msg = vbYes Then
            Try
                My.Computer.FileSystem.DeleteDirectory(Form1.prefix & "Regions\" + RegionName.Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
                Me.Close()
            Catch ex As Exception
                MsgBox("Cannot delete region file:" + ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub EnabledCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EnabledCheckBox.CheckedChanged
        MyRegion.RegionEnabled = EnabledCheckBox.Checked
    End Sub


#End Region

End Class