Imports Bogus
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class ScatterPointSeries_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            Dim faker = New Faker(Of EmployeeData)().StrictMode(True).RuleFor(Function(o) o.Name, Function(f) f.Name.FirstName()).RuleFor(Function(o) o.Age, Function(f) f.Random.Int(20, 40)).RuleFor(Function(o) o.Salary, Function(f) f.Random.Int(10000, 25000))

            DataContext = faker.Generate(30)
        End Sub

        Private Sub RadCartesianChart_MouseDown(sender As Object, e As Input.MouseButtonEventArgs)
            AddHandler Application.Current.MainWindow.KeyDown, AddressOf MainWindow_KeyDown
        End Sub

        Private Sub RadCartesianChart_MouseUp(sender As Object, e As Input.MouseButtonEventArgs)
            RemoveHandler Application.Current.MainWindow.KeyDown, AddressOf MainWindow_KeyDown
        End Sub

        Private Sub MainWindow_KeyDown(sender As Object, e As Input.KeyEventArgs)
            If e.Key = Input.Key.Escape Then
                Me.panZoomBehavior.CancelDragToZoom()
            End If
        End Sub

        Private NotInheritable Class EmployeeData
            Public Property Name As String
            Public Property Age As Integer
            Public Property Salary As Double
        End Class
    End Class
End Namespace
