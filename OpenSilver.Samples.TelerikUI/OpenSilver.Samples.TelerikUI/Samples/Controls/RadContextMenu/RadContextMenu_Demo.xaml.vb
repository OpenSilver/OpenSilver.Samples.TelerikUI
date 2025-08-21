Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports Telerik.Windows

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadContextMenu_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadContextMenu_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadContextMenu/RadContextMenu_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadContextMenu_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadContextMenu/RadContextMenu_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadContextMenu_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadContextMenu/RadContextMenu_Demo.xaml.vb"
    }
})
        End Sub

        Private Sub RadMenuItemRed_Click(sender As Object, e As RadRoutedEventArgs)
            Me.ContextMenuBorder.Background = New SolidColorBrush(Colors.Red)
        End Sub
        Private Sub RadMenuItemGreen_Click(sender As Object, e As RadRoutedEventArgs)
            Me.ContextMenuBorder.Background = New SolidColorBrush(Colors.Green)
        End Sub
        Private Sub RadMenuItemBlue_Click(sender As Object, e As RadRoutedEventArgs)
            Me.ContextMenuBorder.Background = New SolidColorBrush(Colors.Blue)
        End Sub
        Private Sub RadMenuItemReset_Click(sender As Object, e As RadRoutedEventArgs)
            Me.ContextMenuBorder.Background = New SolidColorBrush(Colors.LightGray)
        End Sub
    End Class
End Namespace
