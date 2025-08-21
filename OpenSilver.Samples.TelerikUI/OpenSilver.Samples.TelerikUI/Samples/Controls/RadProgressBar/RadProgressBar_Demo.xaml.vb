Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media.Animation

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadProgressBar_Demo
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

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadProgressBar_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadProgressBar/RadProgressBar_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadProgressBar_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadProgressBar/RadProgressBar_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadProgressBar_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadProgressBar/RadProgressBar_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
