Imports System.Threading

Public Class About

    Private Sub About_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        labelVersion.Content = My.Application.Info.Version.ToString
    End Sub

    Private Sub btnCheckUpdate_Click(sender As Object, e As RoutedEventArgs) Handles btnCheckUpdate.Click

        Dim up As updater = New updater()
        Dim updateActivity As New Thread(AddressOf up.check)
        updateActivity.Start()

        If up.isNewest = False Then labelVersion.Content = My.Application.Info.Version.ToString & "（有新版本）"

    End Sub

    Private Sub btnHomepage_Click(sender As Object, e As RoutedEventArgs) Handles btnHomepage.Click

        Process.Start("https://feightwywx.github.io/Runtime-Express/")

    End Sub

End Class
