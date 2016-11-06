Imports System.IO

Public NotInheritable Class AppInfo
    Public Shared appPath, appName, appVersion, appDensities As String
    Public Shared isInstalledApp As Boolean

#Region "Raw Output"
    Private Function getRawOutput() As String()
        Dim oProcess As Process = New Process()
        oProcess.StartInfo = New ProcessStartInfo(Application.StartupPath + "\files\aapt.exe", "d badging " & """" & appPath & """") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
        oProcess.Start()
        Dim oStreamReader As StreamReader = oProcess.StandardOutput
        Dim rawOutput As String
        Try
            rawOutput = oStreamReader.ReadToEnd()
        Catch ex As Exception
            Return New String() {}
        Finally
            oStreamReader.Dispose()
            oStreamReader.Close()
        End Try
        Return rawOutput.Replace(vbCrLf, vbCrLf).Replace(vbCr, vbCrLf).Replace(vbCrLf & vbCrLf, vbCr).Split(vbCr)
    End Function
#End Region

    Private Sub AppInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MainForm.Enabled = True
    End Sub

    Private Sub AppInfo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub AppInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If isInstalledApp Then
            Me.Height = 180
            Me.Width = 480
            Me.lblSuppDens.Visible = False
            Me.lblSuppScr.Visible = False
            Me.lbPerms.Visible = False
            Me.lblVerCode.Visible = False
            Me.btnInstall.Visible = False
            Me.txtLaunchActivity.Visible = False
            Me.Button2.Visible = False
            Me.placeholder2.Visible = False
            Me.placeholder6.Visible = False
            Me.placeholder7.Visible = False
            Me.placeholder8.Visible = False
            Me.placeholder3.Location = New Point(Me.placeholder3.Location.X, Me.placeholder2.Location.Y)
            Me.lblPackage.Location = New Point(Me.lblPackage.Location.X, Me.placeholder2.Location.Y)
            Me.btnRemove.Visible = True
        Else
            Me.btnRemove.Visible = False
        End If
        MainForm.Enabled = False
        Me.Text = appName
        lblName.Text = appName
        lblVersion.Text = appVersion
        lblSuppDens.Text = appDensities
        Dim rawOutput As String() = getRawOutput()
        If rawOutput.Equals(Nothing) Or rawOutput.Equals("") Or rawOutput.Equals(vbNullString) Or rawOutput.Equals(vbNullChar) Or rawOutput.Equals(vbNull) Then
            Return
        Else
            For i As Integer = 0 To rawOutput.Length - 1
                If rawOutput(i).Contains("targetSdkVersion") Then _
                    lblTargetSdk.Text = rawOutput(i).Remove(0, rawOutput(i).IndexOf(":") + 2).Replace("'", "")
                If rawOutput(i).Contains("sdkVersion:") And Not rawOutput(i).Contains("targetSdkVersion") Then _
                    lblSdkVersion.Text = rawOutput(i).Remove(0, rawOutput(i).IndexOf(":") + 2).Replace("'", "")
                If rawOutput(i).Contains("supports-screens") Then _
                    lblSuppScr.Text = rawOutput(i).Substring(rawOutput(i).IndexOf("supports-screens") + 18).Replace("'", "").Replace(" ", ", ")
                If rawOutput(i).Contains("versionCode") Then
                    Dim verCode As String = rawOutput(i).Remove(0, rawOutput(i).IndexOf("versionCode=") + 13)
                    lblVerCode.Text = verCode.Substring(0, verCode.IndexOf("'"))
                End If
                If rawOutput(i).Contains("package: name=") Then
                    Dim packageCode As String = rawOutput(i).Substring(rawOutput(i).IndexOf("package: name=") + 15)
                    lblPackage.Text = packageCode.Substring(0, packageCode.IndexOf("'"))
                End If
                If rawOutput(i).Contains("launchable-activity") Then
                    Dim xas As String = rawOutput(i).Substring(rawOutput(i).IndexOf("launchable-activity:") + 21)
                    xas = xas.Substring(xas.IndexOf("name='") + 6)
                    txtLaunchActivity.Text = xas.Substring(0, xas.IndexOf("'"))
                    txtLaunchActivity.Enabled = True
                    Return
                Else
                    txtLaunchActivity.Text = "NO ACTIVITY FOUND"
                    txtLaunchActivity.Enabled = False
                End If
            Next
            btnInfoSDK.Location = New Point(lblSdkVersion.Location.X + lblSdkVersion.Size.Width + 5, btnInfoSDK.Location.Y)
        End If
    End Sub

    Private Sub btnInfoSDK_Click(sender As Object, e As EventArgs) Handles btnInfoSDK.Click
        MsgBox("SDK Version : " & lblSdkVersion.Text & " : " & getAndroidVersion(lblSdkVersion.Text) & vbNewLine & "SDK Target Version : " & lblTargetSdk.Text & " : " & getAndroidVersion(lblTargetSdk.Text))
    End Sub

    Private Sub btnInstall_Click(sender As Object, e As EventArgs) Handles btnInstall.Click
        BigDevices.fromForm = Me
        BigDevices.Show()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim oProcess As Process = New Process()
        oProcess.StartInfo = New ProcessStartInfo(BigDevices.adbPath, " -s " & BigDevices.selectedDeviceSerial & " uninstall " & lblPackage.Text & "") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
        oProcess.Start()
        Dim oStreamReader As StreamReader = oProcess.StandardOutput
        Dim rawOutput As String = ""
        Try
            rawOutput = oStreamReader.ReadToEnd()
        Catch ex As Exception
        Finally
            oStreamReader.Dispose()
            oStreamReader.Close()
        End Try
        If rawOutput IsNot Nothing And rawOutput.Length > 0 And rawOutput.ToLower.Contains("success") Then
            For i As Integer = MainForm.ListView1.Items.Count - 1 To 0 Step -1
                If MainForm.ListView1.Items(i).Selected Then
                    MainForm.ListView1.Items.Remove(MainForm.ListView1.Items(i))
                    GC.Collect()
                    If MainForm.isDev Then Console.WriteLine("removeSelected: " & _
                        MainForm.ListView1.Items(i).SubItems.Item(1).Text & MainForm.ListView1.Items(i).SubItems.Item(2).Text & i & _
                        " - " & MainForm.ListView1.SmallImageList.Images.Count)
                End If
            Next
            Me.Close()
        Else
            MsgBox(rawOutput)
            Console.WriteLine(rawOutput)
        End If
    End Sub
End Class
