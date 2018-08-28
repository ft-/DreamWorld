Imports System.Net
Imports System.IO

' Copyright 2018 Fred Beckhusen  
' Redistribution and use in binary and source form is permitted provided 
' that ALL the licenses in the text files are followed and included in all copies

' Command line args:
'     '-debug' forces this to use the \Outworldzs folder for testing 

Public Class Update

    Dim MyFolder = Nothing   ' Holds the current folder that we are running in

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Show()
        Application.DoEvents()

        Me.Text = "Downloader V1"
        MyFolder = My.Application.Info.DirectoryPath
        ' I would like to buy an argument
        Dim arguments As String() = Environment.GetCommandLineArgs()
        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "-debug" Then
                MyFolder = "C:\Opensim\V2.15 - Copy" ' for testing, as the compiler buries itself in ../../../debug
                ChDir(MyFolder)
            End If
        End If

        Label1.Text = ""

        Dim Name1 As String = "https://www.outworldz.com/Outworldz_Installer/Downloader/DotNetZip.dll"
        Dim Name2 As String = "https://www.outworldz.com/Outworldz_Installer/Downloader/DotNetZip.xml"
        Dim Name3 As String = "https://www.outworldz.com/Outworldz_Installer/Downloader/UpdategridV3.exe"

        Try
            Label1.Text = "Downloading Updater"
            Application.DoEvents()
            Dim client As WebClient
            client = New WebClient()
            client.Credentials = New NetworkCredential("", "")
            client.DownloadFile(Name1, "DotNetZip.dll")
            Log("DotNetZip.dll loaded")
            client.DownloadFile(Name2, "DotNetZip.xml")
            Log("DotNetZip.xml loaded")
            client.DownloadFile(Name3, "UpdategridV3.exe")
            Log("Updategrid.exe loaded")

            Application.DoEvents()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try


        Log("Bootstrap Complete")

        Label1.Text = "Download Complete"
        Application.DoEvents()

        Dim newDream As New Process()
        Try
            newDream.StartInfo.UseShellExecute = False
            newDream.StartInfo.FileName = "UpdategridV3.exe"
            newDream.Start()
        Catch ex As Exception
            Label1.Text = "How odd, there seems to be no UpdategridV3.exe to run!"
            Log("No Start.exe Exit")
            Application.DoEvents()

            End
        End Try
        Log("Normal Exit")
        End

    End Sub

    Public Function Log(message As String)
        Try
            Using outputFile As New StreamWriter(MyFolder & "\UpdateGrid.log", True)
                outputFile.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + message)
            End Using
        Catch
        End Try
        Return True

    End Function



End Class


