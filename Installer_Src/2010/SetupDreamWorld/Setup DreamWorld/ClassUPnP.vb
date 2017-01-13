
Imports System.Net
Imports System.Runtime.InteropServices

Public Class UPNP
    Implements IDisposable

    Private upnpnat As NATUPNPLib.UPnPNAT
    Private staticMapping As NATUPNPLib.IStaticPortMappingCollection
    Private dynamicMapping As NATUPNPLib.IDynamicPortMappingCollection

    Private staticEnabled As Boolean = True
    Private dynamicEnabled As Boolean = True

    ''' <summary>
    ''' The different supported protocols
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Protocol

        ''' <summary>
        ''' Transmission Control Protocol
        ''' </summary>
        ''' <remarks></remarks>
        TCP

        ''' <summary>
        ''' User Datagram Protocol
        ''' </summary>
        ''' <remarks></remarks>
        UDP

    End Enum

    ''' <summary>
    ''' Returns if UPnP is enabled.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UPNPEnabled As Boolean
        Get
            Return staticEnabled = True OrElse dynamicEnabled = True
        End Get
    End Property

    ''' <summary>
    ''' The UPnP Managed Class
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        'Create the new NAT Class
        upnpnat = New NATUPNPLib.UPnPNAT

        'generate the static mappings
        Me.GetStaticMappings()
        Me.GetDynamicMappings()

    End Sub

    ''' <summary>
    ''' Returns all static port mappings
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetStaticMappings()
        Try
            staticMapping = upnpnat.StaticPortMappingCollection()
            If staticMapping Is Nothing Then
                staticEnabled = False
            End If

        Catch ex As NotImplementedException
            staticEnabled = False
        End Try
    End Sub

    ''' <summary>
    ''' Returns all dynamic port mappings
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetDynamicMappings()
        Try
            dynamicMapping = upnpnat.DynamicPortMappingCollection()
            If dynamicMapping Is Nothing Then
                dynamicEnabled = False
            End If
        Catch ex As NotImplementedException
            dynamicEnabled = False
        End Try
    End Sub

    ''' <summary>
    ''' Adds a port mapping to the UPnP enabled device.
    ''' </summary>
    ''' <param name="localIP">The local IP address to map to.</param>
    ''' <param name="Port">The port to forward.</param>
    ''' <param name="prot">The protocol of the port [TCP/UDP]</param>
    ''' <param name="desc">A small description of the port.</param>
    ''' <exception cref="ApplicationException">This exception is thrown when UPnP is disabled.</exception>
    ''' <exception cref="ObjectDisposedException">This exception is thrown when this class has been disposed.</exception>
    ''' <exception cref="ArgumentException">This exception is thrown when any of the supplied arguments are invalid.</exception>
    ''' <remarks></remarks>
    Public Sub Add(ByVal localIP As String, ByVal port As Integer, ByVal prot As Protocol, ByVal desc As String)

        ' Begin utilizing
        If Exists(port, prot) Then Throw New ArgumentException("This mapping already exists!", "Port;prot")

        ' Check
        If Not IsPrivateIP(localIP) Then Throw New ArgumentException("This is not a local IP address!", "localIP")

        ' Final check!
        If Not staticEnabled Then Throw New ApplicationException("UPnP is not enabled, or there was an error with UPnP Initialization.")

        ' Okay, continue on
        staticMapping.Add(port, prot.ToString(), port, localIP, True, desc)

    End Sub

    ''' <summary>
    ''' Removes a port mapping from the UPnP enabled device.
    ''' </summary>
    ''' <param name="Port">The port to remove.</param>
    ''' <param name="prot">The protocol of the port [TCP/UDP]</param>
    ''' <exception cref="ApplicationException">This exception is thrown when UPnP is disabled.</exception>
    ''' <exception cref="ObjectDisposedException">This exception is thrown when this class has been disposed.</exception>
    ''' <exception cref="ArgumentException">This exception is thrown when the port [or protocol] is invalid.</exception>
    ''' <remarks></remarks>
    Public Sub Remove(ByVal port As Integer, ByVal prot As Protocol)

        ' Begin utilizing
        If Not Exists(port, prot) Then Throw New ArgumentException("This mapping doesn't exist!", "port;prot")

        ' Final check!
        If Not staticEnabled Then Throw New ApplicationException("UPnP is not enabled, or there was an error with UPnP Initialization.")

        ' Okay, continue on
        staticMapping.Remove(port, prot.ToString)

    End Sub

    ''' <summary>
    ''' Checks to see if a port exists in the mapping.
    ''' </summary>
    ''' <param name="Port">The port to check.</param>
    ''' <param name="prot">The protocol of the port [TCP/UDP]</param>
    ''' <exception cref="ApplicationException">This exception is thrown when UPnP is disabled.</exception>
    ''' <exception cref="ObjectDisposedException">This exception is thrown when this class has been disposed.</exception>
    ''' <exception cref="ArgumentException">This exception is thrown when the port [or protocol] is invalid.</exception>
    ''' <remarks></remarks>
    Public Function Exists(ByVal port As Integer, ByVal prot As Protocol) As Boolean

        ' Final check!
        If Not staticEnabled Then Throw New ApplicationException("UPnP is not enabled, or there was an error with UPnP Initialization.")

        ' Begin checking
        For Each mapping As NATUPNPLib.IStaticPortMapping In staticMapping

            ' Compare
            If mapping.ExternalPort.Equals(port) AndAlso mapping.Protocol.ToString.Equals(prot.ToString) Then
                Return True
            End If

        Next

        'Nothing!
        Return False

    End Function

    ''' <summary>
    ''' Attempts to locate the local IP address of this computer.
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Shared Function LocalIP() As String
        Dim IPList As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        For Each IPaddress In IPList.AddressList
            If (IPaddress.AddressFamily = Sockets.AddressFamily.InterNetwork) AndAlso IsPrivateIP(IPaddress.ToString()) Then
                Dim ip = IPaddress.ToString()
                Return ip
            End If
        Next
        Return String.Empty
    End Function

    ''' <summary>
    ''' Checks to see if an IP address is a local IP address.
    ''' </summary>
    ''' <param name="CheckIP">The IP address to check.</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Private Shared Function IsPrivateIP(ByVal CheckIP As String) As Boolean
        Dim Quad1, Quad2 As Integer

        Quad1 = CInt(CheckIP.Substring(0, CheckIP.IndexOf(".")))
        Quad2 = CInt(CheckIP.Substring(CheckIP.IndexOf(".") + 1).Substring(0, CheckIP.IndexOf(".")))
        Select Case Quad1
            Case 10
                Return True
            Case 172
                If Quad2 >= 16 And Quad2 <= 31 Then Return True
            Case 192
                If Quad2 = 168 Then Return True
        End Select
        Return False
    End Function

    ''' <summary>
    ''' Disposes of the UPnP class
    ''' </summary>
    ''' <param name="disposing">True or False makes no difference.</param>
    ''' <remarks></remarks>
    Protected Overridable Sub Dispose(disposing As Boolean)
        Marshal.ReleaseComObject(staticMapping)
        Marshal.ReleaseComObject(dynamicMapping)
        Marshal.ReleaseComObject(upnpnat)
    End Sub

    ''' <summary>
    ''' Dispose!
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ''' <summary>
    ''' Prints out some debugging information to use.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Print() As List(Of String)

        ' Return list
        Dim L As New List(Of String)

        ' Loop through all the data after a check
        If staticEnabled Then
            For Each mapping As NATUPNPLib.IStaticPortMapping In staticMapping

                ' Add some initial data
                L.Add("--------------------------------------")

                'Grab the rest
                L.Add(String.Format("IP: {0}", mapping.InternalgWSCLient))
                L.Add(String.Format("Port: {0}", mapping.InternalPort))
                L.Add(String.Format("Description: {0}", mapping.Description))

            Next
        End If

        'Finisher
        L.Add("--------------------------------------")

        ' Give it back
        Return L

    End Function

End Class