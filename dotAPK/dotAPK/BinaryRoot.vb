Public Class BinaryRoot
    Public adbPath As String = "" & Application.StartupPath & "\files\adb.exe"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            doNormal()
        ElseIf RadioButton2.Checked Then
            doSpecial()
        ElseIf RadioButton3.Checked Then
            doUnroot()
        End If
    End Sub

    Public Sub doNormal()
        Dim isRIC As Boolean

        RichTextBox1.AppendText("------------------------------------" & Date.Now & "------------------------------------" & vbNewLine)
        RichTextBox1.AppendText("I: Killing ADB server..." & vbNewLine)
        Shell(adbPath & " kill-server", AppWinStyle.Hide, True)
        RichTextBox1.AppendText("I: Killed ADB server" & vbNewLine)

        RichTextBox1.AppendText("I: Pulling ric" & vbNewLine)
        Shell(adbPath & " pull /system/bin/ric " & """" & Application.StartupPath & "\" & """", AppWinStyle.Hide, True)
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\ric") Then
            RichTextBox1.AppendText("I: Pulled ric" & vbNewLine)
            isRIC = True
        Else
            RichTextBox1.AppendText("W: No ric found" & vbNewLine)
            isRIC = False
        End If

        RichTextBox1.AppendText("I: Pulling Backup-Restore.apk" & vbNewLine)
        Shell(adbPath & " pull /system/app/Backup-Restore.apk " & """" & Application.StartupPath & "\" & """", AppWinStyle.Hide, True)
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Backup-Restore.apk") Then
            RichTextBox1.AppendText("I: Found Backup-Restore.apk" & vbNewLine)
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Backup-Restore.apk")
            If isRIC Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\ric")
            End If
            ' XPS
        Else
            RichTextBox1.AppendText("W: No Backup-Restore.apk found!!" & vbNewLine)
            ' OTHER
        End If
        RichTextBox1.AppendText("------------------------------------ END ------------------------------------" & vbNewLine)
    End Sub

    Public Sub doSpecial()

    End Sub

    Public Sub doUnroot()

    End Sub

    Private Sub BinaryRoot_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MainForm.Show()
    End Sub
End Class