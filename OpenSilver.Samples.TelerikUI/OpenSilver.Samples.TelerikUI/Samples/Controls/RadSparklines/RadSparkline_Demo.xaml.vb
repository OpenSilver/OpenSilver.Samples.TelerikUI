Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadSparkline_Demo
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
    End Class
End Namespace
