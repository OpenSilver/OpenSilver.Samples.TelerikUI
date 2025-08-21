Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Threading

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadTileList_Demo
        Inherits UserControl
        Private ReadOnly _viewModel As NASDAQViewModel
        Private ReadOnly _timer As DispatcherTimer

        Public Sub New()
            Me.InitializeComponent()

            AddHandler Me.RadTileList.MouseWheel, Sub(o, e) e.Handled = True

            AddHandler Loaded, AddressOf OnLoaded
            AddHandler Unloaded, AddressOf OnUnloaded

            _viewModel = New NASDAQViewModel()
            _timer = New DispatcherTimer()
            _timer.Interval = TimeSpan.FromSeconds(5)
            AddHandler _timer.Tick, AddressOf OnTimerTick

            DataContext = _viewModel
        End Sub

        Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
            _timer.Start()
        End Sub

        Private Sub OnUnloaded(sender As Object, e As RoutedEventArgs)
            _timer.Stop()
        End Sub

        Private Sub OnTimerTick(sender As Object, e As EventArgs)
            _viewModel.UpdateDisplayValue()
        End Sub

        Private NotInheritable Class NASDAQViewModel
            Implements INotifyPropertyChanged
            Public Sub New()
                displayValueField = 3498
            End Sub

            Private displayValueField As Double
            Public Property DisplayValue As Double
                Get
                    Return displayValueField
                End Get
                Set(value As Double)
                    If displayValueField <> value Then
                        displayValueField = value
                        OnPropertyChanged("DisplayValue")
                    End If
                End Set
            End Property

            Public Sub UpdateDisplayValue()
                If DisplayValue = 3498 Then
                    DisplayValue = 3470
                Else
                    DisplayValue = 3498
                End If
            End Sub

            Private Sub OnPropertyChanged(propertyName As String)
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
            End Sub

            Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        End Class

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadTileList_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTileList/RadTileList_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTileList_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTileList/RadTileList_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTileList_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTileList/RadTileList_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
