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
