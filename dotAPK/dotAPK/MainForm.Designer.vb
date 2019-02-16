<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            Try
                MyBase.Dispose(disposing)
            Catch ex As Exception
            End Try
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.btnGetInstall = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.btnRemSel = New System.Windows.Forms.Button()
        Me.btnDelSel = New System.Windows.Forms.Button()
        Me.btnFindDups = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnInstallBulk = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.appIcon = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.appName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.appVersion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.appSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.appPackage = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.largeList = New System.Windows.Forms.ImageList(Me.components)
        Me.smallList = New System.Windows.Forms.ImageList(Me.components)
        Me.lblBattery = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblDeviceSelected = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.btnGetInstall)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.btnRemSel)
        Me.GroupBox1.Controls.Add(Me.btnDelSel)
        Me.GroupBox1.Controls.Add(Me.btnFindDups)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btnInstallBulk)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(-1, 404)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(758, 105)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.SystemColors.Control
        Me.Button10.Enabled = False
        Me.Button10.Location = New System.Drawing.Point(470, 62)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(107, 35)
        Me.Button10.TabIndex = 1
        Me.Button10.Text = "-WIP-"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Enabled = False
        Me.Button9.Location = New System.Drawing.Point(357, 62)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(107, 35)
        Me.Button9.TabIndex = 1
        Me.Button9.Text = "-WIP-"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'btnGetInstall
        '
        Me.btnGetInstall.BackColor = System.Drawing.SystemColors.Control
        Me.btnGetInstall.Location = New System.Drawing.Point(470, 19)
        Me.btnGetInstall.Name = "btnGetInstall"
        Me.btnGetInstall.Size = New System.Drawing.Size(107, 35)
        Me.btnGetInstall.TabIndex = 1
        Me.btnGetInstall.Text = "Get Installed &Apps"
        Me.btnGetInstall.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Enabled = False
        Me.Button8.Location = New System.Drawing.Point(244, 62)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(107, 35)
        Me.Button8.TabIndex = 1
        Me.Button8.Text = "-WIP-"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'btnRemSel
        '
        Me.btnRemSel.BackColor = System.Drawing.SystemColors.Control
        Me.btnRemSel.Location = New System.Drawing.Point(357, 19)
        Me.btnRemSel.Name = "btnRemSel"
        Me.btnRemSel.Size = New System.Drawing.Size(107, 35)
        Me.btnRemSel.TabIndex = 1
        Me.btnRemSel.Text = "&Remove Selected"
        Me.btnRemSel.UseVisualStyleBackColor = False
        '
        'btnDelSel
        '
        Me.btnDelSel.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelSel.Location = New System.Drawing.Point(131, 62)
        Me.btnDelSel.Name = "btnDelSel"
        Me.btnDelSel.Size = New System.Drawing.Size(107, 35)
        Me.btnDelSel.TabIndex = 1
        Me.btnDelSel.Text = "D&elete Selected"
        Me.btnDelSel.UseVisualStyleBackColor = False
        '
        'btnFindDups
        '
        Me.btnFindDups.BackColor = System.Drawing.SystemColors.Control
        Me.btnFindDups.Location = New System.Drawing.Point(244, 19)
        Me.btnFindDups.Name = "btnFindDups"
        Me.btnFindDups.Size = New System.Drawing.Size(107, 35)
        Me.btnFindDups.TabIndex = 1
        Me.btnFindDups.Text = "&Find Duplicates"
        Me.btnFindDups.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.Location = New System.Drawing.Point(6, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 78)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Select &Device"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnInstallBulk
        '
        Me.btnInstallBulk.BackColor = System.Drawing.SystemColors.Control
        Me.btnInstallBulk.Location = New System.Drawing.Point(131, 19)
        Me.btnInstallBulk.Name = "btnInstallBulk"
        Me.btnInstallBulk.Size = New System.Drawing.Size(107, 35)
        Me.btnInstallBulk.TabIndex = 1
        Me.btnInstallBulk.Text = "Install &Selected"
        Me.btnInstallBulk.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(16, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Commands"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(575, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(187, 105)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(11, 62)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(158, 35)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "-WIP-"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(11, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 35)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Root (&Bin4ry)"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Toolbox"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.appIcon, Me.appName, Me.appVersion, Me.appSize, Me.appPackage})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.LargeImageList = Me.largeList
        Me.ListView1.Location = New System.Drawing.Point(14, 33)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(724, 365)
        Me.ListView1.SmallImageList = Me.smallList
        Me.ListView1.TabIndex = 11
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
        Me.appVersion.Width = 85
        '
        'appSize
        '
        Me.appSize.Text = "Size"
        Me.appSize.Width = 65
        '
        'appPackage
        '
        Me.appPackage.Text = "Package Name"
        Me.appPackage.Width = 110
        '
        'largeList
        '
        Me.largeList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.largeList.ImageSize = New System.Drawing.Size(128, 128)
        Me.largeList.TransparentColor = System.Drawing.Color.Transparent
        '
        'smallList
        '
        Me.smallList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.smallList.ImageSize = New System.Drawing.Size(63, 63)
        Me.smallList.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblBattery
        '
        Me.lblBattery.Location = New System.Drawing.Point(606, 9)
        Me.lblBattery.Name = "lblBattery"
        Me.lblBattery.Size = New System.Drawing.Size(34, 13)
        Me.lblBattery.TabIndex = 16
        Me.lblBattery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 20
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.SteelBlue
        Me.ProgressBar1.Location = New System.Drawing.Point(646, 9)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 13)
        Me.ProgressBar1.TabIndex = 15
        '
        'lblDeviceSelected
        '
        Me.lblDeviceSelected.AutoSize = True
        Me.lblDeviceSelected.ForeColor = System.Drawing.Color.Red
        Me.lblDeviceSelected.Location = New System.Drawing.Point(103, 9)
        Me.lblDeviceSelected.Name = "lblDeviceSelected"
        Me.lblDeviceSelected.Size = New System.Drawing.Size(93, 13)
        Me.lblDeviceSelected.TabIndex = 13
        Me.lblDeviceSelected.Text = "SELECT DEVICE!"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Selected Device:"
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 518)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.lblBattery)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblDeviceSelected)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(772, 557)
        Me.Name = "MainForm"
        Me.Text = "dotAPK"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button10 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents btnGetInstall As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents btnRemSel As Button
    Friend WithEvents btnDelSel As Button
    Friend WithEvents btnFindDups As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents btnInstallBulk As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents appIcon As ColumnHeader
    Friend WithEvents appName As ColumnHeader
    Friend WithEvents appVersion As ColumnHeader
    Friend WithEvents appSize As ColumnHeader
    Friend WithEvents appPackage As ColumnHeader
    Friend WithEvents largeList As ImageList
    Friend WithEvents smallList As ImageList
    Friend WithEvents lblBattery As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblDeviceSelected As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
End Class
