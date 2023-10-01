Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Telerik.Windows.Controls
Imports Telerik.Windows.Controls.GanttView
Imports Telerik.Windows.Controls.Scheduling

Namespace Global.OpenSilver.Samples.TelerikUI
    Public Class GanttViewModel
        Inherits ViewModelBase
        Private ganttTasksField As ObservableCollection(Of GanttTask)
        Private pixelLengthField As TimeSpan
        Private visibleRangeField As VisibleRange
        Private isBusyField As Boolean

        Public Sub New()
            GanttTasks = New ObservableCollection(Of GanttTask)()
            pixelLengthField = New TimeSpan(0, 10, 0)
            VisibleRange = New VisibleRange(Date.Today, Date.Today.AddDays(9))
        End Sub

        Public Property GanttTasks As ObservableCollection(Of GanttTask)
            Get
                Return ganttTasksField
            End Get
            Set(ByVal value As ObservableCollection(Of GanttTask))
                ganttTasksField = value
                OnPropertyChanged(Function() GanttTasks)
            End Set
        End Property

        Public Property PixelLength As TimeSpan
            Get
                Return pixelLengthField
            End Get
            Set(ByVal value As TimeSpan)
                pixelLengthField = value
                OnPropertyChanged(Function() PixelLength)
            End Set
        End Property

        Public Property VisibleRange As VisibleRange
            Get
                Return visibleRangeField
            End Get
            Set(ByVal value As VisibleRange)
                visibleRangeField = value
                OnPropertyChanged(Function() VisibleRange)
            End Set
        End Property

        Public Property IsBusy As Boolean
            Get
                Return isBusyField
            End Get
            Set(ByVal value As Boolean)
                If isBusyField <> value Then
                    isBusyField = value
                    OnPropertyChanged(Function() IsBusy)

                    If IsBusy Then
                        Dim backgroundWorker = New BackgroundWorker()
                        AddHandler backgroundWorker.DoWork, AddressOf OnBackgroundWorkerDoWork
                        AddHandler backgroundWorker.RunWorkerCompleted, AddressOf OnBackgroundWorkerRunWorkerCompleted
                        backgroundWorker.RunWorkerAsync()
                    End If
                End If
            End Set
        End Property

        Private Sub OnBackgroundWorkerRunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
            Dim backgroundWorker = TryCast(sender, BackgroundWorker)
            RemoveHandler backgroundWorker.DoWork, AddressOf OnBackgroundWorkerDoWork
            RemoveHandler backgroundWorker.RunWorkerCompleted, AddressOf OnBackgroundWorkerRunWorkerCompleted

            Call InvokeOnUIThread(Sub()
                                      GanttTasks = New ObservableCollection(Of GanttTask)(CType(e.Result, IEnumerable(Of GanttTask)))
                                      IsBusy = False
                                  End Sub)

        End Sub

        Private Sub OnBackgroundWorkerDoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
            Dim ganttTasks = GenerateTasks()
            e.Result = ganttTasks
        End Sub

        Private Function GenerateTasks() As IEnumerable(Of GanttTask)
            Dim ganttTasks As List(Of GanttTask) = New List(Of GanttTask)()

            Dim ganttTasksCount = 0

            For index = 0 To 2
                Dim start = Date.Today.AddDays(1)
                Dim [end] = start.AddDays(1)

                Dim ganttTask = New GanttTask With {
                    .Title = String.Format("Task{0}", ganttTasksCount),
                    .Start = start.AddDays(-0.5),
                    .[End] = [end].AddDays(6.5),
                    .UniqueId = index.ToString()
                }

                ganttTasks.Add(ganttTask)
                ganttTasksCount += 1

                For children = 0 To 4
                    Dim startAdd = children / 2 + (children Mod 2) * 0.5 - 0.5
                    Dim endAdd = startAdd + 0.5
                    Dim child = New GanttTask With {
                        .Title = String.Format("Task{0}", ganttTasksCount),
                        .Start = start.AddDays(startAdd),
                        .[End] = start.AddDays(endAdd)
                    }
                    If children <> 0 Then
                        child.Dependencies.Add(New Dependency With {
                            .FromTask = ganttTask.Children(children - 1),
                            .Type = DependencyType.FinishStart
                        })
                    End If
                    ganttTask.Children.Add(child)
                    ganttTasksCount += 1
                Next
            Next

            Return ganttTasks
        End Function
    End Class
End Namespace
