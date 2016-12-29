Imports System
Imports IniParser
Imports System.IO

Public Class FormRegion

#Region "Declarations"

    Dim aRegion(4) As Object

    Private Class Region_data
        Public RegionName As String
        Public UUID As String
        Public CoordX As Integer
        Public CoordY As Integer
        Public RegionPort As String
        Public SizeX As String
        Public SizeY As String
        Public CoordXY As String
    End Class
#End Region

#Region "Functions"

    Public Function GetIni(num As Integer)
        Return aRegion(num)
    End Function

    Private Sub FormRegion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetAllRegions()
    End Sub

    Private Sub FormRegion_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        SaveRegion(aRegion(1))
        SaveRegion(aRegion(2))
        SaveRegion(aRegion(3))
        SaveRegion(aRegion(4))
    End Sub

    Private Function oValidate(oRegion As Object)
        If Len(oRegion.UUID) <> 36 Then
            Form1.Log("region UUID is invalid: " + oRegion.UUID)
            Return False
        End If

        If Convert.ToInt16(oRegion.CoordX) = 0 Or Convert.ToInt16(oRegion.CoordX) > 10000 Then
            Form1.Log("Region CoordX is zero")
            Return False
        End If

        If Convert.ToInt16(oRegion.CoordY) = 0 Or Convert.ToInt16(oRegion.CoordY) > 10000 Then
            Form1.Log("Region CoordY is incorrect:" + oRegion.CoordY)
            Return False
        End If

        If Convert.ToInt16(oRegion.RegionPort) = 0 Then
            Form1.Log("Region RegionPort is zero")
            Return False
        End If

        If Convert.ToInt16(oRegion.SizeX) = 0 Then
            Form1.Log("Region SizeX is zero")
            Return False
        End If
        If Convert.ToInt16(oRegion.SizeY) = 0 Then
            Form1.Log("Region SizeY is zero")
            Return False
        End If

        Return True
    End Function

    Private Function GetIni(filepath As String, section As String, key As String, delim As String) As String
        ' gets values from an INI file
        Dim parser = New FileIniDataParser()
        parser.Parser.Configuration.SkipInvalidLines = True
        parser.Parser.Configuration.CommentString = delim ' Opensim uses semicolons

        Dim Data = parser.ReadFile(filepath)
        GetIni = Data(section)(key)
    End Function

    Private Sub SaveRegion(oRegion As Object)
        If oValidate(oRegion) Then
            WriteRegion(oRegion)
        End If
    End Sub

    Public Sub GetAllRegions()
        ' read all Region INI files

        Dim counter As Integer = 1
        Dim files() As String
        Dim ini As String = Form1.MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\"

        files = Directory.GetFiles(ini, "*.ini", SearchOption.TopDirectoryOnly)
        For Each FileName As String In files
            Try
                aRegion(counter) = New Region_data
                Dim pos = InStrRev(FileName, "\")
                Dim name As String = Mid(FileName, pos + 1)
                Dim fname = Mid(name, 1, Len(name) - 4)

                aRegion(counter).RegionName = fname
                aRegion(counter).UUID = GetIni(Form1.MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\" + name, fname, "RegionUUID", ";")
                aRegion(counter).CoordXY = Stripqq(GetIni(Form1.MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\" + name, fname, "Location", ";"))
                aRegion(counter).SizeX = Stripqq(GetIni(Form1.MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\" + name, fname, "SizeX", ";"))
            Catch ex As Exception
                Form1.Log(ex.Message)
            End Try

            counter = counter + 1
        Next

    End Sub

    Private Function Stripqq(input As String)
        Return Replace(input, """", "")
    End Function
    Private Sub WriteRegion(r As Object)

        Dim size As String

        If r.SizeX = "256" And r.SizeY = "256" Then
            size = "256,256"
        ElseIf r.SizeX = "512" And r.SizeY = "512" Then
            size = "512,512"
        ElseIf r.SizeX = "1024" And r.SizeY = "1024" Then
            size = "1024,1024"
        Else
            size = r.SizeX + "," + r.SizeY
        End If

        ' make a new UUID is there is none
        If Len(r.UUID) <> 36 Then r.UUID = Guid.NewGuid()

        Dim RegionText As String = "; * Regions configuration file " + vbCrLf _
    + "; * This Is Your World. Change this And it will break. See Setting->Region instead." + vbCrLf _
    + "; Automatically changed by Dreamworld - do Not change this file!" + vbCrLf _
    + "[" + r.RegionName + "]" + vbCrLf _
    + "RegionUUID = " + """" + r.UUID + """" + vbCrLf _
    + "Location = " + """" + r.CoordXY + """" + vbCrLf _
    + "InternalAddress = " + """" + "0.0.0.0" + """" + vbCrLf _
    + "InternalPort =" + r.RegionPort + vbCrLf _
    + "AllowAlternatePorts = False" + vbCrLf _
    + "ExternalHostName = " + My.Settings.PublicIP _
    + "SizeX = " + r.SizeX + vbCrLf _
    + "SizeY = " + r.SizeY + vbCrLf

        ' save the Region File

        Try
            My.Computer.FileSystem.DeleteFile(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\" + r.RegionName + ".ini")
            Try
                'Save the INI file
                Using outputFile As New StreamWriter(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\" + r.RegionName + ".ini", True)
                    outputFile.WriteLine(RegionText)
                End Using
            Catch ex As Exception
                Form1.Log("Could not create Region file " + ex.Message)
            End Try
        Catch ex As Exception
            Form1.Log("Info: Region file did not exist")
        End Try

    End Sub

#End Region
#Region "Checkboxes"

    Private Sub CheckBox256_CheckedChanged(sender As Object, e As EventArgs) Handles R1CheckBox256.CheckedChanged
        If CheckBox256.Checked = True Then
            R1CheckBox512.Checked = False
            R1CheckBox1024.Checked = False
            My.Settings.SizeX = "256"
            My.Settings.SizeY = "256"
            R1SizeX.Text = ""
            R1SizeY.Text = ""
        End If

    End Sub

    Private Sub CheckBox512_CheckedChanged(sender As Object, e As EventArgs) Handles R1CheckBox512.CheckedChanged
        If R1CheckBox512.Checked = True Then
            CheckBox256.Checked = False
            R1CheckBox1024.Checked = False
            My.Settings.SizeX = "512"
            My.Settings.SizeY = "512"
            R1SizeX.Text = ""
            R1SizeY.Text = ""
        End If

    End Sub

    Private Sub CheckBox1024_CheckedChanged(sender As Object, e As EventArgs) Handles R1CheckBox1024.CheckedChanged
        If R1CheckBox1024.Checked = True Then
            CheckBox256.Checked = False
            R1CheckBox512.Checked = False
            My.Settings.SizeX = "1024"
            My.Settings.SizeY = "1024"
            R1SizeX.Text = ""
            R1SizeY.Text = ""
        End If

    End Sub

    Private Sub SizeX_TextChanged(sender As Object, e As EventArgs) Handles R1SizeX.TextChanged
        If R1SizeX.Text <> "" Then
            CheckBox256.Checked = False
            R1CheckBox512.Checked = False
            R1CheckBox1024.Checked = False
            My.Settings.SizeX = R1SizeX.Text
        End If

    End Sub

    Private Sub SizeY_TextChanged(sender As Object, e As EventArgs) Handles R1SizeY.TextChanged
        If R1SizeY.Text <> "" Then
            CheckBox256.Checked = False
            R1CheckBox512.Checked = False
            R1CheckBox1024.Checked = False
            My.Settings.SizeY = R1SizeY.Text
        End If
    End Sub
    Private Sub RegionPort_TextChanged(sender As Object, e As EventArgs) Handles R1RegionPort.TextChanged
        aRegion(1).RegionPort = R1RegionPort.Text
    End Sub

    Private Sub R1RegionName_TextChanged(sender As Object, e As EventArgs) Handles R1RegionName.TextChanged

        If Len(R1RegionName.Text) > 0 Then
            Try
                My.Computer.FileSystem.RenameFile(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\", R1RegionName.Text + ".ini")
            Catch ex As Exception
                MsgBox("Not a valid name for a region", vbAbort)
            End Try
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles R1CoordX.TextChanged
        aRegion(1).CoordX = R1CoordX.Text
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles R1CoordY.TextChanged
        aRegion(1).CoordY = R1CoordY.Text
    End Sub

#End Region

End Class