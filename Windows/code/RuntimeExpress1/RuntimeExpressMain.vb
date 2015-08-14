'1.全新的数据处理器[2.0]
'1.支持配置文件和专用化部署[2.0]
'3.文件完整性校验[2.0]
'4.日志记录[2.0]

Imports System.Threading

Public Class RuntimeExpressMain

    Public isStartup As Boolean
    Dim UpdateChannel As String = "Developer" '定义当前所使用的软件版本
    Dim checkserver

#Region "更新检查"

    '实例化线程
    Dim UpdateChecker As New Thread(AddressOf FeightUpdate)

    Private Sub FeightUpdate()

        Control.CheckForIllegalCrossThreadCalls = False

        Try

            CheckUpdate.Text = "正在检查"

            Select Case UpdateChannel



                Case "Release"

                    If SourceSelector1.Text <> "" Then
                        checkserver = SourceSelector1.Text
                    Else
                        checkserver = "https://raw.githubusercontent.com/feight-github/Runtime-Express/master/Windows/version.xml"
                    End If

                    Dim doc As New Xml.XmlDocument
                    doc.Load(checkserver.Trim)
                    Dim re As Xml.XmlNodeReader = New Xml.XmlNodeReader(doc)
                    Dim xmlnewestver As String
                    Dim xmlnewestdate As String
                    Dim xmlnewestinfo As String
                    Dim name As String
                    '进行一系列的定义

                    While re.Read

                        Select Case re.NodeType

                            Case Xml.XmlNodeType.Element
                                name = re.Name

                            Case Xml.XmlNodeType.Text
                                If name.Equals("edition") Then
                                    xmlnewestver = re.Value
                                End If

                                If name.Equals("buildtime") Then
                                    xmlnewestdate = re.Value
                                End If

                                If name.Equals("whatsnew") Then
                                    xmlnewestinfo = re.Value
                                End If

                        End Select

                    End While
                    '循环获取服务器端的版本信息

                    If xmlnewestver = My.Application.Info.Version.ToString Then

                        CheckUpdate.Text = "已是最新"

                    Else

                        CheckUpdate.BackColor = Color.LimeGreen
                        CheckUpdate.Text = "有新版本"

                        If MsgBox("检测到新版本：" & xmlnewestver & vbCrLf &
                                   "更新时间：" & xmlnewestdate & vbCrLf &
                                   "更新内容：" & xmlnewestinfo & vbCrLf &
                                   "要更新吗？",
                                    MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "检测到新版本") = MsgBoxResult.Ok _
                                Then Process.Start("http://pan.baidu.com/s/1o6jULke")

                    End If

                Case "Developer"

                    CheckUpdate.BackColor = Color.Gray
                    CheckUpdate.Text = "不可用"

                    If isStartup = False Then MsgBox("你目前处于Developer通道，软件更新不可用。" _
                        , MsgBoxStyle.Exclamation, "Runtime Express")

            End Select

        Catch ex As Exception

            If isStartup = False Then MsgBox("目前无法连接到服务器。请检查你的网络连接，然后再试一次。" _
                , MsgBoxStyle.Critical, "Runtime Express")
            CheckUpdate.Text = "连接错误"
            CheckUpdate.BackColor = Color.Red
            '出于用户考虑没有显示出ex.StackTrace的堆栈信息和ex.Message的信息

        End Try

        '初始化线程以便下次调用
        UpdateChecker = New Thread(AddressOf FeightUpdate)

        isStartup = False

    End Sub

