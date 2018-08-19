Imports System.IO

Public Class RegionSpecific

    Dim RegionName As String
    Dim X As Integer
    Private Sub RegionSpecific_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub RegionSpecific_unLoad(sender As Object, e As EventArgs) Handles MyBase.Closed

        Dim n As Integer = Form1.RegionClass.FindRegionByName(RegionName)
        If n < 0 Then
            MsgBox("Cannot find region " + name, vbInformation, "Error")
            Return
        End If

        Dim pathtoWelcome As String = Form1.prefix + "bin\Regions\" + RegionName + "\Region\"
        Dim fname = pathtoWelcome + RegionName + ".ini"
        If Not Directory.Exists(pathtoWelcome) Then
            Try
                Directory.CreateDirectory(pathtoWelcome)
            Catch ex As Exception
            End Try
        End If

        Dim proto = "; * Regions configuration file; " + vbCrLf _
        + "; Automatically changed and read by Dreamworld. Edits are allowed" + vbCrLf _
        + "; Rule1: The File name must match the [RegionName]" + vbCrLf _
        + "; Rule2: Only one region per INI file." + vbCrLf _
        + ";" + vbCrLf _
        + "[" + Name + "]" + vbCrLf _
        + "RegionUUID = " + Form1.RegionClass.UUID(n) + vbCrLf _
        + "Location = " + Form1.RegionClass.CoordX(n).ToString & "," & CoordY(n).ToString + vbCrLf _
        + "InternalAddress = 0.0.0.0" + vbCrLf _
        + "InternalPort = " + Form1.RegionClass.RegionPort(n).ToString + vbCrLf _
        + "AllowAlternatePorts = False" + vbCrLf _
        + "ExternalHostName = " + Form1.MySetting.PublicIP + vbCrLf _
        + "SizeX = " + Form1.RegionClass.SizeX(n).ToString + vbCrLf _
        + "SizeY = " + Form1.RegionClass.SizeY(n).ToString + vbCrLf _
        + "Enabled = " + Form1.RegionClass.RegionEnabled(n).ToString + vbCrLf _
        + "NonPhysicalPrimMax = " + Form1.RegionClass.NonPhysicalPrimMax(n).ToString + vbCrLf _
        + "PhysicalPrimMax = " + Form1.RegionClass.PhysicalPrimMax(n).ToString + vbCrLf _
        + "ClampPrimSize = " + Form1.RegionClass.ClampPrimSize(n).ToString + vbCrLf + vbCrLf _
        + ";Dreamgrid Specific Settings: " + vbCrLf _
        + "MaxPrims = " + Form1.RegionClass.MaxPrims(n) + vbCrLf _
        + "MapType = " + Form1.RegionClass.MapType(n) + vbCrLf _
        + "Physics = " + Form1.RegionClass.Physics(n) + vbCrLf _
        + "AllowGods = " + Form1.RegionClass.AllowGods(n) + vbCrLf _
        + "RegionGod = " + Form1.RegionClass.RegionGod(n) + vbCrLf _
        + "ManagerGod = " + Form1.RegionClass.ManagerGod(n) + vbCrLf

        Try
            My.Computer.FileSystem.DeleteFile(fname)
        Catch
        End Try
        Using outputFile As New StreamWriter(fname, True)
            outputFile.WriteLine(proto)
        End Using

    End Sub


    Public Sub init(Region As String)
        RegionName = Region

        X = Form1.RegionClass.FindRegionByName(Region)
        If X > -1 Then
            If Form1.RegionClass.MapType(X) = "None" Then
                MapNone.Checked = True
                MapPicture.Image = Nothing
            ElseIf Form1.RegionClass.MapType(X) = "Simple" Then
                MapSimple.Checked = True
                MapPicture.Image = My.Resources.Simple
            ElseIf Form1.RegionClass.MapType(X) = "Good" Then
                MapGood.Checked = True
                MapPicture.Image = My.Resources.Good
            ElseIf Form1.RegionClass.MapType(X) = "Better" Then
                MapBetter.Checked = True
                MapPicture.Image = My.Resources.Better
            ElseIf Form1.RegionClass.MapType(X) = "Best" Then
                MapBest.Checked = True
                MapPicture.Image = My.Resources.Best
            End If

            Select Case Form1.RegionClass.Physics(X)
                Case "0" : PhysicsNone.Checked = True
                Case "1" : PhysicsODE.Checked = True
                Case "2" : PhysicsBullet.Checked = True
                Case "3" : PhysicsSeparate.Checked = True
                Case "4" : PhysicsubODE.Checked = True
                Case Else : PhysicsSeparate.Checked = True
            End Select

            MaxPrims.Text = Form1.RegionClass.MaxPrims(X).ToString

            AllowGods.Checked = CBool(Form1.RegionClass.AllowGods(X))
            RegionGod.Checked = CBool(Form1.RegionClass.RegionGod(X))
            ManagerGod.Checked = CBool(Form1.RegionClass.ManagerGod(X))
        End If


    End Sub

    Private Sub MapNone_CheckedChanged(sender As Object, e As EventArgs) Handles MapNone.CheckedChanged
        Form1.RegionClass.MapType(X) = "None"
    End Sub

    Private Sub MapSimple_CheckedChanged(sender As Object, e As EventArgs) Handles MapSimple.CheckedChanged
        Form1.RegionClass.MapType(X) = "Simple"
    End Sub

    Private Sub MapGood_CheckedChanged(sender As Object, e As EventArgs) Handles MapGood.CheckedChanged
        Form1.RegionClass.MapType(X) = "Good"
    End Sub

    Private Sub MapBetter_CheckedChanged(sender As Object, e As EventArgs) Handles MapBetter.CheckedChanged
        Form1.RegionClass.MapType(X) = "Better"
    End Sub

    Private Sub MapBest_CheckedChanged(sender As Object, e As EventArgs) Handles MapBest.CheckedChanged
        Form1.RegionClass.MapType(X) = "Best"
    End Sub


    Private Sub PhysicsNone_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsNone.CheckedChanged
        Form1.RegionClass.Physics(X) = "0"
    End Sub

    Private Sub PhysicsODE_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsODE.CheckedChanged
        Form1.RegionClass.Physics(X) = "1"
    End Sub

    Private Sub PhysicsBullet_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsBullet.CheckedChanged
        Form1.RegionClass.Physics(X) = "2"
    End Sub

    Private Sub PhysicsSeparate_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsSeparate.CheckedChanged
        Form1.RegionClass.Physics(X) = "3"
    End Sub

    Private Sub PhysicsubODE_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsubODE.CheckedChanged
        Form1.RegionClass.Physics(X) = "4"
    End Sub

    Private Sub EnableMaxPrims_CheckedChanged(sender As Object, e As EventArgs) Handles MaxPrims.TextChanged
        Form1.RegionClass.MaxPrims(X) = MaxPrims.Text
    End Sub

    Private Sub AllowGods_CheckedChanged(sender As Object, e As EventArgs) Handles AllowGods.CheckedChanged
        Form1.RegionClass.AllowGods(X) = AllowGods.Checked.ToString
    End Sub

    Private Sub RegionGod_CheckedChanged(sender As Object, e As EventArgs) Handles RegionGod.CheckedChanged
        Form1.RegionClass.RegionGod(X) = RegionGod.Checked.ToString
    End Sub

    Private Sub ManagerGod_CheckedChanged(sender As Object, e As EventArgs) Handles ManagerGod.CheckedChanged
        Form1.RegionClass.ManagerGod(X) = ManagerGod.Checked.ToString
    End Sub

End Class