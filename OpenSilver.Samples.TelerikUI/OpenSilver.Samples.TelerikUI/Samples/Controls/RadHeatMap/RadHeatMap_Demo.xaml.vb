Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadHeatMap_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            Me.radHeatMap.Definition.ItemsSource = CreateWeatherData()
        End Sub

        Private Shared Function CreateWeatherData() As List(Of MonthlyTemperature)
            Dim time = New DateTime(2004, 1, 1)
            Dim result = New List(Of MonthlyTemperature)()
            Dim r As Random = New Random()

            For i = 0 To 4
                For a = 0 To 2
                    result.Add(New MonthlyTemperature(time, r.Next(0, 10)))
                    time = time.AddMonths(1)
                Next
                For a = 0 To 2
                    result.Add(New MonthlyTemperature(time, r.Next(10, 20)))
                    time = time.AddMonths(1)
                Next
                For a = 0 To 2
                    result.Add(New MonthlyTemperature(time, r.Next(20, 30)))
                    time = time.AddMonths(1)
                Next
                For a = 0 To 2
                    result.Add(New MonthlyTemperature(time, r.Next(10, 20)))
                    time = time.AddMonths(1)
                Next
            Next
            Return result
        End Function

        Private NotInheritable Class MonthlyTemperature
            Public Sub New(time As Date, temp As Double)
                Me.Time = time
                Temperature = temp
            End Sub

            Public Property Time As Date

            Public Property Temperature As Double
        End Class
    End Class
End Namespace
