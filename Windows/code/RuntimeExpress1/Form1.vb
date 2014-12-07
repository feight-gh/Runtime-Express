'下次更新内容
'1.更新器
'2.语言

Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1


    Private Function rexist(ByVal Str_Path As String) As Boolean
        rexist = System.IO.File.Exists(Str_Path)
    End Function

    Private Function frexist(ByVal FPath As String) As Boolean
        frexist = System.IO.Directory.Exists(FPath)
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        ScreenRE1.SelectedIndex = 0
        DllHelper1.SelectedIndex = 0

    End Sub

    Private Sub InstNow1_Click(sender As Object, e As EventArgs) Handles InstNow1.Click
        Installer1.RunWorkerAsync()
    End Sub

    Private Sub XNA2_CheckedChanged(sender As Object, e As EventArgs) Handles XNA2.CheckedChanged
        If XNA2.Checked Then
            DX9.Checked = True
            MsgBox("已经自动勾选了所须的DX 9.0c！", MsgBoxStyle.Exclamation, "提示")
        End If
    End Sub

    Private Sub XNA4_CheckedChanged(sender As Object, e As EventArgs) Handles XNA4.CheckedChanged
        If XNA4.Checked Then
            dotnet.Checked = True
            MsgBox("已经自动勾选了所须的.net Framework 4.5.2！", MsgBoxStyle.Exclamation, "提示")
        End If
    End Sub

    Private Sub AutoCheck2_Click(sender As Object, e As EventArgs) Handles AutoCheck2.Click
        '重置复选框状态
        VC20051.Checked = False
        VC20052.Checked = False
        VC20081.Checked = False
        VC20082.Checked = False
        VC20101.Checked = False
        VC20102.Checked = False
        VC20121.Checked = False
        VC20122.Checked = False
        VC20131.Checked = False
        VC20132.Checked = False
        Java71.Checked = False
        Java72.Checked = False
        XNA2.Checked = False
        XNA31.Checked = False
        XNA4.Checked = False
        DX9.Checked = False
        oal203.Checked = False
        mgfw.Checked = False
        mwse.Checked = False
        physx912.Checked = False
        '重置所有复选框选择状态
        VC20051.Enabled = True
        VC20052.Enabled = True
        VC20081.Enabled = True
        VC20082.Enabled = True
        VC20101.Enabled = True
        VC20102.Enabled = True
        VC20121.Enabled = True
        VC20122.Enabled = True
        VC20131.Enabled = True
        VC20132.Enabled = True
        Java71.Enabled = True
        Java72.Enabled = True
        XNA2.Enabled = True
        XNA31.Enabled = True
        XNA4.Enabled = True
        DX9.Enabled = True
        oal203.Enabled = True
        mgfw.Enabled = True
        mwse.Enabled = True
        physx912.Enabled = True
        '重置所有复选框可用状态

        Dim OSver As String
        OSver = ScreenRE1.SelectedItem.ToString.Trim

        '判断语句块：这个系统支持哪些运行库？
        If OSver = "Windows Vista x86" Then
            VC20051.Enabled = True
            VC20052.Enabled = False
            VC20081.Enabled = True
            VC20082.Enabled = False
            VC20101.Enabled = True
            VC20102.Enabled = False
            VC20121.Enabled = True
            VC20122.Enabled = False
            VC20131.Enabled = True
            VC20132.Enabled = False
            Java71.Enabled = True
            Java72.Enabled = False
            msxml1.Enabled = True
            msxml2.Enabled = False
            '禁用不适合的选项
        ElseIf OSver = "Windows Vista x64" Then
            VC20051.Enabled = True
            VC20052.Enabled = True
            VC20081.Enabled = True
            VC20082.Enabled = True
            VC20101.Enabled = True
            VC20102.Enabled = True
            VC20121.Enabled = True
            VC20122.Enabled = True
            VC20131.Enabled = True
            VC20132.Enabled = True
            Java71.Enabled = True
            Java72.Enabled = False
            msxml1.Enabled = True
            msxml2.Enabled = False
            '禁用不适合的选项
        ElseIf OSver = "Windows 7 x86" Then
            VC20051.Enabled = True
            VC20052.Enabled = False
            VC20081.Enabled = True
            VC20082.Enabled = False
            VC20101.Enabled = True
            VC20102.Enabled = False
            VC20121.Enabled = True
            VC20122.Enabled = False
            VC20131.Enabled = True
            VC20132.Enabled = False
            Java71.Enabled = True
            Java72.Enabled = False
            msxml1.Enabled = True
            msxml2.Enabled = False
            '禁用不适合的选项
        ElseIf OSver = "Windows 7 x64" Then
            VC20051.Enabled = True
            VC20052.Enabled = True
            VC20081.Enabled = True
            VC20082.Enabled = True
            VC20101.Enabled = True
            VC20102.Enabled = True
            VC20121.Enabled = True
            VC20122.Enabled = True
            VC20131.Enabled = True
            VC20132.Enabled = True
            Java71.Enabled = True
            Java72.Enabled = False
            msxml1.Enabled = True
            msxml2.Enabled = False
            '禁用不适合的选项
        ElseIf OSver = "Windows 8/8.1 x86" Then
            VC20051.Enabled = True
            VC20052.Enabled = False
            VC20081.Enabled = True
            VC20082.Enabled = False
            VC20101.Enabled = True
            VC20102.Enabled = False
            VC20121.Enabled = True
            VC20122.Enabled = False
            VC20131.Enabled = True
            VC20132.Enabled = False
            Java71.Enabled = True
            Java72.Enabled = False
            msxml1.Enabled = True
            msxml2.Enabled = False
            '禁用不适合的选项
        ElseIf OSver = "Windows 8/8.1 x64" Then
            VC20051.Enabled = True
            VC20052.Enabled = True
            VC20081.Enabled = True
            VC20082.Enabled = True
            VC20101.Enabled = True
            VC20102.Enabled = True
            VC20121.Enabled = True
            VC20122.Enabled = True
            VC20131.Enabled = True
            VC20132.Enabled = True
            Java71.Enabled = True
            Java72.Enabled = True
            msxml1.Enabled = True
            msxml2.Enabled = True
            '禁用不适合的选项
        End If

        '判断语句块：需要勾选吗？要勾选哪些运行库？
        If AutoChk1.Checked Then
            If OSver = "Windows Vista x86" Then
                VC20051.Checked = True
                VC20052.Checked = False
                VC20081.Checked = True
                VC20082.Checked = False
                VC20101.Checked = True
                VC20102.Checked = False
                VC20121.Checked = True
                VC20122.Checked = False
                VC20131.Checked = False
                VC20132.Checked = False
                Java71.Checked = True
                Java72.Checked = False
                '自动勾选
            ElseIf OSver = "Windows Vista x64" Then
                VC20051.Checked = True
                VC20052.Checked = True
                VC20081.Checked = True
                VC20082.Checked = True
                VC20101.Checked = True
                VC20102.Checked = True
                VC20121.Checked = True
                VC20122.Checked = True
                VC20131.Checked = False
                VC20132.Checked = False
                Java71.Checked = True
                Java72.Checked = False
                '自动勾选
            ElseIf OSver = "Windows 7 x86" Then
                VC20051.Checked = True
                VC20052.Checked = False
                VC20081.Checked = True
                VC20082.Checked = False
                VC20101.Checked = True
                VC20102.Checked = False
                VC20121.Checked = True
                VC20122.Checked = False
                VC20131.Checked = False
                VC20132.Checked = False
                Java71.Checked = True
                Java72.Checked = False
                '自动勾选
            ElseIf OSver = "Windows 7 x64" Then
                VC20051.Checked = True
                VC20052.Checked = True
                VC20081.Checked = True
                VC20082.Checked = True
                VC20101.Checked = True
                VC20102.Checked = True
                VC20121.Checked = True
                VC20122.Checked = True
                VC20131.Checked = False
                VC20132.Checked = False
                Java71.Checked = True
                Java72.Checked = False
                '自动勾选
            ElseIf OSver = "Windows 8/8.1 x86" Then
                VC20051.Checked = True
                VC20052.Checked = False
                VC20081.Checked = True
                VC20082.Checked = False
                VC20101.Checked = True
                VC20102.Checked = False
                VC20121.Checked = True
                VC20122.Checked = False
                VC20131.Checked = False
                VC20132.Checked = False
                Java71.Checked = True
                Java72.Checked = False
                '自动勾选
            ElseIf OSver = "Windows 8/8.1 x64" Then
                VC20051.Checked = True
                VC20052.Checked = True
                VC20081.Checked = True
                VC20082.Checked = True
                VC20101.Checked = True
                VC20102.Checked = True
                VC20121.Checked = True
                VC20122.Checked = True
                VC20131.Checked = False
                VC20132.Checked = False
                Java71.Checked = True
                Java72.Checked = False
                '自动勾选
            Else
                MsgBox("请选择一个选项")
            End If
        End If
    End Sub

    Private Sub DllHelper3_Click(sender As Object, e As EventArgs) Handles DllHelper3.Click
        Dim DllBox As String
        DllBox = DllHelper1.SelectedItem.ToString.Trim
        'xactengine**.dll
        If DllBox = "d3dx9_**.dll" Then
            MsgBox("看起来需要安装或修复DirectX 9c~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "xinput**.dll" Then
            MsgBox("看起来需要安装或修复DirectX 9c~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "XAudio**.dll" Then
            MsgBox("看起来需要安装或修复DirectX 9c~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "xactengine**.dll" Then
            MsgBox("看起来需要安装或修复DirectX 9c~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "MSVC**.dll" Then
            MsgBox("看起来需要安装或修复VC++运行库~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "openal32.dll" Then
            MsgBox("看起来需要安装或修复OpenAL~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "PhysXLoader.dll" Then
            MsgBox("看起来需要安装或修复PhysX驱动~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "xlive.dll" Then
            MsgBox("看起来需要安装或修复MGFW~", MsgBoxStyle.Information, "分析结果")
        End If

    End Sub

    Private Sub DllHelper2_Click(sender As Object, e As EventArgs) Handles DllHelper2.Click
        MsgBox("Google大法好，删RE保平安", MsgBoxStyle.Exclamation, "Runtime Express")
        Shell("explorer.exe " & " https://www.google.com.hk")
    End Sub

    Private Sub Installer1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Installer1.DoWork
        Dim rPath As String = Application.StartupPath
        Dim instErr As Boolean = False

        If dotnet.Checked Then
            If rexist(rPath & "\uruntime\dotnet.exe") Then
                System.Diagnostics.Process.Start("uruntime\dotnet.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20051.Checked Then
            If rexist(rPath & "\uruntime\vc2005_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2005_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20051.Checked Then
            If rexist(rPath & "\uruntime\vc2005_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2005_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20052.Checked Then
            If rexist(rPath & "\uruntime\vc2005_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2005_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20081.Checked Then
            If rexist(rPath & "\uruntime\vc2008_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2008_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20082.Checked Then
            If rexist(rPath & "\uruntime\vc2008_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2005_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20101.Checked Then
            If rexist(rPath & "\uruntime\vc2010_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2010_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20102.Checked Then
            If rexist(rPath & "\uruntime\vc2010_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2010_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20131.Checked Then
            If rexist(rPath & "\uruntime\vc2013_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2013_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20132.Checked Then
            If rexist(rPath & "\uruntime\vc2013_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2013_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If Java71.Checked Then
            If rexist(rPath & "\uruntime\jre7_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\jre7_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If Java72.Checked Then
            If rexist(rPath & "\uruntime\jre7_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\jre7_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If jsharp1.Checked Then
            If rexist(rPath & "\uruntime\js.exe") Then
                System.Diagnostics.Process.Start("uruntime\js.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If fsharp1.Checked Then
            If rexist(rPath & "\uruntime\fs.exe") Then
                System.Diagnostics.Process.Start("uruntime\fs.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If DX9.Checked Then
            If dxolmode.Checked Then
                If rexist(rPath & "\gruntime\dxwebsetup.exe") Then
                    System.Diagnostics.Process.Start("gruntime\dxwebsetup.exe").WaitForExit()
                Else : instErr = True
                End If
            Else
                If rexist(rPath & "\gruntime\DX\DXSETUP.exe") Then
                    System.Diagnostics.Process.Start("gruntime\DX\DXSETUP.exe").WaitForExit()
                Else : instErr = True
                End If
            End If
        End If

        If XNA2.Checked Then
            If rexist(rPath & "\gruntime\xna20.msi") Then
                System.Diagnostics.Process.Start("gruntime\xna20.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If XNA31.Checked Then
            If rexist(rPath & "\gruntime\xna31.msi") Then
                System.Diagnostics.Process.Start("gruntime\xna31.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If XNA4.Checked Then
            If rexist(rPath & "\gruntime\xna40.msi") Then
                System.Diagnostics.Process.Start("gruntime\xna40.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If oal203.Checked Then
            If rexist(rPath & "\gruntime\openal.exe") Then
                System.Diagnostics.Process.Start("gruntime\openal.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If mgfw.Checked Then
            If rexist(rPath & "\gruntime\gfwlive.exe") Then
                System.Diagnostics.Process.Start("gruntime\gfwlive.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If physx912.Checked Then
            If rexist(rPath & "\gruntime\physx.msi") Then
                System.Diagnostics.Process.Start("gruntime\physx.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If mwse.Checked Then
            If rexist(rPath & "\gruntime\mwse3.msi") Then
                System.Diagnostics.Process.Start("gruntime\mwse3.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If msxml1.Checked Then
            If rexist(rPath & "\gruntime\msxml6.msi") Then
                System.Diagnostics.Process.Start("gruntime\msxml6.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If msxml2.Checked Then
            If rexist(rPath & "\gruntime\msxml6_x64.msi") Then
                System.Diagnostics.Process.Start("gruntime\msxml6_x64.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If instErr = False Then
            MsgBox("已经完成指定的操作！可能需要重新启动计算机更改才会生效。", MsgBoxStyle.Information, "提示")
        Else : MsgBox("有些运行库没有被安装，请检查运行库文件完整性，然后再试一次。", MsgBoxStyle.Critical, "提示")
        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CheckUpdate.Click
        CheckUpdate.Text = "请稍后" '更新按钮上的提示信息

        Const checkserver As String = "https://raw.githubusercontent.com/feight-github/Runtime-Express/master/Windows/version"
        Dim stream As IO.Stream
        Dim sr
        Dim newestver
        '进行一系列的变量/常量定义，以便进行验证操作


        stream = WebRequest.Create(checkserver).GetResponse().GetResponseStream()
        sr = New StreamReader(stream, System.Text.Encoding.UTF8)
        newestver = Regex.Match(sr.ReadToEnd, "[\s\S]{4,5}").ToString
        '使用sr.readtoend读取网页流到末尾，即使用正则表达式从网页流中提取布尔值
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



    End Sub
End Class