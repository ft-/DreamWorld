Imports System
Imports IniParser
Imports System.IO

Public Class FormRegion

    Inherits System.Windows.Forms.Form

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


#End Region

#Region "Functions"

    Public Sub Init(num As Integer)

        gNum = num

        InitializeComponent()

        MyRegion.RegionName = Form1.aRegion(num).RegionName
        MyRegion.UUID = Form1.aRegion(num).UUID
        MyRegion.CoordX = Form1.aRegion(num).CoordX
        MyRegion.CoordY = Form1.aRegion(num).CoordY
        MyRegion.RegionPort = Form1.aRegion(num).RegionPort
        MyRegion.SizeY = Form1.aRegion(num).SizeY
        MyRegion.SizeX = Form1.aRegion(num).SizeX

        Me.Show()


        Me.Text = "Region " + MyRegion.RegionName

        bRegionName.Text = "hiya!"

        Application.DoEvents()

        Return

        If MyRegion.SizeY = 256 And MyRegion.SizeX = 256 Then
            bCheckBox256.Checked = True
            bCheckBox512.Checked = False
            bCheckBox1024.Checked = False
            bSizeX.Text = ""
            bSizeY.Text = ""
        End If

        If MyRegion.SizeY = 512 And MyRegion.SizeX = 512 Then
            bCheckBox256.Checked = False
            bCheckBox512.Checked = True
            bCheckBox1024.Checked = False
            bSizeX.Text = ""
            bSizeY.Text = ""
        End If

        If MyRegion.SizeY = 1024 And MyRegion.SizeX = 1024 Then
            bCheckBox256.Checked = False
            bCheckBox512.Checked = False
            bCheckBox1024.Checked = True
            bSizeX.Text = ""
            bSizeY.Text = ""
        End If

        If MyRegion.SizeX <> 0 Then
            bCheckBox256.Checked = False
            bCheckBox512.Checked = False
            bCheckBox1024.Checked = False
            bSizeX.Text = Convert.ToString(MyRegion.SizeX)
        End If

        If MyRegion.SizeY <> 0 Then
            bCheckBox256.Checked = False
            bCheckBox512.Checked = False
            bCheckBox1024.Checked = False
            bSizeY.Text = Convert.ToString(MyRegion.SizeY)
        End If

        If MyRegion.RegionName <> "" Then
            bRegionName.Text = MyRegion.RegionName
        End If

        If MyRegion.CoordX <> 0 Then
            bCoordX.Text = MyRegion.CoordX
        End If

        If MyRegion.CoordY <> 0 Then
            bCoordX.Text = MyRegion.CoordY
        End If



    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim message = RegionValidate()
        If Len(message) Then
            Dim v = MsgBox(message + vbCrLf + "Discard Changes?", vbYesNo)
            If v = vbNo Then
                e.Cancel = True
            End If
        Else
            WriteRegion()
        End If
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
            Message = ("Region bSizeX is zero")
            Form1.Log(Message)
            Return Message
        End If
        If Convert.ToInt16(MyRegion.SizeY) = 0 Then
            Message = "Region bSizeY is zero"
            Form1.Log(Message)
            Return Message
        End If

        Return ""
    End Function

    Private Sub WriteRegion()

        Dim size As String

        If MyRegion.SizeX = "256" And MyRegion.SizeY = "256" Then
            size = "256,256"
        ElseIf MyRegion.SizeX = "512" And MyRegion.SizeY = "512" Then
            size = "512,512"
        ElseIf MyRegion.SizeX = "1024" And MyRegion.SizeY = "1024" Then
            size = "1024,1024"
        Else
            size = MyRegion.SizeX + "," + MyRegion.SizeY
        End If

        ' make a new UUID is there is none
        If Len(MyRegion.UUID) <> 36 Then MyRegion.UUID = Convert.ToString(Guid.NewGuid())

        Dim RegionText As String = "; * Regions configuration file " + vbCrLf _
    + "; * This Is Your World. Change This And It Will break. See Advance->[Region Settings] instead." + vbCrLf _
    + "; Automatically changed by Dreamworld - do Not change this file!" + vbCrLf _
    + "[" + MyRegion.RegionName + "]" + vbCrLf _
    + "RegionUUID = " + """" + MyRegion.UUID + """" + vbCrLf _
    + "Location = " + """" + Convert.ToString(MyRegion.CoordX) + "," + Convert.ToString(MyRegion.CoordY) + """" + vbCrLf _
    + "InternalAddress = " + """" + "0.0.0.0" + """" + vbCrLf _
    + "InternalPort =" + Convert.ToString(MyRegion.RegionPort) + vbCrLf _
    + "AllowAlternatePorts = False" + vbCrLf _
    + "ExternalHostName = " + My.Settings.PublicIP _
    + "SizeX = " + Convert.ToString(MyRegion.SizeX) + vbCrLf _
    + "SizeY = " + Convert.ToString(MyRegion.SizeY) + vbCrLf

        ' save the Region File

        Try
            My.Computer.FileSystem.DeleteFile(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\" + MyRegion.RegionName + ".ini")
            Try
                'Save the INI file
                Using outputFile As New StreamWriter(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\" + MyRegion.RegionName + ".ini", True)
                    outputFile.WriteLine(RegionText)
                End Using
            Catch ex As Exception
                Form1.Log("Could not create Region file " + MyRegion.RegionName + ":" + ex.Message)
            End Try
        Catch ex As Exception
            Form1.Log("Info: Region file did not exist")
        End Try


        Form1.aRegion(gNum).RegionName = MyRegion.RegionName
        Form1.aRegion(gNum).UUID = MyRegion.UUID
        Form1.aRegion(gNum).CoordX = MyRegion.CoordX
        Form1.aRegion(gNum).CoordY = MyRegion.CoordY
        Form1.aRegion(gNum).RegionPort = MyRegion.RegionPort
        Form1.aRegion(gNum).SizeY = MyRegion.SizeY
        Form1.aRegion(gNum).SizeX = MyRegion.SizeX

    End Sub

#End Region

#Region "Checkboxes"

    Private Sub CheckBox256_CheckedChanged(sender As Object, e As EventArgs) Handles bCheckBox256.CheckedChanged
        If CheckBox256.Checked = True Then
            bCheckBox512.Checked = False
            bCheckBox256.Checked = False
            MyRegion.SizeX = 256
            MyRegion.SizeY = 256
            bSizeX.Text = ""
            bSizeY.Text = ""
        End If

    End Sub

    Private Sub CheckBox512_CheckedChanged(sender As Object, e As EventArgs) Handles bCheckBox512.CheckedChanged
        If bCheckBox512.Checked = True Then
            bCheckBox256.Checked = False
            bCheckBox256.Checked = False
            MyRegion.SizeX = 512
            MyRegion.SizeY = 512
            bSizeX.Text = ""
            bSizeY.Text = ""
        End If

    End Sub

    Private Sub CheckBox1024_CheckedChanged(sender As Object, e As EventArgs) Handles bCheckBox256.CheckedChanged
        If bCheckBox256.Checked = True Then
            bCheckBox256.Checked = False
            bCheckBox512.Checked = False
            MyRegion.SizeX = 1024
            MyRegion.SizeY = 1024
            bSizeX.Text = ""
            bSizeY.Text = ""
        End If

    End Sub

    Private Sub SizeX_TextChanged(sender As Object, e As EventArgs) Handles bSizeX.TextChanged
        If bSizeX.Text <> "" Then
            bCheckBox256.Checked = False
            bCheckBox512.Checked = False
            bCheckBox256.Checked = False
            My.Settings.SizeX = Convert.ToInt16(bSizeX.Text)
        End If

    End Sub

    Private Sub SizeY_TextChanged(sender As Object, e As EventArgs) Handles bSizeY.TextChanged
        If bSizeY.Text <> "" Then
            bCheckBox256.Checked = False
            bCheckBox512.Checked = False
            bCheckBox256.Checked = False
            My.Settings.SizeY = Convert.ToInt16(bSizeY.Text)
        End If
    End Sub
    Private Sub RegionPort_TextChanged(sender As Object, e As EventArgs) Handles bRegionPort.TextChanged
        MyRegion.RegionPort = Convert.ToInt16(bRegionPort.Text)
    End Sub

    Private Sub RegionName_TextChanged(sender As Object, e As EventArgs) Handles bRegionName.TextChanged

        If Len(bRegionName.Text) > 0 Then
            Try
                Dim oldname = Form1.aRegion(gNum).RegionName
                '  My.Computer.FileSystem.RenameFile(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\" + oldname + ".ini", bRegionName.Text + ".ini")
            Catch ex As Exception
                Dim str = ex.Message
            End Try
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles bCoordX.TextChanged
        MyRegion.CoordX = Convert.ToInt16(bCoordX.Text)
        'MsgBox(bCoordX.Text)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles bCoordY.TextChanged
        MyRegion.CoordY = Convert.ToInt16(bCoordY.Text)
    End Sub


#End Region

End Class