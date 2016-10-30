<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MagicDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnHigherAPI = New System.Windows.Forms.Button()
        Me.btnLowerAPI = New System.Windows.Forms.Button()
        Me.btnHigherApp = New System.Windows.Forms.Button()
        Me.btnLowerApp = New System.Windows.Forms.Button()
        Me.lblAppDuplicates = New System.Windows.Forms.Label()
        Me.pbDupAppIcon = New System.Windows.Forms.PictureBox()
        Me.lblDupAppName = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.appIcon = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.appName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.appVersion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.apiVersion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.pbDupAppIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(588, 310)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(140, 53)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'btnHigherAPI
        '
        Me.btnHigherAPI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHigherAPI.Location = New System.Drawing.Point(442, 310)
        Me.btnHigherAPI.Name = "btnHigherAPI"
        Me.btnHigherAPI.Size = New System.Drawing.Size(140, 53)
        Me.btnHigherAPI.TabIndex = 3
        Me.btnHigherAPI.Text = "Remove higher API version(s)"
        '
        'btnLowerAPI
        '
        Me.btnLowerAPI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLowerAPI.Location = New System.Drawing.Point(296, 310)
        Me.btnLowerAPI.Name = "btnLowerAPI"
        Me.btnLowerAPI.Size = New System.Drawing.Size(140, 53)
        Me.btnLowerAPI.TabIndex = 3
        Me.btnLowerAPI.Text = "Remove lower API version(s)"
        '
        'btnHigherApp
        '
        Me.btnHigherApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHigherApp.Location = New System.Drawing.Point(150, 310)
        Me.btnHigherApp.Name = "btnHigherApp"
        Me.btnHigherApp.Size = New System.Drawing.Size(140, 53)
        Me.btnHigherApp.TabIndex = 3
        Me.btnHigherApp.Text = "Remove higher app version(s)"
        '
        'btnLowerApp
        '
        Me.btnLowerApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLowerApp.Location = New System.Drawing.Point(4, 310)
        Me.btnLowerApp.Name = "btnLowerApp"
        Me.btnLowerApp.Size = New System.Drawing.Size(140, 53)
        Me.btnLowerApp.TabIndex = 3
        Me.btnLowerApp.Text = "Remove lower app version(s)"
        '
        'lblAppDuplicates
        '
        Me.lblAppDuplicates.Location = New System.Drawing.Point(12, 12)
        Me.lblAppDuplicates.Name = "lblAppDuplicates"
        Me.lblAppDuplicates.Size = New System.Drawing.Size(166, 45)
        Me.lblAppDuplicates.TabIndex = 4
        Me.lblAppDuplicates.Text = "This app has {1} duplicate{s}:"
        Me.lblAppDuplicates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbDupAppIcon
        '
        Me.pbDupAppIcon.Location = New System.Drawing.Point(184, 12)
        Me.pbDupAppIcon.Name = "pbDupAppIcon"
        Me.pbDupAppIcon.Size = New System.Drawing.Size(45, 45)
        Me.pbDupAppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbDupAppIcon.TabIndex = 5
        Me.pbDupAppIcon.TabStop = False
        '
        'lblDupAppName
        '
        Me.lblDupAppName.Location = New System.Drawing.Point(235, 12)
        Me.lblDupAppName.Name = "lblDupAppName"
        Me.lblDupAppName.Size = New System.Drawing.Size(501, 45)
        Me.lblDupAppName.TabIndex = 4
        Me.lblDupAppName.Text = "UNKNOWN"
        Me.lblDupAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.appIcon, Me.appName, Me.appVersion, Me.apiVersion})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(12, 63)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(716, 241)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 6
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'appIcon
        '
        Me.appIcon.Text = "Icon"
        Me.appIcon.Width = 80
        '
        'appName
        '
        Me.appName.Text = "Name"
        Me.appName.Width = 372
        '
        'appVersion
        '
        Me.appVersion.Text = "Version"
        Me.appVersion.Width = 120
        '
        'apiVersion
        '
        Me.apiVersion.Text = "API Version"
        Me.apiVersion.Width = 120
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(64, 64)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'MagicDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 375)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.pbDupAppIcon)
        Me.Controls.Add(Me.lblDupAppName)
        Me.Controls.Add(Me.lblAppDuplicates)
        Me.Controls.Add(Me.btnLowerApp)
        Me.Controls.Add(Me.btnHigherApp)
        Me.Controls.Add(Me.btnLowerAPI)
        Me.Controls.Add(Me.btnHigherAPI)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MagicDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MagicDialog"
        CType(Me.pbDupAppIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHigherAPI As System.Windows.Forms.Button
    Friend WithEvents btnLowerAPI As System.Windows.Forms.Button
    Friend WithEvents btnHigherApp As System.Windows.Forms.Button
    Friend WithEvents btnLowerApp As System.Windows.Forms.Button
    Friend WithEvents lblAppDuplicates As System.Windows.Forms.Label
    Friend WithEvents pbDupAppIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblDupAppName As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents appIcon As System.Windows.Forms.ColumnHeader
    Friend WithEvents appName As System.Windows.Forms.ColumnHeader
    Friend WithEvents appVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents apiVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
