Imports System.IO
Imports IniParser

Public Class MySettings

    Dim parser As FileIniDataParser
    Dim INI As String
    Dim Data As IniParser.Model.IniData

#Region "New"
    Public Sub New()


    End Sub

    Public Sub Init()
        INI = Form1.MyFolder + "/OutworldzFiles/All_Settings.ini"

        If Not File.Exists(INI) Then

            Dim contents = "[Data]" + vbCrLf
            Using outputFile As New StreamWriter(INI, True)
                outputFile.WriteLine(contents)
            End Using

            LoadIni(INI, ";", False)

            AdminFirst() = "Wifi"
            AdminLast() = "Admin"
            AdminEmail() = "email@somewhere.com"
            AutoBackup() = True
            AutobackupInterval() = 720
            AutoLoad() = False
            Autostart() = False
            AccountConfirmationRequired() = True

            BackupFolder() = "AutoBackup"
            BootStart() = False

            ChatTime() = 1000
            ConsoleUser() = "Console"
            ConsolePass() = "secret"
            CoordX() = 2000
            CoordY() = 2000
            ConsoleShow = True

            DiagFailed() = False

            DiagnosticPort() = 8001
            DNSName() = """" + """"

            EnableHypergrid() = True

            GLProdSecret() = "OAuth Production secret"
            GLProdKey() = "OAuth Production key"
            GLBOwnerName() = "Your Avatar Name"
            GLBOwnerEmail() = "Your Email"
            GLSandSecret() = "OAuth sandbox secret"
            GLSandKey() = "OAuth Sandbox key"
            GloebitsMode() = False
            GloebitsEnable() = False

            HttpPort() = 8002

            ImageNum() = 0

            KeepForDays() = 30

            LoopBackDiag() = False

            ' Save a random machine ID - we don't want any data to be sent that's personal or identifiable,  but it needs to be unique
            Randomize()
            ' Save a random machine ID - we don't want any data to be sent that's personal or identifiable,  but it needs to be unique\
            MachineID() = Random()  ' a random machine ID
            MapType() = "Simple"

            MySqlPort() = 3306
            MyX() = 0
            MyY = 0

            Password() = "secret"
            Physics() = 3 ' Robust in thread
            PrivatePort() = 8003

            PublicIP() = "127.0.0.1"

            region_owner_is_god() = False
            region_manager_is_god() = False


            RanAllDiags() = False
            RegionDBName() = "Welcome" ' Welcome
            RegionDbPassword() = "opensimpassword"
            RegionDBUsername() = "opensimuser"
            RobustServer() = "127.0.0.1"
            RobustMySqlPassword() = "robustpassword"
            RobustMySqlUsername() = "robustuser"
            RobustMySqlName() = "robust"
            RunOnce() = False

            SizeX() = 256
            SizeY() = 256
            SimName() = "DreamGrid"
            SkipUpdateCheck() = False
            SmtpUsername() = "Gmail For notification"
            SmtpPassword() = "Gmail password"
            SplashPage() = """" + """"

            TimerInterval() = 60

            UPnPEnabled() = True
            UPnpDiag() = False

            ViewerInstalled() = False
            VivoxEnabled = False
            Vivox_UserName() = "User Name"
            Vivox_password() = "Password"

            WebStats() = True
            WelcomeRegion() = "Welcome"
            WifiEnabled() = True

            Form1.MySetting.SaveINI()

            LoadIni(INI, ";", False)

        End If

    End Sub
#End Region

#Region "Functions And Subs"

    Public Sub SetIni(section As String, key As String, value As String)

        ' sets values into any INI file
        Try
            Form1.Log("Info:Writing '" + INI + " section [" + section + "] " + key + "=" + value)
            Data(section)(key) = value ' replace it and save it
        Catch ex As Exception
            Form1.Log(ex.Message)
        End Try

    End Sub
    Public Sub LoadIni(filepath As String, delim As String, Optional whine As Boolean = True)

        parser = New FileIniDataParser()

        parser.Parser.Configuration.SkipInvalidLines = True
        parser.Parser.Configuration.CommentString = delim ' Opensim uses semicolons
        Try
            Data = parser.ReadFile(filepath, System.Text.Encoding.ASCII)
        Catch ex As Exception
            If whine Then MsgBox("Cannot read an INI file: " + ex.Message, "INI Error")
        End Try

        INI = filepath

    End Sub

    Public Function GetIni(filepath As String, section As String, key As String, delim As String) As String
        ' gets values from an INI file
        Dim parser = New FileIniDataParser()
        parser.Parser.Configuration.SkipInvalidLines = True
        parser.Parser.Configuration.CommentString = delim ' Opensim uses semicolons

        Dim Data = parser.ReadFile(filepath, System.Text.Encoding.ASCII)
        GetIni = Stripqq(Data(section)(key))

        parser = Nothing

    End Function

    Public Sub SaveINI()

        Try
            parser.WriteFile(INI, Data, System.Text.Encoding.ASCII)
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


