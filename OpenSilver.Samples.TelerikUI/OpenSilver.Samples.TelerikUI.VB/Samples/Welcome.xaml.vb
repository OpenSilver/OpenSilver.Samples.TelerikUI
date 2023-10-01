Imports System.Windows
Imports System.Windows.Controls

Namespace Global.OpenSilver.Samples.TelerikUI.VB
    Public Partial Class Welcome
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub ButtonToContinue_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            MainPage.Current.NavigateToPage("/Controls")
        End Sub
    End Class
End Namespace
