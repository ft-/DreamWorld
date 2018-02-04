Public Class RegionList

    Dim writetodisk As Boolean
    Dim TheView As Integer = 0
    Private Shared FormExists As Boolean = False
    Dim pixels As Integer = 70
    Dim imageListSmall As New ImageList()
    Dim imageListLarge As New ImageList()


    ' property exposing FormExists
    Public Shared ReadOnly Property InstanceExists() As Boolean
        Get
            ' Access shared members through the Class name, not an instance.
            Return RegionList.FormExists
        End Get
    End Property

#Region "Layout"

    Private Sub Panel1_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseWheel
        ' Update the drawing based upon the mouse wheel scrolling.
        Dim numberOfTextLinesToMove As Integer = CInt(e.Delta * SystemInformation.MouseWheelScrollLines / 120)

        pixels = pixels + numberOfTextLinesToMove
        'Debug.Print(pixels.ToString)
        If pixels > 256 Then pixels = 256
        If pixels < 0 Then pixels = 0

        LoadMyListView()

    End Sub


    Private Sub RegionList_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout

        Dim X = Me.Width - 45
        Dim Y = Me.Height - 95
        ListView1.Size = New System.Drawing.Size(X, Y)

    End Sub
#End Region

    Private Sub _Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Size = New System.Drawing.Size(300, 410)
        imageListLarge.ImageSize = New Size(70, 70)
        pixels = 70
        imageListLarge = New ImageList()
        RegionList.FormExists = True

        ' Set the view to show details.
        ListView1.View = View.Details
        ' Allow the user to edit item text.
        ListView1.LabelEdit = True
        ' Allow the user to rearrange columns.
        ListView1.AllowColumnReorder = True
        ' Display check boxes.
        ListView1.CheckBoxes = True
        ' Select the item and subitems when selection is made.
        ListView1.FullRowSelect = True
        ' Display grid lines.
        ListView1.GridLines = True
        ' Sort the items in the list in ascending order.
        ListView1.Sorting = SortOrder.Ascending

        'Add the items to the ListView.
        ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
        AddHandler Me.ListView1.ColumnClick, AddressOf ColumnClick

        ' Me.Controls.Add(ListView1)
        Me.Name = "Region List"
        Me.Text = "Region List"

        ' index of 0-4 to display icons
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("navigate_up2"))   ' 0 booting up
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("navigate_down2")) ' 1 shutting down
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("check2")) ' 2 okay, up
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("navigate_plus")) ' 3 disabled
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("media_stop_red")) ' 4 disabled
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("media_stop"))  ' 5 enabled

        LoadMyListView()

        Timer1.Interval = 30000
        Timer1.Start() 'Timer starts functioning

    End Sub
    Private Sub SingletonForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        RegionList.FormExists = False

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        LoadMyListView()
        Timer1.Interval = 30000

    End Sub

    Private Sub LoadMyListView()

        writetodisk = False

        Dim RegionClass As RegionMaker = RegionMaker.Instance

        Me.SuspendLayout()

        imageListLarge = New ImageList()
        imageListLarge.ImageSize = New Size(pixels, pixels)
        ListView1.Clear()
        ListView1.Items.Clear()
        ' Create columns for the items and subitems.
        ' Width of -2 indicates auto-size.
        ListView1.Columns.Add("Enabled", 120, HorizontalAlignment.Center)
        ListView1.Columns.Add("Agents", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("Status", 60, HorizontalAlignment.Center)

        Dim imageList1 As New ImageList
        Dim Num As Integer
        Dim n As Integer = 0
        For Each X In RegionClass.RegionNumbers
            Application.DoEvents()
            RegionClass.DebugRegions(n)

            If RegionClass.RegionName(n) = "Isis" Then
                Debug.Print("Egypt")
            End If

            ' Create  items and subitems for each item.
            Dim item1 As New ListViewItem(RegionClass.RegionName(n), n)
            ' Place a check mark next to the item.
            item1.Checked = RegionClass.RegionEnabled(n)
            item1.SubItems.Add(RegionClass.AvatarCount(n).ToString)

            Dim Letter As String = ""
            If RegionClass.WarmingUp(n) Then
                Letter = "Booting"
                Num = 0
            ElseIf RegionClass.ShuttingDown(n) Then
                Letter = "Shutting Down"
                Num = 1
            ElseIf RegionClass.Ready(n) Then
                Letter = "Running"
                Num = 2
            ElseIf Not RegionClass.ProcessID(n) And RegionClass.ShuttingDown(n) Then
                Letter = "Exiting"
                Num = 3
            ElseIf Not RegionClass.RegionEnabled(n) Then
                Letter = "Disabled"
                Num = 4
            ElseIf RegionClass.RegionEnabled(n) Then
                Letter = "Stopped"
                Num = 5
            Else
                Num = 5
            End If

            item1.SubItems.Add(Letter)
            ListView1.Items.AddRange(New ListViewItem() {item1})

            If TheView = 2 Then
                If RegionClass.Ready(n) Then
                    Dim img As String = "http://127.0.0.1:" + RegionClass.RegionPort(n).ToString + "/" + "index.php?method=regionImage" + RegionClass.UUID(n).Replace("-", "")
                    Debug.Print(img)
                    Dim bmp As Image = LoadImage(img)
                    If bmp Is Nothing Then
                        imageListLarge.Images.Add(My.Resources.ResourceManager.GetObject("water"))
                    Else
                        imageListLarge.Images.Add(bmp)
                    End If
                    Num = n
                Else
                    imageListLarge.Images.Add(My.Resources.ResourceManager.GetObject("water"))
                    Num = n
                End If
            End If

            ListView1.Items(n).ImageIndex = Num
            n = n + 1
        Next

        'Assign the ImageList objects to the ListView.
        ListView1.LargeImageList = imageListLarge
        ListView1.SmallImageList = imageListSmall

        Me.ListView1.TabIndex = 0
        Me.ListView1.LabelEdit = False
        Me.ResumeLayout(True)
        writetodisk = True

    End Sub 'listView1

    Private Function LoadImage(url As String) As Image
        Dim bmp As Bitmap = Nothing
        Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(url)
        Try
            Dim response As System.Net.WebResponse = request.GetResponse()
            Dim responseStream As System.IO.Stream = response.GetResponseStream()
            bmp = New Bitmap(responseStream)
            responseStream.Dispose()
        Catch
        End Try

        Return bmp

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LoadMyListView()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        Dim regions As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem

        For Each item In regions
            Dim RegionName = item.SubItems(0).Text
            Debug.Print("Clicked row " + RegionName)
            Dim n As Integer = RegionClass.FindRegionByName(RegionName)

            StartStop(n)
        Next

    End Sub
    Private Sub StartStop(n As Integer)

        ' Running, stop it
        Dim RegionClass As RegionMaker = RegionMaker.Instance
        If RegionClass.ShuttingDown(n) Then
            RegionClass.ShuttingDown(n) = False
        End If

        If RegionClass.RegionEnabled(n) And (RegionClass.Ready(n) Or RegionClass.WarmingUp(n)) Then
            ' if enabled and running, even partly up, stop it.
            Try
                Form1.ConsoleCommand(RegionClass.ProcessID(n), "quit{ENTER}")
                Me.Focus()

                RegionClass.Ready(n) = False
                RegionClass.WarmingUp(n) = False
                RegionClass.ShuttingDown(n) = True

                Form1.LoadIni(RegionClass.RegionPath(n), ";")
                Form1.SetIni(RegionClass.RegionName(n), "Enabled", "false")
                Form1.SaveINI()

                Form1.Log("Region:Stopped Region " + RegionClass.RegionName(n))

            Catch ex As Exception
                Form1.Log("Region:Could not stop " + RegionClass.RegionName(n))
            End Try

        ElseIf RegionClass.RegionEnabled(n) And Not (RegionClass.Ready(n) Or RegionClass.WarmingUp(n) Or RegionClass.ShuttingDown(n)) Then
            ' it was stopped, and disabled, so we start up
            If Not Form1.StartMySQL() Then Return
            Form1.Start_Robust()
            Form1.CopyOpensimProto()
            Form1.Boot(RegionClass.RegionName(n))
            Debug.Print("Region:Started Region " + RegionClass.RegionName(n))
        Else
            Try
                Dim ActualForm As New FormRegion
                ActualForm.Init(RegionClass.RegionName(n))
                'ActualForm.SetDesktopLocation(X, Y)
                ActualForm.Activate()
                ActualForm.Visible = True

            Catch ex As Exception
                Form1.Log("Info:" + ex.Message)
            End Try

        End If
        Timer1.Interval = 1000

    End Sub

    ' Handles the ItemChecked event. The method uses the CurrentValue property 
    ' of the ItemCheckEventArgs to retrieve and tally the price of the menu 
    ' items selected.  
    Private Sub ListView1_ItemCheck1(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListView1.ItemCheck

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        Dim Item As ListViewItem = ListView1.Items.Item(e.Index)
        Dim n As Integer = RegionClass.FindRegionByName(Item.Text)

        If writetodisk Then
            If (e.CurrentValue = CheckState.Unchecked) Then
                RegionClass.RegionEnabled(n) = True
                ' and region file on disk
                Form1.LoadIni(RegionClass.RegionPath(n), ";")
                Form1.SetIni(RegionClass.RegionName(n), "Enabled", "true")
                Form1.SaveINI()
                RegionClass.ProcessID(n) = 0
                Application.DoEvents()
            ElseIf (e.CurrentValue = CheckState.checked) Then
                RegionClass.RegionEnabled(n) = False
                ' and region file on disk
                Form1.LoadIni(RegionClass.RegionPath(n), ";")
                Form1.SetIni(RegionClass.RegionName(n), "Enabled", "false")
                Form1.SaveINI()
                Application.DoEvents()
            End If
        End If
        Timer1.Interval = 100

    End Sub

    ' ColumnClick event handler.
    Private Sub ColumnClick(ByVal o As Object, ByVal e As ColumnClickEventArgs)

        Me.ListView1.Sorting = SortOrder.None
        ' Set the ListViewItemSorter property to a new ListViewItemComparer 
        ' object. Setting this property immediately sorts the 
        ' ListView using the ListViewItemComparer object.
        Me.ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ViewButton.Click

        While Not writetodisk
            Form1.Sleep(500)
        End While

        If TheView = 0 Then
            ListView1.CheckBoxes = False
            ListView1.View = View.List
        ElseIf TheView = 1 Then
            ListView1.CheckBoxes = False
            ListView1.View = View.LargeIcon
        ElseIf TheView = 2 Then
            ListView1.CheckBoxes = True
            ListView1.View = View.Details
        End If
        TheView = TheView + 1
        If TheView > 2 Then TheView = 0

        LoadMyListView()

    End Sub

    Private Sub Addregion_Click(sender As Object, e As EventArgs) Handles Addregion.Click

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        RegionClass.CreateRegion("")
        Dim ActualForm As New FormRegion
        'ActualForm.SetDesktopLocation(300, 200)
        ActualForm.Init("")
        ActualForm.Activate()
        ActualForm.Visible = True

    End Sub


End Class

' Implements the manual sorting of items by columns.
Class ListViewItemComparer
    Implements IComparer
    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare

        Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)

    End Function
End Class
