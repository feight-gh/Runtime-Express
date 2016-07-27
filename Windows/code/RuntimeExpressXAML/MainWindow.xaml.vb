Class MainWindow

    Public selectStatus(39) As Boolean

    Private Sub fetchAll()

        For rei = 0 To listBoxRt.Items.Count - 1

            selectStatus(rei) = False

        Next
        '循环获取勾选项的代码段
        For i = 0 To listBoxRt.Items.Count - 1

            Try
                If listBoxRt.Items.Item(i).IsChecked = True Then
                    selectStatus(i) = True
                End If
            Catch ex As Exception '忽略无IsChecked属性的Item

            End Try

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



    Private Sub btnApply_Click(sender As Object, e As RoutedEventArgs) Handles btnApply.Click

        fetchAll()
        Dim rtsrc(39) '定义安装源
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
            "\sources\DX\DXSETUP.exe", "\sources\openal.exe", "\sources\gfwlive.exe", "\sources\mwse3.msi", "\sources\physx.msi" '35-39
        }

        If rbDxOnlineT1.IsChecked = True Then rtsrc(35) = "\sources\dxwebsetup.exe" '读取DX安装选项

        For i = 0 To 39
            If selectStatus(i) = True Then
                Process.Start(My.Application.Info.DirectoryPath & rtsrc(i)).WaitForExit()
            End If
        Next

    End Sub

    Private Sub btnAbout_Click(sender As Object, e As RoutedEventArgs) Handles btnAbout.Click

        Dim about As New About
        about.Show()
    End Sub

End Class