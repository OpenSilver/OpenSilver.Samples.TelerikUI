Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadColorPicker_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadColorPicker_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadColorPicker/RadColorPicker_Demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadColorPicker_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadColorPicker/RadColorPicker_Demo.xaml.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadColorPicker_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadColorPicker/RadColorPicker_Demo.xaml.vb"
    }
})
        End Sub

        Private Sub SelectedColor_Changed(ByVal sender As Object, ByVal e As EventArgs)
            Dim color As Color = Me.ColorPicker.SelectedColor
            Dim brush As SolidColorBrush = New SolidColorBrush(color)
            Me.ColorBorder.Background = brush
        End Sub
    End Class
End Namespace
