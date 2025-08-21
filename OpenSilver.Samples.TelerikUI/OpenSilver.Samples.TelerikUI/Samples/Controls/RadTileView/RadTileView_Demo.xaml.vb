Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadTileView_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            DataContext = TelerikUI.Planet.GetListOfPlanets()
        End Sub

        Private Sub tileView1_TileStateChanged(sender As Object, e As RadRoutedEventArgs)
            Dim item As RadTileViewItem = TryCast(e.OriginalSource, RadTileViewItem)
            If item IsNot Nothing Then
                Dim fluid As RadFluidContentControl = item.ChildrenOfType(Of RadFluidContentControl)().FirstOrDefault()
                If fluid IsNot Nothing Then
                    Select Case item.TileState
                        Case TileViewItemState.Maximized
                            fluid.State = FluidContentControlState.Large
                        Case TileViewItemState.Minimized
                            fluid.State = FluidContentControlState.Normal
                        Case TileViewItemState.Restored
                            fluid.State = FluidContentControlState.Normal
                        Case Else
                    End Select
                End If
            End If
        End Sub

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadTileView_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTileView/RadTileView_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTileView_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTileView/RadTileView_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTileView_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTileView/RadTileView_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
