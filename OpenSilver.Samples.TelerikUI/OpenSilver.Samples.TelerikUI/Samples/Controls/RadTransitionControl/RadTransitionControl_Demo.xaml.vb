Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadTransitionControl_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            DataContext = New ViewModel()
        End Sub

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadTransitionControl_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTransitionControl/RadTransitionControl_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTransitionControl_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTransitionControl/RadTransitionControl_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTransitionControl_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTransitionControl/RadTransitionControl_Demo.xaml.vb"
    }
})
        End Sub

        Public Class ViewModel
            Public Property ColorItems As ObservableCollection(Of ColorItem)

            Public Sub New()
                ColorItems = New ObservableCollection(Of ColorItem) From {
    New ColorItem("Yellow", Colors.Yellow),
    New ColorItem("Orange", Colors.Orange),
    New ColorItem("Red", Colors.Red),
    New ColorItem("Blue", Colors.Blue),
    New ColorItem("Green", Colors.Green),
    New ColorItem("Purple", Colors.Purple)
}
            End Sub
        End Class

        Public Class ColorItem
            Public Sub New(name As String, color As Color)
                Me.Name = name
                Me.Color = color
            End Sub

            Public Property Name As String

            Public Property Color As Color
        End Class
    End Class
End Namespace