#End Region

#Region "Properties"


    Public Property INIData(key As String) As String
        Get
            Try
                Return GetIni(INI, "Data", key, ";")
            Catch
            End Try
            Return Nothing
        End Get
        Set
            SetIni("Data", key, Value)
        End Set
    End Property

    Public Property ConsoleShow() As Boolean
        Get
            Return CType(INIData("ConsoleShow"), Boolean)
        End Get
        Set
            INIData("ConsoleShow") = Value
        End Set
    End Property

    Public Property AutoBackup() As Boolean
        Get
            Return CType(INIData("AutoBackup"), Boolean)
        End Get
        Set
            INIData("AutoBackup") = Value
        End Set
    End Property

    Public Property PublicIP() As String
        Get
            Return CType(INIData("PublicIP"), String)
        End Get
        Set
            INIData("PublicIP") = Value
        End Set
    End Property

    Public Property CoordX() As String
        Get
            Return CType(INIData("CoordX"), String)
        End Get
        Set
            INIData("CoordX") = Value
        End Set
    End Property

    Public Property CoordY() As String
        Get
            Return CType(INIData("CoordY"), String)
        End Get
        Set
            INIData("CoordY") = Value
        End Set
    End Property
    Public Property PrivatePort() As String
        Get
            Return CType(INIData("PrivatePort"), String)
        End Get
        Set
            INIData("PrivatePort") = Value
        End Set
    End Property

    Public Property SizeX() As String
        Get
            Return CType(INIData("SizeX"), String)
        End Get
        Set
            INIData("SizeX") = Value
        End Set
    End Property

    Public Property SizeY() As String
        Get
            Return CType(INIData("SizeY"), String)
        End Get
        Set
            INIData("SizeY") = Value
        End Set
    End Property

    Public Property AutobackupInterval() As String
        Get
            Return CType(INIData("AutobackupInterval"), String)
        End Get
        Set
            INIData("AutobackupInterval") = Value
        End Set
    End Property

    Public Property KeepForDays() As Integer
        Get
            Return CType(INIData("KeepForDays"), Integer)
        End Get
        Set
            INIData("KeepForDays") = Value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return CType(INIData("Password"), String)
        End Get
        Set
            INIData("Password") = Value
        End Set
    End Property

    Public Property AdminFirst() As String
        Get
            Return CType(INIData("AdminFirst"), String)
        End Get
        Set
            INIData("AdminFirst") = Value
        End Set
    End Property

    Public Property AdminLast() As String
        Get
            Return CType(INIData("AdminLast"), String)
        End Get
        Set
            INIData("AdminLast") = Value
        End Set
    End Property

    Public Property AdminEmail() As String
        Get
            Return CType(INIData("AdminEmail"), String)
        End Get
        Set
            INIData("AdminEmail") = Value
        End Set
    End Property

    Public Property ConsoleUser() As String
        Get
            Return CType(INIData("ConsoleUser"), String)
        End Get
        Set
            INIData("ConsoleUser") = Value
        End Set
    End Property

    Public Property ConsolePass() As String
        Get
            Return CType(INIData("ConsolePass"), String)
        End Get
        Set
            INIData("ConsolePass") = Value
        End Set
    End Property


    Public Property ChatTime() As Integer
        Get
            Return CType(INIData("ChatTime"), Integer)
        End Get
        Set
            INIData("ChatTime") = Value
        End Set
    End Property

    Public Property ViewerInstalled() As Boolean
        Get
            Return CType(INIData("ViewerInstalled"), Boolean)
        End Get
        Set
            INIData("ViewerInstalled") = Value
        End Set
    End Property

    Public Property ImageNum() As Integer
        Get
            Return CType(INIData("ImageNum"), Integer)
        End Get
        Set
            INIData("ImageNum") = Value
        End Set
    End Property


    Public Property region_owner_is_god() As Boolean
        Get
            Return CType(INIData("region_owner_is_god"), Boolean)
        End Get
        Set
            INIData("region_owner_is_god") = Value
        End Set
    End Property

    Public Property region_manager_is_god() As Boolean
        Get
            Return CType(INIData("region_manager_is_god"), Boolean)
        End Get
        Set
            INIData("region_manager_is_god") = Value
        End Set
    End Property

    Public Property TimerInterval() As Integer
        Get
            Return CType(INIData("TimerInterval"), Integer)
        End Get
        Set
            INIData("TimerInterval") = Value
        End Set
    End Property

    Public Property AccountConfirmationRequired() As Boolean
        Get
            Return CType(INIData("AccountConfirmationRequired"), Boolean)
        End Get
        Set
            INIData("AccountConfirmationRequired") = Value
        End Set
    End Property


    Public Property SmtpUsername() As String
        Get
            Return CType(INIData("SmtpUsername"), String)
        End Get
        Set
            INIData("SmtpUsername") = Value
        End Set
    End Property

    Public Property SmtpPassword() As String
        Get
            Return CType(INIData("SmtpPassword"), String)
        End Get
        Set
            INIData("SmtpPassword") = Value
        End Set
    End Property


    Public Property RanAllDiags() As Boolean
        Get
            Return CType(INIData("RanAllDiags"), Boolean)
        End Get
        Set
            INIData("RanAllDiags") = Value
        End Set
    End Property


    Public Property SkipUpdateCheck() As Boolean
        Get
            Return CType(INIData("SkipUpdateCheck"), Boolean)
        End Get
        Set
            INIData("SkipUpdateCheck") = Value
        End Set
    End Property


    Public Property DiagFailed() As Boolean
        Get
            Return CType(INIData("DiagFailed"), Boolean)
        End Get
        Set
            INIData("DiagFailed") = Value
        End Set
    End Property

    Public Property DNSName() As String
        Get
            Return CType(INIData("DnsName"), String)
        End Get
        Set
            INIData("DnsName") = Value
        End Set
    End Property

    Public Property WebStats() As Boolean
        Get
            Return CType(INIData("WebStats"), Boolean)
        End Get
        Set
            INIData("WebStats") = Value
        End Set
    End Property


    Public Property HttpPort() As String
        Get
            Return CType(INIData("HttpPort"), String)
        End Get
        Set
            INIData("HttpPort") = Value
        End Set
    End Property


    Public Property MachineID() As String
        Get
            Return CType(INIData("MachineID"), String)
        End Get
        Set
            INIData("MachineID") = Value
        End Set
    End Property


    Public Property LoopBackDiag() As Boolean
        Get
            Return CType(INIData("LoopBackDiag"), Boolean)
        End Get
        Set
            INIData("LoopBackDiag") = Value
        End Set
    End Property


    Public Property UPnpDiag() As Boolean
        Get
            Return CType(INIData("UPnpDiag"), Boolean)
        End Get
        Set
            INIData("UPnpDiag") = Value
        End Set
    End Property


    Public Property SplashPage() As String
        Get
            Return CType(INIData("SplashPage"), String)
        End Get
        Set
            INIData("SplashPage") = Value
        End Set
    End Property

    Public Property Physics() As Integer
        Get
            Return CType(INIData("Physics"), Integer)
        End Get
        Set
            INIData("Physics") = Value
        End Set
    End Property


    Public Property MyX() As Integer
        Get
            Return CType(INIData("MyX"), Integer)
        End Get
        Set
            INIData("MyX") = Value
        End Set
    End Property

    Public Property MyY() As Integer
        Get
            Return CType(INIData("MyY"), Integer)
        End Get
        Set
            INIData("MyY") = Value
        End Set
    End Property

    Public Property RobustServer() As String
        Get
            Return CType(INIData("RobustServer"), String)
        End Get
        Set
            INIData("RobustServer") = Value
        End Set
    End Property

    Public Property VivoxEnabled() As Boolean
        Get
            Return CType(INIData("VivoxEnabled"), Boolean)
        End Get
        Set
            INIData("VivoxEnabled") = Value
        End Set
    End Property


    Public Property Vivox_UserName() As String
        Get
            Return CType(INIData("Vivox_username"), String)
        End Get
        Set
            INIData("Vivox_username") = Value
        End Set
    End Property

    Public Property Vivox_password() As String
        Get
            Return CType(INIData("Vivox_password"), String)
        End Get
        Set
            INIData("Vivox_password") = Value
        End Set
    End Property


    Public Property MapType() As String
        Get
            Return CType(INIData("MapType"), String)
        End Get
        Set
            INIData("MapType") = Value
        End Set
    End Property


    Public Property BackupFolder() As String
        Get
            Return CType(INIData("BackupFolder"), String)
        End Get
        Set
            INIData("BackupFolder") = Value
        End Set
    End Property


    Public Property WelcomeRegion() As String
        Get
            Return CType(INIData("WelcomeRegion"), String)
        End Get
        Set
            INIData("WelcomeRegion") = Value
        End Set
    End Property


    Public Property GloebitsEnable() As Boolean
        Get
            Return CType(INIData("GloebitsEnable"), Boolean)
        End Get
        Set
            INIData("GloebitsEnable") = Value
        End Set
    End Property


    Public Property GloebitsMode() As Boolean
        Get
            Return CType(INIData("GloebitsMode"), Boolean)
        End Get
        Set
            INIData("GloebitsMode") = Value
        End Set
    End Property


    Public Property GLSandKey() As String
        Get
            Return CType(INIData("GLSandKey"), String)
        End Get
        Set
            INIData("GLSandKey") = Value
        End Set
    End Property

    Public Property GLSandSecret() As String
        Get
            Return CType(INIData("GLSandSecret"), String)
        End Get
        Set
            INIData("GLSandSecret") = Value
        End Set
    End Property
    Public Property GLBOwnerEmail() As String
        Get
            Return CType(INIData("GLBOwnerEmail"), String)
        End Get
        Set
            INIData("GLBOwnerEmail") = Value
        End Set
    End Property


    Public Property GLBOwnerName() As String
        Get
            Return CType(INIData("GLBOwnerName"), String)
        End Get
        Set
            INIData("GLBOwnerName") = Value
        End Set
    End Property


    Public Property GLProdKey() As String
        Get
            Return CType(INIData("GLProdKey"), String)
        End Get
        Set
            INIData("GLProdKey") = Value
        End Set
    End Property
    Public Property MySqlPort() As String
        Get
            Return CType(INIData("MySqlPort"), String)
        End Get
        Set
            INIData("MySqlPort") = Value
        End Set
    End Property

    Public Property GLProdSecret() As String
        Get
            Return CType(INIData("GLProdSecret"), String)
        End Get
        Set
            INIData("GLProdSecret") = Value
        End Set
    End Property

    Public Property RegionDbPassword() As String
        Get
            Return CType(INIData("RegionDbPassword"), String)
        End Get
        Set
            INIData("RegionDbPassword") = Value
        End Set
    End Property
    Public Property RegionDBUsername() As String
        Get
            Return CType(INIData("RegionDBUsername"), String)
        End Get
        Set
            INIData("RegionDBUsername") = Value
        End Set
    End Property

    Public Property RegionDBName() As String
        Get
            Return CType(INIData("RegionDBName"), String)
        End Get
        Set
            INIData("RegionDBName") = Value
        End Set
    End Property

    Public Property WifiEnabled() As Boolean
        Get
            Return CType(INIData("WifiEnabled"), Boolean)
        End Get
        Set
            INIData("WifiEnabled") = Value
        End Set
    End Property

    Public Property DiagnosticPort() As String
        Get
            Return CType(INIData("DiagnosticPort"), String)
        End Get
        Set
            INIData("DiagnosticPort") = Value
        End Set
    End Property

    Public Property RobustMySqlName() As String
        Get
            Return CType(INIData("RobustMySqlName"), String)
        End Get
        Set
            INIData("RobustMySqlName") = Value
        End Set
    End Property

    Public Property RobustMySqlUsername() As String
        Get
            Return CType(INIData("RobustMySqlUsername"), String)
        End Get
        Set
            INIData("RobustMySqlUsername") = Value
        End Set
    End Property

    Public Property RobustMySqlPassword() As String
        Get
            Return CType(INIData("RobustMySqlPassword"), String)
        End Get
        Set
            INIData("RobustMySqlPassword") = Value
        End Set
    End Property

    Public Property SimName() As String
        Get
            Return CType(INIData("SimName"), String)
        End Get
        Set
            INIData("SimName") = Value
        End Set
    End Property

    Public Property UPnPEnabled() As Boolean
        Get
            Return CType(INIData("UPnPEnabled"), Boolean)
        End Get
        Set
            INIData("UPnPEnabled") = Value
        End Set
    End Property

    Public Property Autostart() As Boolean
        Get
            Return CType(INIData("Autostart"), Boolean)
        End Get
        Set
            INIData("Autostart") = Value
        End Set
    End Property

    Public Property BootStart() As Boolean
        Get
            Return CType(INIData("BootStart"), Boolean)
        End Get
        Set
            INIData("BootStart") = Value
        End Set
    End Property

    Public Property EnableHypergrid() As Boolean
        Get
            Return CType(INIData("EnableHypergrid"), Boolean)
        End Get
        Set
            INIData("EnableHypergrid") = Value
        End Set
    End Property

    Public Property AutoLoad() As Boolean
        Get
            Return CType(INIData("AutoLoad"), Boolean)
        End Get
        Set
            INIData("AutoLoad") = Value
        End Set
    End Property

    Public Property RunOnce() As Boolean
        Get
            Return CType(INIData("RunOnce"), Boolean)
        End Get
        Set
            INIData("RunOnce") = Value
        End Set
    End Property
End Class

#End Region