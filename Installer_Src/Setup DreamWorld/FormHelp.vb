Public Class FormHelp
    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Dim webAddress As String = "https://www.outworldz.com"
        Process.Start(webAddress)
    End Sub

    Private Sub DreamgridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DreamgridToolStripMenuItem.Click
        Dim webAddress As String = "https://www.outworldz.com/Outworldz_installer/"
        Process.Start(webAddress)
    End Sub

    Private Sub TechnicalInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TechnicalInfoToolStripMenuItem.Click
        Dim webAddress As String = "https://www.outworldz.com/Outworldz_installer/technical.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub TroubleshootingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TroubleshootingToolStripMenuItem.Click
        Dim webAddress As String = "https://www.outworldz.com/Outworldz_installer/Manual_TroubleShooting.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub StepbyStepInstallationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StepbyStepInstallationToolStripMenuItem.Click
        Dim webAddress As String = "https://www.outworldz.com/Outworldz_installer/Startup.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub PortsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PortsToolStripMenuItem.Click
        Dim webAddress As String = "https://www.outworldz.com/Outworldz_installer/PortForwarding.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub LoopbackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoopbackToolStripMenuItem.Click
        Dim webAddress As String = "https://www.outworldz.com/Outworldz_installer/Loopback.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub DatabaseHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseHelpToolStripMenuItem.Click
        Dim webAddress As String = "https://www.outworldz.com/Outworldz_installer/Rebuilding_from_a_blank_database.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub SourceCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SourceCodeToolStripMenuItem.Click
        Dim webAddress As String = "https://github.com/Outworldz/DreamWorld"
        Process.Start(webAddress)
    End Sub
End Class