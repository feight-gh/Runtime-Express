Imports System.Diagnostics.FileVersionInfo

Public Class Main

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load

        Show()

        ProgressBar.Style = ProgressBarStyle.Marquee '指示初始化进度
        InfoLabel.Text = "应用程序初始化"
        init()
        ProgressBar.Style = ProgressBarStyle.Blocks '初始化完成

    End Sub

    Private Sub init()

        Dim osver As String = My.Computer.Info.OSVersion.Substring(0, 3) '获取NT主要版本号
        Dim is64bit As Boolean = Environment.Is64BitOperatingSystem '获取是否为64位
        Dim osfullname As String = My.Computer.Info.OSFullName '获取全名
        Dim osbit As String
        If is64bit = True Then
            osbit = "64位"
        Else osbit = "32位"
        End If

        Select Case osver

            Case "6.0"
                atWinVerCombo.SelectedIndex = 0

            Case "6.1"
                atWinVerCombo.SelectedIndex = 1

            Case "6.2"
                If osfullname.Substring(0, 20) = "Microsoft Windows 10" Then
                    atWinVerCombo.SelectedIndex = 3
                Else
                    atWinVerCombo.SelectedIndex = 2
                End If

            Case Else
                atWinVerCombo.SelectedIndex = 0

        End Select

        If is64bit = False Then
            atTargetCombo.SelectedIndex = 0
        ElseIf is64bit = True Then
            atTargetCombo.SelectedIndex = 1
        End If

        InfoLabel.Text = osfullname & " " & osbit

    End Sub

End Class
