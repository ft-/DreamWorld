

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
    End Class

    Public RegionList(0) As Object
    Private gCurRegionNum As UInteger


#End Region

#Region "Properties"
    Public Property ProcessID() As Integer
        Get
            Return RegionList(RegionNum()).ProcessID
        End Get
        Set(ByVal Value As Integer)
            RegionList(RegionNum()).ProcessID = Value
        End Set
    End Property
    Public Property RegionNum() As Integer
        Get
            Return gCurRegionNum
        End Get
        Set(ByVal Value As Integer)
            gCurRegionNum = Value
        End Set
    End Property
    Public Property RegionName() As String
        Get
            Return RegionList(RegionNum()).RegionName
        End Get
        Set(ByVal Value As String)
            RegionList(RegionNum()).RegionName = Value
        End Set
    End Property
    Public Property UUID() As String
        Get
            Return RegionList(RegionNum()).UUID
        End Get
        Set(ByVal Value As String)
            RegionList(RegionNum()).UUID = Value
        End Set
    End Property
    Public Property SizeX() As Integer
        Get
            Return RegionList(RegionNum()).SizeX
        End Get
        Set(ByVal Value As Integer)
            RegionList(RegionNum()).SizeX = Value
        End Set
    End Property
    Public Property SizeY() As Integer
        Get
            Return RegionList(RegionNum()).SizeY
        End Get
        Set(ByVal Value As Integer)
            RegionList(RegionNum()).SizeY = Value
        End Set
    End Property
    Public Property RegionPort() As Integer
        Get
            If RegionList(RegionNum()).RegionPort <= My.Settings.PrivatePort Then
                RegionList(RegionNum()).RegionPort = My.Settings.PrivatePort + 1 ' 8004, by default
            End If
            Return RegionList(RegionNum()).RegionPort
        End Get
        Set(ByVal Value As Integer)
            RegionList(RegionNum()).RegionPort = Value
        End Set
    End Property
    Public Property CoordX() As Integer
        Get
            Return RegionList(RegionNum()).CoordX
        End Get
        Set(ByVal Value As Integer)
            RegionList(RegionNum()).CoordX = Value
        End Set
    End Property
    Public Property CoordY() As Integer
        Get
            Return RegionList(RegionNum()).CoordY
        End Get
        Set(ByVal Value As Integer)
            RegionList(RegionNum()).CoordY = Value
        End Set
    End Property

#End Region

#Region "Code"

    Public Sub New()

        GetAllRegions()

    End Sub
    Public Function CurrentRegionName() As String

        Dim id = RegionNum
        Return FindRegionidByName(id)

    End Function

    Public Function FindRegionidByName(Name As String) As Integer

        Dim index = RegionList.GetUpperBound(0)
        While index > -1
            If Name = RegionList(index).RegionName Then
                Return index
            End If
            index = index - 1
        End While
        Return -1

    End Function

    Public Sub CreateRegion()

        'make room for a new region
        Array.Resize(RegionList, Count() + 1)
        Dim index = Count()
        RegionList(index) = New Region_data
        ' default data
        RegionNum = index
        RegionName() = ""
        UUID() = Guid.NewGuid().ToString
        SizeX() = 256
        SizeY() = 256
        RegionPort() = LargestPort() + 1 '8004 + 1

        ' form a line acrss the X Axis 4 to the right
        CoordX() = LargestX() + 4
        CoordY() = LargestY() + 0

    End Sub

    Public Sub GetAllRegions()

        Dim folders() As String
        Dim regionfolders() As String

        folders = Directory.GetDirectories(Form1.prefix + "Regions\")
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
                        CreateRegion()
                        Form1.Log("Info:Reading Region " + ini)

                        ' populate from disk
                        RegionName() = fName
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
                    Form1.Log("Err:Parse file " + FileName + ":" + ex.Message)
                End Try
            Next
        Next
    End Sub

#End Region

#Region "Public"

    Public Function Count() As Integer
        Dim s = RegionList.GetUpperBound(0)
        Return s
    End Function

#End Region
#Region "Private"

    Private Function LargestX() As Integer

        ' locate largest global coords
        Dim Max As Integer
        Dim counter As Integer = 1
        Dim L = RegionList.GetUpperBound(0)
        While counter <= L
            Dim val = RegionList(counter).CoordX
            If val > Max Then Max = val
            counter += 1
        End While
        Return Max

    End Function

    Private Function LargestY() As Integer

        ' locate largest global coords
        Dim Max As Integer
        Dim counter As Integer = 1
        Dim L = RegionList.GetUpperBound(0)
        While counter <= L
            Dim val = RegionList(counter).CoordY
            If val > Max Then Max = val
            counter += 1
        End While
        Return Max

    End Function

    Private Function LargestPort() As Integer

        ' locate largest global coords
        Dim Max As Integer
        Dim counter As Integer = 1
        Dim L = RegionList.GetUpperBound(0)
        While counter <= L
            Dim val = RegionList(counter).RegionPort
            If val > Max Then Max = val
            counter += 1
        End While
        Return Max

    End Function

#End Region

End Class
