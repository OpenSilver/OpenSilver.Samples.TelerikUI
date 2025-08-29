Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadPathButton_Demo
        Inherits UserControl
        Private _clickCount As Integer = 0

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub RadPathButton_Click(sender As Object, e As RoutedEventArgs)
            _clickCount += 1
            Me.counter.Text = _clickCount.ToString()
        End Sub
    End Class
End Namespace
