
Imports System.IO
Imports System.ComponentModel

Public Class FormRegion

#Region "Declarations"
    Dim n As Integer
    Dim oldname As String = ""
    Dim initted As Boolean = False ' needed a flag to see if we are initted as the dialogs change on start.
    Dim changed As Boolean    ' true if we need to save a form
    Dim isNew As Integer = False

#End Region

#Region "Functions"


    Public Sub Init(Name As String)

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        If Name = "" Then
            isNew = True
            RegionName.Text = Name
            UUID.Text = Guid.NewGuid().ToString
            SizeX.Text = 256
            SizeY.Text = 256
            CoordX.Text = RegionClass.LargestX() + 4
            CoordY.Text = RegionClass.LargestY() + 0
            RegionPort.Text = RegionClass.LargestPort() + 1 '8004 + 1
            EnabledCheckBox.Checked = True
            RadioButton1.Checked = True

            n = RegionClass.CreateRegion("")

        Else
            isNew = False
            n = RegionClass.FindRegionByName(Name)
            oldname = RegionClass.RegionName(n) ' backup in case of rename
            EnabledCheckBox.Checked = RegionClass.RegionEnabled(n)
            RegionName.Text = Name
            Me.Text = Name ' on screen
            RegionName.Text = RegionClass.RegionName(n) ' on form
            UUID.Text = RegionClass.UUID(n)   ' on screen

            Me.Show() ' time to show the results
            Me.Focus()
            Application.DoEvents()

            ' Size buttons
            If RegionClass.SizeY(n) = 256 And RegionClass.SizeX(n) = 256 Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
                RadioButton3.Checked = False
                RadioButton4.Checked = False
                SizeX.Text = "256"
                SizeY.Text = "256"
            ElseIf RegionClass.SizeY(n) = 512 And RegionClass.SizeX(n) = 512 Then
                RadioButton1.Checked = False
                RadioButton2.Checked = True
                RadioButton3.Checked = False
                RadioButton4.Checked = False
                SizeX.Text = "512"
                SizeY.Text = "512"
            ElseIf RegionClass.SizeY(n) = 768 And RegionClass.SizeX(n) = 768 Then
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = True
                RadioButton4.Checked = False
                SizeX.Text = "768"
                SizeY.Text = "768"
            ElseIf RegionClass.SizeY(n) = 1024 And RegionClass.SizeX(n) = 1024 Then
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = False
                RadioButton4.Checked = True
                SizeX.Text = "1024"
                SizeY.Text = "1024"
            Else
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = False
                RadioButton4.Checked = False
                SizeX.Text = Convert.ToString(RegionClass.SizeX(n))
                SizeY.Text = Convert.ToString(RegionClass.SizeY(n))
            End If

            ' global coords
            If RegionClass.CoordX(n) <> 0 Then
                CoordX.Text = RegionClass.CoordX(n)
            End If

            If RegionClass.CoordY(n) <> 0 Then
                CoordY.Text = RegionClass.CoordY(n)
            End If

            ' and port
            If RegionClass.RegionPort(n) <> 0 Then
                RegionPort.Text = RegionClass.RegionPort(n)
            End If
        End If
        Me.Focus()
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

        If Len(RegionName.Text) = 0 Then
            Message = "Region name must not be blank"
            Form1.Log(Message)
            Return Message
        End If

        ' UUID
        Dim result As Guid
        If Not Guid.TryParse(UUID.Text, result) Then
            Message = "Region UUID is invalid: " + UUID.Text
            Form1.Log(Message)
            Return Message
        End If

        ' global coords
        If Convert.ToInt16(CoordX.Text) = 0 Then
            Message = "Region CoordX cannot be zero"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(CoordX.Text) > 65536 Then
            Message = "Region CoordX is too large"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(CoordY.Text) = 0 Then
            Message = "Region CoordY cannot be zero"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(CoordY.Text) > 65536 Then
            Message = "Region CoordY is too large"
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(RegionPort.Text) = 0 Then
            Message = "Region Port cannot be zero or undefined"
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

        ' save the Region File, choose an existing DOS box to put it in, or make a new one

        Dim dir = Form1.prefix
        Dim RegionClass As RegionMaker = RegionMaker.Instance

        Dim Filepath = RegionClass.RegionPath(n)

        Dim path = RegionClass.FolderPath(n)

        ' rename is possible
        If oldname <> RegionName.Text And Not isNew Then
            Try
                Directory.Delete(Form1.prefix & "bin\Regions\" + oldname, True)
                Try
                    Filepath = dir & "bin\Regions\" + RegionName.Text + "\Region\"
                    Directory.CreateDirectory(Filepath)
                    Filepath = Filepath + RegionName.Text + ".ini"
                    Form1.CopyOpensimProto()
                Catch
                    MsgBox("Cannot create new region. It seems to already exist")
                    Form1.PrintFast("Aborted")
                    Return
                End Try

            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If

        ' might be a new region, so give them a choice

        If isNew Then
            Dim pathname As String = RegionName.Text
            Dim yesNo As MsgBoxResult = MsgBox("New regions can run in a new DOS box (Yes) or can be combined with other regions in an existing DOS box (NO)", vbYesNo)
            If yesNo = vbNo Then
                pathname = RegionChosen()
                If pathname = "" Then
                    Form1.PrintFast("Aborted")
                    Return
                End If
            End If

            Filepath = dir & "bin\Regions\" + RegionName.Text + "\Region\" + RegionName.Text
            RegionClass.RegionPath(n) = Filepath

            If Not Directory.Exists(Filepath) Then
                Directory.CreateDirectory(dir & "bin\Regions\" + RegionName.Text + "\Region")
            End If

            Filepath = dir & "bin\Regions\" + RegionName.Text + "\Region\" + RegionName.Text + ".ini"
        End If

        Dim Region = "; * Regions configuration file" &
                        "; * This Is Your World. See Common Settings->[Region Settings]." & vbCrLf &
                        "; Automatically changed by Dreamworld" & vbCrLf &
                        "[" & RegionName.Text & "]" & vbCrLf &
                        "RegionUUID = " & UUID.Text & vbCrLf &
                        "Location = " & CoordX.Text & "," & CoordY.Text & vbCrLf &
                        "InternalAddress = 0.0.0.0" & vbCrLf &
                        "InternalPort = " & RegionPort.Text & vbCrLf &
                        "AllowAlternatePorts = False" & vbCrLf &
                        "ExternalHostName = " & My.Settings.PublicIP & vbCrLf &
                        "SizeX = " & SizeX.Text & vbCrLf &
                        "SizeY = " & SizeY.Text & vbCrLf &
                        "Enabled = " & EnabledCheckBox.Checked.ToString & vbCrLf
        'C:\Opensim\Outworldz Source\OutworldzFiles\Opensim\bin\Regions\Frankis\Region\
        Try
            Using outputFile As New StreamWriter(Filepath, False)
                outputFile.Write(Region)
            End Using
        Catch
        End Try

        oldname = RegionName.Text

    End Sub

    Private Function RegionChosen() As String

        Dim Chooseform As New Chooser ' form for choosing a set of regions
        ' Show testDialog as a modal dialog and determine if DialogResult = OK.
        Dim chosen As String
        Chooseform.ShowDialog()
        Try
            ' Read the chosen sim name
            chosen = Chooseform.ListBox1.SelectedItem.ToString()
            If chosen.Length Then
                Chooseform.Dispose()
            End If
        Catch ex As Exception
            chosen = ""
        End Try
        Return chosen

    End Function
#End Region

#Region "Checkboxes"

    Private Sub Coordy_TextChanged(sender As Object, e As EventArgs) Handles CoordY.TextChanged
        If initted And CoordY.Text <> "" Then
            Try
                CoordY.Text = Convert.ToInt16(CoordY.Text)
            Catch
            End Try
            changed = True
        End If

    End Sub

    Private Sub CoordX_TextChanged(sender As Object, e As EventArgs) Handles CoordX.TextChanged

        If initted And CoordX.Text <> "" Then
            Try
                CoordX.Text = Convert.ToInt16(CoordX.Text)
            Catch

            End Try
            changed = True
        End If

    End Sub

    Private Sub RegionPort_TextChanged(sender As Object, e As EventArgs) Handles RegionPort.TextChanged

        If initted Then
            Try
                RegionPort.Text = Convert.ToInt16(RegionPort.Text)
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

            Me.Text = RegionName.Text
            changed = True
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        If initted And RadioButton1.Checked Then
            SizeX.Text = 256
            SizeY.Text = 256
            changed = True
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        If initted And RadioButton2.Checked Then
            SizeX.Text = 512
            SizeY.Text = 512
            changed = True
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

        If initted And RadioButton3.Checked Then
            SizeX.Text = 768
            SizeY.Text = 768
            changed = True
        End If

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged

        If initted And RadioButton4.Checked Then
            SizeX.Text = 1024
            SizeY.Text = 1024
            changed = True
        End If

    End Sub

    Private Sub UUID_LostFocus(sender As Object, e As EventArgs) Handles UUID.LostFocus

        If UUID.Text <> UUID.Text And initted Then
            Dim resp = MsgBox("Changing the UUID will lose all data in the old sim and create a new, empty sim. Are you sure you wish to change the UUID?", vbYesNo)
            If resp = vbYes Then
                changed = True
                Dim result As Guid
                If Guid.TryParse(UUID.Text, result) Then

                Else
                    Dim ok = MsgBox("Not a valid UUID. Do you want a new, Random UUID?", vbOKCancel)
                    If ok = vbOK Then
                        UUID.Text = System.Guid.NewGuid.ToString
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        Dim message = RegionValidate()
        If Len(message) Then
            Dim v = MsgBox(message + vbCrLf + "Discard all changes and exit anyway?", vbYesNo)
            If v = vbYes Then
                Me.Close()
            End If
        Else

            WriteRegion()
            Form1.CopyOpensimProto()
            RegionClass.GetAllRegions()
            changed = False
            Me.Close()
        End If

    End Sub

    Private Sub FormRegion_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim RegionClass As RegionMaker = RegionMaker.Instance
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
                    Form1.CopyOpensimProto()
                    RegionClass.GetAllRegions()
                End If
            End If
        End If

    End Sub

    Private Sub SizeX_Changed(sender As Object, e As EventArgs) Handles SizeX.LostFocus

        If initted And SizeX.Text <> "" Then
            If Not IsPowerOf256(Convert.ToSingle(SizeX.Text)) Then
                MsgBox("Must be a multiple of 256: 256,512,768,1024,1280,1536,1792,2048,2304,2560, ..", vbInformation)
            Else
                If SizeX.Text > 1024 Then
                    RadioButton1.Checked = False
                    RadioButton2.Checked = False
                    RadioButton3.Checked = False
                    RadioButton4.Checked = False
                End If

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

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        Dim msg = MsgBox("Are you sure you want to delete this region? ", vbYesNo)
        If msg = vbYes Then
            Try
                My.Computer.FileSystem.DeleteFile(Form1.prefix & "bin\Regions\" + RegionName.Text + "\Region\" + RegionName.Text + ".bak")
            Catch
            End Try

            Try
                My.Computer.FileSystem.RenameFile(Form1.prefix & "bin\Regions\" + RegionName.Text + "\Region\" + RegionName.Text + ".ini", RegionName.Text + ".bak")
                RegionClass.GetAllRegions()
                Me.Close()
            Catch ex As Exception
                MsgBox("Cannot rename region file:" + ex.Message, vbInformation)
            End Try
        End If

    End Sub

#End Region

End Class