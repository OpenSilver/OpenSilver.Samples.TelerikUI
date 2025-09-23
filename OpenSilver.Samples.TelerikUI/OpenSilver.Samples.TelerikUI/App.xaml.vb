Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public NotInheritable Partial Class App
        Inherits Application
        Public Sub New()
            Me.New(New NoOpLazyAssemblyLoader())
        End Sub

        Public Sub New(assemblyLoader As TelerikUI.ILazyAssemblyLoader)
            TelerikUI.ThemeHelper.Initialize(assemblyLoader)

            Me.InitializeComponent()
            AddHandler Startup, AddressOf OnStartup
        End Sub

        Private Async Sub OnStartup(sender As Object, e As StartupEventArgs)
            Dim rootVisual = New Grid()

            MyBase.RootVisual = rootVisual

            If Await TelerikUI.ThemeHelper.LoadThemeAsync() Then
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

        Private NotInheritable Class NoOpLazyAssemblyLoader
            Implements TelerikUI.ILazyAssemblyLoader
            Public Function LoadAssembliesAsync(assembliesToLoad As IEnumerable(Of String)) As Task(Of IEnumerable(Of Assembly)) Implements TelerikUI.ILazyAssemblyLoader.LoadAssembliesAsync
                Return Task.FromResult(Enumerable.Empty(Of Assembly)())
            End Function
        End Class
    End Class
End Namespace
