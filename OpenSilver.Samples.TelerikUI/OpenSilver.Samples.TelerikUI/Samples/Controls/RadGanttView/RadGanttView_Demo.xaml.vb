Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadGanttView_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            AddHandler Loaded, AddressOf RadGanttView_Demo_Loaded
        End Sub

        Private Sub RadGanttView_Demo_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim model As GanttViewModel = New GanttViewModel()
            model.IsBusy = True
            DataContext = model
        End Sub

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadGanttVieww_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGanttView/RadGanttView_Demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadGanttView_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGanttView/RadGanttView_Demo.xaml.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "GanttViewModel.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Other/GanttViewModel.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadGanttView_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGanttView/RadGanttView_Demo.xaml.vb"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "GanttViewModel.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Other/GanttViewModel.vb"
    }
})
        End Sub
    End Class
End Namespace
