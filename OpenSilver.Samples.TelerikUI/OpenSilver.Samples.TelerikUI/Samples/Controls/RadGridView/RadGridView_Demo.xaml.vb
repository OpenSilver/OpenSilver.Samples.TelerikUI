Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadGridView_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            AddHandler Loaded, AddressOf RadGridView_Demo_Loaded
        End Sub

        Private Sub RadGridView_Demo_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.RadGridView1.ItemsSource = Planet.GetListOfPlanets()
            Me.RadGridView1.AutoGenerateColumns = True
        End Sub

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadGridView_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadGridView_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "Planets.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Other/Planets.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadGridView_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml.vb"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "Planets.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Other/Planets.vb"
    }
})
        End Sub
    End Class
End Namespace
