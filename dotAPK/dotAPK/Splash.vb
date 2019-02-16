Public NotInheritable Class Splash
    Private i As Integer = 0
    Private adbPath As String = Application.StartupPath & "\files\adb.exe"

    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrSlider.Start()
        pbdotAPK.Image = splashIcons.Images(0)
        For Each p As Process In Process.GetProcesses
            Try
                If p.ProcessName.Equals("adb") Then
                    adbPath = p.Modules(0).FileName
                    ProgressBar1.Value = ProgressBar1.Maximum / 2
                    Exit For
                End If
            Catch ex As Exception
                adbPath = Application.StartupPath & "\files\adb.exe"
            End Try
        Next
        Shell(adbPath & " start-server", AppWinStyle.Hide, False)
    End Sub

    Private Sub tmrSlider_Tick(sender As Object, e As EventArgs) Handles tmrSlider.Tick
        If i >= 9 Then
            pbdotAPK.Image = splashIcons.Images(9)
            tmrSlider.Enabled = False
        Else
            pbdotAPK.Image = splashIcons.Images(i)
        End If
        i += 1
    End Sub

    Private Sub tmrProgress_Tick(sender As Object, e As EventArgs) Handles tmrProgress.Tick
        If Not ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Value += 1
        Else
            tmrProgress.Stop()
            tmrSlider.Stop()
            Close()
            MainForm.Show()
            MainForm.ShowInTaskbar = True
            MainForm.Visible = True
            MainForm.Focus()
        End If
    End Sub
End Class
