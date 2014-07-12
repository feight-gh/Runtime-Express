<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.AboutUs = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'AboutUs
        '
        Me.AboutUs.BackColor = System.Drawing.Color.Indigo
        Me.AboutUs.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AboutUs.ForeColor = System.Drawing.Color.Gold
        Me.AboutUs.Location = New System.Drawing.Point(0, 0)
        Me.AboutUs.Multiline = True
        Me.AboutUs.Name = "AboutUs"
        Me.AboutUs.ReadOnly = True
        Me.AboutUs.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AboutUs.Size = New System.Drawing.Size(285, 263)
        Me.AboutUs.TabIndex = 1
        Me.AboutUs.TabStop = False
        Me.AboutUs.Text = resources.GetString("AboutUs.Text")
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.AboutUs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "About"
        Me.Text = "关于 Runtime Express"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AboutUs As System.Windows.Forms.TextBox
End Class
