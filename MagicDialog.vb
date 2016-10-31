Imports System.Windows.Forms
Imports System.Linq

Public Class MagicDialog

    Private Sub btnLowerApp_Click(sender As Object, e As EventArgs) Handles btnLowerApp.Click
        Dim newItems As New List(Of ListViewItem)
        For x As Integer = 0 To ListView1.Items.Count - 1
            Dim item As ListViewItem = ListView1.Items(x)
            newItems.Add(item)
        Next
        newItems = newItems.OrderByDescending(Function(f) f.SubItems(2).Text).ToList
        For i As Integer = 1 To newItems.Count - 1
            ListView1.Items.Remove(newItems(i))
        Next
        For z As Integer = MainForm.ListView1.Items.Count - 1 To 0 Step -1
            'newItems(0).Tag
            If Trim(MainForm.ListView1.Items(z).SubItems(4).Text) = Trim(newItems(0).SubItems(4).Text) Then
                If Trim(MainForm.ListView1.Items(z).Tag) = Trim(newItems(0).Tag) Then
                    ' DO NOTHING
                Else
                    MainForm.ListView1.Items(z).Remove()
                    'listCount -= 1
                End If
            End If
        Next
        DialogResult = 1
        Me.Close()
    End Sub

    Private Sub btnHigherApp_Click(sender As Object, e As EventArgs) Handles btnHigherApp.Click
        Dim newItems As New List(Of ListViewItem)
        For x As Integer = 0 To ListView1.Items.Count - 1
            Dim item As ListViewItem = ListView1.Items(x)
            newItems.Add(item)
        Next
        newItems = newItems.OrderBy(Function(f) f.SubItems(2).Text).ToList
        For i As Integer = 1 To newItems.Count - 1
            ListView1.Items.Remove(newItems(i))
        Next
        For z As Integer = MainForm.ListView1.Items.Count - 1 To 0 Step -1
            'newItems(0).Tag
            If Trim(MainForm.ListView1.Items(z).SubItems(4).Text) = Trim(newItems(0).SubItems(4).Text) Then
                If Trim(MainForm.ListView1.Items(z).Tag) = Trim(newItems(0).Tag) Then
                    ' DO NOTHING
                Else
                    MainForm.ListView1.Items(z).Remove()
                    'listCount -= 1
                End If
            End If
        Next

        DialogResult = 2
        Me.Close()
    End Sub

    Private Sub btnLowerAPI_Click(sender As Object, e As EventArgs) Handles btnLowerAPI.Click
        DialogResult = 3
        Me.Close()
    End Sub

    Private Sub btnHigherAPI_Click(sender As Object, e As EventArgs) Handles btnHigherAPI.Click
        DialogResult = 4
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = 5
        Me.Close()
    End Sub
End Class
