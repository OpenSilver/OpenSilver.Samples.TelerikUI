Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace Global.OpenSilver.Samples.TelerikUI
    Public Partial Class RadCartesianChart_BarSeries_Demo
        Inherits UserControl

        Public Sub New()
            'deactivated for now 
            'InitializeComponent();
        End Sub

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadCartesianChart_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadCartesianChart/RadCartesianChart_BarSeries_Demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadCartesianChart_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadCartesianChart/RadCartesianChart_BarSeries_Demo.xaml.cs"
    }
})
        End Sub
    End Class
End Namespace
