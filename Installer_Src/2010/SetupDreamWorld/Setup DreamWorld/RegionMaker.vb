

Imports System
Imports System.IO

Public Class RegionMaker

#Region "Declarations"
    ' hold a copy of the Main region data on a per-form basis
    Private Class Region_data
        Public ProcessID As Integer
        Public RegionName As String
        Public UUID As String
        Public CoordX As Integer
        Public CoordY As String
        Public RegionPort As Integer
        Public SizeX As Integer
        Public SizeY As Integer
        Public RegionEnabled As Boolean
        Public Ready As Boolean
    End Class

    Public Shared RegionList As New ArrayList
    Private gCurCurRegionNum As UInteger
#End Region

#Region "Properties"
    Public Shared Property RegionCount() As Integer
        Get
            Try
                Return RegionList.Count
            Catch
                Return 0
            End Try

        End Get
        Set(value As Integer)
        End Set
    End Property
    Public Property RegionEnabled() As Boolean
        Get
            Return RegionList(CurRegionNum()).RegionEnabled
        End Get
        Set(ByVal Value As Boolean)
            RegionList(CurRegionNum()).RegionEnabled = Value
        End Set
    End Property
    Public Property ProcessID() As Integer
        Get
            Return RegionList(CurRegionNum()).ProcessID
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum()).ProcessID = Value
        End Set
    End Property
    Public Property CurRegionNum() As Integer
        Get
            Return gCurCurRegionNum
        End Get
        Set(ByVal Value As Integer)
            gCurCurRegionNum = Value
        End Set
    End Property
    Public Property RegionName() As String
        Get
            Return RegionList(CurRegionNum()).RegionName
        End Get
        Set(ByVal Value As String)
            RegionList(CurRegionNum()).RegionName = Value
        End Set
    End Property
    Public Property UUID() As String
        Get
            Return RegionList(CurRegionNum()).UUID
        End Get
        Set(ByVal Value As String)
            RegionList(CurRegionNum()).UUID = Value
        End Set
    End Property
    Public Property SizeX() As Integer
        Get
            Return RegionList(CurRegionNum()).SizeX
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum()).SizeX = Value
        End Set
    End Property
    Public Property SizeY() As Integer
        Get
            Return RegionList(CurRegionNum()).SizeY
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum()).SizeY = Value
        End Set
    End Property
    Public Property RegionPort() As Integer
        Get
            If RegionList(CurRegionNum()).RegionPort <= My.Settings.PrivatePort Then
                RegionList(CurRegionNum()).RegionPort = My.Settings.PrivatePort + 1 ' 8004, by default
            End If
            Return RegionList(CurRegionNum()).RegionPort
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum()).RegionPort = Value
        End Set
    End Property
    Public Property CoordX() As Integer
        Get
            Return RegionList(CurRegionNum()).CoordX
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum()).CoordX = Value
        End Set
    End Property
    Public Property CoordY() As Integer
        Get
            Return RegionList(CurRegionNum()).CoordY
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum()).CoordY = Value
        End Set
    End Property
    Public Property Ready() As Boolean
        Get
            Return RegionList(CurRegionNum()).Ready
        End Get
        Set(ByVal Value As Boolean)
            RegionList(CurRegionNum()).CoordY = Ready
        End Set
    End Property



#End Region

