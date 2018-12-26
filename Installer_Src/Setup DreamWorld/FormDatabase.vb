Public Class FormDatabase

    Dim initted As Boolean

#Region "ScreenSize"
    Public ScreenPosition As ScreenPos
    Private Handler As New EventHandler(AddressOf resize_page)

    'The following detects  the location of the form in screen coordinates
    Private Sub resize_page(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Text = "Form screen position = " + Me.Location.ToString
        ScreenPosition.SaveXY(Me.Left, Me.Top)
    End Sub
    Private Sub SetScreen()
        Me.Show()
        ScreenPosition = New ScreenPos(Me.Name)
        AddHandler ResizeEnd, Handler
        Dim xy As List(Of Integer) = ScreenPosition.GetXY()
        Me.Left = xy.Item(0)
        Me.Top = xy.Item(1)
    End Sub

#End Region

#Region "Load/Exit"

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        'Database 
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        RegionDbName.Text = Form1.MySetting.RegionDBName
        RegionDBUsername.Text = Form1.MySetting.RegionDBUsername
        RegionMySqlPassword.Text = Form1.MySetting.RegionDbPassword

        ' Robust DB
        RobustServer.Text = Form1.MySetting.RobustServer
        RobustDbName.Text = Form1.MySetting.RobustDataBaseName
        RobustDBPassword.Text = Form1.MySetting.RobustPassword
        RobustDBUsername.Text = Form1.MySetting.RobustUsername
        RobustDbPort.Text = Form1.MySetting.MySqlPort.ToString

        RobustDBPassword.UseSystemPasswordChar = True

        initted = True

    End Sub

#End Region


#Region "Database"

    Private Sub RobustServer_TextChanged(sender As Object, e As EventArgs)
        If Not initted Then Return
        Form1.MySetting.RobustServer = RobustServer.Text
        Form1.MySetting.SaveSettings()
    End Sub

    Private Sub DatabaseNameUser_TextChanged(sender As Object, e As EventArgs)
        If Not initted Then Return
        Form1.MySetting.RegionDBName = RegionDbName.Text
        Form1.MySetting.SaveSettings()
    End Sub

    Private Sub DbUsername_TextChanged(sender As Object, e As EventArgs)
        If Not initted Then Return
        Form1.MySetting.RegionDBUsername = RegionDBUsername.Text
        Form1.MySetting.SaveSettings()
    End Sub

    Private Sub DbPassword_TextChanged(sender As Object, e As EventArgs)
        If Not initted Then Return
        Form1.MySetting.RegionDbPassword = RegionMySqlPassword.Text
        Form1.MySetting.SaveSettings()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs)
        If Not initted Then Return
        Form1.MySetting.RobustDataBaseName = RobustDbName.Text
        Form1.MySetting.SaveSettings()
    End Sub

    Private Sub RobustUsernameTextBox_TextChanged(sender As Object, e As EventArgs)
        If Not initted Then Return
        Form1.MySetting.RobustUsername = RobustDBUsername.Text
        Form1.MySetting.SaveSettings()
    End Sub

    Private Sub RobustPasswordTextBox_TextChanged(sender As Object, e As EventArgs)
        If Not initted Then Return
        Form1.MySetting.RobustPassword = RobustDBPassword.Text
        Form1.MySetting.SaveSettings()
    End Sub

    Private Sub RobustDbPortTextbox_TextChanged(sender As Object, e As EventArgs)
        If Not initted Then Return
        Form1.MySetting.MySqlPort = RobustDbPort.Text
        Form1.MySetting.SaveSettings()
    End Sub



#End Region


End Class