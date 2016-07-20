Imports System.Threading

Class MainWindow

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        Dim osVersion As String = Environment.OSVersion.ToString.Substring(0, 24).ToString
        Dim osTarget As Short = Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) * 8
        Select Case osVersion
            Case "Microsoft Windows NT 6.0"
                cbOSver.SelectedIndex = 0

            Case "Microsoft Windows NT 6.1"
                cbOSver.SelectedIndex = 1

            Case "Microsoft Windows NT 6.2" '以后来补充Windows 10的支持
                cbOSver.SelectedIndex = 2

        End Select

        Select Case osTarget
            Case 32
                cbOStarget.SelectedIndex = 0

            Case 64
                cbOStarget.SelectedIndex = 1

        End Select

        labelStat.Content = "就绪。程序版本" & My.Application.Info.Version.ToString & "。"

    End Sub

    Private Sub btnCheckUpdate_Click(sender As Object, e As RoutedEventArgs) Handles btnCheckUpdate.Click

        Dim up As updater = New updater()
        Dim updateActivity As New Thread(AddressOf up.check)
        updateActivity.Start()

    End Sub

    Private Sub btnHomepage_Click(sender As Object, e As RoutedEventArgs) Handles btnHomepage.Click

        Process.Start("http://feightwywx.github.io/Runtime-Express/")

    End Sub

End Class
