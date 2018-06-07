Imports System.IO
Imports Newtonsoft.Json

Public Class RegionMaker

#Region "Declarations"

    Public RegionList As New ArrayList()
    Public Grouplist As New Dictionary(Of String, Integer)

    Private initted As Boolean = False
    Private Shared FInstance As RegionMaker = Nothing
    Dim Backup As New ArrayList()

    Public Sub DebugGroup()
        For Each pair In Grouplist
            Debug.Print("Group name: {0}, httpport: {1}", pair.Key, pair.Value)
        Next
    End Sub
    Public Property GroupPort(index As Integer) As Integer
        Get
            Dim RegionName = GroupName(index)
            If Grouplist.ContainsKey(RegionName) Then
                Return Grouplist.Item(RegionName)
            End If
            Return 0
        End Get
        Set(ByVal Value As Integer)
            Dim RegionName = GroupName(index)
            If Grouplist.ContainsKey(RegionName) Then
                Grouplist.Remove(RegionName)
                Grouplist.Add(RegionName, Value)
            Else
                Grouplist.Add(RegionName, Value)
            End If

            'DebugGroup
        End Set
    End Property

    Public Shared ReadOnly Property Instance() As RegionMaker
        Get
            If (FInstance Is Nothing) Then
                FInstance = New RegionMaker()
            End If
            Return FInstance
        End Get
    End Property

    Private Sub New()
        GetAllRegions()
        If RegionCount() = 0 Then
            CreateRegion("Welcome")
            Form1.MySetting.WelcomeRegion = "Welcome"
            WriteRegionObject("Welcome")
            GetAllRegions()
            Form1.MySetting.WelcomeRegion = "Welcome"
            Form1.MySetting.SaveMyINI()
        End If
        RegionDump()

        Debug.Print("Loaded " + RegionCount.ToString + " Regions")

    End Sub

#End Region

