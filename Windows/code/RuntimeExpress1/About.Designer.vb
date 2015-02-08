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
        Me.AboutText1 = New System.Windows.Forms.Label()
        Me.AboutText2 = New System.Windows.Forms.Label()
        Me.CheckUpdate = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.VisitGithub = New System.Windows.Forms.Button()
        Me.CpoyrightText = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AboutText1
        '
        Me.AboutText1.BackColor = System.Drawing.Color.Transparent
        Me.AboutText1.Font = New System.Drawing.Font("微软雅黑 Light", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(134, Byte))
        Me.AboutText1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.AboutText1.Location = New System.Drawing.Point(10, 12)
        Me.AboutText1.Name = "AboutText1"
        Me.AboutText1.Size = New System.Drawing.Size(589, 45)
        Me.AboutText1.TabIndex = 1
        Me.AboutText1.Text = "Runtime Express（Developer）"
        Me.AboutText1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AboutText2
        '
        Me.AboutText2.AutoSize = True
        Me.AboutText2.BackColor = System.Drawing.Color.Transparent
        Me.AboutText2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AboutText2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.AboutText2.Location = New System.Drawing.Point(12, 54)
        Me.AboutText2.Name = "AboutText2"
        Me.AboutText2.Size = New System.Drawing.Size(191, 42)
        Me.AboutText2.TabIndex = 2
        Me.AboutText2.Text = "版本：1.5-dev5（1521）" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "编译日期：2015-2-8"
        '
        'CheckUpdate
        '
        Me.CheckUpdate.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.CheckUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckUpdate.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckUpdate.ForeColor = System.Drawing.Color.Transparent
        Me.CheckUpdate.Location = New System.Drawing.Point(459, 295)
        Me.CheckUpdate.Name = "CheckUpdate"
        Me.CheckUpdate.Size = New System.Drawing.Size(140, 37)
        Me.CheckUpdate.TabIndex = 5
        Me.CheckUpdate.Text = "检查更新"
        Me.CheckUpdate.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(510, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(89, 89)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'VisitGithub
        '
        Me.VisitGithub.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.VisitGithub.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.VisitGithub.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.VisitGithub.ForeColor = System.Drawing.Color.Transparent
        Me.VisitGithub.Location = New System.Drawing.Point(313, 295)
        Me.VisitGithub.Name = "VisitGithub"
        Me.VisitGithub.Size = New System.Drawing.Size(140, 37)
        Me.VisitGithub.TabIndex = 8
        Me.VisitGithub.Text = "转到 Github"
        Me.VisitGithub.UseVisualStyleBackColor = False
        '
        'CpoyrightText
        '
        Me.CpoyrightText.BackColor = System.Drawing.Color.Transparent
        Me.CpoyrightText.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CpoyrightText.ForeColor = System.Drawing.Color.White
        Me.CpoyrightText.Location = New System.Drawing.Point(12, 248)
        Me.CpoyrightText.Name = "CpoyrightText"
        Me.CpoyrightText.Size = New System.Drawing.Size(568, 87)
        Me.CpoyrightText.TabIndex = 9
        Me.CpoyrightText.Text = "使用Visual Basic 2013开发。基于.net Framework 3.5.1。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "禁止在未注明来源的情况下散布。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "本应用程序包括其图标，背景图片版权" & _
    "归Feight所有。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "©Feight Software 2015,All rights reserved."
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(611, 344)
        Me.Controls.Add(Me.VisitGithub)
        Me.Controls.Add(Me.CheckUpdate)
        Me.Controls.Add(Me.CpoyrightText)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.AboutText2)
        Me.Controls.Add(Me.AboutText1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "关于 Runtime Express"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AboutText1 As System.Windows.Forms.Label
    Friend WithEvents AboutText2 As System.Windows.Forms.Label
    Friend WithEvents CheckUpdate As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents VisitGithub As System.Windows.Forms.Button
    Friend WithEvents CpoyrightText As System.Windows.Forms.Label
End Class
