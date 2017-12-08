Public Class Gloebits
    Implements IDisposable
#Region "Globals"
    Dim Initted As Boolean = False
#End Region

#Region "Load/Quit"

#End Region
    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        ContactEmailTextBox.Text = My.Settings.GLBOwnerEmail
        OwnerNameTextbox.Text = My.Settings.GLBOwnerName

        SandboxButton.Checked = Not My.Settings.GloebitsMode
        ProductionButton.Checked = My.Settings.GloebitsMode

        SandKeyTextBox.Text = My.Settings.GLSandKey
        SandSecretTextBox.UseSystemPasswordChar = True
        SandSecretTextBox.Text = My.Settings.GLSandSecret

        ProdKeyTextBox.Text = My.Settings.GLProdKey
        ProdSecretTextBox.UseSystemPasswordChar = True
        ProdSecretTextBox.Text = My.Settings.GLProdSecret

        GloebitsEnabled.Checked = My.Settings.GloebitsEnable

        Initted = True
    End Sub

    Private Sub FormisClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed


        'Gloebits.ini

        Form1.LoadIni(Form1.prefix + "bin\Gloebit.ini", ";")
        If My.Settings.GloebitsEnable Then
            Form1.SetIni("Gloebit", "Enabled", "true")
        Else
            Form1.SetIni("Gloebit", "Enabled", "false")
        End If

        If My.Settings.GloebitsMode Then
            Form1.SetIni("Gloebit", "GLBEnvironment", "production")
        Else
            Form1.SetIni("Gloebit", "GLBEnvironment", "sandbox")
        End If

        Form1.SetIni("Gloebit", "GLBKey", My.Settings.GLSandKey)
        Form1.SetIni("Gloebit", "GLBSecret", My.Settings.GLSandSecret)
        Form1.SetIni("Gloebit", "GLBOwnerName", My.Settings.GLBOwnerName)
        Form1.SetIni("Gloebit", "GLBOwnerEmail", My.Settings.GLBOwnerEmail)


        Dim ConnectionString = """" _
            + "Data Source=" + "localhost" _
            + ";Database=" + My.Settings.RegionDBName _
            + ";Port=" + My.Settings.MySqlPort _
            + ";User ID=" + My.Settings.RegionDBUsername _
            + ";Password=" + My.Settings.RegionDbPassword _
            + ";Old Guids=True;Allow Zero Datetime=True;" _
            + """"
        Form1.SetIni("Gloebit", "GLBSpecificConnectionString", ConnectionString)

        Form1.SaveINI()

    End Sub


#Region "Mode"
    Private Sub SandboxButton_CheckedChanged(sender As Object, e As EventArgs) Handles SandboxButton.CheckedChanged
        If SandboxButton.Checked = True Then
            ProductionButton.Checked = False
            My.Settings.GloebitsMode = False
            My.Settings.Save()
        End If
    End Sub

    Private Sub ProductionButton_CheckedChanged(sender As Object, e As EventArgs) Handles ProductionButton.CheckedChanged
        If ProductionButton.Checked = True Then
            SandboxButton.Checked = False
            My.Settings.GloebitsMode = True
            My.Settings.Save()
        End If
    End Sub

#End Region

#Region "Sandbox"

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles SandKeyTextBox.TextChanged
        My.Settings.GLSandKey = SandKeyTextBox.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles SandSecretTextBox.TextChanged
        My.Settings.GLSandSecret = SandSecretTextBox.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox2_click(sender As Object, e As EventArgs) Handles SandSecretTextBox.Click
        SandSecretTextBox.UseSystemPasswordChar = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles SandBoxSignUpButton.Click
        Dim webAddress As String = "https://sandbox.gloebit.com/signup/"
        Process.Start(webAddress)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles SandBoxReqAppButton.Click
        Dim webAddress As String = "https://sandbox.gloebit.com/merchant-signup/"
        Process.Start(webAddress)
    End Sub

    Private Sub CreateAppButton2_Click(sender As Object, e As EventArgs) Handles SandBoxCreateAppButton.Click
        Dim webAddress As String = "https://www.gloebit.com"
        Process.Start(webAddress)
    End Sub
#End Region

#Region "Production"

    Private Sub ProdSecretTextBox_Click(sender As Object, e As EventArgs) Handles ProdSecretTextBox.Click
        ProdSecretTextBox.UseSystemPasswordChar = False
    End Sub
    Private Sub ProdSecretTextBox_TextChanged(sender As Object, e As EventArgs) Handles ProdSecretTextBox.TextChanged
        My.Settings.GLProdSecret = ProdSecretTextBox.Text
        My.Settings.Save()
    End Sub
    Private Sub ProdKeyTextBox_Click(sender As Object, e As EventArgs) Handles ProdKeyTextBox.Click
        ProdKeyTextBox.UseSystemPasswordChar = False
    End Sub
    Private Sub ProdKeyTextBox_TextChanged(sender As Object, e As EventArgs) Handles ProdKeyTextBox.TextChanged
        My.Settings.GLProdKey = ProdKeyTextBox.Text
        My.Settings.Save()
    End Sub

    Private Sub ProductionCreateButton_Click(sender As Object, e As EventArgs) Handles ProductionCreateButton.Click
        Dim webAddress As String = "https://www.gloebit.com/signup/"
        Process.Start(webAddress)
    End Sub

    Private Sub ProductionReqAppButton_Click(sender As Object, e As EventArgs) Handles ProductionReqAppButton.Click
        Dim webAddress As String = "https://www.gloebit.com/merchant-signup/"
        Process.Start(webAddress)
    End Sub

    Private Sub ProductionCreateAppButton_Click(sender As Object, e As EventArgs) Handles ProductionCreateAppButton.Click
        Dim webAddress As String = "https://www.gloebit.com/merchant-tools/"
        Process.Start(webAddress)
    End Sub

#End Region

#Region "OwnerInfo"

    Private Sub OwnerNameTextbox_TextChanged(sender As Object, e As EventArgs) Handles OwnerNameTextbox.TextChanged
        My.Settings.GLBOwnerName = OwnerNameTextbox.Text
        My.Settings.Save()

    End Sub

    Private Sub ContactEmailTextBox_TextChanged(sender As Object, e As EventArgs) Handles ContactEmailTextBox.TextChanged

        My.Settings.GLBOwnerEmail = ContactEmailTextBox.Text
        My.Settings.Save()

    End Sub

    Private Sub GloebitsEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles GloebitsEnabled.CheckedChanged

        My.Settings.GloebitsEnable = GloebitsEnabled.Checked
        My.Settings.Save()

    End Sub

#End Region

#Region "Help"

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim webAddress As String = "http://dev.gloebit.com/opensim/"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim webAddress As String = "http://dev.gloebit.com/opensim/"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub




#End Region


End Class