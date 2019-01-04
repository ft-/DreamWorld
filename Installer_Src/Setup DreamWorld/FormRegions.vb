Public Class FormRegions

    Dim RegionClass As RegionMaker = RegionMaker.Instance(Form1.MysqlConn)

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
    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        LoadWelcomeBox()
        LoadRegionBox()
        Form1.HelpOnce("Regions")
        SetScreen()

    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        ' nothing
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WelcomeBox1.SelectedIndexChanged

        Dim value As String = TryCast(WelcomeBox1.SelectedItem, String)
        Form1.MySetting.WelcomeRegion = value

        Debug.Print("Selected " + value)
        Form1.MySetting.SaveSettings()

    End Sub

    Private Sub RegionButton1_Click(sender As Object, e As EventArgs) Handles RegionButton.Click

        Dim X As Integer = 300
        Dim Y As Integer = 200
        Dim counter As Integer = 0

        For Each Z As Integer In RegionClass.RegionNumbers
            Try
                Dim RegionName = RegionClass.RegionName(Z)
                Dim RegionForm As New FormRegion

                RegionForm.Init(RegionName)
                RegionForm.Activate()
                RegionForm.Visible = True
                Application.DoEvents()
            Catch ex As Exception
                Form1.Log("Info:" + ex.Message)
            End Try
            counter = counter + 1
            Y += 100
            X += 100

        Next

    End Sub

    Private Sub AddRegion_Click(sender As Object, e As EventArgs) Handles AddRegion.Click

        Dim X As Integer = 300
        Dim Y As Integer = 200

        RegionClass.CreateRegion("")

        Dim RegionForm As New FormRegion
        RegionForm.Init("")
        RegionForm.Activate()
        RegionForm.Visible = True

    End Sub


    Private Sub LoadWelcomeBox()

        ' Default welcome region load
        WelcomeBox1.Items.Clear()

        For Each X As Integer In RegionClass.RegionNumbers
            If RegionClass.RegionEnabled(X) Then
                WelcomeBox1.Items.Add(RegionClass.RegionName(X))
            End If
        Next

        Dim s = WelcomeBox1.FindString(Form1.MySetting.WelcomeRegion)
        If s > -1 Then
            WelcomeBox1.SelectedIndex = s
        Else
            MsgBox("Choose your Welcome region ", vbInformation, "Choose")
            Dim chosen = Form1.ChooseRegion(False)
            Dim Index = WelcomeBox1.FindString(chosen)
            WelcomeBox1.SelectedIndex = Index
        End If

    End Sub

    Private Sub LoadRegionBox()
        ' All region load
        RegionBox.Items.Clear()

        For Each X As Integer In RegionClass.RegionNumbers
            RegionBox.Items.Add(RegionClass.RegionName(X))
        Next

    End Sub



    Private Sub RegionBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RegionBox.SelectedIndexChanged


        Dim value As String = TryCast(RegionBox.SelectedItem, String)
        Dim RegionForm As New FormRegion
        RegionForm.Init(value)
        RegionForm.Activate()
        RegionForm.Visible = True
        RegionForm.Select()

    End Sub

    Private Sub RegionHelp_Click(sender As Object, e As EventArgs) Handles RegionHelp.Click
        Form1.Help("Regions")
    End Sub
End Class