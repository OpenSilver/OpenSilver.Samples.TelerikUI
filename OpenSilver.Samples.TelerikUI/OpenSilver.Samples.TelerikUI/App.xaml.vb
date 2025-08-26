Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public NotInheritable Partial Class App
        Inherits Application
        Public Sub New()
            Me.InitializeComponent()
            AddHandler Startup, AddressOf OnStartup
        End Sub

        Private Sub OnStartup(sender As Object, e As StartupEventArgs)
            Dim rootVisual = New Grid()

            MyBase.RootVisual = rootVisual

            If TelerikUI.ThemeHelper.LoadTheme() Then
                rootVisual.Children.Add(New TelerikUI.MainPage())
                Return
            End If

            Resources(TelerikUI.ThemeHelper.ApplicationThemeKey) = TelerikUI.ThemeHelper.DefaultTheme

            Dim wizard = New OpenSilver.Samples.TelerikUI.StartupWizard() With {
    .HorizontalAlignment = HorizontalAlignment.Center,
    .VerticalAlignment = VerticalAlignment.Center
}

            AddHandler wizard.Completed, Sub(o, arg)
                                             rootVisual.Children.Clear()
                                             rootVisual.Children.Add(New TelerikUI.MainPage())
                                         End Sub

            rootVisual.Children.Add(wizard)
        End Sub
    End Class
End Namespace
