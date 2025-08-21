Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadTreeMap_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            DataContext = GetData()
        End Sub

        Private Shared Function GetData() As List(Of GdpInfo)
            Dim data As List(Of GdpInfo) = New List(Of GdpInfo)() From {
    New GdpInfo With {
        .Country = "Austria",
        .Gdp = 385.1
    },
    New GdpInfo With {
        .Country = "Belgium",
        .Gdp = 468.6
    },
    New GdpInfo With {
        .Country = "Brazil",
        .Gdp = 1749
    },
    New GdpInfo With {
        .Country = "Canada",
        .Gdp = 1565
    },
    New GdpInfo With {
        .Country = "China",
        .Gdp = 5308
    },
    New GdpInfo With {
        .Country = "Denmark",
        .Gdp = 318.1
    },
    New GdpInfo With {
        .Country = "France",
        .Gdp = 2669
    },
    New GdpInfo With {
        .Country = "Germany",
        .Gdp = 3402
    },
    New GdpInfo With {
        .Country = "Greece",
        .Gdp = 329
    },
    New GdpInfo With {
        .Country = "India",
        .Gdp = 1290
    },
    New GdpInfo With {
        .Country = "Indonesia",
        .Gdp = 593.3
    },
    New GdpInfo With {
        .Country = "Iran",
        .Gdp = 346.6
    },
    New GdpInfo With {
        .Country = "Italy",
        .Gdp = 2107
    },
    New GdpInfo With {
        .Country = "Japan",
        .Gdp = 5179
    },
    New GdpInfo With {
        .Country = "Mexico",
        .Gdp = 1021
    },
    New GdpInfo With {
        .Country = "Netherlands",
        .Gdp = 804.7
    },
    New GdpInfo With {
        .Country = "Norway",
        .Gdp = 410.3
    },
    New GdpInfo With {
        .Country = "Poland",
        .Gdp = 467.3
    },
    New GdpInfo With {
        .Country = "Russia",
        .Gdp = 1250
    }
}
            Return data
        End Function

        Private NotInheritable Class GdpInfo
            Public Property Continent As String
            Public Property Country As String
            Public Property City As String
            Public Property Gdp As Double
        End Class

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadTreeMap_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeMap/RadTreeMap_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTreeMap_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeMap/RadTreeMap_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTreeMap_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeMap/RadTreeMap_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
