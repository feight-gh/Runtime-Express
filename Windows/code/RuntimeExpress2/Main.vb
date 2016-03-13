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

        '判断系统版本
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

        '判断系统是32位还是64位
        If is64bit = False Then
            atTargetCombo.SelectedIndex = 0
        ElseIf is64bit = True Then
            atTargetCombo.SelectedIndex = 1
        End If

        InfoLabel.Text = osfullname & " " & osbit '输出

        initTree()

    End Sub

#Region "节点声明"

    '.net Framework begin
    Dim dotnet35node = New TreeNode(".net Framework 3.5")
    'Visual C++ begin
    Dim vcroot = New TreeNode("Visual C++")
    Dim vc20051 = New TreeNode("Visual C++ 2005 x86")
    Dim vc20052 = New TreeNode("Visual C++ 2005 x64")
    Dim vc20081 = New TreeNode("Visual C++ 2008 x86")
    Dim vc20082 = New TreeNode("Visual C++ 2008 x64")
    Dim vc20101 = New TreeNode("Visual C++ 2010 x86")
    Dim vc20102 = New TreeNode("Visual C++ 2010 x64")
    Dim vc20131 = New TreeNode("Visual C++ 2013 x86")
    Dim vc20132 = New TreeNode("Visual C++ 2013 x64")
    Dim vc20151 = New TreeNode("Visual C++ 2015 x86")
    Dim vc20152 = New TreeNode("Visual C++ 2015 x64")
    'JRE begin
    Dim jreroot = New TreeNode("Java Runtime Environment")
    Dim jre71 = New TreeNode("Java 7 Update 79 x86")
    Dim jre72 = New TreeNode("Java 7 Update 79 x64")
    Dim jre81 = New TreeNode("Java 8 Update 73 x86")
    Dim jre82 = New TreeNode("Java 8 Update 73 x64")
    'DirectX begin
    Dim dx9c = New TreeNode("DirectX 9.0c")
    'xna begin
    Dim xnaroot = New TreeNode("Microsoft XNA Framework")
    Dim xna2 = New TreeNode("Microsoft XNA Framework 2")
    Dim xna31 = New TreeNode("Microsoft XNA Framework 3.1")
    Dim xna4 = New TreeNode("Microsoft XNA Framework 4")
    'Microsoft GFW
    'OpenAL begin
    Dim openal = New TreeNode("OpenAL 2.0.7")
    'x# begin
    Dim jsharp = New TreeNode(".net J#")
    Dim fsharp = New TreeNode(".net F#")

#End Region

    Public Sub initTree()

        RuntimeSelector.Nodes.Add(dotnet35node)

        Select Case atTargetCombo.SelectedIndex
            Case 0

            Case 1

        End Select

    End Sub

End Class
