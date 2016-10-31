<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Installer
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.clearLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuClrLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tmrProgFix = New System.Windows.Forms.Timer(Me.components)
        Me.bgInstaller = New System.ComponentModel.BackgroundWorker()
        Me.clearLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(625, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(101, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Advanced View"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.ListBox1.ContextMenuStrip = Me.clearLog
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 30)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(714, 420)
        Me.ListBox1.TabIndex = 1
        '
        'clearLog
        '
        Me.clearLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuClrLog})
        Me.clearLog.Name = "clearLog"
        Me.clearLog.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.clearLog.ShowImageMargin = False
        Me.clearLog.Size = New System.Drawing.Size(100, 26)
        Me.clearLog.Text = "Clear Logs"
        '
        'menuClrLog
        '
        Me.menuClrLog.Name = "menuClrLog"
        Me.menuClrLog.Size = New System.Drawing.Size(99, 22)
        Me.menuClrLog.Text = "Clear Logs"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.LightGray
        Me.TextBox1.ContextMenuStrip = Me.clearLog
        Me.TextBox1.Location = New System.Drawing.Point(12, 30)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(714, 420)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "           "
        '
        'tmrProgFix
        '
        Me.tmrProgFix.Enabled = True
        '
        'bgInstaller
        '
        Me.bgInstaller.WorkerSupportsCancellation = True
        '
        'Installer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 462)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Installer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Installer"
        Me.clearLog.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tmrProgFix As System.Windows.Forms.Timer
    Friend WithEvents clearLog As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuClrLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bgInstaller As System.ComponentModel.BackgroundWorker
End Class
