Imports System.Threading

Public Class About

    Private Sub About_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        labelAbout.Content = "Runtime Express " & My.Application.Info.Version.ToString
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
