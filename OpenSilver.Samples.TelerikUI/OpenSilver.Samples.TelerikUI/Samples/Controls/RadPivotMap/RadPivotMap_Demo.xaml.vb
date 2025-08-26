Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadPivotMap_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            DataContext = GetData()
        End Sub

        Private Shared Function GetData() As ObservableCollection(Of MovieInfo)
            Dim movies = New ObservableCollection(Of MovieInfo)() From {
    New MovieInfo() With {
        .Genre = "Adventure",
        .Title = "Toy Story 3",
        .GrossSales = 415004880
    },
    New MovieInfo() With {
        .Genre = "Adventure",
        .Title = "Iron Man 3",
        .GrossSales = 409013994
    },
    New MovieInfo() With {
        .Genre = "Adventure",
        .Title = "Tangled",
        .GrossSales = 200821936
    },
    New MovieInfo() With {
        .Genre = "Adventure",
        .Title = "The Karate Kid",
        .GrossSales = 176591618
    },
    New MovieInfo() With {
        .Genre = "Action",
        .Title = "Avatar",
        .GrossSales = 760507625
    },
    New MovieInfo() With {
        .Genre = "Action",
        .Title = "Sherlock Holmes",
        .GrossSales = 186848418
    },
    New MovieInfo() With {
        .Genre = "Action",
        .Title = "Red",
        .GrossSales = 130380162
    },
    New MovieInfo() With {
        .Genre = "Comedy",
        .Title = "Despicable Me 3",
        .GrossSales = 264624300
    },
    New MovieInfo() With {
        .Genre = "Comedy",
        .Title = "Easy A",
        .GrossSales = 158401464
    },
    New MovieInfo() With {
        .Genre = "Comedy",
        .Title = "Superbad",
        .GrossSales = 61979680
    },
    New MovieInfo() With {
        .Genre = "Comedy",
        .Title = "Date Night",
        .GrossSales = 121463226
    },
    New MovieInfo() With {
        .Genre = "Horror",
        .Title = "The Ring",
        .GrossSales = 129128133
    },
    New MovieInfo() With {
        .Genre = "Horror",
        .Title = "The Grudge",
        .GrossSales = 110359362
    }
}
            Return movies
        End Function

        Private NotInheritable Class MovieInfo
            Public Property Genre As String
            Public Property Title As String
            Public Property GrossSales As Double
        End Class
    End Class
End Namespace
