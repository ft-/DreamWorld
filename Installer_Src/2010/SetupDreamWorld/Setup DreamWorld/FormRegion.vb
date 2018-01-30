
Imports System.IO
Imports System.ComponentModel

Public Class FormRegion

#Region "Declarations"
    Dim o As New Object
    Dim oldname As String = ""
    Dim initted As Boolean = False ' needed a flag to see if we are initted as the dialogs change on start.
    Dim changed As Boolean    ' true if we need to save a form

#End Region

#Region "Functions"

    Public Sub Init(Name As String)

        o = Form1.RegionClass.FindRegionByName(Name)

        oldname = o.RegionName ' backup in case of rename
        EnabledCheckBox.Checked = o.RegionEnabled()
        '''''''''''''''''''''''''''''''
        ' reasonable default section 

        Dim result As Guid
        ' make a new UUID if there is none or invalid
        If Not Guid.TryParse(o.UUID, result) Then
            o.UUID = Convert.ToString(Guid.NewGuid())
        End If

        ' gack, no region, must be an Add button
        If Len(o.RegionName) = 0 Then
            o.SizeY = 256
            o.SizeX = 256

            ' locate largest X and Y global coords, and Region Port
            ' Add something to make sure we do not intersect
            o.RegionPort = o.LargestPort + 1
            o.CoordX = o.LargestX + 5
            o.CoordY = o.LargestY

        End If

        ' save them
        Me.Text = o.RegionName ' on screen
        RegionName.Text = o.RegionName ' on form
        UUID.Text = o.UUID   ' on screen

        Me.Show() ' time to show the results
        Me.Focus()
        Application.DoEvents()

        ' Size buttons
        If o.SizeY = 256 And o.SizeX = 256 Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""
        ElseIf o.SizeY = 512 And o.SizeX = 512 Then
            RadioButton1.Checked = False
            RadioButton2.Checked = True
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""
        ElseIf o.SizeY = 768 And o.SizeX = 768 Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = True
            RadioButton4.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""
        ElseIf o.SizeY = 1024 And o.SizeX = 1024 Then
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
            SizeX.Text = Convert.ToString(o.SizeX)
            SizeY.Text = Convert.ToString(o.SizeY)
        End If

        ' global coords
        If o.CoordX <> 0 Then
            CoordX.Text = o.CoordX
        End If

        If o.CoordY <> 0 Then
            CoordY.Text = o.CoordY
        End If

        ' and port
        If o.RegionPort <> 0 Then
            RegionPort.Text = o.RegionPort
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

    Private Function RegionValidate() As String

        Dim Message As String

        If Len(o.RegionName) = 0 Then
            Message = "Region name must not be blank"
            Form1.Log(Message)
            Return Message
        End If

        ' UUID
        Dim result As Guid
        If Not Guid.TryParse(o.UUID, result) Then
            Message = "Region UUID is invalid: " + o.UUID
            Form1.Log(Message)
            Return Message
        End If

        ' global coords
        If Convert.ToInt16(o.CoordX) = 0 Then
            Message = "Region CoordX cannot be zero"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(o.CoordX) > 65536 Then
            Message = "Region CoordX is too large"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(o.CoordY) = 0 Then
            Message = "Region CoordY cannot be zero"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(o.CoordY) > 65536 Then
            Message = "Region CoordY is too large"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(o.RegionPort) = 0 Then
            Message = "Region Port cannot be zero or undefined"
            Form1.Log(Message)
            Return Message
        End If
        ' Size
        If Convert.ToInt16(o.SizeX) = 0 Then
            Message = ("Region Size X cannot be zero")
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(o.SizeY) = 0 Then
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

    Private Sub WriteRegion(ByVal o As Object)

        Dim dir = Form1.prefix
        ' save the Region File

        Dim Filepath = o.RegionPath

        Dim path = o.FolderPath
        'Directory.CreateDirectory(o.FolderPath)
        ' rename is possible
        If oldname <> o.RegionName Then
            Try
                File.Delete(Filepath)
                Try
                    Filepath = dir & "bin\Regions\" + o.RegionName + "\Region\"
                    Directory.CreateDirectory(Filepath)
                    Filepath = Filepath + o.RegionName + ".ini"
                Catch
                    MsgBox("Cannot create new region. It seems to already exist")
                End Try

            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If

        ' might be a new region, so no path exists
        If Filepath.length = 0 Then

            Filepath = dir & "bin\Regions\" + o.RegionName + "\Region\" + o.RegionName
            o.RegionPath = Filepath

            If Not Directory.Exists(Filepath) Then
                Directory.CreateDirectory(dir & "bin\Regions\" + o.RegionName + "\Region")
            End If

        End If

        Dim Region = "; * Regions configuration file" &
                        "; * This Is Your World. See Common Settings->[Region Settings]." & vbCrLf &
                        "; Automatically changed by Dreamworld" & vbCrLf &
                        "[" & o.RegionName & "]" & vbCrLf &
                        "RegionUUID = " & o.UUID & vbCrLf &
                        "Location = " & o.CoordX & "," & o.CoordY & vbCrLf &
                        "InternalAddress = 0.0.0.0" & vbCrLf &
                        "InternalPort = " & o.RegionPort & vbCrLf &
                        "AllowAlternatePorts = False" & vbCrLf &
                        "ExternalHostName = " & My.Settings.PublicIP & vbCrLf &
                        "SizeX = " & o.SizeX & vbCrLf &
                        "SizeY = " & o.SizeY & vbCrLf &
                        "Enabled = " & o.RegionEnabled & vbCrLf
        'C:\Opensim\Outworldz Source\OutworldzFiles\Opensim\bin\Regions\Frankis\Region\
        Try
            Using outputFile As New StreamWriter(Filepath, False)
                outputFile.Write(Region)
            End Using
        Catch
        End Try

        oldname = o.RegionName

    End Sub

#End Region

#Region "Checkboxes"

    Private Sub Coordy_TextChanged(sender As Object, e As EventArgs) Handles CoordY.TextChanged
        If initted And CoordY.Text <> "" Then

            o.CoordY = Convert.ToInt16(CoordY.Text)
            changed = True
        End If
    End Sub

    Private Sub CoordX_TextChanged(sender As Object, e As EventArgs) Handles CoordX.TextChanged
        If initted And CoordX.Text <> "" Then

            o.CoordX = Convert.ToInt16(CoordX.Text)
            changed = True
        End If
    End Sub

    Private Sub RegionPort_TextChanged(sender As Object, e As EventArgs) Handles RegionPort.TextChanged
        If initted Then
            Try
                o.RegionPort = Convert.ToInt16(RegionPort.Text)
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

            o.RegionName = RegionName.Text
            Me.Text = o.RegionName
            changed = True
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If initted Then
            o.SizeX = 256
            o.SizeY = 256
            SizeX.Text = ""
            SizeY.Text = ""
            changed = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If initted Then
            o.SizeX = 512
            o.SizeY = 512
            SizeX.Text = ""
            SizeY.Text = ""
            changed = True
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If initted Then
            o.SizeX = 768
            o.SizeY = 768
            SizeX.Text = ""
            SizeY.Text = ""
            changed = True
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If initted Then
            o.SizeX = 1024
            o.SizeY = 1024
            SizeX.Text = ""
            SizeY.Text = ""
            changed = True
        End If
    End Sub

    Private Sub UUID_LostFocus(sender As Object, e As EventArgs) Handles UUID.LostFocus

        If UUID.Text <> o.UUID And initted Then
            Dim resp = MsgBox("Changing the UUID will lose all data in the old sim and create a new, empty sim. Are you sure you wish to change the UUID?", vbYesNo)
            If resp = vbYes Then
                changed = True
                Dim result As Guid
                If Guid.TryParse(UUID.Text, result) Then
                    o.UUID = UUID.Text
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
                    o.SizeX = Convert.ToInt16(SizeX.Text)
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
                    o.SizeY = Convert.ToInt16(SizeY.Text)
                Catch
                End Try

            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Form1.RegionClass.RegionName = o.RegionName
        Form1.RegionClass.UUID = o.UUID
        Form1.RegionClass.CoordX = o.CoordX
        Form1.RegionClass.CoordY = o.CoordY
        Form1.RegionClass.RegionPort = o.RegionPort
        Form1.RegionClass.SizeY = o.SizeY
        Form1.RegionClass.SizeX = o.SizeX

        Dim message = RegionValidate()
        If Len(message) Then
            Dim v = MsgBox(message + vbCrLf + "Discard all changes and exit anyway?", vbYesNo)
            If v = vbYes Then
                Me.Close()
            End If
        Else
            WriteRegion(o)
            Form1.CopyOpensimProto()

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
                    WriteRegion(o)
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

    Private Function IsPowerOf256(x As Integer) As Boolean
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
                My.Computer.FileSystem.DeleteDirectory(Form1.prefix & "bin\Regions\" + RegionName.Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
                Form1.RegionClass.GetAllRegions()
                Form1.CopyOpensimProto()
                Me.Close()
            Catch ex As Exception
                MsgBox("Cannot delete region file:" + ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub EnabledCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EnabledCheckBox.CheckedChanged
        o.RegionEnabled = EnabledCheckBox.Checked
    End Sub


#End Region

End Class