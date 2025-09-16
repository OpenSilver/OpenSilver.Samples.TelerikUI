Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports Telerik.Windows.Controls.Charting

Namespace OpenSilver.Samples.TelerikUI.RadChart3D.Helpers
    Friend NotInheritable Class UserDataPoint
        Public Sub New()
        End Sub

        Public Sub New(x As Double, y As Double)
            Me.X = x
            Me.Y = y
        End Sub

        Public Sub New(high As Double, low As Double, open As Double, close As Double)
            Me.High = high
            Me.Low = low
            Me.Open = open
            Me.Close = close
        End Sub

        Public Property X As Double

        Public Property Y As Double

        Public Property High As Double

        Public Property Low As Double

        Public Property Open As Double

        Public Property Close As Double

        Public Property BubbleSize As Double

        Public Property LegendLabel As String
    End Class

    Friend Module SeriesExtensions
        Private ReadOnly constsY As Double(,) = New Double(2, 11) {
    {24, 9, 18, 31, 25, 13, 17, 33, 21, 28, 19, 11},
    {6, 19, 28, 11, 15, 31, 27, 14, 19, 21, 30, 15},
            {17, 8, 31, 22, 26, 12, 23, 17, 28, 19, 24, 29}}

        Private ReadOnly constsRange As Double(,) = New Double(1, 11) {
    {24, 9, 18, 31, 25, 13, 17, 33, 21, 28, 19, 11},
            {17, 6, 12, 22, 20, 8, 13, 28, 18, 19, 18, 7}}

        Private ReadOnly constsFinancial As Double(,) = New Double(3, 6) {
    {24, 29, 31, 28, 25, 22, 26},
    {16, 18, 24, 16, 15, 18, 16},
    {17, 19, 25, 27, 17, 19, 19},
            {19, 25, 27, 17, 19, 19, 17}}

        Public Function GetUserData(numberOfItems As Integer, seriesIndex As Integer) As Double()
            Dim num = If(numberOfItems Mod 12 = 0, 12, numberOfItems Mod 12)
            Dim ind = seriesIndex Mod 3
            Dim points = New Double(num - 1) {}

            For i = 0 To num - 1
                points(i) = constsY(ind, i)
            Next

            Return points
        End Function

        Public Function GetUserScatterData() As List(Of List(Of UserDataPoint))
            Dim data As List(Of List(Of UserDataPoint)) = New List(Of List(Of UserDataPoint))()
            Dim rand As Random = New Random(Date.Now.Millisecond)

            Dim seriesData As List(Of UserDataPoint) = New List(Of UserDataPoint)()
            For i = 0 To 198
                seriesData.Add(New UserDataPoint(rand.Next(-100, 100), rand.Next(-990, 990)))
            Next
            data.Add(seriesData)

            Dim seriesData2 As List(Of UserDataPoint) = New List(Of UserDataPoint)()
            For i = 0 To 149
                seriesData2.Add(New UserDataPoint(rand.Next(0, 30), rand.Next(10, 300)))
            Next
            data.Add(seriesData2)

            Dim seriesData3 As List(Of UserDataPoint) = New List(Of UserDataPoint)()
            For i = 0 To 49
                seriesData3.Add(New UserDataPoint(rand.Next(-80, 10), rand.Next(10, 600)))
            Next
            data.Add(seriesData3)

            Return data
        End Function

        Public Function GetUserBubbleData() As List(Of UserDataPoint)
            Dim points As List(Of UserDataPoint) = New List(Of UserDataPoint)()

            points.Add(CreateBubbleUserDataPoint(20, -40))
            points.Add(CreateBubbleUserDataPoint(40, 80))
            points.Add(CreateBubbleUserDataPoint(80, -20))
            points.Add(CreateBubbleUserDataPoint(60, 100))
            points.Add(CreateBubbleUserDataPoint(10, 20))

            Return points
        End Function

        Public Function GetUserBubbleMixedData() As List(Of UserDataPoint)
            Dim points As List(Of UserDataPoint) = New List(Of UserDataPoint)()

            points.Add(CreateBubbleUserDataPoint(75, -60))
            points.Add(CreateBubbleUserDataPoint(10, 40))
            points.Add(CreateBubbleUserDataPoint(40, -60))
            points.Add(CreateBubbleUserDataPoint(20, 50))
            points.Add(CreateBubbleUserDataPoint(50, 80))
            points.Add(CreateBubbleUserDataPoint(30, -40))

            Return points
        End Function

        Private Function CreateBubbleUserDataPoint(valueY As Double, bubbleSize As Double) As UserDataPoint
            Dim dataPnt As UserDataPoint = New UserDataPoint()
            dataPnt.Y = valueY
            dataPnt.BubbleSize = bubbleSize
            Return dataPnt
        End Function

        Public Function GetUserFinancialData(numberOfItems As Integer) As List(Of UserDataPoint)
            Dim points As List(Of UserDataPoint) = New List(Of UserDataPoint)()
            Dim num = If(numberOfItems Mod 7 = 0, 7, numberOfItems Mod 7)

            For i = 0 To numberOfItems - 1
                Dim point As UserDataPoint = New UserDataPoint()
                point.Open = constsFinancial(2, i Mod num)
                point.Close = constsFinancial(3, i Mod num)
                point.Low = constsFinancial(1, i Mod num)
                point.High = constsFinancial(0, i Mod num)

                points.Add(point)
            Next

            Return points
        End Function

        Public Function GetUserRadialData() As Double()
            Return GetUserData(10, 0)
        End Function

        Public Function GetUserRangeData(numberOfItems As Integer) As List(Of UserDataPoint)
            Dim points As List(Of UserDataPoint) = New List(Of UserDataPoint)()
            Dim num = If(numberOfItems Mod 12 = 0, 12, numberOfItems Mod 12)

            For i = 1 To num - 1
                Dim data As UserDataPoint = New UserDataPoint()

                data.Low = constsRange(1, i)
                data.High = constsRange(0, i)
                points.Add(data)
            Next

            Return points
        End Function


        Public Sub FillWithSampleData(series As DataSeries)
            Dim random As Random = New Random(CInt((series.GetHashCode() + Date.Now.Ticks Mod 10000)))
            FillWithSampleData(series, random.Next(10, 15))
        End Sub

        Public Sub FillWithSampleData(series As DataSeries, numberOfItems As Integer, max As Integer, deviation As Integer)
            Dim random As Random = New Random(CInt((series.GetHashCode() + Date.Now.Ticks Mod 10000)))

            If deviation > max Then deviation = max

            For i = 0 To numberOfItems - 1
                series.Add(New DataPoint(random.Next(max - deviation, max)))
            Next
        End Sub

        Public Sub FillWithSampleData(series As DataSeries, numberOfItems As Integer, sum As Integer)
            Dim localSum = 0

            Dim random As Random = New Random(CInt((series.GetHashCode() + Date.Now.Ticks Mod 10000)))

            For i = 0 To numberOfItems - 1
                Dim randomNumber = 0

                While randomNumber <= 0
                    randomNumber = random.Next(sum / numberOfItems - 3, sum / numberOfItems + 3)
                End While

                If localSum + randomNumber > sum Then randomNumber = sum - localSum

                If i = numberOfItems - 1 AndAlso localSum + randomNumber < sum Then randomNumber = sum - localSum

                localSum += randomNumber

                Dim dataPoint As DataPoint = New DataPoint()
                dataPoint.YValue = randomNumber

                series.Add(dataPoint)
            Next
        End Sub

        Public Sub FillWithSampleRadialData(series As DataSeries)
            Dim random As Random = New Random(CInt((series.GetHashCode() + Date.Now.Ticks Mod 10000)))
            FillWithSampleData(series, random.Next(4, 7))
        End Sub

        Public Sub FillWithSampleBubbleData(series As DataSeries)
            series.Add(New DataPoint With {
                .YValue = 20,
                .BubbleSize = 40
            })
            series.Add(New DataPoint With {
                .YValue = 40,
                .BubbleSize = 80
            })
            series.Add(New DataPoint With {
                .YValue = 80,
                .BubbleSize = 20
            })
            series.Add(New DataPoint With {
                .YValue = 60,
                .BubbleSize = 100
            })
            series.Add(New DataPoint With {
                .YValue = 10,
                .BubbleSize = 20
            })
        End Sub

        Public Sub FillWithSampleBubbleMixedData(series As DataSeries)
            series.Add(New DataPoint With {
                .YValue = 75,
                .BubbleSize = -60
            })
            series.Add(New DataPoint With {
                .YValue = 10,
                .BubbleSize = 40
            })
            series.Add(New DataPoint With {
                .YValue = 40,
                .BubbleSize = -60
            })
            series.Add(New DataPoint With {
                .YValue = 20,
                .BubbleSize = 50
            })
            series.Add(New DataPoint With {
                .YValue = 50,
                .BubbleSize = 80
            })
            series.Add(New DataPoint With {
                .YValue = 30,
                .BubbleSize = -40
            })
        End Sub

        Public Sub FillWithSampleData(series As DataSeries, numberOfItems As Integer)
            Dim random As Random = New Random(CInt((series.GetHashCode() + Date.Now.Ticks Mod 10000)))
            For i = 0 To numberOfItems - 1
                Dim randomNumber = random.Next(30, 100)
                series.Add(New DataPoint(randomNumber))
            Next
        End Sub

        Public Sub FillWithSampleFinancialData(series As DataSeries, numberOfItems As Integer, numberOfPeaks As Integer)
            Dim random As Random = New Random(CInt((series.GetHashCode() + Date.Now.Ticks Mod 10000)))

            Dim openArray = New Integer(numberOfItems - 1) {}
            Dim closeArray = New Integer(numberOfItems - 1) {}
            Dim maxArray = New Integer(numberOfItems - 1) {}
            Dim minArray = New Integer(numberOfItems - 1) {}

            Dim peakIndices = New Integer(numberOfPeaks - 1) {}

            ' Calculate peak indices
            For i = 1 To numberOfPeaks
                peakIndices(i - 1) = Math.Min(i * numberOfItems / numberOfPeaks, numberOfItems - 1)
            Next

            Dim trend = False

            Dim currentIndex = 0
            Dim startValue = 20

            'Calculate open close values
            For j = 0 To numberOfPeaks - 1
                trend = Not trend

                Dim peakIndex = numberOfItems - 1

                Try
                    peakIndex = peakIndices(j)
                Catch
                End Try

                Dim k = currentIndex + 1

                While k <= peakIndex
                    Dim factor = random.Next(1, 5)

                    If trend Then
                        openArray(k) = random.Next(Math.Abs(startValue + factor), Math.Abs(startValue + CInt(1.1) * factor))
                    Else
                        Dim min = Math.Min(Math.Abs(startValue - factor), Math.Abs(startValue - CInt(1.1) * factor))
                        Dim max = Math.Max(Math.Abs(startValue - CInt(1.1) * factor), Math.Abs(startValue - factor))

                        openArray(k) = random.Next(min, max)
                    End If
                    closeArray(k - 1) = openArray(k)
                    k += 1
                    currentIndex += 1
                End While
            Next

            openArray(0) = random.Next(startValue, closeArray(0))
            closeArray(numberOfItems - 1) = random.Next(openArray(numberOfItems - 1), openArray(numberOfItems - 1) + 15)

            random = New Random(CInt((series.GetHashCode() + Date.Now.Ticks Mod 10000)))

            'Calculate high values
            For i = 0 To numberOfItems - 1
                Dim max = Math.Max(openArray(i), closeArray(i))
                Dim abs = Math.Abs(openArray(i) - closeArray(i))

                Do
                    maxArray(i) = random.Next(max + 1, max + 3)
                Loop While maxArray(i) <= max
            Next

            'Calculate low values
            For i = 0 To numberOfItems - 1
                Dim min = Math.Min(openArray(i), closeArray(i))

                Debug.Assert(min >= 0, "Open or close value is negative")

                Dim abs = Math.Abs(openArray(i) - closeArray(i))

                Do
                    If min > 0 Then
                        minArray(i) = Math.Abs(random.Next(min - 3, min - 1))
                    Else
                        minArray(i) = 0
                    End If
                Loop While minArray(i) > min OrElse minArray(i) < 0
            Next

            Dim randomPoints As List(Of DataPoint) = New List(Of DataPoint)()

            For i = 0 To numberOfItems - 1
                Dim point As DataPoint = New DataPoint()
                point.Open = openArray(i)
                point.Close = closeArray(i)
                point.Low = minArray(i)
                point.High = maxArray(i)

                randomPoints.Add(point)
            Next

            Dim invalid = From r In randomPoints Where r.Low < 0 OrElse r.Open < 0 OrElse r.High < 0 OrElse r.Close < 0 Select r

            Call Debug.Assert(invalid.Count() = 0, "The generated data contains negative values.")

            series.AddRange(randomPoints)
        End Sub

        Public Sub FillWithSampleRangeData(series As DataSeries, numberOfItems As Integer)
            Dim r As Random = New Random()
            Dim data As DataPoint = New DataPoint()
            data.Low = r.Next(20, 70)
            data.High = data.Low + r.Next(20, 30)
            series.Add(data)
            For i = 1 To numberOfItems - 1
                data = New DataPoint()
                Dim change = r.Next(0, 24) - 12
                data.Low = series(i - 1).Low + change
                data.High = Math.Max(series(i - 1).High + change + r.Next(0, 12) - 6, data.Low + 4)
                series.Add(data)
            Next
        End Sub
    End Module
End Namespace
