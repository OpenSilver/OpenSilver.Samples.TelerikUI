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
