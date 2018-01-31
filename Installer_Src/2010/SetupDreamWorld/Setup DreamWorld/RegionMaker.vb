

Imports System
Imports System.IO


Public Class RegionMaker

#Region "Declarations"
    ' hold a copy of the Main region data on a per-form basis
    Public Class Region_data
        Public _RegionPath As String = ""  ' The full path to the region ini file
        Public _FolderPath As String = ""   ' the path to the folde r that holds the region ini
        Public _Folder As String = ""       ' the folder name that holds the region(s), can be different named
        Public _IniPath As String = ""      ' the folder that hold the Opensim.ini, above 'Region'
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
    Public Property IniPath(n As Integer) As String
        Get
            Return RegionList(n)._IniPath
        End Get
        Set(ByVal Value As String)
            RegionList(n)._IniPath = Value
        End Set
    End Property
    Public Property ShuttingDown(n As Integer) As Boolean
        Get
            Return RegionList(n)._ShuttingDown
        End Get
        Set(ByVal Value As Boolean)
            RegionList(n)._ShuttingDown = Value
        End Set
    End Property
    Public Property Ready(n As Integer) As Boolean
        Get
            Return RegionList(n)._Ready
        End Get
        Set(ByVal Value As Boolean)
            RegionList(n)._Ready = Value
        End Set
    End Property
    Public Property Timer(n As Integer) As Integer
        Get
            Return RegionList(n)._Timer
        End Get
        Set(ByVal Value As Integer)
            RegionList(n)._Timer = Value
        End Set
    End Property
    Public Property WarmingUp(n As Integer) As Boolean
        Get
            Return RegionList(n)._WarmingUp
        End Get
        Set(ByVal Value As Boolean)
            RegionList(n)._WarmingUp = Value
        End Set
    End Property
    Public ReadOnly Property RegionCount() As Integer
        Get
            Return RegionList.Count
        End Get

    End Property
    Public Property RegionPath(n As Integer) As String
        Get
            Return RegionList(n)._RegionPath
        End Get
        Set(ByVal Value As String)
            RegionList(n)._RegionPath = Value
        End Set
    End Property
    Public Property FolderPath(n As Integer) As String
        Get
            Return RegionList(n)._FolderPath
        End Get
        Set(ByVal Value As String)
            RegionList(n)._FolderPath = Value
        End Set
    End Property
    Public Property Folder(n As Integer) As String
        Get
            Return RegionList(n)._Folder
        End Get
        Set(ByVal Value As String)
            RegionList(n)._Folder = Value
        End Set
    End Property
    Public Property RegionEnabled(n As Integer) As Boolean
        Get
            Return RegionList(n)._RegionEnabled
        End Get
        Set(ByVal Value As Boolean)
            RegionList(n)._RegionEnabled = Value
        End Set
    End Property
    Public Property ProcessID(n As Integer) As Integer
        Get
            Return RegionList(n)._ProcessID
        End Get
        Set(ByVal Value As Integer)
            RegionList(n)._ProcessID = Value
        End Set
    End Property
    Public Property AvatarCount(n As Integer) As Integer
        Get
            Return RegionList(n)._AvatarCount
        End Get
        Set(ByVal Value As Integer)
            RegionList(n)._AvatarCount = Value
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
    Public Property RegionName(n As Integer) As String
        Get
            Return RegionList(n)._RegionName
        End Get
        Set(ByVal Value As String)
            RegionList(n)._RegionName = Value
        End Set
    End Property
    Public Property UUID(n As Integer) As String
        Get
            Return RegionList(n)._UUID
        End Get
        Set(ByVal Value As String)
            RegionList(n)._UUID = Value
        End Set
    End Property
    Public Property SizeX(n As Integer) As Integer
        Get
            Return RegionList(n)._SizeX
        End Get
        Set(ByVal Value As Integer)
            RegionList(n)._SizeX = Value
        End Set
    End Property
    Public Property SizeY(n As Integer) As Integer
        Get
            Return RegionList(n)._SizeY
        End Get
        Set(ByVal Value As Integer)
            RegionList(n)._SizeY = Value
        End Set
    End Property
    Public Property RegionPort(n As Integer) As Integer
        Get
            If RegionList(n)._RegionPort <= My.Settings.PrivatePort Then
                RegionList(n)._RegionPort = My.Settings.PrivatePort + 1 ' 8004, by default
            End If
            Return RegionList(n)._RegionPort
        End Get
        Set(ByVal Value As Integer)
            RegionList(n)._RegionPort = Value
        End Set
    End Property
    Public Property CoordX(n As Integer) As Integer
        Get
            Return RegionList(n)._CoordX
        End Get
        Set(ByVal Value As Integer)
            RegionList(n)._CoordX = Value
        End Set
    End Property
    Public Property CoordY(n As Integer) As Integer
        Get
            Return RegionList(n)._CoordY
        End Get
        Set(ByVal Value As Integer)
            RegionList(n)._CoordY = Value
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

    End Sub

    Public Function RegionNumbers() As List(Of Integer)
        Dim L As New List(Of Integer)
        Dim ctr = 0
        For Each n As Region_data In RegionList
            L.Add(ctr)
            ctr = ctr + 1
        Next
        Debug.Print("List Len = " + L.Count.ToString)
        Return L
    End Function

    Public Sub DebugRegions(o As Region_data)

        Debug.Print("Region:" + o._RegionName +
            " WarmingUp=" + o._WarmingUp.ToString +
           " ShuttingDown=" + o._ShuttingDown.ToString +
            " Ready=" + o._Ready.ToString +
           " RegionEnabled=" + o._RegionEnabled.ToString)

    End Sub

    Public Function FindRegionByName(Name As String) As Integer

        Dim i As Integer = 0
        For Each obj As Region_data In RegionList
            If Name = obj._RegionName Then
                CurRegionNum = i
                Debug.Print("Current Region #: " + CurRegionNum.ToString + " is " + obj._RegionName)
                Return i
            End If
            i = i + 1
        Next
        Return Nothing

    End Function

    Public Function FindRegionByProcessID(PID As Integer) As Integer

        Dim i As Integer = 0
        For Each obj As Region_data In RegionList
            If PID = obj._ProcessID Then
                CurRegionNum = i
                Debug.Print("Current Region #: " + CurRegionNum.ToString + " is " + obj._RegionName)
                Return i
            End If
            i = i + 1
        Next
        Return Nothing

    End Function

    Public Function CreateRegion(name As String) As Integer

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
        Return CurRegionNum

    End Function

    Public Sub GetAllRegions()

        RegionList.Clear()
        Dim folders() As String
        Dim regionfolders() As String
        Dim n As Integer = 0
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
                            RegionEnabled(n) = Form1.GetIni(ini, fName, "Enabled", ";")
                        Catch ex As Exception
                            RegionEnabled(n) = True
                        End Try

                        RegionPath(n) = ini ' save the path
                        FolderPath(n) = Path.GetDirectoryName(ini)

                        Dim theEnd as integer  = FolderPath(n).LastIndexOf("\")
                        IniPath(n) = FolderPath(n).Substring(0, theEnd + 1)


                        ' need folder name in case there are more than 1 ini
                        Dim theStart = FolderPath(n).IndexOf("Regions\") + 8
                        theEnd = FolderPath(n).LastIndexOf("\")
                        Folder(n) = FolderPath(n).Substring(theStart, theEnd - theStart)

                        UUID(n) = Form1.GetIni(ini, fName, "RegionUUID", ";")
                        SizeX(n) = Convert.ToInt16(Form1.GetIni(ini, fName, "SizeX", ";"))
                        SizeY(n) = Convert.ToInt16(Form1.GetIni(ini, fName, "SizeY", ";"))
                        RegionPort(n) = Convert.ToInt16(Form1.GetIni(ini, fName, "InternalPort", ";"))
                        ' Location is int,int format.
                        Dim C = Form1.GetIni(ini, fName, "Location", ";")
                        Dim parts As String() = C.Split(New Char() {","c}) ' split at the comma
                        CoordX(n) = parts(0)
                        CoordY(n) = parts(1)
                        n = n + 1
                    Next

                Catch ex As Exception
                    MsgBox("Error: Cannot parse a Region file:" + fName + ":" + ex.Message)
                    Form1.Log("Err:Parse file " + fName + ":" + ex.Message)
                End Try
            Next
        Next

    End Sub

    Public Sub WriteRegionObject(name As String)

        Dim n As Integer = FindRegionByName(name)
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
        Form1.SetIni(name, "RegionUUID", UUID(n))
        Form1.SetIni(name, "Location", CoordX(n) & "," & CoordY(n))
        Form1.SetIni(name, "InternalPort", RegionPort(n))
        Form1.SetIni(name, "ExternalHostName", My.Settings.PublicIP)
        Form1.SetIni(name, "SizeX", SizeX(n))
        Form1.SetIni(name, "SizeY", SizeY(n))
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
