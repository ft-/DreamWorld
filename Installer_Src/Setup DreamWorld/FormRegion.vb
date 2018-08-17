
Imports System.IO
Imports System.ComponentModel

Public Class FormRegion

#Region "Declarations"
    Dim Big As Boolean = False
    Dim n As Integer
    Dim oldname As String = ""
    Dim initted As Boolean = False ' needed a flag to see if we are initted as the dialogs change on start.
    Dim changed As Boolean    ' true if we need to save a form
    Dim isNew As Boolean = False
    Dim RegionClass As RegionMaker

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Functions"


    Public Sub Init(Name As String)

        Me.Size = New System.Drawing.Size(275, 335)
        Advanced.Visible = False
        Big = True
        Me.Focus()

        RegionClass = RegionMaker.Instance(Form1.MysqlConn)
        If Name = "" Then
            isNew = True
            RegionName.Text = Name
            UUID.Text = Guid.NewGuid().ToString
            SizeX.Text = 256.ToString
            SizeY.Text = 256.ToString
            CoordX.Text = (RegionClass.LargestX() + 4).ToString
            CoordY.Text = (RegionClass.LargestY() + 0).ToString
            RegionPort.Text = (RegionClass.LargestPort() + 1).ToString
            EnabledCheckBox.Checked = True
            RadioButton1.Checked = True
            NonphysicalPrimMax.Text = 1024.ToString
            PhysicalPrimMax.Text = 64.ToString
            ClampPrimSize.Checked = False
            MaxPrims.Text = 45000.ToString
            MaxAgents.Text = 100.ToString

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
            NonphysicalPrimMax.Text = RegionClass.NonPhysicalPrimMax(n).ToString
            PhysicalPrimMax.Text = RegionClass.PhysicalPrimMax(n).ToString
            ClampPrimSize.Checked = RegionClass.ClampPrimSize(n)
            MaxPrims.Text = RegionClass.MaxPrims(n).ToString
            MaxAgents.Text = RegionClass.MaxAgents(n).ToString

            Me.Show() ' time to show the results
            Me.Activate()
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
                CoordX.Text = RegionClass.CoordX(n).ToString
            End If

            If RegionClass.CoordY(n) <> 0 Then
                CoordY.Text = RegionClass.CoordY(n).ToString
            End If

            ' and port
            If RegionClass.RegionPort(n) <> 0 Then
                RegionPort.Text = RegionClass.RegionPort(n).ToString
            End If
        End If
        Me.Focus()
        initted = True

    End Sub

    Public Shared Function FilenameIsOK(ByVal fileName As String) As Boolean
        ' check for invalid chars in file name for INI file


        Dim value As Boolean = False
        Try
            value = Not fileName.Intersect(Path.GetInvalidFileNameChars()).Any()
        Catch
        End Try

        Return value

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
            Message = "Region Coordinate X cannot be zero"
            Form1.Log(Message)
            Return Message
        ElseIf Convert.ToInt16(CoordX.Text) > 65536 Then
            Message = "Region Coordinate X is too large"
            Form1.Log(Message)
            Return Message
        End If

        If Convert.ToInt16(CoordY.Text) = 0 Then
            Message = "Region CoordY cannot be zero"
            Form1.Log(Message)
            Return Message
        ElseIf Convert.ToInt16(CoordY.Text) > 65536 Then
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
        Dim Filepath = RegionClass.RegionPath(n)
        Dim Folderpath = RegionClass.FolderPath(n)

        ' rename is possible
        If oldname <> RegionName.Text And Not isNew Then
            Try
                My.Computer.FileSystem.RenameFile(Filepath, RegionName.Text + ".bak")
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            Try
                Dim NewFilepath = dir & "bin\Regions\" + RegionName.Text + "\Region\"
                Directory.CreateDirectory(NewFilepath)
                Filepath = NewFilepath + RegionName.Text + ".ini"
                RegionClass.RegionPath(n) = Filepath
                Form1.CopyOpensimProto()
            Catch
                MsgBox("Cannot create new region. It seems to already exist", vbInformation, "Info")
                Form1.PrintFast("Aborted")
                Return
            End Try
        End If

        ' might be a new region, so give them a choice

        If isNew Then
            Dim NewGroup As String = RegionName.Text
            Dim yesNo As MsgBoxResult = MsgBox("New regions can can be combined with other regions in an existing DOS box (Yes), or run in their own Dos Box (No)", vbYesNo, "Combine Regions?")
            If yesNo = vbYes Then
                NewGroup = RegionChosen()
                If NewGroup = "" Then
                    Form1.PrintFast("Aborted")
                    Return
                End If
            End If

            If Not Directory.Exists(Filepath) Or Filepath = "" Then
                Directory.CreateDirectory(dir & "bin\Regions\" + NewGroup + "\Region")
            End If

            RegionClass.RegionPath(n) = dir & "bin\Regions\" + NewGroup + "\Region\" + RegionName.Text + ".ini"


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
                        "ExternalHostName = " & Form1.MySetting.PublicIP & vbCrLf &
                        "SizeX = " & SizeX.Text & vbCrLf &
                        "SizeY = " & SizeY.Text & vbCrLf &
                        "Enabled = " & EnabledCheckBox.Checked.ToString & vbCrLf &
                        "NonPhysicalPrimMax = " & NonphysicalPrimMax.Text & vbCrLf &
                        "PhysicalPrimMax = " & PhysicalPrimMax.Text & vbCrLf &
                        "ClampPrimSize = " & ClampPrimSize.Checked.ToString & vbCrLf &
                        "MaxPrims = " & MaxPrims.Text & vbCrLf &
                        "MaxAgents = " & MaxAgents.Text & vbCrLf

        Try
            Using outputFile As New StreamWriter(RegionClass.RegionPath(n), False)
                outputFile.Write(Region)
            End Using
        Catch
        End Try

        oldname = RegionName.Text

    End Sub

    Private Function RegionChosen() As String

        Dim Chooseform As New Choice ' form for choosing a set of regions
        ' Show testDialog as a modal dialog and determine if DialogResult = OK.

        Chooseform.FillGrid("Group")  ' populate the grid with either Group or RegionName

        Dim chosen As String
        Chooseform.ShowDialog()
        Try
            ' Read the chosen sim name
            chosen = Chooseform.DataGridView.CurrentCell.Value.ToString()
            If chosen.Length > 0 Then
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
                CoordY.Text = CoordY.Text
            Catch
            End Try
            changed = True
        End If

    End Sub

    Private Sub CoordX_TextChanged(sender As Object, e As EventArgs) Handles CoordX.TextChanged

        If initted And CoordX.Text <> "" Then
            Try
                CoordX.Text = CoordX.Text
            Catch

            End Try
            changed = True
        End If

    End Sub

    Private Sub RegionPort_TextChanged(sender As Object, e As EventArgs) Handles RegionPort.TextChanged

        If initted Then
            Try
                RegionPort.Text = RegionPort.Text
            Catch

            End Try
            changed = True
        End If

    End Sub

    Private Sub RLostFocus(sender As Object, e As EventArgs) Handles RegionName.TextChanged

        If Len(RegionName.Text) > 0 And initted Then
            If Not FilenameIsOK(RegionName.Text) Then
                MsgBox("Region name can't use special characters such as < > : """" / \ | ? *", vbInformation, "Info")
                Return
            End If
            changed = True
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        If initted And RadioButton1.Checked Then
            SizeX.Text = "256"
            SizeY.Text = "256"
            changed = True
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        If initted And RadioButton2.Checked Then
            SizeX.Text = "512"
            SizeY.Text = "512"
            changed = True
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

        If initted And RadioButton3.Checked Then
            SizeX.Text = "768"
            SizeY.Text = "768"
            changed = True
        End If

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged

        If initted And RadioButton4.Checked Then
            SizeX.Text = "1024"
            SizeY.Text = "1024"
            changed = True
        End If

    End Sub

    Private Sub UUID_LostFocus(sender As Object, e As EventArgs) Handles UUID.LostFocus

        If UUID.Text <> UUID.Text And initted Then
            Dim resp = MsgBox("Changing the UUID will lose all data in the old sim and create a new, empty sim. Are you sure you wish to change the UUID?", vbYesNo, "Info")
            If resp = vbYes Then
                changed = True
                Dim result As Guid
                If Guid.TryParse(UUID.Text, result) Then

                Else
                    Dim ok = MsgBox("Not a valid UUID. Do you want a new, Random UUID?", vbOKCancel, "Info")
                    If ok = vbOK Then
                        UUID.Text = System.Guid.NewGuid.ToString
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim message = RegionValidate()
        If Len(message) > 0 Then
            Dim v = MsgBox(message + vbCrLf + "Discard all changes and exit anyway?", vbYesNo, "Info")
            If v = vbYes Then
                Me.Close()
            End If
        Else

            WriteRegion()
            RegionClass.GetAllRegions()
            Form1.CopyOpensimProto()

            changed = False
            Me.Close()
        End If

    End Sub

    Private Sub FormRegion_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If changed Then
            Dim v = MsgBox("Save changes?", vbYesNo, "Region Save")
            If v = vbYes Then
                Dim message = RegionValidate()
                If Len(message) > 0 Then
                    v = MsgBox(message + vbCrLf + "Discard all changes and exit anyway?", vbYesNo, "Info")
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
            If Not IsPowerOf256(CType(SizeX.Text, Integer)) Then
                MsgBox("Must be a multiple of 256: 256,512,768,1024,1280,1536,1792,2048,2304,2560, ..", vbInformation, "Size X,Y")
            Else
                If CType(SizeX.Text, Double) > 1024 Then
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


        Dim msg = MsgBox("Are you sure you want to delete this region? ", vbYesNo, "Delete?")
        If msg = vbYes Then
            Try
                My.Computer.FileSystem.DeleteFile(Form1.prefix & "bin\Regions\" + RegionName.Text + "\Region\" + RegionName.Text + ".bak")
            Catch
            End Try

            Try
                My.Computer.FileSystem.RenameFile(RegionClass.RegionPath(n), RegionName.Text + ".bak")
                RegionClass.GetAllRegions()

            Catch ex As Exception
            End Try
        End If
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Big Then
            Me.Size = New System.Drawing.Size(275, 535)
            Advanced.Visible = True
            Big = False
        Else
            Me.Size = New System.Drawing.Size(275, 335)
            Advanced.Visible = False
            Big = True
        End If
    End Sub



#End Region

End Class