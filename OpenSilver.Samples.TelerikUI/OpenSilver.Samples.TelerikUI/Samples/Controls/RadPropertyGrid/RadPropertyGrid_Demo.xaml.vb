Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls.Data.PropertyGrid

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadPropertyGrid_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub rpg_AutoGeneratingPropertyDefinition(sender As Object, e As AutoGeneratingPropertyDefinitionEventArgs)
            If Equals(e.PropertyDefinition.DisplayName, "Opacity") Then
                e.PropertyDefinition.OrderIndex = 0
                e.PropertyDefinition.EditorTemplate = CType(Resources("opacityEditorTemplate"), DataTemplate)
                Return
            End If

            If Equals(e.PropertyDefinition.DisplayName, "Width") OrElse Equals(e.PropertyDefinition.DisplayName, "Height") Then
                e.PropertyDefinition.OrderIndex = 1
                e.PropertyDefinition.EditorTemplate = CType(Resources("widthHeightEditorTemplate"), DataTemplate)
                Return
            End If

            e.PropertyDefinition.OrderIndex = 2
            e.PropertyDefinition.IsReadOnly = True
        End Sub

        Private Sub RadButton_Click(sender As Object, e As RoutedEventArgs)
            Me.rpg.ReloadData()
        End Sub

        Private Sub image_SizeChanged(sender As Object, e As SizeChangedEventArgs)
            RemoveHandler Me.image.SizeChanged, AddressOf Me.image_SizeChanged
            Me.rpg.Item = Me.image

        End Sub

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadPropertyGrid_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadPropertyGrid/RadPropertyGrid_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadPropertyGrid_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadPropertyGrid/RadPropertyGrid_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadPropertyGrid_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadPropertyGrid/RadPropertyGrid_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
