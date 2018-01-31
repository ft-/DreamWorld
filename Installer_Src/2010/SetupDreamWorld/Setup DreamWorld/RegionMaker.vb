

Imports System
Imports System.IO


Public Class RegionMaker

#Region "Declarations"
    ' hold a copy of the Main region data on a per-form basis
    Public Class Region_data
        Public _RegionPath As String = ""
        Public _FolderPath As String = ""
        Public _Folder As String = ""
        Public _ProcessID As Integer = 0
        Public _RegionName As String = ""
        Public _UUID As String = ""
        Public _CoordX As Integer = 0
        Public _CoordY As Integer = 0
        Public _RegionPort As Integer = 0
        Public _SizeX As Integer = 0
        Public _SizeY As Integer = 0
        Public _AvatarCount As Integer = 0
        Public _RegionEnabled As Boolean = False ' Will run or not
        Public _Ready As Boolean = False       ' is up
        Public _WarmingUp As Boolean = False    ' booting up
        Public _ShuttingDown As Boolean = False ' shutting down
        Public _Timer As Integer
    End Class

    Public RegionList As New ArrayList()
    Private gCurRegionNum As Integer

#End Region

#Region "Properties"

    Public Property ShuttingDown() As Boolean
        Get
            Return RegionList(CurRegionNum())._ShuttingDown
        End Get
        Set(ByVal Value As Boolean)
            RegionList(CurRegionNum())._ShuttingDown = Value
        End Set
    End Property
    Public Property Ready() As Boolean
        Get
            Return RegionList(CurRegionNum())._Ready
        End Get
        Set(ByVal Value As Boolean)
            RegionList(CurRegionNum())._Ready = Value
        End Set
    End Property
    Public Property Timer() As Integer
        Get
            Return RegionList(CurRegionNum())._Timer
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum())._Timer = Value
        End Set
    End Property
    Public Property WarmingUp() As Boolean
        Get
            Return RegionList(CurRegionNum())._WarmingUp
        End Get
        Set(ByVal Value As Boolean)
            RegionList(CurRegionNum())._WarmingUp = Value
        End Set
    End Property
    Public ReadOnly Property RegionCount() As Integer
        Get
            Return RegionList.Count
        End Get

    End Property
    Public Property RegionPath() As String
        Get
            Return RegionList(CurRegionNum())._RegionPath
        End Get
        Set(ByVal Value As String)
            RegionList(CurRegionNum())._RegionPath = Value
        End Set
    End Property
    Public Property FolderPath() As String
        Get
            Return RegionList(CurRegionNum())._FolderPath
        End Get
        Set(ByVal Value As String)
            RegionList(CurRegionNum())._FolderPath = Value
        End Set
    End Property
    Public Property Folder() As String
        Get
            Return RegionList(CurRegionNum())._Folder.ToString
        End Get
        Set(ByVal Value As String)
            RegionList(CurRegionNum())._Folder = Value
        End Set
    End Property
    Public Property RegionEnabled() As Boolean
        Get
            Return RegionList(CurRegionNum())._RegionEnabled
        End Get
        Set(ByVal Value As Boolean)
            RegionList(CurRegionNum())._RegionEnabled = Value
        End Set
    End Property
    Public Property ProcessID() As Integer
        Get
            Return RegionList(CurRegionNum())._ProcessID
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum())._ProcessID = Value
        End Set
    End Property
    Public Property AvatarCount() As Integer
        Get
            Return RegionList(CurRegionNum())._AvatarCount
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum())._AvatarCount = Value
        End Set
    End Property
    Public Property CurRegionNum() As Integer
        Get
            Return gCurRegionNum
        End Get
        Set(ByVal Value As Integer)
            gCurRegionNum = Value
        End Set
    End Property
    Public Property RegionName() As String
        Get
            Return RegionList(CurRegionNum())._RegionName
        End Get
        Set(ByVal Value As String)
            RegionList(CurRegionNum())._RegionName = Value
        End Set
    End Property
    Public Property UUID() As String
        Get
            Return RegionList(CurRegionNum())._UUID
        End Get
        Set(ByVal Value As String)
            RegionList(CurRegionNum())._UUID = Value
        End Set
    End Property
    Public Property SizeX() As Integer
        Get
            Return RegionList(CurRegionNum())._SizeX
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum())._SizeX = Value
        End Set
    End Property
    Public Property SizeY() As Integer
        Get
            Return RegionList(CurRegionNum())._SizeY
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum())._SizeY = Value
        End Set
    End Property
    Public Property RegionPort() As Integer
        Get
            If RegionList(CurRegionNum())._RegionPort <= My.Settings.PrivatePort Then
                RegionList(CurRegionNum())._RegionPort = My.Settings.PrivatePort + 1 ' 8004, by default
            End If
            Return RegionList(CurRegionNum())._RegionPort
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum())._RegionPort = Value
        End Set
    End Property
    Public Property CoordX() As Integer
        Get
            Return RegionList(CurRegionNum())._CoordX
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum())._CoordX = Value
        End Set
    End Property
    Public Property CoordY() As Integer
        Get
            Return RegionList(CurRegionNum())._CoordY
        End Get
        Set(ByVal Value As Integer)
            RegionList(CurRegionNum())._CoordY = Value
        End Set
    End Property

#End Region

