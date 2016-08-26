Class MainWindow

    Private Const countTotal As Integer = 39
    Private selectStatus(countTotal) As Boolean
    Public path As String = My.Application.Info.DirectoryPath
    Public sys32path As String = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)
    Public syspath As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
    Public winpath As String = Environment.GetFolderPath(Environment.SpecialFolder.Windows)


    Private Sub fetchAll()

        For rei = 0 To listBoxRt.Items.Count - 1 '重置所有项已存储的状态

            selectStatus(rei) = False

        Next

        '循环获取勾选项的代码段
        For i = 0 To listBoxRt.Items.Count - 1

            If i <> 0 And i <> 13 And i <> 14 And i <> 18 And i <> 19 And i <> 24 And i <> 25 And i <> 29 And
                    i <> 30 And i <> 33 And i <> 34 Then
                If listBoxRt.Items.Item(i).IsChecked = True And listBoxRt.Items.Item(i).IsEnabled = True Then
                    selectStatus(i) = True

                End If

            End If

        Next i

    End Sub

    Private Sub cleanAll()


        For rei = 0 To listBoxRt.Items.Count - 1 '重置所有项已存储的状态
            selectStatus(rei) = False

        Next rei

        For i = 0 To listBoxRt.Items.Count - 1
            If i <> 0 And i <> 13 And i <> 14 And i <> 18 And i <> 19 And i <> 24 And i <> 25 And i <> 29 And
                    i <> 30 And i <> 33 And i <> 34 Then
                listBoxRt.Items.Item(i).IsChecked = False
                listBoxRt.Items.Item(i).IsEnabled = True

            End If

        Next i

    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        Dim osVersion As String = Environment.OSVersion.ToString.Substring(0, 24)
        Dim osTarget As Integer = Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) * 8
        Dim osFullname As String = My.Computer.Info.OSFullName.ToString.Substring(0, 20)
        Select Case osVersion '检查OSVersion
            Case "Microsoft Windows NT 6.0"
                cbOSver.SelectedIndex = 0

            Case "Microsoft Windows NT 6.1"
                cbOSver.SelectedIndex = 1

            Case "Microsoft Windows NT 6.2"
                If osFullname = "Microsoft Windows 10" Then '检查OSFullname
                    cbOSver.SelectedIndex = 3
                Else
                    cbOSver.SelectedIndex = 2
                End If

        End Select

        Select Case osTarget
            Case 32
                cbOStarget.SelectedIndex = 0

            Case 64
                cbOStarget.SelectedIndex = 1

        End Select



        labelStat.Content = "就绪。程序版本" & My.Application.Info.Version.ToString & "。"

    End Sub

    Private Sub btnAutochk_Click(sender As Object, e As RoutedEventArgs) Handles btnAutochk.Click

        cleanAll()

        Select Case cbOStarget.SelectedIndex
            Case 0 '32位判断块
                ck2005x64.IsEnabled = False
                ck2008x64.IsEnabled = False
                ck2010x64.IsEnabled = False
                ck2012x64.IsEnabled = False
                ck2013x64.IsEnabled = False
                ck2015x64.IsEnabled = False
                ckjre7x64.IsEnabled = False
                ckjre8x64.IsEnabled = False
                ckxmlc6x64.IsEnabled = False

                '查找VC++ 2005/2008（WinSxS索引）
                If ckSmart.IsChecked = True Then
                    If IO.Directory.Exists(winpath & "\winsxs\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.4940_none_d08cc06a442b34fc") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.6195_none_d09154e044272b9a") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.762_none_10b2f55f9bffb8f8") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.8428_none_d08a11e2442dc25d") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.91_none_db5f5c9d98cb161f") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.9268_none_d08e1538442a243e") = False Then
                        ck2005x86.IsChecked = True
                    End If

                    If IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.1_none_e163563597edeada") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4148_none_5090ab56bcba71c2") = False And
                        IO.Directory.Exists(winpath & "\winsxs\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4940_none_50916076bcb9a742") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.6161_none_50934f2ebcb7eb57") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.8387_none_5094ca96bcb6b2bb") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.9247_none_5090cb78bcba4a35") = False Then
                        ck2008x86.IsChecked = True
                    End If

                    '查找VC++ 2010/2012/2013/2015
                    If IO.File.Exists(syspath & "\msvcp100.dll") = False Then ck2010x86.IsChecked = True
                    If IO.File.Exists(syspath & "\msvcp110.dll") = False Then ck2012x86.IsChecked = True
                    If IO.File.Exists(syspath & "\msvcp120.dll") = False Then ck2013x86.IsChecked = True
                    If IO.File.Exists(syspath & "\msvcp140.dll") = False Then ck2015x86.IsChecked = True

                End If

            Case 1 '64位判断块
                If ckSmart.IsChecked = True Then
                    '查找VC++ 2005/2008（WinSxS索引）
                    If IO.Directory.Exists(winpath & "\winsxs\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.4940_none_d08cc06a442b34fc") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.6195_none_d09154e044272b9a") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.762_none_10b2f55f9bffb8f8") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.8428_none_d08a11e2442dc25d") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.91_none_db5f5c9d98cb161f") = False AndAlso
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.9268_none_d08e1538442a243e") = False Then
                        ck2005x86.IsChecked = True
                    End If

                    If IO.Directory.Exists(winpath & "\winsxs\amd64_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.4940_none_88df89932faf0bf6") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.762_none_c905be8887838ff2") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.8428_none_88dcdb0b2fb19957") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.9268_none_88e0de612fadfb38") = False Then
                        ck2005x64.IsChecked = True
                    End If

                    If IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.1_none_e163563597edeada") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4148_none_5090ab56bcba71c2") = False And
                        IO.Directory.Exists(winpath & "\winsxs\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4940_none_50916076bcb9a742") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.6161_none_50934f2ebcb7eb57") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.8387_none_5094ca96bcb6b2bb") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.9247_none_5090cb78bcba4a35") = False Then
                        ck2008x86.IsChecked = True
                    End If

                    If IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.1_none_99b61f5e8371c1d4") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4148_none_08e3747fa83e48bc") = False And
                        IO.Directory.Exists(winpath & "\winsxs\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4940_none_08e4299fa83d7e3c") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.6161_none_08e61857a83bc251") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.8387_none_08e793bfa83a89b5") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.9247_none_08e394a1a83e212f") = False Then
                        ck2008x64.IsChecked = True
                    End If

                    '查找VC++ 2010/2012/2013/2015
                    If IO.File.Exists(sys32path & "\msvcp100.dll") = False Then ck2010x86.IsChecked = True
                    If IO.File.Exists(syspath & "\msvcr100.dll") = False Then ck2010x64.IsChecked = True
                    If IO.File.Exists(sys32path & "\msvcp110.dll") = False Then ck2012x86.IsChecked = True
                    If IO.File.Exists(syspath & "\msvcr110.dll") = False Then ck2012x64.IsChecked = True
                    If IO.File.Exists(sys32path & "\msvcp120.dll") = False Then ck2013x86.IsChecked = True
                    If IO.File.Exists(syspath & "\msvcr120.dll") = False Then ck2013x64.IsChecked = True
                    If IO.File.Exists(sys32path & "\msvcp140.dll") = False Then ck2015x86.IsChecked = True
                    If IO.File.Exists(syspath & "\msvcp140.dll") = False Then ck2015x64.IsChecked = True

                End If

        End Select

    End Sub

    Private Sub btnOverview_Click(sender As Object, e As RoutedEventArgs) Handles btnOverview.Click

        fetchAll()
        Dim listRt As String = Nothing

        For i = 0 To countTotal
            If selectStatus(i) = True And i <> 0 And i <> 13 And i <> 14 And i <> 18 And i <> 19 And i <> 24 And
                i <> 25 And i <> 29 And i <> 30 And i <> 33 And i <> 34 Then
                listRt &= listBoxRt.Items.Item(i).Content & vbCrLf

            End If

        Next

        MsgBox("目前已勾选的有：" & vbCrLf & listRt, MsgBoxStyle.Information, "Runtime Express 概览")

    End Sub

    Private Sub btnApply_Click(sender As Object, e As RoutedEventArgs) Handles btnApply.Click

        '获取管理员权限
        If My.Computer.Info.OSVersion.Substring(0, 1) >= 6 Then
            Dim psi As New ProcessStartInfo()
            psi.FileName = path & "\" & My.Application.Info.AssemblyName & ".exe"
            psi.Verb = "runas"
            Try
                Process.Start(psi)
                My.Application.Shutdown()

            Catch ex As Exception
                'MessageBox.Show(ex.Message)

            End Try

        End If

        fetchAll()

        Dim rtsrc(countTotal) '定义安装源
        rtsrc = {
            "", '0 Microsoft Visual C++ 
            "\sources\vc2005_x86.exe", "\sources\vc2005_x64.exe", "\sources\vc2008_x86.exe", "\sources\vc2008_x64.exe", "\sources\vc2010_x86.exe", '1-5
            "\sources\vc2010_x64.exe", "\sources\vc2012_x86.exe", "\sources\vc2012_x64.exe", "\sources\vc2013_x86.exe", "\sources\vc2013_x64.exe", '6-10
            "\sources\vc2015_x86.exe", "\sources\vc2015_x64.exe", '11-12
            "", "", '13-14 Microsoft .NET
            "\sources\dotnet.exe", "\sources\jsharp.exe", "\sources\fsharp.exe", '15-17
            "", "", '18-19 Oracle Java
            "\sources\jre7_x86.exe", "\sources\jre7_x64.exe", "\sources\jre8_x86.exe", "\sources\jre8_x64.exe", '20-23
            "", "", '24-25 Microsoft XNA Framework
            "\sources\xna20.msi", "\sources\xna31.msi", "\sources\xna40.msi", '26-28
            "", "", '29-30 Microsoft XML Core
            "\sources\msxml6_x86.msi", "\sources\msxml6_x64.msi", '31-32
            "", "", '33-34 Others
            "\sources\DX\DXSETUP.exe", "\sources\openal.exe", "\sources\gfwlive.exe", "\sources\mwse3.msi", "\sources\physx.msi" '35-countTotal
        }

        If rbDxOnlineT1.IsChecked = True Then rtsrc(35) = "\sources\dxwebsetup.exe" '读取DX安装选项

        For i = 0 To countTotal
            If selectStatus(i) = True Then
                If IO.File.Exists(path & rtsrc(i)) = True Then
                    Process.Start(path & rtsrc(i)).WaitForExit()
                Else MsgBox("文件" & rtsrc(i) & "不存在！请检查文件完整性后再试。", MsgBoxStyle.Critical, "错误")
                End If
            End If
        Next

    End Sub

    Private Sub btnAbout_Click(sender As Object, e As RoutedEventArgs) Handles btnAbout.Click

        Dim about As New About
        about.Show()

    End Sub

End Class