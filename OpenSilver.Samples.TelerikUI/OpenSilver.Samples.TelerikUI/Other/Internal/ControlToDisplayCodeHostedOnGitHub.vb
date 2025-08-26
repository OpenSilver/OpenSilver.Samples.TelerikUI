Imports System.Windows
Imports System.Windows.Browser
Imports System.Windows.Controls
Imports CSHTML5.Internal

Namespace OpenSilver.Samples.TelerikUI
    Public Class ControlToDisplayCodeHostedOnGitHub
        Inherits ContentControl
        Private _filePathOnGitHub As String
        Private _displayedHtmlString As String

        Public Sub New(absolutePath As String)
            AddHandler Loaded, AddressOf OnLoaded

            VerticalContentAlignment = VerticalAlignment.Stretch
            HorizontalContentAlignment = HorizontalAlignment.Stretch
            FilePathOnGitHub = absolutePath
        End Sub

        Private Function GetHtmlString(filePath As String) As String
            Dim embedJs = INTERNAL_UriHelper.ConvertToHtml5Path("ms-appx:/Other/embed.js")
            Return String.Format("<script src=""{0}?target={1}&style=github&showBorder=on&showLineNumbers=on&showCopy=on""></script>", embedJs, HttpUtility.UrlEncode("https://github.com" & filePath.Substring(6)))
        End Function

        Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
            If Not String.IsNullOrEmpty(_filePathOnGitHub) Then
                Dim htmlString = GetHtmlString(_filePathOnGitHub)
                DisplayHtmlString(htmlString)
            End If
        End Sub

        Private Sub DisplayHtmlString(htmlString As String)
            Dim webView = New WebBrowser()
            webView.NavigateToString(htmlString)
            Content = webView
            _displayedHtmlString = htmlString
        End Sub

        Public Property FilePathOnGitHub As String
            Get
                Return _filePathOnGitHub
            End Get
            Set(value As String)
                _filePathOnGitHub = value

                If IsLoaded Then
                    Dim htmlString = GetHtmlString(FilePathOnGitHub)
                    If Not Equals(htmlString, _displayedHtmlString) Then
                        DisplayHtmlString(htmlString)
                    End If
                End If
            End Set
        End Property
    End Class
End Namespace
