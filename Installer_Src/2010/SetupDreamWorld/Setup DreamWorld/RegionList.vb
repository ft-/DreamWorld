
Imports System.IO


Public Class RegionList

    Dim writetodisk As Boolean
    Dim TheView As Integer = 0
    Private Shared FormExists As Boolean = False
    Dim pixels As Integer = 70
    Dim imageListSmall As New ImageList
    Dim imageListLarge As ImageList
    Dim ItemsAreChecked As Boolean = False
    Dim RegionClass As RegionMaker = RegionMaker.Instance


    ' property exposing FormExists
    Public Shared ReadOnly Property InstanceExists() As Boolean
        Get
            ' Access shared members through the Class name, not an instance.
            Return RegionList.FormExists
        End Get
    End Property

#Region "Layout"

    Private Sub Panel1_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseWheel

        If TheView = 2 Then
            ' Update the drawing based upon the mouse wheel scrolling.
            Dim numberOfTextLinesToMove As Integer = CInt(e.Delta * SystemInformation.MouseWheelScrollLines / 120)

            pixels = pixels + numberOfTextLinesToMove
            'Debug.Print(pixels.ToString)
            If pixels > 256 Then pixels = 256
            If pixels < 10 Then pixels = 10

            LoadMyListView()
        End If

    End Sub


    Private Sub RegionList_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout

        Dim X = Me.Width - 45
        Dim Y = Me.Height - 95
        ListView1.Size = New System.Drawing.Size(X, Y)

    End Sub