#Region "Functions"

    Public Sub New()

        GetAllRegions()
        If RegionListCount() = 0 Then
            CreateRegion("Welcome")
            My.Settings.WelcomeRegion = 0
            WriteRegion()
            GetAllRegions()
        End If

    End Sub
    Public Function CurrentRegionName() As String

        Dim id = CurRegionNum
        Return FindRegionidByName(id)

    End Function

    Public Function RegionListCount() As Integer

        Return RegionCount()

    End Function
    Public Sub DisplayRegions()

        Dim index = RegionListCount() - 1
        Dim counter = 0
        While counter <= index
            Debug.Print("Region:" + RegionList(counter).RegionName)
            counter = counter + 1
        End While

    End Sub

    Public Function FindRegionidByName(Name As String) As Integer

        Dim index = RegionListCount() - 1

        While index > -1
            If Name = RegionList(index).RegionName Then
                Return index
            End If
            index = index - 1
        End While
        Return -1

    End Function

    Public Sub CreateRegion(name As String)

        Dim r As New Region_data
        r.RegionName = name
        r.RegionEnabled = True
        r.UUID = Guid.NewGuid().ToString
        r.SizeX = 256
        r.SizeY = 256

        RegionList.Add(r)
        Dim index = RegionListCount() - 1
        ' default data
        RegionList(index).RegionPort = LargestPort() + 1 '8004 + 1

        ' form a line acrss the X Axis 4 to the right
        RegionList(index).CoordX = LargestX() + 4
        RegionList(index).CoordY = LargestY() + 0
        CurRegionNum() = index

    End Sub

    Public Sub GetAllRegions()

        RegionList.Clear()
        Dim folders() As String
        Dim regionfolders() As String

        folders = Directory.GetDirectories(Form1.prefix + "bin\Regions")
        For Each FolderName As String In folders
            Form1.Log("Info:Region Path:" + FolderName)
            regionfolders = Directory.GetDirectories(FolderName)
            For Each FileName As String In regionfolders
                Try
                    Form1.Log("Info:Loading region from " + FolderName)
                    Dim inis = Directory.GetFiles(FileName, "*.ini", SearchOption.TopDirectoryOnly)
                    For Each ini As String In inis
                        ' remove the ini
                        Dim fName = Path.GetFileName(ini)
                        fName = Mid(fName, 1, Len(fName) - 4)

                        ' make a slot to hold the region data 
                        CreateRegion("")

                        Form1.Log("Info:Reading Region " + ini)

                        ' populate from disk
                        RegionName() = fName
                        Try
                            RegionEnabled() = Form1.GetIni(ini, fName, "Enabled", ";")
                        Catch
                            RegionEnabled() = True
                        End Try

                        UUID() = Form1.GetIni(ini, fName, "RegionUUID", ";")
                        SizeX() = Convert.ToInt16(Form1.GetIni(ini, fName, "SizeX", ";"))
                        SizeY() = Convert.ToInt16(Form1.GetIni(ini, fName, "SizeY", ";"))
                        RegionPort() = Convert.ToInt16(Form1.GetIni(ini, fName, "InternalPort", ";"))
                        ' Location is int,int format.
                        Dim C = Form1.GetIni(ini, fName, "Location", ";")
                        Dim parts As String() = C.Split(New Char() {","c}) ' split at the comma
                        CoordX() = parts(0)
                        CoordY() = parts(1)
                    Next

                Catch ex As Exception
                    MsgBox("Error: Cannot parse a Region file:" + FileName + ":" + ex.Message)
                    Form1.Log("Err:Parse file " + FileName + ":" + ex.Message)
                End Try
            Next
        Next
        DisplayRegions()
    End Sub


    Public Sub WriteRegion()

        Dim path As String = Form1.prefix & "bin\Regions"
        Dim index = CurRegionNum()
        Dim name = RegionList(index).RegionName

        If Not Directory.Exists(path & "\" & name) Then
            Directory.CreateDirectory(path & "\" & name)
        End If
        If Not Directory.Exists(path & "\" & name & "\Region") Then
            Directory.CreateDirectory(path & "\" & name & "\Region")
        End If

        File.Copy(Form1.prefix & "\bin\Regions.proto", path & "\" & name & "\Region\" & name & ".ini")

        Form1.LoadIni(path & "\" & name & "\Region\" & name & ".ini", ";")
        Form1.SetIni(name, "RegionUUID", RegionList(index).UUID)
        Form1.SetIni(name, "Location", RegionList(index).CoordX & "," & RegionList(index).Coordy)
        Form1.SetIni(name, "InternalPort", RegionList(index).RegionPort)
        Form1.SetIni(name, "ExternalHostName", My.Settings.PublicIP)
        Form1.SetIni(name, "SizeX", RegionList(index).SizeX)
        Form1.SetIni(name, "SizeY", RegionList(index).SizeY)
        Form1.SaveINI()

    End Sub

    Public Function LargestX() As Integer

        ' locate largest global coords
        Dim Max As Integer
        Dim counter As Integer = 0 ' index 0
        Dim L = RegionListCount()
        While counter < L
            Dim val = RegionList(counter).CoordX
            If val > Max Then Max = val
            counter += 1
        End While
        If Max = 0 Then Max = 996 ' (1000 - 4 so 1st region ends up at 1000)
        Return Max

    End Function

    Public Function LargestY() As Integer

        ' locate largest global coords
        Dim Max As Integer
        Dim counter As Integer = 1
        Dim L = RegionListCount()
        While counter < L
            Dim val = RegionList(counter).CoordY
            If val > Max Then Max = val
            counter += 1
        End While
        If Max = 0 Then Max = 1000
        Return Max

    End Function

    Public Function LargestPort() As Integer

        ' locate largest global coords
        Dim Max As Integer
        Dim counter As Integer = 0
        Dim L = RegionListCount()
        While counter < L
            Dim val = RegionList(counter).RegionPort
            If val > Max Then Max = val
            counter += 1
        End While
        If Max = 0 Then Max = My.Settings.PrivatePort
        Return Max

    End Function



#End Region

End Class
