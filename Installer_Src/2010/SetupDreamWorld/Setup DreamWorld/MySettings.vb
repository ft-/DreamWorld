Imports System.IO
Imports IniParser

Public Class MySettings

    Dim parser As FileIniDataParser
    Dim Myparser As FileIniDataParser
    Dim INI As String = ""
    Dim Data As IniParser.Model.IniData
    Dim MyData As IniParser.Model.IniData
    Dim myINI As String = ""

#Region "New"
    Public Sub New()

        parser = New FileIniDataParser()
        parser.Parser.Configuration.SkipInvalidLines = True
        parser.Parser.Configuration.AssigmentSpacer = ""

    End Sub

    Public Sub Init()

        myINI = Form1.MyFolder + "\OutworldzFiles\Settings.ini"
        If File.Exists(myINI) Then
            LoadMyIni()
        Else
            myINI = Form1.MyFolder + "\OutworldzFiles\Settings.ini"
            Dim contents = "[Data]" + vbCrLf
            Using outputFile As New StreamWriter(myINI, True)
                outputFile.WriteLine(contents)
            End Using

            LoadMyIni()

            AdminFirst() = My.Settings.AdminFirst
            AdminLast() = My.Settings.AdminLast
            AdminEmail() = My.Settings.AdminEmail
            AutoBackup() = My.Settings.AutoBackup
            AutobackupInterval() = My.Settings.AutobackupInterval
            AutoLoad() = My.Settings.AutoLoad
            Autostart() = My.Settings.Autostart
            AccountConfirmationRequired() = My.Settings.AccountConfirmationRequired

            BackupFolder() = My.Settings.BackupFolder
            BootStart() = My.Settings.BootStart

            ChatTime() = My.Settings.ChatTime
            Clouds() = False    ' does not exist in old code, so set it off
            Density() = 0.5
            ConsoleUser() = My.Settings.ConsoleUser
            ConsolePass() = My.Settings.ConsolePass
            CoordX() = My.Settings.CoordX
            CoordY() = My.Settings.CoordY
            ConsoleShow = My.Settings.ConsoleShow

            DiagFailed() = My.Settings.DiagFailed

            DiagnosticPort() = My.Settings.DiagnosticPort
            DNSName() = My.Settings.DnsName

            EnableHypergrid() = My.Settings.EnableHypergrid

            GLProdSecret() = My.Settings.GLProdSecret
            GLProdKey() = My.Settings.GLProdKey
            GLBOwnerName() = My.Settings.GLBOwnerName
            GLBOwnerEmail() = My.Settings.GLBOwnerEmail
            GLSandSecret() = My.Settings.GLSandSecret
            GLSandKey() = My.Settings.GLSandKey
            GloebitsMode() = My.Settings.GloebitsMode
            GloebitsEnable() = My.Settings.GloebitsEnable

            HttpPort() = My.Settings.HttpPort

            ImageNum() = My.Settings.ImageNum

            KeepForDays() = My.Settings.KeepForDays

            LoopBackDiag() = My.Settings.LoopBackDiag

            MapType() = My.Settings.MapType

            MySqlPort() = My.Settings.MySqlPort
            MyX() = My.Settings.MyX
            MyY = My.Settings.MyY

            Password() = My.Settings.Password
            Physics() = My.Settings.Physics
            PrivatePort() = My.Settings.PrivatePort
            PublicIP() = My.Settings.PublicIP

            Region_owner_is_god() = My.Settings.region_owner_is_god
            Region_manager_is_god() = My.Settings.region_manager_is_god
            RanAllDiags() = My.Settings.RanAllDiags
            RegionDBName() = My.Settings.RegionDBName
            RegionDbPassword() = My.Settings.RegionDbPassword
            RegionDBUsername() = My.Settings.RegionDBUsername
            RobustServer() = My.Settings.RobustServer
            RobustMySqlPassword() = My.Settings.RobustMySqlPassword
            RobustMySqlUsername() = My.Settings.RobustMySqlUsername
            RobustMySqlName() = My.Settings.RobustMySqlName
            RunOnce() = My.Settings.RunOnce

            SC_Enable() = False
            SC_PortBase() = 8080
            SC_PortBase1() = 8081
            SC_Password() = "A password"
            SC_AdminPassword() = ""
            SC_Show() = True

            SizeX() = My.Settings.SizeX
            SizeY() = My.Settings.SizeY
            SimName() = My.Settings.SimName
            SkipUpdateCheck() = My.Settings.SkipUpdateCheck

            'email
            SmtpHost() = "smtp.gmail.com"
            SmtpPort() = "587"
            SmtpUsername() = My.Settings.SmtpUsername
            SmtpPassword() = My.Settings.SmtpPassword

            SplashPage() = My.Settings.SplashPage

            TimerInterval() = My.Settings.TimerInterval

            UPnPEnabled() = My.Settings.UPnPEnabled
            UPnpDiag() = My.Settings.UPnpDiag

            ViewerInstalled() = My.Settings.ViewerInstalled
            VivoxEnabled = My.Settings.VivoxEnabled
            Vivox_UserName() = My.Settings.Vivox_username
            Vivox_password() = My.Settings.Vivox_password

            WelcomeRegion() = My.Settings.WelcomeRegion
            WifiEnabled() = My.Settings.WifiEnabled

        End If

        ' new bool vars have to exist
        Try
            Dim x = Clouds()
        Catch ex As Exception
            Clouds() = False
            Density() = 0.5
            SaveMyINI()
        End Try

        SaveMyINI()


    End Sub
