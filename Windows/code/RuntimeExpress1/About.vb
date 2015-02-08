Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net

Public Class About

    Private Sub FeightUpdate()
        Dim UpdateChannel As String = "Developer"

        If UpdateChannel = "Release" Then
            CheckUpdate.Text = "请稍后" '更新按钮上的提示信息

            Const checkserver As String = "https://raw.githubusercontent.com/feight-github/Runtime-Express/master/Windows/version"
            Dim stream As IO.Stream
            Dim sr
            Dim newestver
            '进行一系列的变量/常量定义，以便进行验证操作


            stream = WebRequest.Create(checkserver).GetResponse().GetResponseStream()
            sr = New StreamReader(stream, System.Text.Encoding.UTF8)
            newestver = Regex.Match(sr.ReadToEnd, "[\s\S]{4,5}").ToString
            '使用sr.readtoend读取网页流到末尾，即使用正则表达式从网页流中提取版本号
            '读取网页内容头部分后4和5字节内容，刚好足够版本号使用，然后赋值给变量CheckUpdate

            sr.Dispose() '关闭流

            If newestver = 1482 Then
                CheckUpdate.Text = "已是最新"
            Else
                CheckUpdate.Text = "有新版本"
                If MsgBox("有新的版本：Build " & newestver & vbCrLf & "要现在更新吗？", MsgBoxStyle.Question + _
                MsgBoxStyle.OkCancel, "Runtime Express") = MsgBoxResult.Ok Then
                    System.Diagnostics.Process.Start("http://pan.baidu.com/s/1o6jULke")
                Else : CheckUpdate.Text = "检查更新"
                End If
            End If
            '判断
        ElseIf UpdateChannel = "Developer" Then
            MsgBox("你现在使用的是开发版本，软件更新已禁用。", MsgBoxStyle.Exclamation, "Runtime Express")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles VisitGithub.Click
        Shell("explorer.exe " & " https://github.com/feight-github")
    End Sub

    Private Sub CheckUpdate_Click(sender As Object, e As EventArgs) Handles CheckUpdate.Click
        FeightUpdate()
    End Sub
End Class