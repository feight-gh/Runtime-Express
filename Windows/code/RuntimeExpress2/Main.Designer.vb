<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.TitleLogo = New System.Windows.Forms.PictureBox()
        Me.Title1 = New System.Windows.Forms.Label()
        Me.Title2 = New System.Windows.Forms.Label()
        Me.RuntimeSelector = New System.Windows.Forms.TreeView()
        Me.RunButton = New System.Windows.Forms.Button()
        Me.UpdateCheckButton = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ShowStatusButton = New System.Windows.Forms.Button()
        Me.FilterGroupBox = New System.Windows.Forms.GroupBox()
        Me.atTargetCombo = New System.Windows.Forms.ComboBox()
        Me.FilteratLibLabel = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.FilteratWinVerLabel = New System.Windows.Forms.Label()
        Me.AllowAutoCheck = New System.Windows.Forms.CheckBox()
        Me.ApplyFilterButton = New System.Windows.Forms.Button()
        Me.atWinVerCombo = New System.Windows.Forms.ComboBox()
        Me.MultiPackageGroupBox = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.UseOnlineDX = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.InfoLabel = New System.Windows.Forms.Label()
        CType(Me.TitleLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FilterGroupBox.SuspendLayout()
        Me.MultiPackageGroupBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleLogo
        '
        Me.TitleLogo.Image = CType(resources.GetObject("TitleLogo.Image"), System.Drawing.Image)
        Me.TitleLogo.Location = New System.Drawing.Point(1, 1)
        Me.TitleLogo.Name = "TitleLogo"
        Me.TitleLogo.Size = New System.Drawing.Size(48, 48)
        Me.TitleLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.TitleLogo.TabIndex = 0
        Me.TitleLogo.TabStop = False
        '
        'Title1
        '
        Me.Title1.Font = New System.Drawing.Font("微软雅黑 Light", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Title1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Title1.Location = New System.Drawing.Point(55, 1)
        Me.Title1.Name = "Title1"
        Me.Title1.Size = New System.Drawing.Size(484, 48)
        Me.Title1.TabIndex = 1
        Me.Title1.Text = "Runtime Express"
        '
        'Title2
        '
        Me.Title2.AutoSize = True
        Me.Title2.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Title2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Title2.Location = New System.Drawing.Point(592, 1)
        Me.Title2.Name = "Title2"
        Me.Title2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Title2.Size = New System.Drawing.Size(136, 20)
        Me.Title2.TabIndex = 2
        Me.Title2.Text = "当前版本：2.0.0.100"
        '
        'RuntimeSelector
        '
        Me.RuntimeSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RuntimeSelector.CheckBoxes = True
        Me.RuntimeSelector.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RuntimeSelector.Location = New System.Drawing.Point(7, 4)
        Me.RuntimeSelector.Name = "RuntimeSelector"
        Me.RuntimeSelector.Size = New System.Drawing.Size(251, 323)
        Me.RuntimeSelector.TabIndex = 0
        '
        'RunButton
        '
        Me.RunButton.BackColor = System.Drawing.Color.DodgerBlue
        Me.RunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RunButton.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RunButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RunButton.Location = New System.Drawing.Point(607, 385)
        Me.RunButton.Name = "RunButton"
        Me.RunButton.Size = New System.Drawing.Size(121, 32)
        Me.RunButton.TabIndex = 4
        Me.RunButton.Text = "应用更改"
        Me.RunButton.UseVisualStyleBackColor = False
        '
        'UpdateCheckButton
        '
        Me.UpdateCheckButton.BackColor = System.Drawing.Color.DodgerBlue
        Me.UpdateCheckButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpdateCheckButton.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.UpdateCheckButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.UpdateCheckButton.Location = New System.Drawing.Point(625, 24)
        Me.UpdateCheckButton.Name = "UpdateCheckButton"
        Me.UpdateCheckButton.Size = New System.Drawing.Size(103, 25)
        Me.UpdateCheckButton.TabIndex = 5
        Me.UpdateCheckButton.Text = "检查更新"
        Me.UpdateCheckButton.UseVisualStyleBackColor = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(5, 384)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(493, 19)
        Me.ProgressBar.TabIndex = 6
        '
        'ShowStatusButton
        '
        Me.ShowStatusButton.BackColor = System.Drawing.Color.Orange
        Me.ShowStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ShowStatusButton.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ShowStatusButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ShowStatusButton.Location = New System.Drawing.Point(504, 385)
        Me.ShowStatusButton.Name = "ShowStatusButton"
        Me.ShowStatusButton.Size = New System.Drawing.Size(97, 32)
        Me.ShowStatusButton.TabIndex = 7
        Me.ShowStatusButton.Text = "概览"
        Me.ShowStatusButton.UseVisualStyleBackColor = False
        '
        'FilterGroupBox
        '
        Me.FilterGroupBox.Controls.Add(Me.atTargetCombo)
        Me.FilterGroupBox.Controls.Add(Me.FilteratLibLabel)
        Me.FilterGroupBox.Controls.Add(Me.ComboBox1)
        Me.FilterGroupBox.Controls.Add(Me.FilteratWinVerLabel)
        Me.FilterGroupBox.Controls.Add(Me.AllowAutoCheck)
        Me.FilterGroupBox.Controls.Add(Me.ApplyFilterButton)
        Me.FilterGroupBox.Controls.Add(Me.atWinVerCombo)
        Me.FilterGroupBox.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FilterGroupBox.Location = New System.Drawing.Point(264, 4)
        Me.FilterGroupBox.Name = "FilterGroupBox"
        Me.FilterGroupBox.Size = New System.Drawing.Size(462, 133)
        Me.FilterGroupBox.TabIndex = 6
        Me.FilterGroupBox.TabStop = False
        Me.FilterGroupBox.Text = "过滤器"
        '
        'atTargetCombo
        '
        Me.atTargetCombo.AutoCompleteCustomSource.AddRange(New String() {"x86", "x64"})
        Me.atTargetCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.atTargetCombo.FormattingEnabled = True
        Me.atTargetCombo.Items.AddRange(New Object() {"x86", "x64"})
        Me.atTargetCombo.Location = New System.Drawing.Point(399, 16)
        Me.atTargetCombo.Name = "atTargetCombo"
        Me.atTargetCombo.Size = New System.Drawing.Size(54, 25)
        Me.atTargetCombo.TabIndex = 14
        '
        'FilteratLibLabel
        '
        Me.FilteratLibLabel.AutoSize = True
        Me.FilteratLibLabel.Location = New System.Drawing.Point(6, 50)
        Me.FilteratLibLabel.Name = "FilteratLibLabel"
        Me.FilteratLibLabel.Size = New System.Drawing.Size(68, 17)
        Me.FilteratLibLabel.TabIndex = 13
        Me.FilteratLibLabel.Text = "根据文件名"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(121, 47)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(335, 25)
        Me.ComboBox1.TabIndex = 12
        '
        'FilteratWinVerLabel
        '
        Me.FilteratWinVerLabel.AutoSize = True
        Me.FilteratWinVerLabel.Location = New System.Drawing.Point(6, 19)
        Me.FilteratWinVerLabel.Name = "FilteratWinVerLabel"
        Me.FilteratWinVerLabel.Size = New System.Drawing.Size(109, 17)
        Me.FilteratWinVerLabel.TabIndex = 11
        Me.FilteratWinVerLabel.Text = "根据Windows版本"
        '
        'AllowAutoCheck
        '
        Me.AllowAutoCheck.AutoSize = True
        Me.AllowAutoCheck.Location = New System.Drawing.Point(195, 102)
        Me.AllowAutoCheck.Name = "AllowAutoCheck"
        Me.AllowAutoCheck.Size = New System.Drawing.Size(99, 21)
        Me.AllowAutoCheck.TabIndex = 10
        Me.AllowAutoCheck.Text = "允许自动勾选"
        Me.AllowAutoCheck.UseVisualStyleBackColor = True
        '
        'ApplyFilterButton
        '
        Me.ApplyFilterButton.Location = New System.Drawing.Point(300, 96)
        Me.ApplyFilterButton.Name = "ApplyFilterButton"
        Me.ApplyFilterButton.Size = New System.Drawing.Size(156, 31)
        Me.ApplyFilterButton.TabIndex = 9
        Me.ApplyFilterButton.Text = "应用"
        Me.ApplyFilterButton.UseVisualStyleBackColor = True
        '
        'atWinVerCombo
        '
        Me.atWinVerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.atWinVerCombo.FormattingEnabled = True
        Me.atWinVerCombo.Items.AddRange(New Object() {"Windows Vista", "Windows 7", "Windows 8/8.1", "Windows 10"})
        Me.atWinVerCombo.Location = New System.Drawing.Point(121, 16)
        Me.atWinVerCombo.Name = "atWinVerCombo"
        Me.atWinVerCombo.Size = New System.Drawing.Size(272, 25)
        Me.atWinVerCombo.TabIndex = 8
        '
        'MultiPackageGroupBox
        '
        Me.MultiPackageGroupBox.Controls.Add(Me.CheckBox1)
        Me.MultiPackageGroupBox.Controls.Add(Me.UseOnlineDX)
        Me.MultiPackageGroupBox.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MultiPackageGroupBox.Location = New System.Drawing.Point(264, 143)
        Me.MultiPackageGroupBox.Name = "MultiPackageGroupBox"
        Me.MultiPackageGroupBox.Size = New System.Drawing.Size(462, 184)
        Me.MultiPackageGroupBox.TabIndex = 7
        Me.MultiPackageGroupBox.TabStop = False
        Me.MultiPackageGroupBox.Text = "安装包选项"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(6, 49)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(409, 21)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "（实验性功能）（Windows 8+）使用WinSxS安装.net Framework 3.5"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'UseOnlineDX
        '
        Me.UseOnlineDX.AutoSize = True
        Me.UseOnlineDX.Location = New System.Drawing.Point(6, 22)
        Me.UseOnlineDX.Name = "UseOnlineDX"
        Me.UseOnlineDX.Size = New System.Drawing.Size(211, 21)
        Me.UseOnlineDX.TabIndex = 0
        Me.UseOnlineDX.Text = "使用在线安装包安装DirecetX 9.0c"
        Me.UseOnlineDX.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Controls.Add(Me.MultiPackageGroupBox)
        Me.Panel1.Controls.Add(Me.FilterGroupBox)
        Me.Panel1.Controls.Add(Me.RuntimeSelector)
        Me.Panel1.Location = New System.Drawing.Point(0, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(729, 330)
        Me.Panel1.TabIndex = 8
        '
        'InfoLabel
        '
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.InfoLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.InfoLabel.Location = New System.Drawing.Point(2, 406)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(128, 17)
        Me.InfoLabel.TabIndex = 9
        Me.InfoLabel.Text = "这里是将会显示的信息"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(729, 421)
        Me.Controls.Add(Me.InfoLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ShowStatusButton)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.UpdateCheckButton)
        Me.Controls.Add(Me.RunButton)
        Me.Controls.Add(Me.Title2)
        Me.Controls.Add(Me.Title1)
        Me.Controls.Add(Me.TitleLogo)
        Me.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Main"
        Me.Text = "Runtime Express"
        CType(Me.TitleLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FilterGroupBox.ResumeLayout(False)
        Me.FilterGroupBox.PerformLayout()
        Me.MultiPackageGroupBox.ResumeLayout(False)
        Me.MultiPackageGroupBox.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TitleLogo As PictureBox
    Friend WithEvents Title1 As Label
    Friend WithEvents Title2 As Label
    Friend WithEvents RunButton As Button
    Friend WithEvents UpdateCheckButton As Button
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents RuntimeSelector As TreeView
    Friend WithEvents ShowStatusButton As Button
    Friend WithEvents FilterGroupBox As GroupBox
    Friend WithEvents AllowAutoCheck As CheckBox
    Friend WithEvents ApplyFilterButton As Button
    Friend WithEvents atWinVerCombo As ComboBox
    Friend WithEvents MultiPackageGroupBox As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents UseOnlineDX As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents FilteratLibLabel As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents FilteratWinVerLabel As Label
    Friend WithEvents atTargetCombo As ComboBox
    Friend WithEvents InfoLabel As Label
End Class
