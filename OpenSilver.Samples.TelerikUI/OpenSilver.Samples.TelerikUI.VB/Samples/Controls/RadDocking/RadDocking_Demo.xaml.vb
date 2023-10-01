Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace Global.OpenSilver.Samples.TelerikUI
    Public Partial Class RadDocking_Demo
        Inherits UserControl
        Private firstPaneField As RadPane
        Public Sub New()
            Me.InitializeComponent()
            firstPaneField = Me.FirstPane
        End Sub

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadDocking_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadDocking_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadDocking_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI.VB/Samples/Controls/RadDocking/RadDocking_Demo.xaml.vb"
    }
})
        End Sub


        Private Sub ButtonShowPanes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            'make sure the pane is rendered visible even if floating:    
            Me.FirstPane.IsHidden = False

            Me.PaneGroup.ShowAllPanes()
        End Sub
    End Class
End Namespace
