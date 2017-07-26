#Disable Warning BC42104

Public Class updater

    ''' <summary>
    ''' 从远端服务器获取最新版本信息，并和当前版本比对。
    ''' </summary>
    ''' <param name="BuildType">指定一个值，0表示Release通道，1表示Dev通道</param>
    ''' <returns>返回一个Boolean类型的值，False表示和最新版本不同，True表示和最新版本相同。</returns>
    Public Function isNewest(ByVal BuildType As Integer) As Boolean

        Dim checkserver As String
        Dim xmlnewestver As String
        Dim xmlnewestdate As String
        Dim xmlnewestinfo As String

        Try

            Select Case BuildType

                Case 0
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

                        Return True

                    ElseIf xmlnewestver <> My.Application.Info.Version.ToString Then
                        If MsgBox("检测到新版本：" & xmlnewestver & vbCrLf &
                                   "更新时间：" & xmlnewestdate & vbCrLf &
                                   "更新内容：" & xmlnewestinfo & vbCrLf &
                                   "要更新吗？",
                                    MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "检测到新版本") = MsgBoxResult.Ok _
                                Then Process.Start("http://pan.baidu.com/s/1o6jULke")
                        Return False



                    End If

                Case 1
                    MsgBox("你目前处于Developer通道，软件更新不可用。", MsgBoxStyle.Exclamation, "Runtime Express")
                    Return True
            End Select

        Catch ex As Exception

            MsgBox("目前无法连接到更新服务器。请检查你的网络连接，然后再试一次。", MsgBoxStyle.Critical, "Runtime Express")
            '出于用户考虑没有显示出ex.StackTrace的信息和ex.Message的信息
            '日后会加入日志记录
            Return True
        End Try

    End Function

End Class
