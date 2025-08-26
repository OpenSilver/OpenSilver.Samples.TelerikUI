Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadGanttView_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            AddHandler Loaded, AddressOf RadGanttView_Demo_Loaded
        End Sub

        Private Sub RadGanttView_Demo_Loaded(sender As Object, e As RoutedEventArgs)
            Dim model As TelerikUI.GanttViewModel = New TelerikUI.GanttViewModel()
            model.IsBusy = True
            DataContext = model
        End Sub
    End Class
End Namespace