#End Region

#Region "Functions And Subs"

    Public Sub SetOtherIni(section As String, key As String, value As String)

        ' sets values into any INI file
        Try
            Form1.Log("Info:Writing section [" + section + "] " + key + "=" + value)
            Data(section)(key) = value ' replace it 
        Catch ex As Exception
            Form1.Log(ex.Message)
        End Try

    End Sub

    Public Sub SetMyIni(section As String, key As String, value As String)

        ' sets values into any INI file
        Try
            Form1.Log("Info:Writing section [" + section + "] " + key + "=" + value)
            MyData(section)(key) = value ' replace it 
        Catch ex As Exception
            Form1.Log(ex.Message)
        End Try

    End Sub

    Public Sub LoadMyIni()

        Myparser = New FileIniDataParser()

        Myparser.Parser.Configuration.SkipInvalidLines = True
        parser.Parser.Configuration.AssigmentSpacer = ""
        Myparser.Parser.Configuration.CommentString = ";" ' Opensim uses semicolons
        Try
            MyData = Myparser.ReadFile(Form1.MyFolder + "\OutworldzFiles\Settings.ini", System.Text.Encoding.ASCII)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadOtherIni(arg As String, comment As String)

        parser = New FileIniDataParser()

        parser.Parser.Configuration.SkipInvalidLines = True
        parser.Parser.Configuration.AssigmentSpacer = ""
        parser.Parser.Configuration.CommentString = comment ' Opensim uses semicolons
        Try
            Data = parser.ReadFile(arg, System.Text.Encoding.ASCII)
        Catch ex As Exception
        End Try
        INI = arg
    End Sub

#End Region

