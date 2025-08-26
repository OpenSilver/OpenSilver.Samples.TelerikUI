Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadRating_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            DataContext = New RatingViewModel(5)
        End Sub

        Private NotInheritable Class RatingViewModel
            Inherits ViewModelBase
            Private Shared randomNumberGenerator As Random = New Random()
            Private averageRatingField As Double
            Private totalVotesField As Double
            Private ratingPointsField As Integer
            Private valueField As Double?

            Public Property Items As ObservableCollection(Of RatingItemModel)
            Public Property UpdateVotesCommand As DelegateCommand

            Public Sub New(ratingPoints As Integer, Optional generateRandomVotes As Boolean = True)
                ratingPointsField = ratingPoints
                Items = New ObservableCollection(Of RatingItemModel)()
                For i = 1 To ratingPoints
                    Items.Add(New RatingItemModel() With {
                        .Value = i
                    })
                Next

                UpdateVotesCommand = New DelegateCommand(AddressOf OnUpdateVotesExecuted, AddressOf OnCanUpdateVotesExecute)

                If generateRandomVotes Then
                    Me.GenerateRandomVotes()
                    TotalVotes = CalculateTotalVotesCount()
                    AverageRating = CalculateAverageRating()
                End If
            End Sub

            Private Sub GenerateRandomVotes()
                For Each item In Items
                    item.VotesCount = randomNumberGenerator.Next(10, 100)
                Next
            End Sub

            Public Property Value As Double?
                Get
                    Return valueField
                End Get

                Set(value As Double?)
                    valueField = value
                    OnPropertyChanged("Value")
                    UpdateVotesCommand.InvalidateCanExecute()
                End Set
            End Property

            Public Property TotalVotes As Double
                Get
                    Return totalVotesField
                End Get

                Set(value As Double)
                    totalVotesField = value
                    OnPropertyChanged("TotalVotes")
                End Set
            End Property

            Public Property AverageRating As Double
                Get
                    Return averageRatingField
                End Get

                Set(value As Double)
                    averageRatingField = value
                    OnPropertyChanged("AverageRating")
                End Set
            End Property

            Public ReadOnly Property RatingPoints As Integer
                Get
                    Return ratingPointsField
                End Get
            End Property

            Private Function OnCanUpdateVotesExecute(obj As Object) As Boolean
                Return If(obj IsNot Nothing, True, False)
            End Function

            Private Sub OnUpdateVotesExecuted(obj As Object)
                Dim itemValue = CDbl(obj)
                Dim ratingModel = Items.FirstOrDefault(Function(x) x.Value = itemValue)
                ratingModel.VotesCount += 1

                TotalVotes = CalculateTotalVotesCount()
                AverageRating = CalculateAverageRating()
            End Sub


            Private Function CalculateAverageRating() As Double
                Dim sum = SumAllVotes()

                Dim average = sum / TotalVotes
                Return Math.Round(average, 2)
            End Function

            Private Function CalculateTotalVotesCount() As Double
                Dim totalVotes = 0
                For Each item In Items
                    totalVotes += item.VotesCount
                Next

                Return totalVotes
            End Function

            Private Function SumAllVotes() As Double
                Dim votesSum As Double = 0
                For Each item In Items
                    votesSum += item.VotesCount * item.Value
                Next

                Return votesSum
            End Function
        End Class

        Private NotInheritable Class RatingItemModel
            Inherits ViewModelBase
            Private votesCountField As Integer

            Public Property Value As Integer

            Public Property VotesCount As Integer
                Get
                    Return votesCountField
                End Get
                Set(value As Integer)
                    If votesCountField <> value Then
                        votesCountField = value
                        OnPropertyChanged("VotesCount")
                    End If
                End Set
            End Property
        End Class
    End Class
End Namespace
