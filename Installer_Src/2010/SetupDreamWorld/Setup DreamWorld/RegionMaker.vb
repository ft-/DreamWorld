

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
        Public CoordY As Integer
        Public RegionPort As Integer
        Public SizeX As Integer
        Public SizeY As Integer

        Public RegionEnabled As Boolean ' Will run or not
        Public Ready As Boolean         ' is up
        Public WarmingUp As Boolean     ' booting up
        Public ShuttingDown As Boolean  ' shutting down
    End Class

    Public Shared RegionList As New ArrayList
    Private gCurRegionNum As Integer
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
    Public Property isRegionEnabled() As Boolean
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
            If gCurRegionNum > RegionList.Count - 1 Then
                gCurRegionNum = RegionList.Count - 1
            End If
            If gCurRegionNum = -1 Then
                Return 0
            End If
            Return gCurRegionNum
        End Get
        Set(ByVal Value As Integer)
            gCurRegionNum = Value
        End Set
    End Property
    Public Property RegionName() As String
        Get

            If gCurRegionNum > RegionList.Count - 1 Then
                gCurRegionNum = RegionList.Count - 1
            End If
            If gCurRegionNum < 0 Then
                gCurRegionNum = 0
            End If
            If RegionList.Count > 0 Then
                Return RegionList(CurRegionNum()).RegionName
            End If
            Return ""
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
            RegionList(CurRegionNum()).Ready = Value
        End Set
    End Property



#End Region

#Region "Functions"

    Public Sub New()

        GetAllRegions()
        If RegionCount() = 0 Then
            CreateRegion("Welcome")
            My.Settings.WelcomeRegion = ""
            WriteRegion()
            GetAllRegions()
        End If

    End Sub



    Public Sub DebugRegions()

        For Each obj In RegionList
            Debug.Print("Region:" + obj.RegionName)
        Next

    End Sub

    Public Function AllRegionObjects()

        Dim rlist As New ArrayList
        For Each obj In RegionList
            Debug.Print("Region:" + obj.RegionName)
            rlist.Add(obj)
        Next
        Return rlist

    End Function

    Public Function FindRegionByName(Name As String) As Object

        For Each obj In RegionList
            If Name = obj.RegionName Then
                Return obj
            End If
        Next
        Return Nothing

    End Function

    Public Function FindRegionByProcessID(PID As Integer) As Object

        For Each obj In RegionList
            If PID = obj.ProcessID Then
                Return obj
            End If
        Next
        Return Nothing

    End Function

    Public Sub CreateRegion(name As String)

        Dim r As New Region_data
        r.RegionName = name
        r.RegionEnabled = True
        r.UUID = Guid.NewGuid().ToString
        r.SizeX = 256
        r.SizeY = 256
        r.CoordX = LargestX() + 4
        r.CoordY = LargestY() + 0
        r.RegionPort = LargestPort() + 1 '8004 + 1

        RegionList.Add(r)
        CurRegionNum = RegionCount() - 1

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
                        CreateRegion(fName)

                        Form1.Log("Info:Reading Region " + ini)

                        ' populate from disk
                        RegionName() = fName
                        Try
                            isRegionEnabled() = Form1.GetIni(ini, fName, "Enabled", ";")
                        Catch
                            isRegionEnabled() = True
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
        DebugRegions()
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

        File.Copy(Form1.prefix & "bin\Regions.proto", path & "\" & name & "\Region\" & name & ".ini")

        Form1.LoadIni(path & "\" & name & "\Region\" & name & ".ini", ";")
        Form1.SetIni(name, "RegionUUID", RegionList(index).UUID)
        Form1.SetIni(name, "Location", RegionList(index).CoordX & "," & RegionList(index).CoordY)
        Form1.SetIni(name, "InternalPort", RegionList(index).RegionPort)
        Form1.SetIni(name, "ExternalHostName", My.Settings.PublicIP)
        Form1.SetIni(name, "SizeX", RegionList(index).SizeX)
        Form1.SetIni(name, "SizeY", RegionList(index).SizeY)
        Form1.SaveINI()

    End Sub

    Public Function LargestX() As Integer

        ' locate largest global coords
        Dim Max As Integer
        For Each obj In RegionList
            If obj.CoordX > Max Then Max = obj.CoordX
        Next
        If Max = 0 Then Max = 996 ' (1000 - 4 so 1st region ends up at 1000)
        Return Max

    End Function

    Public Function LargestY() As Integer

        ' locate largest global coords
        Dim Max As Integer
        For Each obj In RegionList
            Dim val = obj.CoordY
            If val > Max Then Max = val
        Next
        If Max = 0 Then Max = 1000
        Return Max

    End Function

    Public Function LargestPort() As Integer

        ' locate largest global coords
        Dim Max As Integer
        Dim counter As Integer = 0
        For Each obj In RegionList
            Dim val = obj.RegionPort
            If val > Max Then Max = val
        Next
        If Max = 0 Then Max = My.Settings.PrivatePort
        Return Max

    End Function


#End Region

End Class
