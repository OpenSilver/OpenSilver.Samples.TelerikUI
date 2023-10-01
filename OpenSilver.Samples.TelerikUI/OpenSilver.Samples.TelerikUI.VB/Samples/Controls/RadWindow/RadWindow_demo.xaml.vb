Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace Global.OpenSilver.Samples.TelerikUI
    Public Partial Class RadWindow_demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadWindow_demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWindow/RadWindow_demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadWindow_demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWindow/RadWindow_demo.xaml.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadWindow_demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI.VB/Samples/Controls/RadWindow/RadWindow_demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
