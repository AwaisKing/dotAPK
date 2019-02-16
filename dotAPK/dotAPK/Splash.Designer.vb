<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Splash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Splash))
        Me.pbdotAPK = New System.Windows.Forms.PictureBox()
        Me.tmrSlider = New System.Windows.Forms.Timer(Me.components)
        Me.splashIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.tmrProgress = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.pbdotAPK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbdotAPK
        '
        Me.pbdotAPK.BackColor = System.Drawing.SystemColors.Control
        Me.pbdotAPK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbdotAPK.InitialImage = Nothing
        Me.pbdotAPK.Location = New System.Drawing.Point(12, 12)
        Me.pbdotAPK.Name = "pbdotAPK"
        Me.pbdotAPK.Size = New System.Drawing.Size(128, 128)
        Me.pbdotAPK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbdotAPK.TabIndex = 1
        Me.pbdotAPK.TabStop = False
        '
        'tmrSlider
        '
        Me.tmrSlider.Interval = 20
        '
        'splashIcons
        '
        Me.splashIcons.ImageStream = CType(resources.GetObject("splashIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.splashIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.splashIcons.Images.SetKeyName(0, "0")
        Me.splashIcons.Images.SetKeyName(1, "1")
        Me.splashIcons.Images.SetKeyName(2, "2")
        Me.splashIcons.Images.SetKeyName(3, "3")
        Me.splashIcons.Images.SetKeyName(4, "4")
        Me.splashIcons.Images.SetKeyName(5, "5")
        Me.splashIcons.Images.SetKeyName(6, "6")
        Me.splashIcons.Images.SetKeyName(7, "7")
        Me.splashIcons.Images.SetKeyName(8, "8")
        Me.splashIcons.Images.SetKeyName(9, "9")
        '
        'tmrProgress
        '
        Me.tmrProgress.Enabled = True
        Me.tmrProgress.Interval = 5
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 146)
        Me.ProgressBar1.Maximum = 250
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(152, 13)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 0
        '
        'Splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(152, 160)
        Me.ControlBox = False
        Me.Controls.Add(Me.pbdotAPK)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Splash"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.pbdotAPK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbdotAPK As System.Windows.Forms.PictureBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents tmrSlider As Timer
    Private WithEvents splashIcons As ImageList
    Private WithEvents tmrProgress As Timer
End Class
