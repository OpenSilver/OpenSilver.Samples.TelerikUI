﻿Namespace OpenSilver.Samples.TelerikUI
    Public Class ViewSourceButtonInfo
        Public Sub New()
        End Sub

        Public Sub New(relativePath As String, fileName As String)
            Me.RelativePath = relativePath
            Me.FileName = fileName
        End Sub

        Public Property FileName As String

        Public Property RelativePath As String

        Public Property Branch As String = "master"

        Public Property Repository As String = "OpenSilver.Samples.TelerikUI"

        Public Property Owner As String = "OpenSilver"

        Public Property TabHeader As String

        Public Property Fragment As String

        Public Property Notes As String

        Public Function GetHeader() As String
            Return If(Not String.IsNullOrEmpty(TabHeader), TabHeader, FileName)
        End Function

        Public Function GetAbsoluteUrl() As String
            Return $"https://github.com/{Owner}/{Repository}/blob/{Branch}/{RelativePath}/{FileName}{Fragment}"
        End Function
    End Class
End Namespace
