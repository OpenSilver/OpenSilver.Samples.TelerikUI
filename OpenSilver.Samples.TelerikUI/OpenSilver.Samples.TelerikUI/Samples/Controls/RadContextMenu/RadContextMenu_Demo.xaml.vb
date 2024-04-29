Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports Telerik.Windows

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadContextMenu_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadContextMenu_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadContextMenu/RadContextMenu_Demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadContextMenu_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadContextMenu/RadContextMenu_Demo.xaml.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadContextMenu_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadContextMenu/RadContextMenu_Demo.xaml.vb"
    }
})
        End Sub

        Private Sub RadMenuItemRed_Click(ByVal sender As Object, ByVal e As RadRoutedEventArgs)
            Me.ContextMenuBorder.Background = New SolidColorBrush(Colors.Red)
        End Sub
        Private Sub RadMenuItemGreen_Click(ByVal sender As Object, ByVal e As RadRoutedEventArgs)
            Me.ContextMenuBorder.Background = New SolidColorBrush(Colors.Green)
        End Sub
        Private Sub RadMenuItemBlue_Click(ByVal sender As Object, ByVal e As RadRoutedEventArgs)
            Me.ContextMenuBorder.Background = New SolidColorBrush(Colors.Blue)
        End Sub
        Private Sub RadMenuItemReset_Click(ByVal sender As Object, ByVal e As RadRoutedEventArgs)
            Me.ContextMenuBorder.Background = New SolidColorBrush(Colors.LightGray)
        End Sub
    End Class
End Namespace
