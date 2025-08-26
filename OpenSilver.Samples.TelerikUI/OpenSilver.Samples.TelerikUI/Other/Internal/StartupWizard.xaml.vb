Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class StartupWizard
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            Me.listbox.ItemsSource = TelerikUI.ThemeHelper.Themes
            Me.listbox.SelectedItem = TelerikUI.ThemeHelper.DefaultTheme
        End Sub

        Public Event Completed As EventHandler

        Private Sub Wizard_Completed(sender As Object, e As RoutedEventArgs)
            Dim theme = If(CType(Me.listbox.SelectedItem, Theme), TelerikUI.ThemeHelper.DefaultTheme)

            TelerikUI.ThemeHelper.SetTheme(theme, Me.choice.IsChecked = True)

            RaiseEvent Completed(Me, EventArgs.Empty)
        End Sub
    End Class
End Namespace
