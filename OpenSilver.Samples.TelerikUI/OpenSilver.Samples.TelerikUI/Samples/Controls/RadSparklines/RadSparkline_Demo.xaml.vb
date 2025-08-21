Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadSparkline_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            DataContext = New ViewModel()
        End Sub

        Private NotInheritable Class MyCost
            Public Property Cost As Double
            Public Property UnitCost As Double
        End Class

        Private NotInheritable Class ViewModel
            Public Sub New()
                Costs = New ObservableCollection(Of MyCost)()

                Dim randomGenerator = New Random()

                For i = 1 To 99
                    Costs.Add(New MyCost With {
    .Cost = i,
    .UnitCost = randomGenerator.Next(-10, 11)
})
                Next
            End Sub

            Public ReadOnly Property Costs As ObservableCollection(Of MyCost)
        End Class

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadSparkline_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadSparklines/RadSparkline_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadSparkline_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadSparklines/RadSparkline_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadSparkline_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadSparklines/RadSparkline_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
