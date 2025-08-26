Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadTimeBar_Demo
        Inherits UserControl
        Private sliderActualHeight As Double

        Public Sub New()
            Me.InitializeComponent()
            DataContext = GetData()
        End Sub

        Private Shared Function GetData() As List(Of PlotInfo)
            Dim r As Random = New Random()
            Dim data = New List(Of PlotInfo)()

            For i = 0 To 99
                data.Add(New PlotInfo With {
                    .[Date] = New DateTime(2014, 10, 3).AddDays(i),
                    .Val = r.Next(0, 500)
                })
            Next

            Return data
        End Function

        Private Sub chart1_PlotAreaClipChanged(sender As Object, e As EventArgs)
            UpdateTimeBarMargin()
        End Sub

        Private Sub slider_SelectionChanged(sender As Object, e As Telerik.Windows.RadRoutedEventArgs)
            Dim slider = CType(sender, RadSlider)
            Dim range = slider.Maximum - slider.Minimum
            If range <> 0 Then
                Me.chart1.HorizontalZoomRangeStart = (slider.SelectionStart - slider.Minimum) / range
                Me.chart1.HorizontalZoomRangeEnd = (slider.SelectionEnd - slider.Minimum) / range
            End If
        End Sub

        Private Sub timeBarContent_SizeChanged(sender As Object, e As SizeChangedEventArgs)
            UpdateChartMargin()
        End Sub

        Private Sub slider_SizeChanged(sender As Object, e As SizeChangedEventArgs)
            sliderActualHeight = e.NewSize.Height
            UpdateChartMargin()
        End Sub

        Private Sub UpdateChartMargin()
            Dim topMargin As Double = Me.timeBar1.ActualHeight - (Me.timeBarContent1.ActualHeight + sliderActualHeight)
            Me.chart1.Margin = New Thickness(0, topMargin, 0, sliderActualHeight)
        End Sub

        Private Sub UpdateTimeBarMargin()
            Dim verticalAxisWidth As Double = Me.chart1.PlotAreaClip.X + Me.chart1.PanOffset.X
            Me.timeBar1.Margin = New Thickness(verticalAxisWidth, 0, 0, 0)
        End Sub

        Private NotInheritable Class PlotInfo
            Public Property [Date] As Date
            Public Property Val As Double
        End Class
    End Class
End Namespace