#Region "Functions"

    Public Sub New()

        GetAllRegions()
        If RegionCount() = 0 Then
            CreateRegion("Welcome")
            My.Settings.WelcomeRegion = "Welcome"
            WriteRegionObject("Welcome")
        End If

        CreateRegion("Robust")
        WriteRegionObject("Robust")
        GetAllRegions()

    End Sub


    Public Sub DebugRegions(o As Region_data)

        Debug.Print("Region:" + o._RegionName +
            " WarmingUp=" + o._WarmingUp.ToString +
           " ShuttingDown=" + o._ShuttingDown.ToString +
            " Ready=" + o._Ready.ToString +
           " RegionEnabled=" + o._RegionEnabled.ToString)

    End Sub

    Public Function FindRegionByName(Name As String) As Region_data

        Dim i As Integer = 0
        For Each obj As Region_data In RegionList
            If Name = obj._RegionName Then
                CurRegionNum = i
                Debug.Print("Current Region #: " + CurRegionNum.ToString + " is " + obj._RegionName)
                Return obj
            End If
            i = i + 1
        Next
        Return Nothing

    End Function

    Public Function FindRegionByProcessID(PID As Integer) As Region_data

        Dim i As Integer = 0
        For Each obj As Region_data In RegionList
            If PID = obj._ProcessID Then
                CurRegionNum = i
                Debug.Print("Current Region #: " + CurRegionNum.ToString + " is " + obj._RegionName)
                Return obj
            End If
            i = i + 1
        Next
        Return Nothing

    End Function

    Public Function CreateRegion(name As String) As Region_data

        Debug.Print("Create Region " + name)
        Dim r As New Region_data
        r._RegionName = name
        r._RegionEnabled = True
        r._UUID = Guid.NewGuid().ToString
        r._SizeX = 256
        r._SizeY = 256
        r._CoordX = LargestX() + 4
        r._CoordY = LargestY() + 0
        r._RegionPort = LargestPort() + 1 '8004 + 1

        RegionList.Add(r)
        CurRegionNum = RegionCount() - 1
        Return FindRegionByName(name)

    End Function

    Public Sub GetAllRegions()

        RegionList.Clear()
        Dim folders() As String
        Dim regionfolders() As String

        folders = Directory.GetDirectories(Form1.prefix + "bin\Regions")
        For Each FolderName As String In folders
            'Form1.Log("Info:Region Path:" + FolderName)
            regionfolders = Directory.GetDirectories(FolderName)
            For Each FileName As String In regionfolders

                Dim fName = ""
                Try
                    'Form1.Log("Info:Loading region from " + FolderName)
                    Dim inis = Directory.GetFiles(FileName, "*.ini", SearchOption.TopDirectoryOnly)

                    For Each ini As String In inis
                        ' remove the ini
                        'Debug.Print(FileName)

                        fName = Path.GetFileName(ini)
                        fName = Mid(fName, 1, Len(fName) - 4)

                        ' make a slot to hold the region data 
                        CreateRegion(fName)

                        Try
                            RegionEnabled() = Form1.GetIni(ini, fName, "Enabled", ";")
                        Catch ex As Exception
                            RegionEnabled() = True
                        End Try

                        RegionPath() = ini ' save the path
                        FolderPath() = Path.GetDirectoryName(ini)

                        ' need folder name in case there are more than 1 ini
                        Dim theStart = FolderPath().IndexOf("Regions\") + 8
                        Dim theEnd = FolderPath().LastIndexOf("\")
                        Folder() = FolderPath().Substring(theStart, theEnd - theStart)

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
                    MsgBox("Error: Cannot parse a Region file:" + fName + ":" + ex.Message)
                    Form1.Log("Err:Parse file " + fName + ":" + ex.Message)
                End Try
            Next
        Next

    End Sub

    Public Sub WriteRegionObject(name As String)

        Dim pathtoWelcome As String = Form1.prefix + "bin\Regions\" + name + "\Region\"
        Dim fname = pathtoWelcome + name + ".ini"
        If Not Directory.Exists(pathtoWelcome) Then
            Try
                Directory.CreateDirectory(pathtoWelcome)
            Catch ex As Exception

            End Try

        End If

        File.Copy(Form1.prefix & "bin\Regions.proto", fname, True)

        Form1.LoadIni(fname, ";")
        Form1.SetIni(name, "RegionUUID", UUID)
        Form1.SetIni(name, "Location", CoordX & "," & CoordY)
        Form1.SetIni(name, "InternalPort", RegionPort)
        Form1.SetIni(name, "ExternalHostName", My.Settings.PublicIP)
        Form1.SetIni(name, "SizeX", SizeX)
        Form1.SetIni(name, "SizeY", SizeY)
        Form1.SaveINI()

    End Sub

    Public Function LargestX() As Integer

        ' locate largest global coords
        Dim Max As Integer
        For Each obj As Region_data In RegionList
            If obj._CoordX > Max Then Max = obj._CoordX
        Next
        If Max = 0 Then Max = 996 ' (1000 - 4 so 1st region ends up at 1000)
        Return Max

    End Function

    Public Function LargestY() As Integer

        ' locate largest global coords
        Dim Max As Integer
        For Each obj As Region_data In RegionList
            Dim val = obj._CoordY
            If val > Max Then Max = val
        Next
        If Max = 0 Then Max = 1000
        Return Max

    End Function

    Public Function LargestPort() As Integer

        ' locate largest global coords
        Dim Max As Integer
        Dim counter As Integer = 0
        For Each obj As Region_data In RegionList
            Dim val = obj._RegionPort
            If val > Max Then Max = val
        Next
        If Max = 0 Then Max = My.Settings.PrivatePort
        Return Max

    End Function


#End Region

End Class
