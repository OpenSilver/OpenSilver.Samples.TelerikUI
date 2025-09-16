Imports OpenSilver.Samples.TelerikUI.RadChart3D.Helpers
Imports System.Collections.Generic

Namespace OpenSilver.Samples.TelerikUI.RadChart3D.ViewModel
    Public NotInheritable Class UserDataViewModel
        Private _data As IList(Of IEnumerable(Of Double))
        Private _itemsCount As Integer
        Private _seriesCount As Integer

        Public ReadOnly Property CollectionData As IList(Of IEnumerable(Of Double))
            Get
                If _data Is Nothing Then
                    _data = FillSampleChartData(SeriesCount, ItemsCount)
                End If

                Return _data
            End Get
        End Property

        Public ReadOnly Property Data As IEnumerable(Of Double)
            Get
                Return CollectionData(0)
            End Get
        End Property

        Public Property ItemsCount As Integer
            Get
                Return _itemsCount
            End Get
            Set(value As Integer)
                _itemsCount = value
            End Set
        End Property

        Public Property SeriesCount As Integer
            Get
                Return _seriesCount
            End Get
            Set(value As Integer)
                _seriesCount = value
            End Set
        End Property

        Private Function FillSampleChartData(seriesCount As Integer, numbOfItems As Integer) As IList(Of IEnumerable(Of Double))
            Dim itemsSource As List(Of IEnumerable(Of Double)) = New List(Of IEnumerable(Of Double))()

            For i = 0 To seriesCount - 1
                itemsSource.Add(RadChart3D.Helpers.SeriesExtensions.GetUserData(numbOfItems, i))
            Next

            Return itemsSource
        End Function
    End Class
End Namespace
