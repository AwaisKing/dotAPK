Imports System.IO
Imports Ionic.Zip
Imports System.Linq
Imports System.Text.RegularExpressions

Public Class MainForm
    Public isDev As Boolean = False
    Public isMessageSeen As Boolean

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Try
            Dim files As String() = e.Data.GetData(DataFormats.FileDrop)

            For x As Integer = 0 To files.Length - 1
                Dim path As String = files(x)

                ' NO DUPS, MAN!!!
                Try
                    If ListView1.Items.Count > 0 Then
                        Dim items As New List(Of ListViewItem)
                        For Each item As ListViewItem In ListView1.Items
                            items.Add(item)
                        Next
                        items = items.Where(Function(g) Trim(g.SubItems(6).Text) = Trim(path)).ToList
                        If items.Count >= 1 Then
                            Continue For
                        End If
                    End If
                Catch ex As Exception
                End Try
                '''''''''''''''''''

                Dim oProcess As Process = New Process()
                oProcess.StartInfo = New ProcessStartInfo(Application.StartupPath + "\files\aapt.exe", "d badging " & """" & path & """") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
                oProcess.Start()
                Dim oStreamReader As StreamReader = oProcess.StandardOutput
                Dim appName, appVersion, appPackage, apiVersion, appDensities As String
                Try
                    appName = oStreamReader.ReadToEnd()
                Finally
                    If oStreamReader IsNot Nothing Then
                        oStreamReader.Dispose()
                    End If
                End Try
                If appName.Equals(Nothing) Or appName.Equals("") Or appName.Equals(vbNullString) Or appName.Equals(vbNullChar) Or appName.Equals(vbNull) Then
                    Continue For
                End If
                If Not appName.Equals(vbNullChar) Or appName.Equals(Nothing) Or appName.Equals("") Or appName.Equals(vbNull) Then
                    Dim outputLines As String() = appName.Replace(vbCrLf, vbCrLf).Replace(vbCr, vbCrLf).Replace(vbCrLf & vbCrLf, vbCr).Split(vbCr)

                    ' RESET VALUES
                    appName = ""
                    appVersion = ""

                    For i As Integer = 0 To outputLines.Length - 1
                        ' APP - LABEL
                        If outputLines(i).Contains("application:") Or outputLines(i).Contains("application-label:") Then
                            Dim str As String = outputLines(i).Remove(0, outputLines(i).IndexOf(":") + 1).Replace("label=", "")
                            If str.Contains("icon=") Then
                                str = str.Remove(str.IndexOf(" icon"), str.Length - str.IndexOf(" icon"))
                            End If
                            str = str.Remove(0, str.IndexOf("'") + 1)
                            str = str.Substring(0, str.LastIndexOf("'"))
                            If appName.Equals("") Then
                                appName = str
                            ElseIf appName.Equals(str) Then
                                appName = str
                            Else
                                If appName.Length >= str.Length Then
                                    appName = appName
                                Else
                                    appName = str
                                End If
                            End If
                        End If
                        ' APP - ICON
                        If outputLines(i).Contains("icon=") Or outputLines(i).Contains("application-icon") Then
                            If Not outputLines(i).Contains("icon=''") Then
                                If outputLines(i).Contains("icon=") Then
                                    Try
                                        Dim mosFILE As String = outputLines(i).Remove(0, outputLines(i).IndexOf("icon=")).Replace("icon=", "").Replace("'", "")
                                        Dim enumerator As IEnumerator(Of ZipEntry) = ZipFile.Read(path).GetEnumerator()
                                        While enumerator.MoveNext()
                                            Dim ex As ZipEntry = enumerator.Current
                                            If ex.FileName.Equals(mosFILE) Then
                                                ex.Extract(My.Computer.FileSystem.SpecialDirectories.Temp & "\dotAPK_TEMP_FILES", ExtractExistingFileAction.OverwriteSilently)
                                            End If
                                        End While
                                    Catch ex As Exception
                                    End Try
                                ElseIf outputLines(i).Contains("application-icon") Then
                                    Try
                                        Dim mosFILE As String = outputLines(i).Remove(0, outputLines(i).IndexOf(":'")).Replace("'", "").Replace(":", "")
                                        Dim enumerator As IEnumerator(Of ZipEntry) = ZipFile.Read(path).GetEnumerator()
                                        While enumerator.MoveNext()
                                            Dim ex2 As ZipEntry = enumerator.Current
                                            If ex2.FileName.Equals(mosFILE) Then
                                                ex2.Extract(My.Computer.FileSystem.SpecialDirectories.Temp + "\dotAPK_TEMP_FILES", ExtractExistingFileAction.OverwriteSilently)
                                            End If
                                        End While
                                    Catch ex As Exception
                                    End Try
                                End If
                            End If
                        End If
                        ' APP - VERSION
                        If outputLines(i).Contains("' versionName") Then
                            Dim mosVER As String = outputLines(i).Remove(0, outputLines(i).IndexOf("' versionName=") + 15)
                            appVersion = mosVER.Substring(0, mosVER.IndexOf("'"))
                        End If

                        If outputLines(i).Contains("densities") Then
                            appDensities = outputLines(i).Substring(outputLines(i).IndexOf("densities") + 11).Replace("'", "").Replace(" ", ", ")
                        End If

                        If outputLines(i).Contains("package: name=") Then
                            Dim packageCode As String = outputLines(i).Substring(outputLines(i).IndexOf("package: name=") + 15)
                            appPackage = packageCode.Substring(0, packageCode.IndexOf("'"))
                        End If

                        If outputLines(i).Contains("sdkVersion:") Then
                            apiVersion = outputLines(i).Replace(vbNewLine, "").Replace(vbCr, "").Replace(vbCrLf, "").Replace(vbLf, "").Replace("sdkVersion:", "").Replace("'", "")
                        End If
                    Next
                End If
                ListView1.LargeImageList.Images.Add(appName & appVersion, getLargestImage())
                ListView1.SmallImageList.Images.Add(appName & appVersion, getLargestImage())

                Dim NewItem As ListViewItem = New ListViewItem(New String() {"", appName, appVersion, _
                                "" + Toolkit.FormatFileSize(path), appPackage, _
                                appDensities, path, apiVersion}, appName & appVersion)
                ListView1.Items.Add(NewItem)
                NewItem.Tag = ListView1.Items(ListView1.Items.Count - 1).Bounds.Y
                Try
                    My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\dotAPK_TEMP_FILES", FileIO.DeleteDirectoryOption.DeleteAllContents)
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        End If
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        If e.ColumnIndex = 0 Then
            e.Cancel = True
            e.NewWidth = 80
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            For i As Integer = Me.ListView1.Items.Count - 1 To 0 Step -1
                If ListView1.Items(i).Selected Then
                    Dim imageKey As String = ListView1.Items(i).SubItems.Item(1).Text & ListView1.Items(i).SubItems.Item(2).Text & i
                    'largeList.Images.RemoveByKey(imageKey)
                    'smallList.Images.RemoveByKey(imageKey)
                    'ListView1.LargeImageList.Images.RemoveAt(ListView1.Items(i).ImageIndex)
                    'ListView1.SmallImageList.Images.RemoveAt()
                    ListView1.Items.Remove(ListView1.Items(i))
                    GC.Collect()
                    If isDev Then Console.WriteLine("lvKeyDown[Delete]: " & imageKey & " - " & ListView1.SmallImageList.Images.Count)
                End If
            Next
        End If
        If e.Control And (e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back) Then
            ListView1.Items.Clear()
            largeList.Images.Clear()
            smallList.Images.Clear()
            GC.Collect()
        End If
        If e.Control And e.KeyCode = Keys.A Then
            For i As Integer = 0 To ListView1.Items.Count - 1
                ListView1.Items(i).Selected = True
            Next
        End If
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Dim imageKey As String = ListView1.GetItemAt(e.X, e.Y).SubItems(1).Text & ListView1.GetItemAt(e.X, e.Y).SubItems(2).Text
        AppInfo.pbAppIcon.Image = largeList.Images(largeList.Images.IndexOfKey(imageKey))
        AppInfo.appPath = """" & ListView1.GetItemAt(e.X, e.Y).SubItems(6).Text & """"
        AppInfo.appName = ListView1.GetItemAt(e.X, e.Y).SubItems(1).Text
        AppInfo.appVersion = ListView1.GetItemAt(e.X, e.Y).SubItems(2).Text
        AppInfo.appDensities = ListView1.GetItemAt(e.X, e.Y).SubItems(5).Text
        AppInfo.lblPackage.Text = ListView1.GetItemAt(e.X, e.Y).SubItems(4).Text

        If ListView1.GetItemAt(e.X, e.Y).SubItems(5).Text.Equals("<WIP>") Then AppInfo.isInstalledApp = True

        AppInfo.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ListView1.Items.Count = 0 Then
            Me.Text = "dotAPK"
            ListView1.Items.Clear()
            largeList.Images.Clear()
            smallList.Images.Clear()
        Else
            Me.Text = "dotAPK - " & ListView1.Items.Count & " APKs added"
        End If
        lblBattery.Text = ProgressBar1.Value & "%"
        If ProgressBar1.Value <= 15 Then
            ProgressBar1.ForeColor = Color.Red
        ElseIf ProgressBar1.Value <= 30 Then
            ProgressBar1.ForeColor = Color.Orange
        ElseIf ProgressBar1.Value <= 50 Then
            ProgressBar1.ForeColor = Color.Blue
        ElseIf ProgressBar1.Value <= 80 Then
            ProgressBar1.ForeColor = Color.MediumSeaGreen
        ElseIf ProgressBar1.Value <= 90 Then
            ProgressBar1.ForeColor = Color.ForestGreen
        ElseIf ProgressBar1.Value <= 100 Then
            ProgressBar1.ForeColor = Color.LimeGreen
        End If

        Try
            If Not bgWorker.IsBusy Then bgWorker.RunWorkerAsync()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnInstallBulk_Click(sender As Object, e As EventArgs) Handles btnInstallBulk.Click
        If ListView1.SelectedItems.Count = 0 Or ListView1.Items.Count = 0 Then
            MsgBox("Please select one or more APK files to install.")
        Else
            If BigDevices.selectedDeviceIndex = -1 Then
                BigDevices.fromForm = Me
                BigDevices.Show()
            Else
                ' TODO: ADD BATCH INTSALLER
                If isDev Then Console.WriteLine("bulkInstall: " & BigDevices.selectedDeviceIndex)
                Dim apkList As New List(Of String())
                For Each myItem As ListViewItem In ListView1.SelectedItems
                    Dim apkPath As String = myItem.SubItems(6).Text
                    If apkPath.Contains(":") Or apkPath.Contains("/") = False Then _
                        apkList.Add(New String() {apkPath, myItem.SubItems(1).Text & ", " & myItem.SubItems(2).Text})
                Next
                Installer.apkList = apkList
                Installer.Show()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        BigDevices.fromForm = Me
        BigDevices.Show()
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\dotAPK_TEMP_FILES", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\dotAPK_TEMP_FILES", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not isDev Then
            Splash.Show()
            Splash.Focus()
            Me.Visible = False
            Me.ShowInTaskbar = False
        Else
            Timer1.Stop()
            Timer1.Enabled = False
            Timer1.Dispose()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''THIS WORKS
            'Dim fx As Byte() = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAABHNCSVQICAgIfAhkiAAAAw5JREFUaIHtmc1rE0EYxn9jTNJiY2sR+mHVUhH0op7ESxDBcy+9eSioePEqCF49KF48ilD0oPUPEBT0INbqTQ1CQYKhJjkUrVRttZF2N+l42N10dzNps8l2tmKeHDI7OzvzPPO+73xCG2383xB18mNAEkjY6ShRAQxg1U5vilg6nR4oFouTpmkuyYhRLpeXisXiZDqdHqDBzkzl8/lHURP3I5fL3Qe6/GRVLtRnGEYuHo+nGlGrC6Zp/k4kEoeBeXf+DkXZzu1GHsDm1OnPVwlQ5W0X1HDbzmQbwk7dDa6slnkyleX1uwL5uR8slww6knFSuxL0701xYKCbKxfSDdenCuIRKeVseJTX8SH7hRt3p/i++AcAKaX17xSwn18+uKT8XghxCPjsztNmgY+z37h2+zmmWUGIKtca8lIqP68LLTFQrqxxa2Ia07Qm0qAkN4IWAdNvC8zNL3nyHPcR1gMI0ZQwLS705n3B8+yQ7+3u5OrF0xw70k9HsjkqWgR8KixU0+5evnzuFCePD7VUtxYBCz9LSvc4cXSw5bq1BbGwB2zpUtLdlWy5bm0zsd8CEojFWm9ei4DqmO+fuEKARgv4TRCOjNCXEmfP36um3Rw9ve964Z+Re1JJHt8ZV5PVtZSoS9z30k9eSsnBwT2B2trSYXQz8lJRdnhfMAGhx4BqtKnCHkudMo7/uuNjZH9voPa2QID0/Iv1FyClMnZFdZKA4cGeQO1tUQxIb8/XWSq7fR8AAcNDwSygZUNzZnwCqPX7Vw/VG5d6iGxDE+b63w+tm3rVqNMq9FjAnQ7ZHHot4JnhwqkzurVQvXPxgNAUxOH3vAO9J3MeHeEoiexoUYTkQ3oOthSd/c9ZwCEs7V9YUAmoGIaxHFoLeMlDczOzzanmjkwlYCWbzb4I3kQwBBUxMzPzDFjx56sELI+Ojl7PZDJPDcMoNUdPDXtFHQiGYZQymczTsbGxm0CNZ6iGghiwG+gDerCuWkOadgJDYl2xLgJfgV/AmrvARvfEcSzyUd/irGGJMGnwnriNNgLgL0DrV0VfUggGAAAAAElFTkSuQmCC")
            'File.WriteAllBytes("C:\Users\AwaisKing\Desktop\lala.png", fx)
        End If
    End Sub

    Private Sub bgWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        Try
            If Not lblDeviceSelected.Text = "" Or Not lblDeviceSelected.Text = "UNKNOWN" Then
                Dim oProcess As Process = New Process()
                oProcess.StartInfo = New ProcessStartInfo(BigDevices.adbPath, " -s " & BigDevices.selectedDeviceSerial & " shell dumpsys battery") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
                oProcess.Start()
                Dim oStreamReader As StreamReader = oProcess.StandardOutput
                Dim batteryInfo As String = ""
                Try
                    batteryInfo = oStreamReader.ReadToEnd()
                Finally
                    If oStreamReader IsNot Nothing Then
                        Try
                            oStreamReader.Dispose()
                        Catch ex As Exception
                        End Try
                    End If
                End Try
                If batteryInfo.Contains("Can't find service") Or batteryInfo.Equals(Nothing) Or batteryInfo.Equals("") Or batteryInfo.Equals(vbNullString) Or batteryInfo.Equals(vbNullChar) Or batteryInfo.Equals(vbNull) Then
                    lblBattery.Text = "??"
                    ProgressBar1.Value = 0
                Else
                    batteryInfo = batteryInfo.Replace(vbLf, "").Replace(vbNewLine, "").Replace(vbCr, vbNewLine).Replace(vbNewLine & vbNewLine, vbNewLine)
                    If isDev Then Console.Write("batteryInfo: " & batteryInfo)

                    If batteryInfo.ToLower.Contains(" level:") Then
                        Dim level As String = ""
                        For Each ch As Char In batteryInfo.Substring(batteryInfo.ToLower.IndexOf(" level:"), 14).ToCharArray
                            If Char.IsDigit(ch) Then level += ch
                        Next
                        If lblBattery.InvokeRequired Then
                            lblBattery.Invoke(Sub() lblBattery.Text = level & "%")
                        Else
                            Try
                                lblBattery.Text = level & "%"
                            Catch ex As Exception
                            End Try
                        End If
                        If ProgressBar1.InvokeRequired Then
                            ProgressBar1.Invoke(Sub() ProgressBar1.Value = level)
                        Else
                            Try
                                ProgressBar1.Value = level
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            If isDev Then If Not ex.Message.Contains("lblBattery") Then Console.WriteLine("batterException: " & ex.Message)
        End Try
    End Sub

    Private Sub ListView1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles ListView1.ItemDrag
        Dim fileList As New Collections.Specialized.StringCollection
        For Each myItem As ListViewItem In ListView1.SelectedItems
            fileList.Add(myItem.SubItems(6).Text)
        Next
        Dim dataObj As New DataObject
        dataObj.SetFileDropList(fileList)
        ListView1.DoDragDrop(dataObj, DragDropEffects.Copy)
    End Sub

    Private Sub btnFindDups_Click(sender As Object, e As EventArgs) Handles btnFindDups.Click
        Dim items As New List(Of ListViewItem)
        Dim newItems As New List(Of ListViewItem)
        If ListView1.Items.Count >= 2 Then
            For x As Integer = 0 To ListView1.Items.Count - 1
                newItems.Add(ListView1.Items(x))
            Next
            newItems = newItems.GroupBy(Function(s) s.SubItems(4).Text).Where(Function(g) g.Count() > 1).SelectMany(Function(g) g.Skip(0)).ToList
        End If
        items = newItems.GroupBy(Function(s) s.SubItems(4).Text).Where(Function(g) g.Count() > 1).SelectMany(Function(g) g.Skip(0)).ToList

        If isDev Then Console.WriteLine("findDups: " & String.Join("--", getDuplicates(items).Select(Function(x) x.SubItems(4).Text).ToArray))
        For Each elem In getDuplicates(items).Select(Function(x) x.SubItems(4).Text).Distinct
            Dim xa As List(Of ListViewItem) = items.FindAll(Function(s) Trim(s.SubItems(4).Text) = Trim(elem))
            Toolkit.showDialog(xa)
        Next

    End Sub

    Function getDuplicates(ByVal cas As List(Of ListViewItem)) As List(Of ListViewItem)
        Dim xa As New List(Of ListViewItem)
        xa.Clear()

        Dim itemI As ListViewItem
        Dim itemJ As ListViewItem

        For i As Integer = cas.Count - 1 To 0 Step -1
            itemI = cas(i)

            For z As Integer = i + 1 To cas.Count - 1 Step 1
                itemJ = cas(z)
                If isDev Then Console.WriteLine("getDuplicates: " & itemI.SubItems(4).Text & " == " & itemJ.SubItems(4).Text)
                If Trim(itemI.SubItems(4).Text) = Trim(itemJ.SubItems(4).Text) Then
                    xa.Add(itemJ)
                End If
                Exit For
            Next z
        Next (i)
        'xa.RemoveAt(0)
        Return xa
    End Function

    Private Sub btnGetInstall_Click(sender As Object, e As EventArgs) Handles btnGetInstall.Click
        If isMessageSeen = False Then
            'MsgBox("READ THIS:" & vbNewLine & "There are some problems getting all installed apps, but in future updates I'll try to fix them." & vbNewLine & _
            '    "Also there's source code available on GitHub if you want to fix too (help would be appreciated) :)" & vbNewLine & _
            '    "----------------------------------" & vbNewLine & "If you are stuck at getting installed apps, that's probably because:" & vbNewLine & _
            '    "1. You have a lot of apps (or)" & vbNewLine & "2. Your phone is locked and screen is off" & vbNewLine & "----------------------------------" & vbNewLine & _
            '    "All you have to do is unlock phone and wait...")
            MsgBox("If you are stuck at getting installed apps, that's probably because:" & vbNewLine & _
                "1. You have a lot of apps (or)" & vbNewLine & "2. Your phone is locked and screen is off" & vbNewLine & _
                "----------------------------------" & vbNewLine & "All you have to do is unlock phone and wait...")
            isMessageSeen = True
        End If

        If isDev Then MsgBox(BigDevices.selectedDeviceIndex)
        If BigDevices.selectedDeviceIndex = -1 Then
            BigDevices.fromForm = Me
            BigDevices.Show()
        Else
            '''''''' <<<<<<<<<<< CHECK FOR dotAPK Helper IS INSTALLED OR NOT
            Try
                Dim oProcess As Process = New Process()
                oProcess.StartInfo = New ProcessStartInfo(BigDevices.adbPath, " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "pm list packages" & """") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
                oProcess.Start()
                Dim oStreamReader As StreamReader = oProcess.StandardOutput
                Dim apps As String
                Try
                    apps = oStreamReader.ReadToEnd()
                Finally
                    If oStreamReader IsNot Nothing Then
                        oStreamReader.Dispose()
                    End If
                End Try

                If apps.Equals(Nothing) Or apps.Equals("") Or apps.Equals(vbNullString) Or apps.Equals(vbNullChar) Or apps.Equals(vbNull) Then
                    Return
                End If
                If Not apps.Equals(vbNullChar) Or apps.Equals(Nothing) Or apps.Equals("") Or apps.Equals(vbNull) Then
                    If Not apps.Contains("awaisking.dotapk") Then
                        If MessageBox.Show("dotAPK Helper is not found on your device, do you want to install it?", "dotAPK Helper", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            MsgBox("Thank you for installing dotAPK Helper app :)" & vbNewLine & "Also thank you for using dotAPK tool ^_^")

                            Dim xProcess As Process = New Process()
                            xProcess.StartInfo = New ProcessStartInfo(BigDevices.adbPath, " -s " & BigDevices.selectedDeviceSerial & " install " & """" & Application.StartupPath & "\files\dotAPKHelper.apk" & """") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
                            xProcess.Start()
                            Dim xStreamReader As StreamReader = xProcess.StandardOutput
                            Dim installation As String
                            Try
                                installation = xStreamReader.ReadToEnd()
                            Finally
                                If xStreamReader IsNot Nothing Then
                                    xStreamReader.Dispose()
                                End If
                            End Try

                            Console.WriteLine(installation)
                            If installation.Equals(Nothing) Or installation.Equals("") Or installation.Equals(vbNullString) Or installation.Equals(vbNullChar) Or installation.Equals(vbNull) Then
                                MsgBox("Installation failed :( << nothing")
                                Return
                            Else
                                If installation.ToLower.Contains("success") Then
                                    MsgBox("Installation completed! :D" & vbNewLine & "Now press button again to get installed apps :)")
                                    Return
                                Else
                                    MsgBox("Installation failed :(")
                                    Return
                                End If
                            End If
                        Else
                            MsgBox("You will no be able to get installed apps.")
                            Return
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            Try
                'Shell(BigDevices.adbPath & " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "run-as awaisking.dot am force-stop awaisking.dotapk" & """", AppWinStyle.Hide, True)
                'Shell(BigDevices.adbPath & " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "run-as awaisking.dot pm disable awaisking.dotapk && run-as awaisking.dot pm enable awaisking.dotapk" & """", AppWinStyle.Hide, True)
                Shell(BigDevices.adbPath & " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "am broadcast -a awaisking.dotapk.STOP" & """", AppWinStyle.Hide, True)
                Shell(BigDevices.adbPath & " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "am start -W -n awaisking.dotapk/awaisking.dotapk.Main" & """", AppWinStyle.Hide, True)
                Shell(BigDevices.adbPath & " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "am broadcast -a awaisking.dotapk.STOP" & """", AppWinStyle.Hide, True)
                'Shell(BigDevices.adbPath & " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "run-as awaisking.dot am force-stop awaisking.dotapk" & """", AppWinStyle.Hide, True)
                'Shell(BigDevices.adbPath & " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "run-as awaisking.dot pm disable awaisking.dotapk && run-as awaisking.dot pm enable awaisking.dotapk" & """", AppWinStyle.Hide, True)

                Dim oProcess As Process = New Process()
                'oProcess.StartInfo = New ProcessStartInfo(BigDevices.adbPath, " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "logcat -d -v long" & """") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
                oProcess.StartInfo = New ProcessStartInfo(BigDevices.adbPath, " -s " & BigDevices.selectedDeviceSerial & " shell " & """" & "run-as awaisking.dotapk cat /data/data/awaisking.dotapk/files/dotAPK.txt" & """") With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
                oProcess.Start()
                Dim oStreamReader As StreamReader = oProcess.StandardOutput
                Dim apps As String
                Try
                    apps = oStreamReader.ReadToEnd()
                Finally
                    If oStreamReader IsNot Nothing Then
                        oStreamReader.Dispose()
                    End If
                End Try

                If apps.Equals(Nothing) Or apps.Equals("") Or apps.Equals(vbNullString) Or apps.Equals(vbNullChar) Or apps.Equals(vbNull) Then
                    Return
                End If
                If Not apps.Equals(vbNullChar) Or apps.Equals(Nothing) Or apps.Equals("") Or apps.Equals(vbNull) Then
                    ListView1.Items.Clear()
                    largeList.Images.Clear()
                    smallList.Images.Clear()
                    GC.Collect()
                    ' Format:
                    ' {
                    '  [appname],
                    '  [package],
                    '  [targetSdk],
                    '  {[apkPath1|apkPath2]},
                    '  [Icon]
                    ' }
                    apps = apps.Replace(vbCr + vbCrLf, vbNewLine)
                    Dim appsList As MatchCollection = New Regex("AWAISKING:DOTAPK:APP\{[^\{]*\}").Matches(apps)
                    For Each rawApp As Match In appsList
                        Dim appMark As String = rawApp.Value.Replace(vbNewLine, "")
                        appMark = appMark.Replace(vbCr, "").Replace(vbLf, "")
                        appMark = appMark.Replace(vbCrLf, "").Replace("AWAISKING:DOTAPK:APP{", "").Replace("}", "")
                        Dim appContent As String() = appMark.Split(",")

                        Dim appName As String = appContent(0)
                        Dim appPackage As String = appContent(1)
                        Dim apkSize As Decimal = Decimal.Parse(appContent(2))
                        Dim appVersion As String = appContent(3)
                        Dim appTargetSdk As String = appContent(4)
                        Dim appSourceDir As String = appContent(5).Substring(1, appContent(5).Length - 2).Split("|")(0)
                        Dim appPublicSourceDir As String = appContent(5).Substring(1, appContent(5).Length - 2).Split("|")(1)
                        Dim appIcon As Image = Image.FromStream(New MemoryStream(Convert.FromBase64String(appContent(6))))

                        Dim apkPath As String = "<Error>"
                        If appSourceDir.Equals(appPublicSourceDir) Then apkPath = appSourceDir
                        If appSourceDir.Equals("") Or appSourceDir.Length <= 0 Then apkPath = appPublicSourceDir
                        If appPublicSourceDir.Equals("") Or appPublicSourceDir.Length <= 0 Then apkPath = appSourceDir
                        If (appSourceDir.Equals("") Or appSourceDir.Length <= 0) And (appPublicSourceDir.Equals("") Or appPublicSourceDir.Length <= 0) Then apkPath = "<Error>"

                        'Console.WriteLine(appSourceDir & " - " & appPublicSourceDir)
                        'MsgBox("App Name: " & appName & vbNewLine & "path: " & apkPath)

                        ListView1.LargeImageList.Images.Add(appName & appVersion, appIcon)
                        ListView1.SmallImageList.Images.Add(appName & appVersion, appIcon)

                        Dim NewItem As ListViewItem = New ListViewItem(New String() {"", appName, appVersion, _
                                    Toolkit.ReadableSize(apkSize), appPackage, "<WIP>", apkPath, appTargetSdk}, appName & appVersion)
                        ListView1.Items.Add(NewItem)
                        NewItem.Tag = ListView1.Items(ListView1.Items.Count - 1).Bounds.Y
                    Next
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnRemSel_Click(sender As Object, e As EventArgs) Handles btnRemSel.Click
        For i As Integer = Me.ListView1.Items.Count - 1 To 0 Step -1
            If ListView1.Items(i).Selected Then
                Dim imageKey As String = ListView1.Items(i).SubItems.Item(1).Text & ListView1.Items(i).SubItems.Item(2).Text & i
                'largeList.Images.RemoveByKey(imageKey)
                'smallList.Images.RemoveByKey(imageKey)
                'ListView1.LargeImageList.Images.RemoveAt(ListView1.Items(i).ImageIndex)
                'ListView1.SmallImageList.Images.RemoveAt()
                ListView1.Items.Remove(ListView1.Items(i))
                GC.Collect()
                If isDev Then Console.WriteLine("removeSelected: " & imageKey & " - " & ListView1.SmallImageList.Images.Count)
            End If
        Next
    End Sub

    Private Sub btnDelSel_Click(sender As Object, e As EventArgs) Handles btnDelSel.Click
        For i As Integer = Me.ListView1.Items.Count - 1 To 0 Step -1
            If ListView1.Items(i).Selected Then
                Dim selItem As ListViewItem = ListView1.Items(i)
                If isDev Then Console.WriteLine("deleteSelected: " & selItem.SubItems(6).Text)

                Dim rResult As DialogResult = MessageBox.Show("Are you sure to delete " & ListView1.Items(i).SubItems(1).Text & "?" & vbNewLine & "NOTE: THIS WILL DELETE FILE PERMANENTLY!" & vbNewLine & vbNewLine & "Location: " & ListView1.Items(i).SubItems(6).Text, "Deleting file: " & ListView1.Items(i).SubItems(6).Text.Remove(0, ListView1.Items(i).SubItems(6).Text.LastIndexOf("\") + 1), MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If rResult = Windows.Forms.DialogResult.Yes Then
                    Try
                        File.Delete(ListView1.Items(i).SubItems(6).Text)
                    Catch ex As Exception
                        Try
                            My.Computer.FileSystem.DeleteFile(ListView1.Items(i).SubItems(6).Text)
                        Catch exx As Exception
                            MsgBox("Error deleting file!" & vbNewLine & vbNewLine & exx.Message, MsgBoxStyle.Exclamation, "Error")
                            Return
                        End Try
                    End Try
                    ListView1.Items.Remove(ListView1.Items(i))
                End If
                GC.Collect()
            End If
        Next
    End Sub
End Class