#End Region

    Private Sub _Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Size = New System.Drawing.Size(410, 410)

        pixels = 70

        RegionList.FormExists = True

        ' ListView Setup
        ListView1.AllowDrop = True
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
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("media_stop"))  ' 5 enabled, stopped
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("media_stop"))  ' 6 

        LoadMyListView()

        Timer1.Interval = 30000
        Timer1.Start() 'Timer starts functioning

    End Sub
    Private Sub SingletonForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        RegionList.FormExists = False

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        LoadMyListView()
        'Timer1.Interval = 30000

    End Sub

    Private Sub LoadMyListView()

        writetodisk = False

        ListView1.SuspendLayout()

        imageListLarge = New ImageList()
        If pixels = 0 Then pixels = 20
        imageListLarge.ImageSize = New Size(pixels, pixels)
        ListView1.Clear()
        ListView1.Items.Clear()

        ' Create columns for the items and subitems.
        ' Width of -2 indicates auto-size.
        ListView1.Columns.Add("Enabled", 120, HorizontalAlignment.Center)
        ListView1.Columns.Add("Group", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("Agents", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("Status", 60, HorizontalAlignment.Center)

        Dim imageList1 As New ImageList
        Dim Num As Integer = 0
        Dim n As Integer = 0
        For Each X In RegionClass.RegionNumbers

            Application.DoEvents()
            RegionClass.DebugRegions(n)

            ' If RegionClass.RegionName(n) = "Deliverance" Then
            ' Debug.Print("Deliverance")
            ' End If

            Dim Letter As String = ""
            If RegionClass.WarmingUp(n) Then
                Letter = "Booting"
                Num = 0
            ElseIf RegionClass.ShuttingDown(n) Then
                Letter = "Shutting Down"
                Num = 1
            ElseIf RegionClass.Booted(n) Then
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

            ' Create  items and subitems for each item.
            Dim item1 As New ListViewItem(RegionClass.RegionName(n), Num)
            ' Place a check mark next to the item.
            item1.Checked = RegionClass.RegionEnabled(n)
            item1.SubItems.Add(RegionClass.GroupName(n).ToString)
            item1.SubItems.Add(RegionClass.AvatarCount(n).ToString)

            item1.SubItems.Add(Letter)

            ListView1.Items.AddRange(New ListViewItem() {item1})

            If TheView = 2 Then
                If RegionClass.Booted(n) Then
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
            'ListView1.Items(n).ImageIndex = 1
            n = n + 1
        Next

        'Assign the ImageList objects to the ListView.
        ListView1.LargeImageList = imageListLarge
        ListView1.SmallImageList = imageListSmall

        Me.ListView1.TabIndex = 0
        Me.ListView1.LabelEdit = False
        ListView1.ResumeLayout(True)
        writetodisk = True
        Timer1.Interval = 30000

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

        RegionClass.GetAllRegions()
        LoadMyListView()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        Dim regions As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem

        For Each item In regions
            Dim RegionName = item.SubItems(0).Text
            Debug.Print("Clicked row " + RegionName)
            Dim n As Integer = RegionClass.FindRegionByName(RegionName)
            StartStopEdit(n)
        Next

    End Sub
    Private Sub StartStopEdit(n As Integer)

        ' stop it, start it, or edit it

        If RegionClass.RegionEnabled(n) And (RegionClass.Booted(n) Or RegionClass.WarmingUp(n)) Or RegionClass.ShuttingDown(n) Then
            ' if enabled and running, even partly up, stop it.
            Try

                For Each num In RegionClass.RegionListByGroupNum(RegionClass.GroupName(n))
                    Form1.ConsoleCommand(RegionClass.ProcessID(num), "quit{ENTER}")
                    RegionClass.Booted(num) = False
                    RegionClass.WarmingUp(num) = False
                    RegionClass.ShuttingDown(num) = True
                    Form1.Log("Region:Stopped Region " + RegionClass.RegionName(num))
                Next

            Catch ex As Exception
                Form1.Log("Region:Could not stop " + RegionClass.RegionName(n))
            End Try
            Me.Focus()

        ElseIf RegionClass.RegionEnabled(n) And Not (RegionClass.Booted(n) Or RegionClass.WarmingUp(n) Or RegionClass.ShuttingDown(n)) Then
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
                ActualForm.Activate()
                ActualForm.Visible = True
            Catch ex As Exception
                Form1.Log("Info:" + ex.Message)
            End Try

        End If
        Timer1.Interval = 2000

    End Sub

    ' Handles the ItemChecked event. The method uses the CurrentValue property 
    ' of the ItemCheckEventArgs to retrieve and tally the price of the menu 
    ' items selected.  
    Private Sub ListView1_ItemCheck1(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListView1.ItemCheck

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
            ElseIf (e.CurrentValue = CheckState.Checked) Then
                RegionClass.RegionEnabled(n) = False
                ' and region file on disk
                Form1.LoadIni(RegionClass.RegionPath(n), ";")
                Form1.SetIni(RegionClass.RegionName(n), "Enabled", "false")
                Form1.SaveINI()
                Application.DoEvents()
            End If
        End If
        Timer1.Interval = 1000

    End Sub

    ' ColumnClick event handler.
    Private Sub ColumnClick(ByVal o As Object, ByVal e As ColumnClickEventArgs)

        ListView1.SuspendLayout()
        Me.ListView1.Sorting = SortOrder.None
        ' Set the ListViewItemSorter property to a new ListViewItemComparer 
        ' object. Setting this property immediately sorts the 
        ' ListView using the ListViewItemComparer object.
        Me.ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column)
        ListView1.ResumeLayout()

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

        Dim ActualForm As New FormRegion
        Dim RegionClass As RegionMaker = RegionMaker.Instance
        RegionClass.CreateRegion("")
        ActualForm.Init("")
        ActualForm.Activate()
        ActualForm.Visible = True

    End Sub

#Region "DragDrop"

    Private Sub ListView1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Private Sub ListView1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop

        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

        Dim dirpathname = ""
        Dim yesNo As MsgBoxResult = MsgBox("New regions can can be combined with other regions in an existing DOS box (Yes), or run in their own Dos Box (No)", vbYesNo, "Grouping Regions")
        If yesNo = vbYes Then
            dirpathname = RegionChosen()
            If dirpathname = "" Then
                Form1.PrintFast("Aborted")
                Return
            End If
        End If

        Dim dir = Form1.prefix

        For Each pathname As String In files
            pathname.Replace("\", "/")
            Dim extension = Path.GetExtension(pathname)
            extension = Mid(extension, 2, 5)
            If extension.ToLower = "ini" Then
                Dim filename = Path.GetFileNameWithoutExtension(pathname)
                Dim i = RegionClass.FindRegionByName(filename)
                If i >= 0 Then
                    MsgBox("Region name " + filename + " already exists", vbInformation, "Info")
                    Return
                End If

                If dirpathname = "" Then dirpathname = filename

                Dim NewFilepath = dir & "bin\Regions\" + dirpathname + "\Region\"
                If Not Directory.Exists(NewFilepath) Then
                    Directory.CreateDirectory(dir & "bin\Regions\" + dirpathname + "\Region")
                End If

                File.Copy(pathname, dir & "bin\Regions\" + dirpathname + "\Region\" + filename + ".ini")

            Else
                Print("Unrecognized file type:" + extension + ".  Drag and drop any Region.ini files to add them to the system")
            End If
        Next
        RegionClass.GetAllRegions()
        LoadMyListView()

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

    Private Sub RegionHelp_Click(sender As Object, e As EventArgs) Handles RegionHelp.Click

        Process.Start(Form1.Domain + "/Outworldz_Installer/RegionHelp.htm") ' !!!

    End Sub

    Private Sub AllNome_CheckedChanged(sender As Object, e As EventArgs) Handles AllNome.CheckedChanged

        For Each X As ListViewItem In ListView1.Items
            If ItemsAreChecked Then
                X.Checked = CheckState.Unchecked
            Else
                X.Checked = CheckState.Checked
            End If
        Next

        If ItemsAreChecked Then
            ItemsAreChecked = False
        Else
            ItemsAreChecked = True
        End If



    End Sub

#End Region

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


    ''!!!  RegionClass.RegionList = RegionClass.RegionList.OrderBy(Function(x) x.RegionName).ToList()

End Class
