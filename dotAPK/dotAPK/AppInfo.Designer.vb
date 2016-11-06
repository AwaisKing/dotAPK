<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppInfo
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
        Me.btnInstall = New System.Windows.Forms.Button()
        Me.pbAppIcon = New System.Windows.Forms.PictureBox()
        Me.placeholder1 = New System.Windows.Forms.Label()
        Me.placeholder0 = New System.Windows.Forms.Label()
        Me.placeholder2 = New System.Windows.Forms.Label()
        Me.placeholder3 = New System.Windows.Forms.Label()
        Me.lbPerms = New System.Windows.Forms.ListBox()
        Me.placeholder4 = New System.Windows.Forms.Label()
        Me.placeholder6 = New System.Windows.Forms.Label()
        Me.placeholder5 = New System.Windows.Forms.Label()
        Me.placeholder7 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblVerCode = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblPackage = New System.Windows.Forms.Label()
        Me.lblSdkVersion = New System.Windows.Forms.Label()
        Me.lblTargetSdk = New System.Windows.Forms.Label()
        Me.lblSuppDens = New System.Windows.Forms.Label()
        Me.txtLaunchActivity = New System.Windows.Forms.TextBox()
        Me.placeholder8 = New System.Windows.Forms.Label()
        Me.btnInfoSDK = New System.Windows.Forms.Button()
        Me.lblSuppScr = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        CType(Me.pbAppIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnInstall
        '
        Me.btnInstall.Location = New System.Drawing.Point(632, 321)
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.Size = New System.Drawing.Size(132, 73)
        Me.btnInstall.TabIndex = 0
        Me.btnInstall.Text = "Install"
        Me.btnInstall.UseVisualStyleBackColor = True
        '
        'pbAppIcon
        '
        Me.pbAppIcon.Location = New System.Drawing.Point(12, 12)
        Me.pbAppIcon.Name = "pbAppIcon"
        Me.pbAppIcon.Size = New System.Drawing.Size(100, 100)
        Me.pbAppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAppIcon.TabIndex = 1
        Me.pbAppIcon.TabStop = False
        '
        'placeholder1
        '
        Me.placeholder1.AutoSize = True
        Me.placeholder1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.placeholder1.Location = New System.Drawing.Point(146, 40)
        Me.placeholder1.Name = "placeholder1"
        Me.placeholder1.Size = New System.Drawing.Size(45, 13)
        Me.placeholder1.TabIndex = 3
        Me.placeholder1.Text = "Version:"
        '
        'placeholder0
        '
        Me.placeholder0.AutoSize = True
        Me.placeholder0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.placeholder0.Location = New System.Drawing.Point(153, 12)
        Me.placeholder0.Name = "placeholder0"
        Me.placeholder0.Size = New System.Drawing.Size(38, 13)
        Me.placeholder0.TabIndex = 2
        Me.placeholder0.Text = "Name:"
        '
        'placeholder2
        '
        Me.placeholder2.AutoSize = True
        Me.placeholder2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.placeholder2.Location = New System.Drawing.Point(118, 68)
        Me.placeholder2.Name = "placeholder2"
        Me.placeholder2.Size = New System.Drawing.Size(73, 13)
        Me.placeholder2.TabIndex = 2
        Me.placeholder2.Text = "Version Code:"
        '
        'placeholder3
        '
        Me.placeholder3.AutoSize = True
        Me.placeholder3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.placeholder3.Location = New System.Drawing.Point(138, 96)
        Me.placeholder3.Name = "placeholder3"
        Me.placeholder3.Size = New System.Drawing.Size(53, 13)
        Me.placeholder3.TabIndex = 3
        Me.placeholder3.Text = "Package:"
        '
        'lbPerms
        '
        Me.lbPerms.FormattingEnabled = True
        Me.lbPerms.Location = New System.Drawing.Point(12, 221)
        Me.lbPerms.Name = "lbPerms"
        Me.lbPerms.Size = New System.Drawing.Size(294, 173)
        Me.lbPerms.TabIndex = 4
        '
        'placeholder4
        '
        Me.placeholder4.AutoSize = True
        Me.placeholder4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.placeholder4.Location = New System.Drawing.Point(457, 12)
        Me.placeholder4.Name = "placeholder4"
        Me.placeholder4.Size = New System.Drawing.Size(70, 13)
        Me.placeholder4.TabIndex = 2
        Me.placeholder4.Text = "SDK Version:"
        Me.placeholder4.Visible = False
        '
        'placeholder6
        '
        Me.placeholder6.AutoSize = True
        Me.placeholder6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.placeholder6.Location = New System.Drawing.Point(424, 68)
        Me.placeholder6.Name = "placeholder6"
        Me.placeholder6.Size = New System.Drawing.Size(103, 13)
        Me.placeholder6.TabIndex = 2
        Me.placeholder6.Text = "Launchable Activity:"
        '
        'placeholder5
        '
        Me.placeholder5.AutoSize = True
        Me.placeholder5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.placeholder5.Location = New System.Drawing.Point(423, 40)
        Me.placeholder5.Name = "placeholder5"
        Me.placeholder5.Size = New System.Drawing.Size(104, 13)
        Me.placeholder5.TabIndex = 3
        Me.placeholder5.Text = "Target SDK Version:"
        Me.placeholder5.Visible = False
        '
        'placeholder7
        '
        Me.placeholder7.AutoSize = True
        Me.placeholder7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.placeholder7.Location = New System.Drawing.Point(422, 96)
        Me.placeholder7.Name = "placeholder7"
        Me.placeholder7.Size = New System.Drawing.Size(105, 13)
        Me.placeholder7.TabIndex = 3
        Me.placeholder7.Text = "Supported Densities:"
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblName.Location = New System.Drawing.Point(197, 12)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(219, 16)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "UNKNOWN"
        '
        'lblVerCode
        '
        Me.lblVerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblVerCode.Location = New System.Drawing.Point(197, 68)
        Me.lblVerCode.Name = "lblVerCode"
        Me.lblVerCode.Size = New System.Drawing.Size(219, 16)
        Me.lblVerCode.TabIndex = 2
        Me.lblVerCode.Text = "00"
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblVersion.Location = New System.Drawing.Point(197, 40)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(219, 16)
        Me.lblVersion.TabIndex = 3
        Me.lblVersion.Text = "0.0"
        '
        'lblPackage
        '
        Me.lblPackage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblPackage.Location = New System.Drawing.Point(197, 96)
        Me.lblPackage.Name = "lblPackage"
        Me.lblPackage.Size = New System.Drawing.Size(219, 16)
        Me.lblPackage.TabIndex = 3
        Me.lblPackage.Text = "org.awaisking.unknown"
        '
        'lblSdkVersion
        '
        Me.lblSdkVersion.AutoSize = True
        Me.lblSdkVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblSdkVersion.Location = New System.Drawing.Point(533, 12)
        Me.lblSdkVersion.Name = "lblSdkVersion"
        Me.lblSdkVersion.Size = New System.Drawing.Size(13, 13)
        Me.lblSdkVersion.TabIndex = 2
        Me.lblSdkVersion.Text = "8"
        Me.lblSdkVersion.Visible = False
        '
        'lblTargetSdk
        '
        Me.lblTargetSdk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblTargetSdk.Location = New System.Drawing.Point(533, 40)
        Me.lblTargetSdk.Name = "lblTargetSdk"
        Me.lblTargetSdk.Size = New System.Drawing.Size(231, 16)
        Me.lblTargetSdk.TabIndex = 3
        Me.lblTargetSdk.Text = "21"
        Me.lblTargetSdk.Visible = False
        '
        'lblSuppDens
        '
        Me.lblSuppDens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblSuppDens.Location = New System.Drawing.Point(533, 96)
        Me.lblSuppDens.Name = "lblSuppDens"
        Me.lblSuppDens.Size = New System.Drawing.Size(231, 16)
        Me.lblSuppDens.TabIndex = 3
        Me.lblSuppDens.Text = "120, 160, 240"
        '
        'txtLaunchActivity
        '
        Me.txtLaunchActivity.Location = New System.Drawing.Point(536, 65)
        Me.txtLaunchActivity.Name = "txtLaunchActivity"
        Me.txtLaunchActivity.Size = New System.Drawing.Size(200, 20)
        Me.txtLaunchActivity.TabIndex = 5
        Me.txtLaunchActivity.Text = "org.awaisking.unknown.MainActivity"
        '
        'placeholder8
        '
        Me.placeholder8.AutoSize = True
        Me.placeholder8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.placeholder8.Location = New System.Drawing.Point(426, 123)
        Me.placeholder8.Name = "placeholder8"
        Me.placeholder8.Size = New System.Drawing.Size(101, 13)
        Me.placeholder8.TabIndex = 3
        Me.placeholder8.Text = "Supported Screens:"
        '
        'btnInfoSDK
        '
        Me.btnInfoSDK.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnInfoSDK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInfoSDK.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnInfoSDK.Location = New System.Drawing.Point(742, 7)
        Me.btnInfoSDK.Name = "btnInfoSDK"
        Me.btnInfoSDK.Size = New System.Drawing.Size(22, 22)
        Me.btnInfoSDK.TabIndex = 6
        Me.btnInfoSDK.Text = "?"
        Me.btnInfoSDK.UseVisualStyleBackColor = True
        Me.btnInfoSDK.Visible = False
        '
        'lblSuppScr
        '
        Me.lblSuppScr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblSuppScr.Location = New System.Drawing.Point(533, 123)
        Me.lblSuppScr.Name = "lblSuppScr"
        Me.lblSuppScr.Size = New System.Drawing.Size(231, 16)
        Me.lblSuppScr.TabIndex = 3
        Me.lblSuppScr.Text = "small, normal, large, xlarge"
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.Green
        Me.Button2.Location = New System.Drawing.Point(742, 63)
        Me.Button2.Name = "Button2"
        Me.Button2.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.Button2.Size = New System.Drawing.Size(22, 22)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "►"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(269, 115)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(193, 34)
        Me.btnRemove.TabIndex = 0
        Me.btnRemove.Text = "Un-Install"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'AppInfo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(776, 406)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnInfoSDK)
        Me.Controls.Add(Me.txtLaunchActivity)
        Me.Controls.Add(Me.lbPerms)
        Me.Controls.Add(Me.lblSuppScr)
        Me.Controls.Add(Me.lblSuppDens)
        Me.Controls.Add(Me.lblPackage)
        Me.Controls.Add(Me.placeholder8)
        Me.Controls.Add(Me.placeholder7)
        Me.Controls.Add(Me.placeholder3)
        Me.Controls.Add(Me.lblTargetSdk)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.placeholder5)
        Me.Controls.Add(Me.lblVerCode)
        Me.Controls.Add(Me.placeholder1)
        Me.Controls.Add(Me.lblSdkVersion)
        Me.Controls.Add(Me.placeholder6)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.placeholder2)
        Me.Controls.Add(Me.placeholder4)
        Me.Controls.Add(Me.placeholder0)
        Me.Controls.Add(Me.pbAppIcon)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnInstall)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AppInfo"
        Me.ShowInTaskbar = False
        CType(Me.pbAppIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInstall As System.Windows.Forms.Button
    Friend WithEvents pbAppIcon As System.Windows.Forms.PictureBox
    Friend WithEvents placeholder1 As System.Windows.Forms.Label
    Friend WithEvents placeholder0 As System.Windows.Forms.Label
    Friend WithEvents placeholder2 As System.Windows.Forms.Label
    Friend WithEvents placeholder3 As System.Windows.Forms.Label
    Friend WithEvents lbPerms As System.Windows.Forms.ListBox
    Friend WithEvents placeholder4 As System.Windows.Forms.Label
    Friend WithEvents placeholder6 As System.Windows.Forms.Label
    Friend WithEvents placeholder5 As System.Windows.Forms.Label
    Friend WithEvents placeholder7 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblVerCode As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblPackage As System.Windows.Forms.Label
    Friend WithEvents lblSdkVersion As System.Windows.Forms.Label
    Friend WithEvents lblTargetSdk As System.Windows.Forms.Label
    Friend WithEvents lblSuppDens As System.Windows.Forms.Label
    Friend WithEvents txtLaunchActivity As System.Windows.Forms.TextBox
    Friend WithEvents placeholder8 As System.Windows.Forms.Label
    Friend WithEvents btnInfoSDK As System.Windows.Forms.Button
    Friend WithEvents lblSuppScr As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button

End Class
