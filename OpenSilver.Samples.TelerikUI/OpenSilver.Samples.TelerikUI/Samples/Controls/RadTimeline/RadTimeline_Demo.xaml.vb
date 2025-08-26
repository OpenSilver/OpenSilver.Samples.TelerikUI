Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls.Timeline

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadTimeline_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            DataContext = New RadTimelineGroupingViewModel()
        End Sub

        Private NotInheritable Class RadTimelineDataItem
            Public Property StartDate As Date

            Public Property Duration As TimeSpan

            Public Property GroupName As String
        End Class

        Private NotInheritable Class RadTimelineGroupingViewModel
            Public Sub New()
                PeriodStart = New DateTime(2011, 1, 1)
                PeriodEnd = New DateTime(2012, 1, 1)

                GenerateTimelineData()
            End Sub

            Public Property PeriodStart As Date

            Public Property PeriodEnd As Date

            Public Property TimelineItems As List(Of RadTimelineDataItem)

            Private Sub GenerateTimelineData()
                Dim r As Random = New Random()
                Dim items As List(Of RadTimelineDataItem) = New List(Of RadTimelineDataItem)()

                Dim [date] = PeriodStart

                While [date] < PeriodEnd
                    items.Add(New RadTimelineDataItem() With {
    .StartDate = [date],
    .Duration = TimeSpan.FromDays(r.Next(0, 10)),
    .GroupName = $"Group{r.Next(1, 4)}"
})
                    [date] = [date].AddDays(2)
                End While

                TimelineItems = items
            End Sub
        End Class

        Private Sub RadToggleButton_Checked(sender As Object, e As RoutedEventArgs)
            Me.timeline.GroupPath = "GroupName"
            Select Case Me.timeline.GroupExpandMode
                Case GroupExpandMode.None
                    Me.choiceNone.IsChecked = True
                Case GroupExpandMode.Single
                    Me.choiceSingle.IsChecked = True
                Case GroupExpandMode.Multiple
                    Me.choiceMultiple.IsChecked = True
            End Select
            Me.choiceNone.IsEnabled = True
            Me.choiceSingle.IsEnabled = True
            Me.choiceMultiple.IsEnabled = True
        End Sub

        Private Sub RadToggleButton_Unchecked(sender As Object, e As RoutedEventArgs)
            Me.timeline.GroupPath = Nothing
            Me.timeline.GroupExpandMode = GroupExpandMode.None
            Me.choiceNone.IsChecked = False
            Me.choiceSingle.IsChecked = False
            Me.choiceMultiple.IsChecked = False
            Me.choiceNone.IsEnabled = False
            Me.choiceSingle.IsEnabled = False
            Me.choiceMultiple.IsEnabled = False
        End Sub

        Private Sub NoneRadioButton_Checked(sender As Object, e As RoutedEventArgs)
            Me.timeline.GroupExpandMode = GroupExpandMode.None
        End Sub

        Private Sub SingleRadioButton_Checked(sender As Object, e As RoutedEventArgs)
            Me.timeline.GroupExpandMode = GroupExpandMode.Single
        End Sub

        Private Sub MultipleRadioButton_Checked(sender As Object, e As RoutedEventArgs)
            Me.timeline.GroupExpandMode = GroupExpandMode.Multiple
        End Sub
    End Class
End Namespace