#Region "Properties"

    Public Property GroupName(n As Integer) As String
        Get
            Return RegionList(CheckN(n))._Group
        End Get
        Set(ByVal Value As String)
            RegionList(CheckN(n))._Group = Value
        End Set
    End Property
    Public Property NonPhysicalPrimMax(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._NonphysicalPrimMax
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._NonphysicalPrimMax = Value
        End Set
    End Property
    Public Property PhysicalPrimMax(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._PhysicalPrimMax
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._PhysicalPrimMax = Value
        End Set
    End Property
    Public Property ClampPrimSize(n As Integer) As Boolean
        Get
            Return RegionList(CheckN(n))._ClampPrimSize
        End Get
        Set(ByVal Value As Boolean)
            RegionList(CheckN(n))._ClampPrimSize = Value
        End Set
    End Property
    Public Property MaxPrims(n As Integer) As Long
        Get
            Return RegionList(CheckN(n))._MaxPrims
        End Get
        Set(ByVal Value As Long)
            RegionList(CheckN(n))._MaxPrims = Value
        End Set
    End Property
    Public Property MaxAgents(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._MaxAgents
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._MaxAgents = Value
        End Set
    End Property

    Public Property Timer(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._Timer
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._Timer = Value
        End Set
    End Property
    Public Property ShuttingDown(n As Integer) As Boolean
        Get
            Return RegionList(CheckN(n))._ShuttingDown
        End Get
        Set(ByVal Value As Boolean)
            Debug.Print(RegionList(CheckN(n))._RegionName + " ShuttingDown set to " + Value.ToString)
            RegionList(CheckN(n))._ShuttingDown = Value
        End Set
    End Property
    Public Property Booted(n As Integer) As Boolean
        Get
            'Debug.Print(RegionList(CheckN(n))._RegionName + "<" + RegionList(CheckN(n))._Ready.ToString)
            Return RegionList(CheckN(n))._Ready
        End Get
        Set(ByVal Value As Boolean)
            Debug.Print(RegionList(CheckN(n))._RegionName + " Ready set to " + Value.ToString)
            RegionList(CheckN(n))._Ready = Value
        End Set
    End Property
    Public Property WarmingUp(n As Integer) As Boolean
        Get
            Return RegionList(CheckN(n))._WarmingUp
        End Get
        Set(ByVal Value As Boolean)
            Debug.Print(RegionList(CheckN(n))._RegionName + " WarmingUp set to " + Value.ToString)
            RegionList(CheckN(n))._WarmingUp = Value
        End Set
    End Property
    Public ReadOnly Property RegionCount() As Integer
        Get
            Return RegionList.Count
        End Get
    End Property
    ''' ''''''''''''''''''' PATHS ''''''''''''''''''''
    Public Property IniPath(n As Integer) As String
        Get
            Return RegionList(CheckN(n))._IniPath
        End Get
        Set(ByVal Value As String)

            RegionList(CheckN(n))._IniPath = Value
        End Set
    End Property
    Public Property RegionPath(n As Integer) As String
        Get
            Return RegionList(CheckN(n))._RegionPath
        End Get
        Set(ByVal Value As String)
            RegionList(CheckN(n))._RegionPath = Value
        End Set
    End Property
    Public Property FolderPath(n As Integer) As String
        Get
            Return RegionList(CheckN(n))._FolderPath
        End Get
        Set(ByVal Value As String)
            RegionList(CheckN(n))._FolderPath = Value
        End Set
    End Property

    Public Property RegionEnabled(n As Integer) As Boolean
        Get
            Return RegionList(CheckN(n))._RegionEnabled
        End Get
        Set(ByVal Value As Boolean)
            RegionList(CheckN(n))._RegionEnabled = Value
        End Set
    End Property
    Public Property ProcessID(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._ProcessID
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._ProcessID = Value
        End Set
    End Property
    Public Property AvatarCount(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._AvatarCount
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._AvatarCount = Value
        End Set
    End Property
    Public Property RegionName(n As Integer) As String
        Get
            Return RegionList(CheckN(n))._RegionName
        End Get
        Set(ByVal Value As String)
            RegionList(CheckN(n))._RegionName = Value
        End Set
    End Property
    Public Property UUID(n As Integer) As String
        Get
            Return RegionList(CheckN(n))._UUID
        End Get
        Set(ByVal Value As String)
            RegionList(CheckN(n))._UUID = Value
        End Set
    End Property
    Public Property SizeX(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._SizeX
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._SizeX = Value
        End Set
    End Property
    Public Property SizeY(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._SizeY
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._SizeY = Value
        End Set
    End Property
    Public Property RegionPort(n As Integer) As Integer
        Get
            If RegionList(CheckN(n))._RegionPort <= Form1.MySetting.PrivatePort Then
                RegionList(CheckN(n))._RegionPort = Form1.MySetting.PrivatePort + 1 ' 8004, by default
            End If
            Return RegionList(CheckN(n))._RegionPort
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._RegionPort = Value
        End Set
    End Property
    Public Property CoordX(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._CoordX
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._CoordX = Value
        End Set
    End Property
    Public Property CoordY(n As Integer) As Integer
        Get
            Return RegionList(CheckN(n))._CoordY
        End Get
        Set(ByVal Value As Integer)
            RegionList(CheckN(n))._CoordY = Value
        End Set
    End Property

#End Region

#Region "Classes"
    Public Class JSON_result
        Public alert As String
        Public login As String
        Public region_name As String
        Public region_id As String
    End Class

    ' hold a copy of the Main region data on a per-form basis
    Private Class Region_data
        Public _RegionPath As String = ""  ' The full path to the region ini file
        Public _FolderPath As String = ""   ' the path to the folde r that holds the region ini
        Public _Group As String = ""       ' the folder name that holds the region(s), can be different named
        Public _IniPath As String = ""      ' the folder that hold the Opensim.ini, above 'Region'
        Public _RegionName As String = ""
        Public _UUID As String = ""
        Public _CoordX As Integer = 0
        Public _CoordY As Integer = 0
        Public _RegionPort As Integer = 0
        Public _SizeX As Integer = 0
        Public _SizeY As Integer = 0
        Public _RegionEnabled As Boolean = False ' Will run or not
        Public _NonPhysicalPrimMax As Integer
        Public _PhysicalPrimMax As Integer
        Public _ClampPrimSize As Boolean
        Public _MaxPrims As Integer
        Public _MaxAgents As Integer

        ' RAM vars, not from files
        Public _AvatarCount As Integer = 0
        Public _ProcessID As Integer = 0
        Public _Ready As Boolean = False       ' is up
        Public _WarmingUp As Boolean = False    ' booting up
        Public _ShuttingDown As Boolean = False ' shutting down
        Public _Timer As Integer

    End Class

#End Region

#Region "Functions"

    Private Function CheckN(n As Integer) As Integer

        If n > RegionList.Count Or n < 0 Then
            Form1.Log("Error: Bad N in Region List " + n.ToString)
            Return 0
        End If
        Return n

    End Function

    Public Sub RegionDump()

        Dim ctr = 0
        For Each r As Region_data In RegionList
            DebugRegions(ctr)
            ctr = ctr + 1
        Next

    End Sub

    Public Sub DebugRegions(n As Integer)

        Debug.Print("RegionNumber:" + n.ToString +
            " Region:" + RegionList(CheckN(n))._RegionName +
            " WarmingUp=" + RegionList(CheckN(n))._WarmingUp.ToString +
           " ShuttingDown=" + RegionList(CheckN(n))._ShuttingDown.ToString +
            " Ready=" + RegionList(CheckN(n))._Ready.ToString +
           " RegionEnabled=" + RegionList(CheckN(n))._RegionEnabled.ToString)

    End Sub

    Public Function RegionListByGroupNum(GroupName As String) As List(Of Integer)
        Dim L As New List(Of Integer)
        Dim ctr = 0
        For Each n As Region_data In RegionList
            If n._Group = GroupName Then
                L.Add(ctr)
            End If
            ctr = ctr + 1
        Next
        Return L

    End Function

    Public Function RegionNumbers() As List(Of Integer)
        Dim L As New List(Of Integer)
        Dim ctr = 0
        For Each n As Region_data In RegionList
            L.Add(ctr)
            ctr = ctr + 1
        Next
        'Debug.Print("List Len = " + L.Count.ToString)
        Return L
    End Function

    Public Function FindRegionByName(Name As String) As Integer

        Dim i As Integer = 0
        For Each obj As Region_data In RegionList
            If Name = obj._RegionName Then
                ' Debug.Print("Current Region is " + obj._RegionName)
                Return i
            End If
            i = i + 1
        Next
        Return -1

    End Function

    Public Function FindRegionByProcessID(PID As Integer) As Integer

        Dim i As Integer = 0
        For Each obj As Region_data In RegionList
            If PID = obj._ProcessID Then
                Debug.Print("Current Region is " + obj._RegionName)
                Return i
            End If
            i = i + 1
        Next
        Return -1

    End Function
    Public Function FindBackupByName(Name As String) As Integer

        Dim i As Integer = 0
        For Each obj As Region_data In Backup
            If Name = obj._RegionName Then
                ' Debug.Print("Current Backup is " + obj._RegionName)
                Return i
            End If
            i = i + 1
        Next
        Return -1

    End Function
    Public Function CreateRegion(name As String) As Integer

        ' Debug.Print("Create Region " + name)
        Dim r As New Region_data
        r._RegionName = name
        r._RegionEnabled = True
        r._UUID = Guid.NewGuid().ToString
        r._SizeX = 256
        r._SizeY = 256
        r._CoordX = LargestX() + 4
        r._CoordY = LargestY() + 0
        r._RegionPort = LargestPort() + 1 '8004 + 1
        r._ProcessID = 0
        r._AvatarCount = 0
        r._Ready = False
        r._WarmingUp = False
        r._ShuttingDown = False
        r._Timer = 0
        r._NonPhysicalPrimMax = 1024
        r._PhysicalPrimMax = 64
        r._ClampPrimSize = False
        r._MaxPrims = 45000
        r._MaxAgents = 100

        'RegionList.Insert(RegionList.Count, r)
        RegionList.Add(r)
        RegionDump()
        Return RegionList.Count - 1

    End Function


    Public Sub GetAllRegions()

        Backup.Clear()

        For Each thing As Region_data In RegionList
            Backup.Add(thing)
        Next

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
                        fName = Path.GetFileName(ini)
                        fName = Mid(fName, 1, Len(fName) - 4)

                        'If (fName.Contains("Alpha")) Then
                        'Dim x = 1
                        'End If

                        ' make a slot to hold the region data 
                        CreateRegion(fName)

                        ' must be after Createregion or port blows up
                        Form1.MySetting.LoadOtherIni(ini, ";")

                        Try

                            RegionEnabled(CheckN(n)) = Form1.MySetting.GetIni(fName, "Enabled")
                        Catch ex As Exception
                            RegionEnabled(CheckN(n)) = True
                        End Try

                        RegionPath(CheckN(n)) = ini ' save the path
                        FolderPath(CheckN(n)) = Path.GetDirectoryName(ini)

                        Dim theEnd As Integer = FolderPath(CheckN(n)).LastIndexOf("\")
                        IniPath(CheckN(n)) = FolderPath(CheckN(n)).Substring(0, theEnd + 1)

                        ' need folder name in case there are more than 1 ini
                        Dim theStart = FolderPath(CheckN(n)).IndexOf("Regions\") + 8
                        theEnd = FolderPath(CheckN(n)).LastIndexOf("\")
                        GroupName(CheckN(n)) = FolderPath(CheckN(n)).Substring(theStart, theEnd - theStart)


                        UUID(CheckN(n)) = Form1.MySetting.GetIni(fName, "RegionUUID")
                        SizeX(CheckN(n)) = Convert.ToInt16(Form1.MySetting.GetIni(fName, "SizeX"))
                        SizeY(CheckN(n)) = Convert.ToInt16(Form1.MySetting.GetIni(fName, "SizeY"))
                        RegionPort(CheckN(n)) = Convert.ToInt16(Form1.MySetting.GetIni(fName, "InternalPort"))

                        ' extended props V2.1
                        NonPhysicalPrimMax(CheckN(n)) = Convert.ToInt16(Form1.MySetting.GetIni(fName, "NonPhysicalPrimMax", 1024))
                        PhysicalPrimMax(CheckN(n)) = Convert.ToInt16(Form1.MySetting.GetIni(fName, "PhysicalPrimMax", 64))
                        ClampPrimSize(CheckN(n)) = Convert.ToBoolean(Form1.MySetting.GetIni(fName, "ClampPrimSize", "False"))
                        MaxPrims(CheckN(n)) = Convert.ToInt32(Form1.MySetting.GetIni(fName, "MaxPrims", 45000))
                        MaxAgents(CheckN(n)) = Convert.ToInt16(Form1.MySetting.GetIni(fName, "MaxAgents", 100))

                        ' Location is int,int format.
                        Dim C = Form1.MySetting.GetIni(fName, "Location")

                        Dim parts As String() = C.Split(New Char() {","c}) ' split at the comma
                        CoordX(CheckN(n)) = parts(0)
                        CoordY(CheckN(n)) = parts(1)

                        If initted Then

                            ' restore backups of transient data 
                            Try ' 6 temp vars from backup
                                Dim o = FindBackupByName(fName)

                                If o >= 0 Then
                                    AvatarCount(CheckN(n)) = Backup(CheckN(o))._AvatarCount
                                    ProcessID(CheckN(n)) = Backup(CheckN(o))._ProcessID
                                    Booted(CheckN(n)) = Backup(CheckN(o))._Ready
                                    WarmingUp(CheckN(n)) = Backup(CheckN(o))._WarmingUp
                                    ShuttingDown(CheckN(n)) = Backup(CheckN(o))._ShuttingDown
                                    Timer(CheckN(n)) = Backup(CheckN(o))._Timer
                                End If

                            Catch
                            End Try

                        End If

                        n = n + 1

                    Next

                Catch ex As Exception
                    MsgBox("Error: Cannot understand the contents of region file " + fName + " : " + ex.Message, vbInformation, "Error")
                    Form1.Log("Err:Parse file " + fName + ":" + ex.Message)
                End Try
            Next
        Next
        initted = True
    End Sub

    Public Sub WriteRegionObject(name As String)

        Dim n As Integer = FindRegionByName(name)
        If n < 0 Then
            MsgBox("Cannot find region " + name, vbInformation, "Error")
            Return
        End If

        Dim pathtoWelcome As String = Form1.prefix + "bin\Regions\" + name + "\Region\"
        Dim fname = pathtoWelcome + name + ".ini"
        If Not Directory.Exists(pathtoWelcome) Then
            Try
                Directory.CreateDirectory(pathtoWelcome)
            Catch ex As Exception

            End Try

        End If

        File.Copy(Form1.prefix & "bin\Regions.proto", fname, True)

        Form1.MySetting.LoadOtherIni(fname, ";")
        Form1.MySetting.SetOtherIni(name, "RegionUUID", UUID(CheckN(n)))
        Form1.MySetting.SetOtherIni(name, "Location", CoordX(CheckN(n)) & "," & CoordY(CheckN(n)))
        Form1.MySetting.SetOtherIni(name, "InternalPort", RegionPort(CheckN(n)))
        Form1.MySetting.SetOtherIni(name, "ExternalHostName", Form1.MySetting.PublicIP)
        Form1.MySetting.SetOtherIni(name, "SizeX", SizeX(CheckN(n)))
        Form1.MySetting.SetOtherIni(name, "SizeY", SizeY(CheckN(n)))

        ' extended props V2.1

        Form1.MySetting.SetOtherIni(name, "NonPhysicalPrimMax", NonPhysicalPrimMax(CheckN(n)))
        Form1.MySetting.SetOtherIni(name, "PhysicalPrimMax", PhysicalPrimMax(CheckN(n)))
        Form1.MySetting.SetOtherIni(name, "ClampPrimSize", Convert.ToString(ClampPrimSize(CheckN(n))))
        Form1.MySetting.SetOtherIni(name, "MaxPrims", MaxPrims(CheckN(n)))
        Form1.MySetting.SetOtherIni(name, "MaxAgents", MaxAgents(CheckN(n)))

        Form1.MySetting.SaveMyINI()

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

        ' locate largest port
        Dim Max As Integer
        Dim counter As Integer = 0
        For Each obj As Region_data In RegionList
            Dim val = obj._RegionPort
            If val > Max Then Max = val
        Next
        If Max = 0 Then Max = Form1.MySetting.PrivatePort
        Return Max

    End Function


#End Region

#Region "POST"
    Public Function ParsePost(POST As String) As String
        ' set Region.Booted to true if the POST from the region indicates it is online
        ' requires a section in Opensim.ini where [RegionReady] has this:


        '[RegionReady]

        '; Enable this module to get notified once all items And scripts in the region have been completely loaded And compiled
        'Enabled = True

        '; Channel on which to signal region readiness through a message
        '; formatted as follows: "{server_startup|oar_file_load},{0|1},n,[oar error]"
        '; - the first field indicating whether this Is an initial server startup
        '; - the second field Is a number indicating whether the OAR file loaded ok (1 == ok, 0 == error)
        '; - the third field Is a number indicating how many scripts failed to compile
        '; - "oar error" if supplied, provides the error message from the OAR load
        'channel_notify = -800

        '; - disallow logins while scripts are loading
        '; Instability can occur on regions with 100+ scripts if users enter before they have finished loading
        'login_disable = True

        '; - send an alert as json to a service
        'alert_uri = ${Const|BaseURL}:${Const|DiagnosticsPort}/${Const|RegionFolderName}


        ' POST = "GET Region name HTTP...{server_startup|oar_file_load},{0|1},n,[oar error]"
        '{"alert":"region_ready","login":"enabled","region_name":"Region 2","region_id":"19f6adf0-5f35-4106-bcb8-dc3f2e846b89"}}
        'POST / Region%202 HTTP/1.1
        'Content-Type: Application/ json
        'Host:   tea.outworldz.net : 8001
        'Content-Length:  118
        'Connection: Keep-Alive
        '
        '{"alert":"region_ready","login":"enabled","region_name":"Region 2","region_id":"19f6adf0-5f35-4106-bcb8-dc3f2e846b89"}

        ' we want region name, UUID and server_startup
        ' could also be a probe from the outworldz to check if ports are open.

        ' WarmingUp(0) = True
        ' ShuttingDown(1) = True


        If (POST.Contains("alert")) Then
            Debug.Print(POST)
            ' This search returns the substring between two strings, so 
            ' the first index Is moved to the character just after the first string.
            POST = Uri.UnescapeDataString(POST)
            Dim first As Integer = POST.IndexOf("{")
            Dim last As Integer = POST.LastIndexOf("}")
            Dim rawJSON = POST.Substring(first, last - first + 1)
            Dim json As JSON_result
            Try
                json = JsonConvert.DeserializeObject(Of JSON_result)(rawJSON)
            Catch ex As Exception
                Debug.Print(ex.Message)
                Return ""
            End Try

            If json.login = "enabled" Then
                Debug.Print("Region " & json.region_name & " is ready for logins")

                Dim n = FindRegionByName(json.region_name)
                If n < 0 Then
                    Return ""
                End If

                If RegionEnabled(CheckN(n)) = False Then
                    RegionEnabled(CheckN(n)) = True
                    Form1.MySetting.LoadOtherIni(RegionPath(CheckN(n)), ";")
                    Form1.MySetting.SetOtherIni(json.region_name, "Enabled", "true")
                    Form1.MySetting.SaveMyINI()
                End If

                Booted(CheckN(n)) = True
                WarmingUp(CheckN(n)) = False
                ShuttingDown(CheckN(n)) = False
                UUID(CheckN(n)) = json.region_id

            ElseIf json.login = "shutdown" Then
                Debug.Print("Region " & json.region_name & " shut down")

                Dim n = FindRegionByName(json.region_name)
                If n < 0 Then
                    Return ""
                End If

                Booted(CheckN(n)) = False
                WarmingUp(CheckN(n)) = False
                ShuttingDown(CheckN(n)) = False

            End If
        ElseIf POST.Contains("UUID") Then
            Debug.Print("UUID:" + POST)
            Return POST
        Else
            Return "Test Completed"
        End If

        Return ""

    End Function

#End Region

End Class