#Region "GetSet"
    Public Function GetIni(section As String, key As String, Optional D As String = "") As String

        Dim R = Stripqq(Data(section)(key))
        If R = Nothing Then R = D
        Return R

    End Function

    Public Function GetMyIni(section As String, key As String, Optional D As String = "") As String

        Dim R = Stripqq(MyData(section)(key))
        If R = Nothing Then R = D
        Return R

    End Function

    Public Sub SaveOtherINI()

        Try
            parser.WriteFile(INI, Data, System.Text.Encoding.ASCII)
        Catch ex As Exception
            Form1.Log("Error:" + ex.Message)
        End Try

    End Sub


    Public Sub SaveMyINI()

        Try
            Myparser.WriteFile(myINI, MyData, System.Text.Encoding.ASCII)
        Catch ex As Exception
            Form1.Log("Error:" + ex.Message)
        End Try

    End Sub

    Public Function Random() As String
    
	    Dim value As Integer = CInt(Int((600000000 * Rnd()) + 1))
        Random = System.Convert.ToString(value)

    End Function
	
    Private Function Stripqq(input As String) As String

        Return Replace(input, """", "")

    End Function

    Public Function GetMySetting(key As String, Optional D As String = "") As String
        Try
            Dim value = GetMyIni("Data", key, D)
            Return value
        Catch
            Return ""
        End Try

    End Function
    Public Sub SetMySetting(key As String, value As String)

        SetMyIni("Data", key, value)

    End Sub
#End Region

#Region "Properties"


    Public Property SmtpHost() As String
        Get
            Return CType(GetMySetting("SmtpHost"), String)
        End Get
        Set
            SetMySetting("SmtpHost", Value)
        End Set
    End Property

    Public Property SmtpPort() As String
        Get
            Return CType(GetMySetting("SmtpPort"), String)
        End Get
        Set
            SetMySetting("SmtpPort", Value)
        End Set
    End Property

    Public Property Clouds() As Boolean
        Get
            Return CType(GetMySetting("Clouds"), Boolean)
        End Get
        Set
            SetMySetting("Clouds", Value)
        End Set
    End Property

    Public Property Density() As Single
        Get
            Return CType(GetMySetting("Density"), Single)
        End Get
        Set
            SetMySetting("Density", Value)
        End Set
    End Property

    Public Property PrivateURL() As String
        Get
            Return CType(GetMySetting("PrivateURL"), String)
        End Get
        Set
            SetMySetting("PrivateURL", Value)
        End Set
    End Property

    Public Property ConsoleShow() As Boolean
        Get
            Return CType(GetMySetting("ConsoleShow"), Boolean)
        End Get
        Set
            SetMySetting("ConsoleShow", Value)
        End Set
    End Property
    Public Property AutoBackup() As Boolean
        Get
            Return CType(GetMySetting("AutoBackup"), Boolean)
        End Get
        Set
            SetMySetting("AutoBackup", Value)
        End Set
    End Property
    Public Property PublicIP() As String
        Get
            Return CType(GetMySetting("PublicIP"), String)
        End Get
        Set
            SetMySetting("PublicIP", Value)
        End Set
    End Property
    Public Property CoordX() As String
        Get
            Return CType(GetMySetting("CoordX"), String)
        End Get
        Set
            SetMySetting("CoordX", Value)
        End Set
    End Property
    Public Property CoordY() As String
        Get
            Return CType(GetMySetting("CoordY"), String)
        End Get
        Set
            SetMySetting("CoordY", Value)
        End Set
    End Property
    Public Property PrivatePort() As String
        Get
            Return CType(GetMySetting("PrivatePort"), String)
        End Get
        Set
            SetMySetting("PrivatePort", Value)
        End Set
    End Property
    Public Property SizeX() As String
        Get
            Return CType(GetMySetting("SizeX"), String)
        End Get
        Set
            SetMySetting("SizeX", Value)
        End Set
    End Property
    Public Property SizeY() As String
        Get
            Return CType(GetMySetting("SizeY"), String)
        End Get
        Set
            SetMySetting("SizeY", Value)
        End Set
    End Property
    Public Property AutobackupInterval() As String
        Get
            Return CType(GetMySetting("AutobackupInterval"), String)
        End Get
        Set
            SetMySetting("AutobackupInterval", Value)
        End Set
    End Property
    Public Property KeepForDays() As Integer
        Get
            Return CType(GetMySetting("KeepForDays"), Integer)
        End Get
        Set
            SetMySetting("KeepForDays", Value)
        End Set
    End Property
    Public Property Password() As String
        Get
            Return CType(GetMySetting("Password"), String)
        End Get
        Set
            SetMySetting("Password", Value)
        End Set
    End Property
    Public Property AdminFirst() As String
        Get
            Return CType(GetMySetting("AdminFirst"), String)
        End Get
        Set
            SetMySetting("AdminFirst", Value)
        End Set
    End Property
    Public Property AdminLast() As String
        Get
            Return CType(GetMySetting("AdminLast"), String)
        End Get
        Set
            SetMySetting("AdminLast", Value)
        End Set
    End Property

    Public Property AdminEmail() As String
        Get
            Return CType(GetMySetting("AdminEmail"), String)
        End Get
        Set
            SetMySetting("AdminEmail", Value)
        End Set
    End Property
    Public Property ConsoleUser() As String
        Get
            Return CType(GetMySetting("ConsoleUser"), String)
        End Get
        Set
            SetMySetting("ConsoleUser", Value)
        End Set
    End Property

    Public Property ConsolePass() As String
        Get
            Return CType(GetMySetting("ConsolePass"), String)
        End Get
        Set
            SetMySetting("ConsolePass", Value)
        End Set
    End Property
    Public Property ChatTime() As Integer
        Get
            Return CType(GetMySetting("ChatTime"), Integer)
        End Get
        Set
            SetMySetting("ChatTime", Value)
        End Set
    End Property
    Public Property ViewerInstalled() As Boolean
        Get
            Return CType(GetMySetting("ViewerInstalled"), Boolean)
        End Get
        Set
            SetMySetting("ViewerInstalled", Value)
        End Set
    End Property
    Public Property ImageNum() As Integer
        Get
            Return CType(GetMySetting("ImageNum"), Integer)
        End Get
        Set
            SetMySetting("ImageNum", Value)
        End Set
    End Property
    Public Property Region_owner_is_god() As Boolean
        Get
            Return CType(GetMySetting("Region_owner_is_god"), Boolean)
        End Get
        Set
            SetMySetting("Region_owner_is_god", Value)
        End Set
    End Property
    Public Property Region_manager_is_god() As Boolean
        Get
            Return CType(GetMySetting("Region_manager_is_god"), Boolean)
        End Get
        Set
            SetMySetting("Region_manager_is_god", Value)
        End Set
    End Property
    Public Property TimerInterval() As Integer
        Get
            Return CType(GetMySetting("TimerInterval"), Integer)
        End Get
        Set
            SetMySetting("TimerInterval", Value)
        End Set
    End Property
    Public Property AccountConfirmationRequired() As Boolean
        Get
            Return CType(GetMySetting("AccountConfirmationRequired"), Boolean)
        End Get
        Set
            SetMySetting("AccountConfirmationRequired", Value)
        End Set
    End Property

    Public Property SmtpUsername() As String
        Get
            Return CType(GetMySetting("SmtpUsername"), String)
        End Get
        Set
            SetMySetting("SmtpUsername", Value)
        End Set
    End Property
    Public Property SmtpPassword() As String
        Get
            Return CType(GetMySetting("SmtpPassword"), String)
        End Get
        Set
            SetMySetting("SmtpPassword", Value)
        End Set
    End Property
    Public Property RanAllDiags() As Boolean
        Get
            Return CType(GetMySetting("RanAllDiags"), Boolean)
        End Get
        Set
            SetMySetting("RanAllDiags", Value)
        End Set
    End Property
    Public Property SkipUpdateCheck() As Boolean
        Get
            Return CType(GetMySetting("SkipUpdateCheck"), Boolean)
        End Get
        Set
            SetMySetting("SkipUpdateCheck", Value)
        End Set
    End Property
    Public Property DiagFailed() As Boolean
        Get
            Return CType(GetMySetting("DiagFailed"), Boolean)
        End Get
        Set
            SetMySetting("DiagFailed", Value)
        End Set
    End Property
    Public Property DNSName() As String
        Get
            Return CType(GetMySetting("DnsName"), String)
        End Get
        Set
            SetMySetting("DnsName", Value)
        End Set
    End Property

    Public Property HttpPort() As String
        Get
            Return CType(GetMySetting("HttpPort"), String)
        End Get
        Set
            SetMySetting("HttpPort", Value)
        End Set
    End Property
    Public Property MachineID() As String
        Get
            Return CType(GetMySetting("MachineID"), String)
        End Get
        Set
            SetMySetting("MachineID", Value)
        End Set
    End Property
    Public Property LoopBackDiag() As Boolean
        Get
            Return CType(GetMySetting("LoopBackDiag"), Boolean)
        End Get
        Set
            SetMySetting("LoopBackDiag", Value)
        End Set
    End Property
    Public Property UPnpDiag() As Boolean
        Get
            Return CType(GetMySetting("UPnpDiag"), Boolean)
        End Get
        Set
            SetMySetting("UPnpDiag", Value)
        End Set
    End Property


    Public Property SplashPage() As String
        Get
            Return CType(GetMySetting("SplashPage"), String)
        End Get
        Set
            SetMySetting("SplashPage", Value)
        End Set
    End Property
    Public Property Physics() As Integer
        Get
            Return CType(GetMySetting("Physics"), Integer)
        End Get
        Set
            SetMySetting("Physics", Value)
        End Set
    End Property
    Public Property MyX() As Integer
        Get
            Return CType(GetMySetting("MyX"), Integer)
        End Get
        Set
            SetMySetting("MyX", Value)
        End Set
    End Property
    Public Property MyY() As Integer
        Get
            Return CType(GetMySetting("MyY"), Integer)
        End Get
        Set
            SetMySetting("MyY", Value)
        End Set
    End Property
    Public Property RobustServer() As String
        Get
            Return CType(GetMySetting("RobustServer"), String)
        End Get
        Set
            SetMySetting("RobustServer", Value)
        End Set
    End Property
    Public Property VivoxEnabled() As Boolean
        Get
            Return CType(GetMySetting("VivoxEnabled"), Boolean)
        End Get
        Set
            SetMySetting("VivoxEnabled", Value)
        End Set
    End Property
    Public Property Vivox_UserName() As String
        Get
            Return CType(GetMySetting("Vivox_username"), String)
        End Get
        Set
            SetMySetting("Vivox_username", Value)
        End Set
    End Property
    Public Property Vivox_password() As String
        Get
            Return CType(GetMySetting("Vivox_password"), String)
        End Get
        Set
            SetMySetting("Vivox_password", Value)
        End Set
    End Property
    Public Property MapType() As String
        Get
            Return CType(GetMySetting("MapType"), String)
        End Get
        Set
            SetMySetting("MapType", Value)
        End Set
    End Property
    Public Property BackupFolder() As String
        Get
            Return CType(GetMySetting("BackupFolder"), String)
        End Get
        Set
            SetMySetting("BackupFolder", Value)
        End Set
    End Property
    Public Property WelcomeRegion() As String
        Get
            Return CType(GetMySetting("WelcomeRegion"), String)
        End Get
        Set
            SetMySetting("WelcomeRegion", Value)
        End Set
    End Property
    Public Property GloebitsEnable() As Boolean
        Get
            Return CType(GetMySetting("GloebitsEnable"), Boolean)
        End Get
        Set
            SetMySetting("GloebitsEnable", Value)
        End Set
    End Property
    Public Property GloebitsMode() As Boolean
        Get
            Return CType(GetMySetting("GloebitsMode"), Boolean)
        End Get
        Set
            SetMySetting("GloebitsMode", Value)
        End Set
    End Property
    Public Property GLSandKey() As String
        Get
            Return CType(GetMySetting("GLSandKey"), String)
        End Get
        Set
            SetMySetting("GLSandKey", Value)
        End Set
    End Property

    Public Property GLSandSecret() As String
        Get
            Return CType(GetMySetting("GLSandSecret"), String)
        End Get
        Set
            SetMySetting("GLSandSecret", Value)
        End Set
    End Property
    Public Property GLBOwnerEmail() As String
        Get
            Return CType(GetMySetting("GLBOwnerEmail"), String)
        End Get
        Set
            SetMySetting("GLBOwnerEmail", Value)
        End Set
    End Property
    Public Property GLBOwnerName() As String
        Get
            Return CType(GetMySetting("GLBOwnerName"), String)
        End Get
        Set
            SetMySetting("GLBOwnerName", Value)
        End Set
    End Property
    Public Property GLProdKey() As String
        Get
            Return CType(GetMySetting("GLProdKey"), String)
        End Get
        Set
            SetMySetting("GLProdKey", Value)
        End Set
    End Property
    Public Property MySqlPort() As String
        Get
            Return CType(GetMySetting("MySqlPort"), String)
        End Get
        Set
            SetMySetting("MySqlPort", Value)
        End Set
    End Property
    Public Property GLProdSecret() As String
        Get
            Return CType(GetMySetting("GLProdSecret"), String)
        End Get
        Set
            SetMySetting("GLProdSecret", Value)
        End Set
    End Property
    Public Property RegionDbPassword() As String
        Get
            Return CType(GetMySetting("RegionDbPassword"), String)
        End Get
        Set
            SetMySetting("RegionDbPassword", Value)
        End Set
    End Property
    Public Property RegionDBUsername() As String
        Get
            Return CType(GetMySetting("RegionDBUsername"), String)
        End Get
        Set
            SetMySetting("RegionDBUsername", Value)
        End Set
    End Property
    Public Property RegionDBName() As String
        Get
            Return CType(GetMySetting("RegionDBName"), String)
        End Get
        Set
            SetMySetting("RegionDBName", Value)
        End Set
    End Property
    Public Property WifiEnabled() As Boolean
        Get
            Return CType(GetMySetting("WifiEnabled"), Boolean)
        End Get
        Set
            SetMySetting("WifiEnabled", Value)
        End Set
    End Property
    Public Property DiagnosticPort() As String
        Get
            Return CType(GetMySetting("DiagnosticPort"), String)
        End Get
        Set
            SetMySetting("DiagnosticPort", Value)
        End Set
    End Property
    Public Property RobustMySqlName() As String
        Get
            Return CType(GetMySetting("RobustMySqlName"), String)
        End Get
        Set
            SetMySetting("RobustMySqlName", Value)
        End Set
    End Property
    Public Property RobustMySqlUsername() As String
        Get
            Return CType(GetMySetting("RobustMySqlUsername"), String)
        End Get
        Set
            SetMySetting("RobustMySqlUsername", Value)
        End Set
    End Property
    Public Property RobustMySqlPassword() As String
        Get
            Return CType(GetMySetting("RobustMySqlPassword"), String)
        End Get
        Set
            SetMySetting("RobustMySqlPassword", Value)
        End Set
    End Property
    Public Property SimName() As String
        Get
            Return CType(GetMySetting("SimName"), String)
        End Get
        Set
            SetMySetting("SimName", Value)
        End Set
    End Property
    Public Property UPnPEnabled() As Boolean
        Get
            Return CType(GetMySetting("UPnPEnabled"), Boolean)
        End Get
        Set
            SetMySetting("UPnPEnabled", Value)
        End Set
    End Property
    Public Property Autostart() As Boolean
        Get
            Return CType(GetMySetting("Autostart"), Boolean)
        End Get
        Set
            SetMySetting("Autostart", Value)
        End Set
    End Property
    Public Property BootStart() As Boolean
        Get
            Return CType(GetMySetting("BootStart"), Boolean)
        End Get
        Set
            SetMySetting("BootStart", Value)
        End Set
    End Property
    Public Property EnableHypergrid() As Boolean
        Get
            Return CType(GetMySetting("EnableHypergrid"), Boolean)
        End Get
        Set
            SetMySetting("EnableHypergrid", Value)
        End Set
    End Property
    Public Property AutoLoad() As Boolean
        Get
            Return CType(GetMySetting("AutoLoad"), Boolean)
        End Get
        Set
            SetMySetting("AutoLoad", Value)
        End Set
    End Property
    Public Property RunOnce() As Boolean
        Get
            Return CType(GetMySetting("RunOnce"), Boolean)
        End Get
        Set
            SetMySetting("RunOnce", Value)
        End Set
    End Property
    Public Property SC_Enable() As Boolean
        Get
            Return CType(GetMySetting("SC_Enable"), Boolean)
        End Get
        Set
            SetMySetting("SC_Enable", Value)
        End Set
    End Property
    Public Property SC_PortBase() As Integer
        Get
            Return CType(GetMySetting("PortBase"), Integer)
        End Get
        Set
            SetMySetting("PortBase", Value)
        End Set
    End Property
    Public Property SC_PortBase1() As Integer
        Get
            Try ' required as it has been added
                Return CType(GetMySetting("PortBase1"), Integer)
            Catch
                Return 8081
            End Try

        End Get
        Set
            SetMySetting("PortBase1", Value)
        End Set
    End Property
    Public Property SC_Password() As String
        Get
            Return CType(GetMySetting("SC_Password"), String)
        End Get
        Set
            SetMySetting("SC_Password", Value)
        End Set
    End Property
    Public Property SC_AdminPassword() As String
        Get
            Return CType(GetMySetting("SC_AdminPassword"), String)
        End Get
        Set
            SetMySetting("SC_AdminPassword", Value)
        End Set
    End Property
    Public Property SC_Show() As Boolean
        Get
            Return CType(GetMySetting("SC_Show"), Boolean)
        End Get
        Set
            SetMySetting("SC_Show", Value)
        End Set
    End Property

    'Save a random machine ID - we don't want any data to be sent that's personal or identifiable,  but it needs to be unique
    Public Property Machine() As String
        Get
            Return CType(GetMySetting("MachineID"), String)
        End Get
        Set(ByVal Value As String)
            If (GetMySetting("MachineID") = "") Then
                SetMySetting("MachineID", Value)
            End If
        End Set


    End Property
End Class

#End Region