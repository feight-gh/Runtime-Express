Imports System.Threading
Imports System.Text.RegularExpressions
Class MainWindow

    Private buildType As Integer = 1
    Private countTotal As Integer = 39 'listBoxRt.Items.Count - 1
    Private selectStatus(countTotal) As Boolean
    Private dxolstat As Boolean
    Public path As String = My.Application.Info.DirectoryPath
    Public sys32path As String = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)
    Public syspath As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
    Public winpath As String = Environment.GetFolderPath(Environment.SpecialFolder.Windows)
    Public program32path As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
    Public programpath As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)


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

    Private Sub checkUpdate()

        Dim updater As New updater
        If updater.isNewest(buildType) = False Then
            labelStat.Content = "有更新可用！请前往选项中查看"
            btnCheckUpdate.Content = "更新可用"
        End If

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

        checkUpdate()
        labelStat.Content = "就绪。程序版本" & My.Application.Info.Version.ToString & "。"

    End Sub

    Private Sub btnAutochk_Click(sender As Object, e As RoutedEventArgs) Handles btnAutochk.Click

        cleanAll() '将目前所有选项复原
        Dim ost As Integer = cbOStarget.SelectedIndex

        If ost = 0 Then '32位判断（总要执行）
            ck2005x64.IsEnabled = False
            ck2008x64.IsEnabled = False
            ck2010x64.IsEnabled = False
            ck2012x64.IsEnabled = False
            ck2013x64.IsEnabled = False
            ck2015x64.IsEnabled = False
            ckjre7x64.IsEnabled = False
            ckjre8x64.IsEnabled = False
            ckxmlc6x64.IsEnabled = False

        End If

        Select Case rbSmart.IsChecked '判断是否进入Smart模式
            Case True 'Smart模式
                '查找VC++ 2005/2008（WinSxS索引）
                If IO.Directory.Exists(winpath & "\winsxs\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.4940_none_d08cc06a442b34fc") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.6195_none_d09154e044272b9a") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.762_none_10b2f55f9bffb8f8") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.8428_none_d08a11e2442dc25d") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.91_none_db5f5c9d98cb161f") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.9268_none_d08e1538442a243e") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.mfc_1fc8b3b9a1e18e3b_8.0.50727.6195_none_cbf5e994470a1a8f") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.mfc_1fc8b3b9a1e18e3b_8.0.50727.762_none_0c178a139ee2a7ed") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc80.mfc_1fc8b3b9a1e18e3b_8.0.50727.91_none_d6c3f1519bae0514") = False Then
                    ck2005x86.IsChecked = True
                End If

                If IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.1_none_e163563597edeada") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4148_none_5090ab56bcba71c2") = False And
                        IO.Directory.Exists(winpath & "\winsxs\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4940_none_50916076bcb9a742") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.6161_none_50934f2ebcb7eb57") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.8387_none_5094ca96bcb6b2bb") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.9247_none_5090cb78bcba4a35") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.mfc_1fc8b3b9a1e18e3b_9.0.30729.1_none_dcc7eae99ad0d9cf") = False And
                        IO.Directory.Exists(winpath & "\winsxs\x86_microsoft.vc90.mfc_1fc8b3b9a1e18e3b_9.0.30729.4148_none_4bf5400abf9d60b7") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\x86_microsoft.vc90.mfc_1fc8b3b9a1e18e3b_9.0.30729.6161_none_4bf7e3e2bf9ada4c") = False Then
                    ck2008x86.IsChecked = True
                End If

                If ost = 1 Then 'x64

                    If IO.Directory.Exists(winpath & "\winsxs\amd64_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.4940_none_88df89932faf0bf6") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.762_none_c905be8887838ff2") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.8428_none_88dcdb0b2fb19957") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc80.crt_1fc8b3b9a1e18e3b_8.0.50727.9268_none_88e0de612fadfb38") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc80.mfc_1fc8b3b9a1e18e3b_8.0.50727.762_none_c46a533c8a667ee7") = False Then
                        ck2005x64.IsChecked = True

                    End If

                    If IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.1_none_99b61f5e8371c1d4") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4148_none_08e3747fa83e48bc") = False And
                        IO.Directory.Exists(winpath & "\winsxs\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.4940_none_08e4299fa83d7e3c") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.6161_none_08e61857a83bc251") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.8387_none_08e793bfa83a89b5") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.crt_1fc8b3b9a1e18e3b_9.0.30729.9247_none_08e394a1a83e212f") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.mfc_1fc8b3b9a1e18e3b_9.0.30729.1_none_951ab4128654b0c9") = False And
                        IO.Directory.Exists(winpath & "\WinSxS\amd64_microsoft.vc90.mfc_1fc8b3b9a1e18e3b_9.0.30729.4148_none_04480933ab2137b1") = False And
                        IO.Directory.Exists(winpath & "\winsxs\amd64_microsoft.vc90.mfc_1fc8b3b9a1e18e3b_9.0.30729.6161_none_044aad0bab1eb146") = False Then
                        ck2008x64.IsChecked = True

                    End If

                End If

                '查找VC++ 2010/2012/2013/2015
                If IO.File.Exists(sys32path & "\msvcp100.dll") = False Or
                    IO.File.Exists(sys32path & "\msvcr100.dll") = False Or
                    IO.File.Exists(sys32path & "\mfc100.dll") = False Or
                    IO.File.Exists(sys32path & "\mfc100u.dll") = False Or
                    IO.File.Exists(sys32path & "\mfcm100.dll") = False Or
                    IO.File.Exists(sys32path & "\mfcm100u.dll") = False Then
                    ck2010x86.IsChecked = True

                End If

                If IO.File.Exists(sys32path & "\msvcp110.dll") = False Or
                    IO.File.Exists(sys32path & "\msvcr110.dll") = False Or
                    IO.File.Exists(sys32path & "\mfc110.dll") = False Or
                    IO.File.Exists(sys32path & "\mfc110u.dll") = False Or
                    IO.File.Exists(sys32path & "\mfcm110.dll") = False Or
                    IO.File.Exists(sys32path & "\mfcm110u.dll") = False Then
                    ck2012x86.IsChecked = True

                End If

                If IO.File.Exists(sys32path & "\msvcp120.dll") = False Or
                    IO.File.Exists(sys32path & "\msvcr120.dll") = False Or
                    IO.File.Exists(sys32path & "\mfc120.dll") = False Or
                    IO.File.Exists(sys32path & "\mfc120u.dll") = False Or
                    IO.File.Exists(sys32path & "\mfcm120.dll") = False Or
                    IO.File.Exists(sys32path & "\mfcm120u.dll") = False Then
                    ck2013x86.IsChecked = True

                End If

                If IO.File.Exists(sys32path & "\msvcp140.dll") = False Or
                    IO.File.Exists(sys32path & "\mfc140.dll") = False Or
                    IO.File.Exists(sys32path & "\mfc140u.dll") = False Or
                    IO.File.Exists(sys32path & "\mfcm140.dll") = False Or
                    IO.File.Exists(sys32path & "\mfcm140u.dll") = False Then
                    ck2015x86.IsChecked = True

                End If

                If ost = 1 Then 'x64
                    If IO.File.Exists(syspath & "\msvcp100.dll") = False Or
                    IO.File.Exists(syspath & "\msvcr100.dll") = False Or
                    IO.File.Exists(syspath & "\mfc100.dll") = False Or
                    IO.File.Exists(syspath & "\mfc100u.dll") = False Or
                    IO.File.Exists(syspath & "\mfcm100.dll") = False Or
                    IO.File.Exists(syspath & "\mfcm100u.dll") = False Then
                        ck2010x64.IsChecked = True

                    End If

                    If IO.File.Exists(syspath & "\msvcp110.dll") = False Or
                    IO.File.Exists(syspath & "\msvcr110.dll") = False Or
                    IO.File.Exists(syspath & "\mfc110.dll") = False Or
                    IO.File.Exists(syspath & "\mfc110u.dll") = False Or
                    IO.File.Exists(syspath & "\mfcm110.dll") = False Or
                    IO.File.Exists(syspath & "\mfcm110u.dll") = False Then
                        ck2012x64.IsChecked = True

                    End If

                    If IO.File.Exists(syspath & "\msvcp120.dll") = False Or
                    IO.File.Exists(syspath & "\msvcr120.dll") = False Or
                    IO.File.Exists(syspath & "\mfc120.dll") = False Or
                    IO.File.Exists(syspath & "\mfc120u.dll") = False Or
                    IO.File.Exists(syspath & "\mfcm120.dll") = False Or
                    IO.File.Exists(syspath & "\mfcm120u.dll") = False Then
                        ck2013x64.IsChecked = True

                    End If

                    If IO.File.Exists(syspath & "\msvcp140.dll") = False Or
                    IO.File.Exists(syspath & "\mfc140.dll") = False Or
                    IO.File.Exists(syspath & "\mfc140u.dll") = False Or
                    IO.File.Exists(syspath & "\mfcm140.dll") = False Or
                    IO.File.Exists(syspath & "\mfcm140u.dll") = False Then
                        ck2015x64.IsChecked = True

                    End If

                End If

                '查找.NET Framework 4.6
                If IO.Directory.Exists(winpath & "\Microsoft.NET\Framework\v4.0.30319\") = True Then
                    Dim dotnet4xver As String =
                            FileVersionInfo.GetVersionInfo(winpath & "\Microsoft.NET\Framework\v4.0.30319\System.Core.dll").FileVersion.ToString.Substring(0, 3)

                    If dotnet4xver <> "4.6" Then
                        ckdotnetfw.IsChecked = True

                    End If

                End If

                If ost = 1 Then 'x64
                    If IO.Directory.Exists(winpath & "\Microsoft.NET\Framework64\v4.0.30319\") = True Then
                        Dim dotnet4xver As String =
                            FileVersionInfo.GetVersionInfo(winpath & "\Microsoft.NET\Framework64\v4.0.30319\System.Core.dll").FileVersion.ToString.Substring(0, 3)

                        If dotnet4xver <> "4.6" Then
                            ckdotnetfw.IsChecked = True

                        End If

                    End If

                End If

                '查找MSXML 6
                If IO.File.Exists(sys32path & "\msxml6.dll") = False Or
                       IO.File.Exists(sys32path & "\msxml6r.dll") = False Then
                    ckxmlc6x86.IsChecked = True

                End If

                If ost = 1 Then 'x64
                    If IO.File.Exists(syspath & "\msxml6.dll") = False Or
                       IO.File.Exists(syspath & "\msxml6r.dll") = False Then
                        ckxmlc6x64.IsChecked = True

                    End If

                End If

                '查找DirectX
                If IO.File.Exists(sys32path & "\D3DCompiler_33.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_34.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_35.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_36.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_37.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_38.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_39.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_40.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_41.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_42.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcompiler_43.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcsx_42.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dcsx_43.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_33.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_34.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_35.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_36.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_37.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_38.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_39.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_40.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_41.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_42.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx10_43.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx11_42.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx11_43.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_24.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_25.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_26.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_27.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_28.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_29.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_30.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_31.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_32.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_33.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_34.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_35.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_36.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_37.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_38.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_39.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_40.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_41.dll") = False Or
                        IO.File.Exists(sys32path & "\d3dx9_42.dll") = False Or
                        IO.File.Exists(sys32path & "\D3DX9_43.dll") = False Or
                        IO.File.Exists(sys32path & "\x3daudio1_0.dll") = False Or
                        IO.File.Exists(sys32path & "\x3daudio1_1.dll") = False Or
                        IO.File.Exists(sys32path & "\x3daudio1_2.dll") = False Or
                        IO.File.Exists(sys32path & "\X3DAudio1_3.dll") = False Or
                        IO.File.Exists(sys32path & "\X3DAudio1_4.dll") = False Or
                        IO.File.Exists(sys32path & "\X3DAudio1_5.dll") = False Or
                        IO.File.Exists(sys32path & "\X3DAudio1_6.dll") = False Or
                        IO.File.Exists(sys32path & "\X3DAudio1_7.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_0.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_1.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_10.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_2.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_3.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_4.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_5.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_6.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_7.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_8.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine2_9.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine3_0.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine3_1.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine3_2.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine3_3.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine3_4.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine3_5.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine3_6.dll") = False Or
                        IO.File.Exists(sys32path & "\xactengine3_7.dll") = False Or
                        IO.File.Exists(sys32path & "\XAPOFX1_0.dll") = False Or
                        IO.File.Exists(sys32path & "\XAPOFX1_1.dll") = False Or
                        IO.File.Exists(sys32path & "\XAPOFX1_2.dll") = False Or
                        IO.File.Exists(sys32path & "\XAPOFX1_3.dll") = False Or
                        IO.File.Exists(sys32path & "\XAPOFX1_4.dll") = False Or
                        IO.File.Exists(sys32path & "\XAPOFX1_5.dll") = False Or
                        IO.File.Exists(sys32path & "\XAudio2_0.dll") = False Or
                        IO.File.Exists(sys32path & "\XAudio2_1.dll") = False Or
                        IO.File.Exists(sys32path & "\XAudio2_2.dll") = False Or
                        IO.File.Exists(sys32path & "\XAudio2_3.dll") = False Or
                        IO.File.Exists(sys32path & "\XAudio2_4.dll") = False Or
                        IO.File.Exists(sys32path & "\XAudio2_5.dll") = False Or
                        IO.File.Exists(sys32path & "\XAudio2_6.dll") = False Or
                        IO.File.Exists(sys32path & "\XAudio2_7.dll") = False Or
                        IO.File.Exists(sys32path & "\xinput1_1.dll") = False Or
                        IO.File.Exists(sys32path & "\xinput1_2.dll") = False Or
                        IO.File.Exists(sys32path & "\xinput1_3.dll") = False Or
                        IO.File.Exists(sys32path & "\XInput9_1_0.dll") = False Then
                    ckdx9c.IsChecked = True

                End If

                If ost = 1 Then 'x64
                    If IO.File.Exists(syspath & "\D3DCompiler_33.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_34.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_35.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_36.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_37.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_38.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_39.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_40.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_41.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_42.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcompiler_43.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcsx_42.dll") = False Or
                        IO.File.Exists(syspath & "\d3dcsx_43.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_33.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_34.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_35.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_36.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_37.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_38.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_39.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_40.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_41.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_42.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx10_43.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx11_42.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx11_43.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_24.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_25.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_26.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_27.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_28.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_29.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_30.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_31.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_32.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_33.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_34.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_35.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_36.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_37.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_38.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_39.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_40.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_41.dll") = False Or
                        IO.File.Exists(syspath & "\d3dx9_42.dll") = False Or
                        IO.File.Exists(syspath & "\D3DX9_43.dll") = False Or
                        IO.File.Exists(syspath & "\x3daudio1_0.dll") = False Or
                        IO.File.Exists(syspath & "\x3daudio1_1.dll") = False Or
                        IO.File.Exists(syspath & "\x3daudio1_2.dll") = False Or
                        IO.File.Exists(syspath & "\X3DAudio1_3.dll") = False Or
                        IO.File.Exists(syspath & "\X3DAudio1_4.dll") = False Or
                        IO.File.Exists(syspath & "\X3DAudio1_5.dll") = False Or
                        IO.File.Exists(syspath & "\X3DAudio1_6.dll") = False Or
                        IO.File.Exists(syspath & "\X3DAudio1_7.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_0.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_1.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_10.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_2.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_3.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_4.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_5.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_6.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_7.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_8.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine2_9.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine3_0.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine3_1.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine3_2.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine3_3.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine3_4.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine3_5.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine3_6.dll") = False Or
                        IO.File.Exists(syspath & "\xactengine3_7.dll") = False Or
                        IO.File.Exists(syspath & "\XAPOFX1_0.dll") = False Or
                        IO.File.Exists(syspath & "\XAPOFX1_1.dll") = False Or
                        IO.File.Exists(syspath & "\XAPOFX1_2.dll") = False Or
                        IO.File.Exists(syspath & "\XAPOFX1_3.dll") = False Or
                        IO.File.Exists(syspath & "\XAPOFX1_4.dll") = False Or
                        IO.File.Exists(syspath & "\XAPOFX1_5.dll") = False Or
                        IO.File.Exists(syspath & "\XAudio2_0.dll") = False Or
                        IO.File.Exists(syspath & "\XAudio2_1.dll") = False Or
                        IO.File.Exists(syspath & "\XAudio2_2.dll") = False Or
                        IO.File.Exists(syspath & "\XAudio2_3.dll") = False Or
                        IO.File.Exists(syspath & "\XAudio2_4.dll") = False Or
                        IO.File.Exists(syspath & "\XAudio2_5.dll") = False Or
                        IO.File.Exists(syspath & "\XAudio2_6.dll") = False Or
                        IO.File.Exists(syspath & "\XAudio2_7.dll") = False Or
                        IO.File.Exists(syspath & "\xinput1_1.dll") = False Or
                        IO.File.Exists(syspath & "\xinput1_2.dll") = False Or
                        IO.File.Exists(syspath & "\xinput1_3.dll") = False Or
                        IO.File.Exists(syspath & "\XInput9_1_0.dll") = False Then
                        ckdx9c.IsChecked = True

                    End If

                End If

                '查找OpenAL
                If IO.File.Exists(syspath & "\OpenAL32.dll") = False Or
                     IO.File.Exists(sys32path & "\OpenAL32.dll") = False Then
                    ckoal.IsChecked = True

                End If

                '查找MGFW
                If IO.File.Exists(sys32path & "\xlive.dll") = False Then
                    ckmgfwl.IsChecked = True

                End If

                '查找PhysX
                If IO.Directory.Exists(program32path & "\NVIDIA Corporation\PhysX") = False Then
                    cknvpx.IsChecked = True

                End If

                '查找vsjsharp
                If IO.Directory.Exists(winpath & "\assembly\GAC_32\vjslib\2.0.0.0__b03f5f7f11d50a3a") = False Then
                    ckdotnetjs.IsChecked = True

                End If

                '查找vsfsharp
                If IO.Directory.Exists(winpath & "\Microsoft.NET\assembly\GAC_MSIL\FSharp.Core\v4.0_4.0.0.0__b03f5f7f11d50a3a") = False Or
                   IO.Directory.Exists(winpath & "\assembly\GAC_MSIL\FSharp.Core\2.0.0.0__b03f5f7f11d50a3a") = False Then
                    ckdotnetfs.IsChecked = True

                End If

                '查找XNA
                If IO.Directory.Exists(program32path & "\Common Files\Microsoft Shared\XNA\Framework\v2.0") = False Or
                   IO.Directory.Exists(winpath & "\assembly\GAC_32\Microsoft.Xna.Framework\2.0.0.0__6d5c3888ef60e27d") = False Then
                    ckxna2.IsChecked = True

                End If

                If IO.Directory.Exists(program32path & "\Common Files\Microsoft Shared\XNA\Framework\v3.1") = False Or
                   IO.Directory.Exists(winpath & "\assembly\GAC_32\Microsoft.Xna.Framework\3.1.0.0__6d5c3888ef60e27d") = False Then
                    ckxna3.IsChecked = True

                End If

                If IO.Directory.Exists(program32path & "\Common Files\Microsoft Shared\XNA\Framework\v4.0") = False Or
                   IO.Directory.Exists(winpath & "\Microsoft.NET\assembly\GAC_32\Microsoft.Xna.Framework\v4.0_4.0.0.0__842cf8be1de50553") = False Then
                    ckxna4.IsChecked = True

                End If

                '查找jre
                If IO.Directory.Exists(program32path & "\Java\jre7\bin") = False Then ckjre7x86.IsChecked = True
                If IO.Directory.Exists(programpath & "\Java\jre7\bin") = False Then ckjre7x64.IsChecked = True
                If IO.Directory.Exists(program32path & "\Java\jre1.8.0_131\bin") = False Then ckjre8x86.IsChecked = True
                If IO.Directory.Exists(programpath & "\Java\jre1.8.0_131\bin") = False Then ckjre8x64.IsChecked = True

                '查找WSE3
                If IO.Directory.Exists(program32path & "\Microsoft WSE\v3.0") = False Then ckmwse.IsChecked = True

            Case False '不进入Smart模式 而是开始无脑勾选
                '如果被选项禁用则不勾选
                For i = 0 To listBoxRt.Items.Count - 1
                    If i <> 0 And i <> 13 And i <> 14 And i <> 18 And i <> 19 And i <> 24 And i <> 25 And i <> 29 And
                            i <> 30 And i <> 33 And i <> 34 Then
                        If listBoxRt.Items.Item(i).IsEnabled = True And ckAutoCheck.IsChecked = True Then
                            listBoxRt.Items.Item(i).IsChecked = True

                        End If

                    End If

                Next i

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
        If listRt <> Nothing Then
            MsgBox("目前已勾选的有：" & vbCrLf & listRt, MsgBoxStyle.Information, "Runtime Express 概览")
        Else
            MsgBox("你还没有勾选任何选项，要不去勾几个？", MsgBoxStyle.Information, "Runtime Express 概览")
        End If

    End Sub

    Private Sub btnApply_Click(sender As Object, e As RoutedEventArgs) Handles btnApply.Click

        fetchAll()
        Dim applyActivity As New Thread(AddressOf apply)
        dxolstat = rbDxOnlineT1.IsChecked
        applyActivity.Start()


    End Sub

    Private Sub apply(ByVal dxol As Boolean)

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

        If dxolstat = True Then
            rtsrc(35) = "\sources\dxwebsetup.exe" '读取DX安装选项
        Else rtsrc(35) = "\sources\DX\DXSETUP.exe"
        End If

        Dim isNull As Boolean = True
        For i = 0 To countTotal
            If selectStatus(i) = True Then
                isNull = False
                If IO.File.Exists(path & rtsrc(i)) = True Then
                    Process.Start(path & rtsrc(i)).WaitForExit()
                Else MsgBox("文件" & rtsrc(i) & "不存在！请检查文件完整性后再试。", MsgBoxStyle.Critical, "错误")
                End If
            End If
            'labelStat.Content = "正在运行。第" & i + 1 & "个，共" & countTotal + 1 & "个。"
        Next

        If isNull = True Then
            MsgBox("没有勾选任何项，去勾选一些试试？", MsgBoxStyle.Information, "Runtime Express")
        End If

    End Sub

    Private Sub btnHomepage_Click(sender As Object, e As RoutedEventArgs) Handles btnHomepage.Click

        Process.Start("https://feightwywx.github.io/Runtime-Express/")

    End Sub

    Private Sub btnCheckUpdate_Click(sender As Object, e As RoutedEventArgs) Handles btnCheckUpdate.Click

        checkUpdate()

    End Sub
End Class