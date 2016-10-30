Imports System.IO
Imports System.Text.RegularExpressions

Public Class BigDevices
    Public Shared selectedDeviceIndex As Integer = -1
    Public Shared selectedDeviceSerial As String
    Public Shared adbPath As String = Application.StartupPath & "\files\adb.exe"
    Public Shared lastIndex As Integer
    Public Shared fromForm As Form

    Private Sub BigDevices_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MainForm.Enabled = True
        BinaryRoot.Enabled = True
        AppInfo.Enabled = True
    End Sub

    Private Sub BigDevices_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            MainForm.Enabled = True
            BinaryRoot.Enabled = True
            AppInfo.Enabled = True
            fromForm.Focus()
        End If
    End Sub

    Private Sub BigDevices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm.Enabled = False
        BinaryRoot.Enabled = False
        AppInfo.Enabled = False

        For Each p As Process In Process.GetProcesses
            Try
                If p.ProcessName.Equals("adb") Then
                    adbPath = p.Modules(0).FileName
                    Exit For
                End If
            Catch ex As Exception
                adbPath = Application.StartupPath & "\files\adb.exe"
            End Try
        Next
        Shell(adbPath & " start-server", AppWinStyle.Hide, True)

        Dim rawOutput() As String = getRawOutput()
        If rawOutput.Length <= 3 Then
            ListBox1.Items.Clear()
            Return
        End If
        ListBox1.Items.Clear()
        For i As Integer = 0 To rawOutput.Length - 1
            If Not ((rawOutput(i).ToLower.Contains("list") And rawOutput(i).ToLower.Contains("attach")) Or (rawOutput(i).ToLower.Contains("daemon") And rawOutput(i).ToLower.Contains("start"))) Then
                Dim modelName As String = "UNKNOWN"
                If rawOutput(i).Length > 2 Then
                    Dim oProcess As Process = New Process()
                    oProcess.StartInfo = New ProcessStartInfo(adbPath, "-s " & Regex.Replace(rawOutput(i).Replace(vbLf, ""), "\t+", "|").Split("|")(0) & " shell getprop ro.product.model") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
                    oProcess.Start()
                    Using oStreamReader As StreamReader = oProcess.StandardOutput
                        modelName = oStreamReader.ReadToEnd
                    End Using
                    If modelName Is "" Or modelName = "" Or modelName Is Nothing Or modelName = Nothing Or modelName.Equals(Nothing) Or modelName.Equals("") Then
                        modelName = "UNKNOWN"
                    End If
                    If rawOutput(i).ToLower.EndsWith("unauth", StringComparison.OrdinalIgnoreCase) Then
                        MsgBox("One or more devices UnAuthorized, please unlock device and check 'Always allow from this computer' box and press OK button in dialog.", MsgBoxStyle.Exclamation, "Unauthorized Device")
                        modelName = "UNKNOWN"
                    End If
                    ListBox1.Items.Add("Device: " & modelName & "   [Serial: " & Regex.Replace(rawOutput(i).Replace(vbLf, ""), "\t+", "|").Split("|")(0) & "]")
                End If
            End If
        Next
        If ListBox1.Items.Count = 1 Then
            ListBox1.SetSelected(0, True)
            lastIndex = 0
            selectedDeviceIndex = 0
            Dim listItem As String = ListBox1.SelectedItem.ToString.Replace(vbCr, "").Replace(vbCrLf, "").Replace(vbLf, "").Replace(vbNewLine, "")
            selectedDeviceSerial = listItem.Substring(listItem.IndexOf("Serial:") + 8).Replace("]", "")
        ElseIf ListBox1.Items.Count > 1 Then
            ListBox1.SetSelected(lastIndex, True)
            selectedDeviceIndex = lastIndex
            Dim listItem As String = ListBox1.SelectedItem.ToString.Replace(vbCr, "").Replace(vbCrLf, "").Replace(vbLf, "").Replace(vbNewLine, "")
            selectedDeviceSerial = listItem.Substring(listItem.IndexOf("Serial:") + 8).Replace("]", "")
        End If
    End Sub

    Private Function getRawOutput() As String()
        Dim oProcess As Process = New Process()
        oProcess.StartInfo = New ProcessStartInfo(adbPath, "devices") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
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
        Return rawOutput.Split(vbCr)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If ListBox1.Items.Count >= 1 Then
            lastIndex = ListBox1.SelectedIndex
        End If
        Dim rawOutput() As String = getRawOutput()
        If rawOutput.Length <= 3 Then
            ListBox1.Items.Clear()
            Return
        End If
        ListBox1.Items.Clear()
        For i As Integer = 0 To rawOutput.Length - 1
            If Not ((rawOutput(i).ToLower.Contains("list") And rawOutput(i).ToLower.Contains("attach")) Or (rawOutput(i).ToLower.Contains("daemon") And rawOutput(i).ToLower.Contains("start"))) Then
                Dim modelName As String = "UNKNOWN"
                If rawOutput(i).Length > 2 Then
                    Dim oProcess As Process = New Process()
                    oProcess.StartInfo = New ProcessStartInfo(adbPath, "-s " & Regex.Replace(rawOutput(i).Replace(vbLf, ""), "\t+", "|").Split("|")(0) & " shell getprop ro.product.model") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
                    oProcess.Start()
                    Using oStreamReader As StreamReader = oProcess.StandardOutput
                        modelName = oStreamReader.ReadToEnd
                    End Using
                    If modelName Is "" Or modelName = "" Or modelName Is Nothing Or modelName = Nothing Or modelName.Equals(Nothing) Or modelName.Equals("") Then
                        modelName = "UNKNOWN"
                    End If
                    If rawOutput(i).ToLower.EndsWith("unauth", StringComparison.OrdinalIgnoreCase) Then
                        MsgBox("One or more devices UnAuthorized, please unlock device and check 'Always allow from this computer' box and press OK button in dialog.", MsgBoxStyle.Exclamation, "Unauthorized Device")
                        modelName = "UNKNOWN"
                    End If
                    ListBox1.Items.Add("Device: " & modelName & "   [Serial: " & Regex.Replace(rawOutput(i).Replace(vbLf, ""), "\t+", "|").Split("|")(0) & "]")
                End If
            End If
        Next
        If lastIndex > ListBox1.Items.Count - 1 Then
            ListBox1.SetSelected(0, True)
        Else
            ListBox1.SetSelected(lastIndex, True)
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        lastIndex = ListBox1.SelectedIndex
        Console.WriteLine("selLast: " & lastIndex)
        Try
            Dim listItem As String = ListBox1.SelectedItem.ToString.Replace(vbCr, "").Replace(vbCrLf, "").Replace(vbLf, "").Replace(vbNewLine, "")
            lblSelectedDevice.Text = listItem.Substring(0, listItem.IndexOf("   [")).Remove(0, 8)
            selectedDeviceSerial = listItem.Substring(listItem.IndexOf("Serial:") + 8).Replace("]", "")
            MainForm.lblDeviceSelected.Text = lblSelectedDevice.Text & "  [  " & selectedDeviceSerial & "  ]"
            MainForm.lblDeviceSelected.ForeColor = Color.Blue
            Console.WriteLine(listItem)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
        fromForm.Focus()
    End Sub
End Class