Imports System.Windows
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class SettingsWindow
        Inherits RadWindow
        Public Sub New()
            Me.InitializeComponent()

            Me.listbox.ItemsSource = TelerikUI.ThemeHelper.Themes
            Me.listbox.SelectedItem = StyleManager.ApplicationTheme
        End Sub

        Private Sub ResetTheme_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ThemeHelper.ResetTheme()
        End Sub

        Private Sub Cancel_Click(sender As Object, e As RoutedEventArgs)
            Close()
        End Sub

        Private Sub Save_Click(sender As Object, e As RoutedEventArgs)
            Dim theme = CType(Me.listbox.SelectedItem, Theme)

            If theme IsNot Nothing Then
                TelerikUI.ThemeHelper.SetTheme(theme, Me.choice.IsChecked = True)
            End If

            Close()
        End Sub
    End Class
End Namespace
