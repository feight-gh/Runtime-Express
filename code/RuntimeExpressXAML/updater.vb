#Disable Warning BC42104

Public Class updater

    Public Property isNewest() As Boolean = True

    Public Sub check()

        Dim UpdateChannel As String = "Release" '定义当前所使用的软件版本
        Dim checkserver As String
        Dim xmlnewestver As String
        Dim xmlnewestdate As String
        Dim xmlnewestinfo As String

        Try

            Select Case UpdateChannel

                Case "Release"
                    checkserver = "https://raw.githubusercontent.com/feight-github/Runtime-Express/re-2/version.xml"

                    Dim doc As New Xml.XmlDocument
                    doc.Load(checkserver.Trim)
                    Dim re As Xml.XmlNodeReader = New Xml.XmlNodeReader(doc)

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

                        isNewest = True

                    ElseIf xmlnewestver <> My.Application.Info.Version.ToString Then

                        isNewest = False



                    End If

                Case "Developer"
                    MsgBox("你目前处于Developer通道，软件更新不可用。" _
                        , MsgBoxStyle.Exclamation, "Runtime Express")

            End Select

        Catch ex As Exception

            MsgBox("目前无法连接到更新服务器。请检查你的网络连接，然后再试一次。", MsgBoxStyle.Critical, "Runtime Express")
            '出于用户考虑没有显示出ex.StackTrace的信息和ex.Message的信息
            '日后会加入日志记录

        End Try

        If isNewest = False Then
            If MsgBox("检测到新版本：" & xmlnewestver & vbCrLf &
                                   "更新时间：" & xmlnewestdate & vbCrLf &
                                   "更新内容：" & xmlnewestinfo & vbCrLf &
                                   "要更新吗？",
                                    MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "检测到新版本") = MsgBoxResult.Ok _
                                Then Process.Start("http://pan.baidu.com/s/1o6jULke")
        End If

    End Sub

End Class