#End Region

    Private Function rexist(ByVal rPath As String) As Boolean

        rexist = System.IO.File.Exists(rPath)

    End Function

    Private Function frexist(ByVal FPath As String) As Boolean

        frexist = System.IO.Directory.Exists(FPath)

    End Function

    Private Sub RuntimeExpressMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        isStartup = True
        Me.Show()

        '重置
        ScreenRE1.SelectedIndex = 0
        DllHelper1.SelectedIndex = 0

        '填充程序自身的信息
        AboutText2.Text = "版本：" & My.Application.Info.Version.ToString & vbCrLf _
            & "更新通道：" & UpdateChannel & vbCrLf _
            & "制作者：Feight"



        '合成环境
        Dim osenvironment = Environment.OSVersion.ToString.Substring(0, 24) & "|" _
                            & System.Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) * 8

        SourceSelector1.SelectedIndex = 0

        Select Case osenvironment

            Case "Microsoft Windows NT 6.0|32"
                ScreenRE1.SelectedIndex = 0

            Case "Microsoft Windows NT 6.0|64"
                ScreenRE1.SelectedIndex = 1

            Case "Microsoft Windows NT 6.1|32"
                ScreenRE1.SelectedIndex = 2

            Case "Microsoft Windows NT 6.1|64"
                ScreenRE1.SelectedIndex = 3

            Case "Microsoft Windows NT 6.2|32"
                ScreenRE1.SelectedIndex = 4

            Case "Microsoft Windows NT 6.2|64"
                ScreenRE1.SelectedIndex = 5

        End Select

        UpdateChecker.Start()


    End Sub

    Private Sub RuntimeExpressMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        UpdateChecker.Abort()

    End Sub

    Private Sub InstNow1_Click(sender As Object, e As EventArgs) Handles InstNow1.Click

        Installer1.RunWorkerAsync()

    End Sub

    Private Sub XNA2_CheckedChanged(sender As Object, e As EventArgs) Handles XNA2.CheckedChanged

        If XNA2.Checked Then
            DX9.Checked = True
            MsgBox("已经自动勾选了所须的DX 9.0c！", MsgBoxStyle.Information, "提示")
        End If

    End Sub

    Private Sub XNA4_CheckedChanged(sender As Object, e As EventArgs) Handles XNA4.CheckedChanged

        If XNA4.Checked Then
            dotnet.Checked = True
            MsgBox("已经自动勾选了所须的.net Framework 4.x！", MsgBoxStyle.Information, "提示")
        End If

    End Sub

    Private Sub ResetStatus() '重置状态的方法

        '
        '重置所有复选框选择状态
        '
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
        VC20151.Checked = False
        VC20152.Checked = False
        Java71.Checked = False
        Java72.Checked = False
        Java81.Checked = False
        Java82.Checked = False
        XNA2.Checked = False
        XNA31.Checked = False
        XNA4.Checked = False
        DX9.Checked = False
        oal203.Checked = False
        mgfw.Checked = False
        mwse.Checked = False
        physx912.Checked = False
        dotnet.Checked = False
        jsharp1.Checked = False
        fsharp1.Checked = False
        msxml1.Checked = False
        msxml2.Checked = False

        '
        '重置所有复选框可用状态
        '
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
        VC20151.Enabled = True
        VC20152.Enabled = True
        Java71.Enabled = True
        Java72.Enabled = True
        Java81.Enabled = True
        Java82.Enabled = True
        XNA2.Enabled = True
        XNA31.Enabled = True
        XNA4.Enabled = True
        DX9.Enabled = True
        oal203.Enabled = True
        mgfw.Enabled = True
        mwse.Enabled = True
        physx912.Enabled = True
        dotnet.Enabled = True
        jsharp1.Enabled = True
        fsharp1.Enabled = True
        msxml1.Enabled = True
        msxml2.Enabled = True

    End Sub

    Private Sub AutoCheck2_Click(sender As Object, e As EventArgs) Handles AutoCheck2.Click

        ResetStatus() '调用方法

        Dim selectedver As String = ScreenRE1.SelectedIndex.ToString.Trim

        '
        '判断语句块：这个系统支持哪些运行库？
        '
        If selectedver = 0 Or selectedver = 2 Or selectedver = 4 Or selectedver = 6 Then
            VC20052.Enabled = False
            VC20082.Enabled = False
            VC20102.Enabled = False
            VC20122.Enabled = False
            VC20132.Enabled = False
            VC20152.Enabled = False
            Java72.Enabled = False
            Java82.Enabled = False
            msxml2.Enabled = False
        End If

        '
        '判断语句块：Windows 8及其以上版本不需要.net 4
        '
        If selectedver = 4 Or selectedver = 5 Or selectedver = 6 Or selectedver = 7 Then
            dotnet.Enabled = False
        End If

        '
        '判断语句块：需要勾选吗？要勾选哪些运行库？
        '      
        If AutoChk1.Checked Then

            '勾选所有系统均需要的运行库
            VC20051.Checked = True
            VC20081.Checked = True
            VC20101.Checked = True
            VC20121.Checked = True
            VC20131.Checked = True
            VC20151.Checked = True
            Java81.Checked = True

            If selectedver = 1 Or selectedver = 3 Or selectedver = 5 Or selectedver = 7 Then
                VC20052.Checked = True
                VC20082.Checked = True
                VC20102.Checked = True
                VC20122.Checked = True
                VC20132.Checked = True
                VC20152.Checked = True
                Java82.Checked = True
                '自动勾选64位Windows所需要的运行库
            End If

        End If

    End Sub

    Private Sub ResetFilter1_Click(sender As Object, e As EventArgs) Handles ResetFilter1.Click

        ResetStatus() '调用方法

    End Sub

    Private Sub DllHelper3_Click(sender As Object, e As EventArgs) Handles DllHelper3.Click
        Dim DllBox As String
        DllBox = DllHelper1.SelectedItem.ToString.Trim
        If DllBox = "d3dx9_**.dll" Then
            MsgBox("看起来需要安装或修复DirectX 9c~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "xinput**.dll" Then
            MsgBox("看起来需要安装或修复DirectX 9c~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "XAudio**.dll" Then
            MsgBox("看起来需要安装或修复DirectX 9c~", MsgBoxStyle.Information, "分析结果")
        ElseIf DllBox = "xactengine*_*.dll" Then
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

        MsgBox("你为什么不问问神奇的度娘呢？", MsgBoxStyle.Information, "Runtime Express")
        Shell("explorer.exe " & " http://www.baidu.com")

    End Sub

    Private Sub Installer1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Installer1.DoWork

        Dim rPath As String = Application.StartupPath
        Dim instErr As Boolean = False
        Dim appflag As Short

        If dotnet.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\dotnet.exe") Then
                System.Diagnostics.Process.Start("uruntime\dotnet.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20051.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2005_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2005_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20052.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2005_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2005_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20081.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2008_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2008_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20082.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2008_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2008_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20101.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2010_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2010_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20102.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2010_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2010_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20131.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2013_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2013_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20132.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2013_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2013_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20151.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2015_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2015_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If VC20152.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\vc2015_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\vc2015_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If Java71.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\jre7_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\jre7_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If Java72.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\jre7_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\jre7_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If Java81.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\jre8_x86.exe") Then
                System.Diagnostics.Process.Start("uruntime\jre8_x86.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If Java82.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\jre8_x64.exe") Then
                System.Diagnostics.Process.Start("uruntime\jre8_x64.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If jsharp1.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\js.exe") Then
                System.Diagnostics.Process.Start("uruntime\js.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If fsharp1.Checked Then
            appflag += 1
            If rexist(rPath & "\uruntime\fs.exe") Then
                System.Diagnostics.Process.Start("uruntime\fs.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If DX9.Checked Then
            appflag += 1
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
            appflag += 1
            If rexist(rPath & "\gruntime\xna20.msi") Then
                System.Diagnostics.Process.Start("gruntime\xna20.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If XNA31.Checked Then
            appflag += 1
            If rexist(rPath & "\gruntime\xna31.msi") Then
                System.Diagnostics.Process.Start("gruntime\xna31.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If XNA4.Checked Then
            appflag += 1
            If rexist(rPath & "\gruntime\xna40.msi") Then
                System.Diagnostics.Process.Start("gruntime\xna40.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If oal203.Checked Then
            appflag += 1
            If rexist(rPath & "\gruntime\openal.exe") Then
                System.Diagnostics.Process.Start("gruntime\openal.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If mgfw.Checked Then
            appflag += 1
            If rexist(rPath & "\gruntime\gfwlive.exe") Then
                System.Diagnostics.Process.Start("gruntime\gfwlive.exe").WaitForExit()
            Else : instErr = True
            End If
        End If

        If physx912.Checked Then
            appflag += 1
            If rexist(rPath & "\gruntime\physx.msi") Then
                System.Diagnostics.Process.Start("gruntime\physx.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If mwse.Checked Then
            appflag += 1
            If rexist(rPath & "\gruntime\mwse3.msi") Then
                System.Diagnostics.Process.Start("gruntime\mwse3.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If msxml1.Checked Then
            appflag += 1
            If rexist(rPath & "\gruntime\msxml6.msi") Then
                System.Diagnostics.Process.Start("gruntime\msxml6.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If msxml2.Checked Then
            appflag += 1
            If rexist(rPath & "\gruntime\msxml6_x64.msi") Then
                System.Diagnostics.Process.Start("gruntime\msxml6_x64.msi").WaitForExit()
            Else : instErr = True
            End If
        End If

        If appflag = 0 Then
            MsgBox("你好像没有勾选任何项，勾选几个试试？", MsgBoxStyle.Information, "Runtime Express")
        Else
            If instErr = False Then
                MsgBox("已经完成指定的操作！可能需要重新启动计算机更改才会生效。", MsgBoxStyle.Information, "Runtime Express")
            Else : MsgBox("有些运行库没有被安装，请检查运行库文件完整性，然后再试一次。", MsgBoxStyle.Critical, "Runtime Express")
            End If
        End If

    End Sub

    Private Sub VisitWebsite_Click(sender As Object, e As EventArgs) Handles VisitWebsite.Click

        Process.Start("http://feight-gh.github.io/Runtime-Express/")

    End Sub

    Private Sub CheckUpdate_Click(sender As Object, e As EventArgs) Handles CheckUpdate.Click

        If UpdateChecker.IsAlive = False Then UpdateChecker.Start()

    End Sub

End Class