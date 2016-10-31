Imports System.IO
Imports System.Linq

Public Class Installer
    Public Shared apkList As List(Of String())

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            ListBox1.Visible = False
            TextBox1.Visible = True
        Else
            ListBox1.Visible = True
            TextBox1.Visible = False
        End If
    End Sub

    Private Sub Installer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MainForm.Enabled = True
    End Sub

    Private Sub Installer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm.Enabled = False

        bgInstaller.RunWorkerAsync()
    End Sub

    Private Sub tmrProgFix_Tick(sender As Object, e As EventArgs) Handles tmrProgFix.Tick
        'ProgressBar1.Location = New Point((Label2.Location.X + Label2.Size.Width) + 5, ProgressBar1.Location.Y)
        'ProgressBar1.Size = New Size((CheckBox1.Left - Label2.Right) - 10, ProgressBar1.Size.Height)
    End Sub

    Private Sub menuClrLog_Click(sender As Object, e As EventArgs) Handles menuClrLog.Click
        TextBox1.Text = ""
        ListBox1.Items.Clear()
    End Sub

    Private Sub bgInstaller_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgInstaller.DoWork
        For Each apkItem As String() In apkList
            If Label2.InvokeRequired Then
                Label2.Invoke(Sub() Label2.Text = "Installing: " & apkItem(1))
            Else
                Try
                    Label2.Text = "Installing: " & apkItem(1)
                Catch ex As Exception
                End Try
            End If

            Try
                If ListBox1.InvokeRequired Then
                    ListBox1.Invoke(Sub() ListBox1.Items.Add("Installing: " & apkItem(1)))
                Else
                    Try
                        ListBox1.Items.Add("Installing: " & apkItem(1))
                    Catch exx As Exception
                    End Try
                End If
                Dim oProcess As Process = New Process()
                oProcess.StartInfo = New ProcessStartInfo(BigDevices.adbPath, " -s " & BigDevices.selectedDeviceSerial & " install " & """" & apkItem(0) & """") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
                oProcess.Start()
                Dim oStreamReader As StreamReader = oProcess.StandardOutput
                Dim installLog As String
                Try
                    installLog = oStreamReader.ReadToEnd()
                Finally
                    If oStreamReader IsNot Nothing Then
                        oStreamReader.Dispose()
                    End If
                End Try

                If installLog.Equals(Nothing) Or installLog.Equals("") Or installLog.Equals(vbNullString) Or installLog.Equals(vbNullChar) Or installLog.Equals(vbNull) Then
                    Return
                End If
                If Not installLog.Equals(vbNullChar) Or installLog.Equals(Nothing) Or installLog.Equals("") Or installLog.Equals(vbNull) Then
                    If installLog.ToLower.Contains("success") Then
                        If ListBox1.InvokeRequired Then
                            ListBox1.Invoke(Sub() ListBox1.Items.Add("Installation succeed!"))
                        Else
                            Try
                                ListBox1.Items.Add("Installation succeed!")
                            Catch exx As Exception
                            End Try
                        End If
                    ElseIf installLog.ToLower.Contains("fail") Then
                        Dim failReason As String = "unknown error"
                        For Each ca As String In installLog.Split(New Char() {vbCrLf, vbNewLine})
                            If ca.ToLower.Contains("fail") Then
                                failReason = ca.Replace(vbCr, "").Replace(vbLf, "").Split(" ")(1).Replace("[", "").Replace("]", "")
                            End If
                        Next
                        Try
                            If ListBox1.InvokeRequired Then
                                ListBox1.Invoke(Sub() ListBox1.Items.Add("Installation failed! Error: " & failReason))
                            Else
                                Try
                                    ListBox1.Items.Add("Installation failed! Error: " & failReason)
                                Catch exx As Exception
                                End Try
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                    Try
                        If TextBox1.InvokeRequired Then
                            TextBox1.Invoke(Sub() TextBox1.Text += vbNewLine & apkItem(1) & vbNewLine & installLog & vbNewLine & "------------------------------------------------------")
                        Else
                            Try
                                TextBox1.Text += "----> " & apkItem(1) & vbNewLine & installLog & vbNewLine & "------------------------------------------------------"
                            Catch exx As Exception
                            End Try
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Catch ex As Exception
                Console.Write(ex.Message)
                If ListBox1.InvokeRequired Then
                    ListBox1.Invoke(Sub() ListBox1.Items.Add("Installation failed! Error: " & ex.Message))
                Else
                    Try
                        ListBox1.Items.Add("Installation failed! Error: " & ex.Message)
                    Catch exx As Exception
                    End Try
                End If
                If TextBox1.InvokeRequired Then
                    TextBox1.Invoke(Sub() TextBox1.Text += vbNewLine & vbNewLine & "ERROR: " & ex.Message)
                Else
                    Try
                        TextBox1.Text += vbNewLine & vbNewLine & "ERROR: " & ex.Message
                    Catch exx As Exception
                    End Try
                End If
                TextBox1.Text += vbNewLine & vbNewLine & "ERROR: " & ex.Message
            Finally
                If Label2.InvokeRequired Then
                    Label2.Invoke(Sub() Label2.Text = "")
                Else
                    Try
                        Label2.Text = ""
                    Catch ex As Exception
                    End Try
                End If
            End Try
        Next
    End Sub
End Class