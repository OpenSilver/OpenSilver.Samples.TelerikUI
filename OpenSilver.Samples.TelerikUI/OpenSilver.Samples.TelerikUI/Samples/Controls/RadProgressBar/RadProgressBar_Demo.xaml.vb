Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media.Animation

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadProgressBar_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            AddHandler Me.ProgressBar.Loaded, AddressOf Me.OnProgressBarLoaded
            AddHandler Me.ProgressBar.Unloaded, AddressOf Me.OnProgressBarUnloaded
        End Sub

        Private Sub OnProgressBarLoaded(sender As Object, e As RoutedEventArgs)
            Me.ProgressBar.BeginAnimation(RangeBase.ValueProperty, New DoubleAnimation With {
    .Duration = New Duration(TimeSpan.FromSeconds(5)),
    .From = Me.ProgressBar.Minimum,
    .[To] = Me.ProgressBar.Maximum,
    .RepeatBehavior = RepeatBehavior.Forever
})
        End Sub

        Private Sub OnProgressBarUnloaded(sender As Object, e As RoutedEventArgs)
            Me.ProgressBar.BeginAnimation(RangeBase.ValueProperty, Nothing)
        End Sub
    End Class
End Namespace
