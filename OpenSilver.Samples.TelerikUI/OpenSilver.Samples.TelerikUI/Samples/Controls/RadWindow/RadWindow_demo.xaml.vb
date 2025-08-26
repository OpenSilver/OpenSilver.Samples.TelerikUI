Imports OpenSilver.Samples.TelerikUI.Window
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports Telerik.Windows.Controls
Imports WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadWindow_Demo
        Inherits UserControl
        Private ReadOnly viewModel As WindowConfigurationViewModel
        Private windowField As RadWindow

        Public Sub New()
            viewModel = New WindowConfigurationViewModel()
            DataContext = viewModel

            Me.InitializeComponent()

            Me.resizeModeCB.ItemsSource = New ResizeMode() {ResizeMode.CanResize, ResizeMode.CanMinimize, ResizeMode.NoResize}

            Me.windowStartupLocationCB.ItemsSource = New WindowStartupLocation() {WindowStartupLocation.Manual, WindowStartupLocation.CenterScreen, WindowStartupLocation.CenterOwner}

            Me.windowStateCB.ItemsSource = New WindowState() {WindowState.Normal, WindowState.Minimized, WindowState.Maximized}

            viewModel.CanClose = True
            viewModel.CanMove = True
            viewModel.RestoreMinimizedLocation = False
            viewModel.IsClosed = True
            viewModel.Height = 250
            viewModel.Width = 250
            viewModel.ResizeMode = ResizeMode.CanResize
            viewModel.StartupLocation = WindowStartupLocation.CenterOwner
            viewModel.State = WindowState.Normal
            viewModel.Left = 0
            viewModel.Top = 0

            AddHandler Unloaded, AddressOf OnExampleUnloaded
        End Sub

        Public ReadOnly Property Window As RadWindow
            Get
                If windowField Is Nothing Then
                    windowField = CreateWindow()
                End If

                Return windowField
            End Get
        End Property

        Private Sub OnExampleUnloaded(sender As Object, e As RoutedEventArgs)
            If windowField IsNot Nothing Then
                windowField.Close()
            End If
        End Sub

        Private Sub OnShowModalClicked(sender As Object, e As RoutedEventArgs)
            If Not Window.IsOpen Then
                viewModel.CanClose = True
                Window.ShowDialog()
            End If
        End Sub

        Private Sub OnShowClicked(sender As Object, e As RoutedEventArgs)
            If Not Window.IsOpen Then
                Window.Show()
            End If
        End Sub

        Private Function CreateWindow() As RadWindow
            windowField = New TelerikUI.Window.ExampleWindow With {
    .DataContext = DataContext
}

            windowField.Owner = Me.owner
            AddHandler windowField.Closed, New EventHandler(Of WindowClosedEventArgs)(AddressOf window_Closed)
            AddHandler windowField.Loaded, New RoutedEventHandler(AddressOf window_Loaded)
            Return windowField
        End Function

        Private Sub window_Loaded(sender As Object, e As RoutedEventArgs)
            viewModel.IsClosed = False
        End Sub

        Private Sub window_Closed(sender As Object, e As WindowClosedEventArgs)
            viewModel.IsClosed = True
        End Sub

        Private Sub OnAlertClicked(sender As Object, e As RoutedEventArgs)
            Dim alertText = "The picture has been uploaded."
            Call RadWindow.Alert(New DialogParameters With {
    .Content = alertText,
    .Closed = New EventHandler(Of WindowClosedEventArgs)(AddressOf OnClosed),
    .DialogStartupLocation = WindowStartupLocation.CenterScreen
})
        End Sub

        Private Sub OnClosed(sender As Object, e As WindowClosedEventArgs)
            Call RadWindow.Alert(New DialogParameters With {
    .Content = $"DialogResult: {e.DialogResult}, PromptResult: {e.PromptResult}",
    .DialogStartupLocation = WindowStartupLocation.CenterScreen
})
        End Sub

        Private Sub OnPromptClicked(sender As Object, e As RoutedEventArgs)
            Dim promptText = "Change title:"
            Call RadWindow.Prompt(New DialogParameters With {
    .Content = promptText,
    .Closed = New EventHandler(Of WindowClosedEventArgs)(AddressOf OnPromptClosed),
    .DialogStartupLocation = WindowStartupLocation.CenterScreen
})
        End Sub

        Private Sub OnPromptClosed(sender As Object, e As WindowClosedEventArgs)
            Call RadWindow.Alert(New DialogParameters With {
    .Content = $"DialogResult: {e.DialogResult}, PromptResult: {e.PromptResult}",
    .DialogStartupLocation = WindowStartupLocation.CenterScreen
})

            If Not Equals(e.PromptResult, Nothing) AndAlso Not Equals(e.PromptResult, String.Empty) Then
                viewModel.Title = e.PromptResult
            End If
        End Sub

        Private Sub OnConfirmClicked(sender As Object, e As RoutedEventArgs)
            Dim confirmText = "Are you sure you want to switch the picture?"
            Call RadWindow.Confirm(New DialogParameters With {
    .Content = confirmText,
    .Closed = New EventHandler(Of WindowClosedEventArgs)(AddressOf OnConfirmClosed),
    .DialogStartupLocation = WindowStartupLocation.CenterScreen
})
        End Sub

        Private Sub OnConfirmClosed(sender As Object, e As WindowClosedEventArgs)
            Call RadWindow.Alert(New DialogParameters With {
    .Content = $"DialogResult: {e.DialogResult}, PromptResult: {e.PromptResult}",
    .DialogStartupLocation = WindowStartupLocation.CenterScreen
})

            If e.DialogResult = True Then
                viewModel.NextPicture()
            End If
        End Sub

        Private NotInheritable Class WindowConfigurationViewModel
            Inherits ViewModelBase
            Private Shared ReadOnly images As BitmapImage() = New BitmapImage() {New BitmapImage(New Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Earth.png", UriKind.RelativeOrAbsolute)), New BitmapImage(New Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Jupiter.png", UriKind.RelativeOrAbsolute)), New BitmapImage(New Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Mars.png", UriKind.RelativeOrAbsolute)), New BitmapImage(New Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Mercury.png", UriKind.RelativeOrAbsolute)), New BitmapImage(New Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Neptune.png", UriKind.RelativeOrAbsolute)), New BitmapImage(New Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Saturn.png", UriKind.RelativeOrAbsolute)), New BitmapImage(New Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Uranus.png", UriKind.RelativeOrAbsolute)), New BitmapImage(New Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Venus.png", UriKind.RelativeOrAbsolute))}

            Private titleField As String = "RadWindow"
            Private pictureField As BitmapImage = images(0)
            Private canCloseField As Boolean
            Private canMoveField As Boolean
            Private restoreMinimizedLocationField As Boolean
            Private isClosedField As Boolean
            Private heightField As Double
            Private widthField As Double
            Private resizeModeField As ResizeMode
            Private startupLocationField As WindowStartupLocation
            Private stateField As WindowState
            Private leftField As Double
            Private topField As Double

            Public Sub NextPicture()
                Picture = images((Array.IndexOf(images, pictureField) + 1) Mod images.Length)
            End Sub

            Public Property Title As String
                Get
                    Return titleField
                End Get
                Set(value As String)
                    If Not Equals(titleField, value) Then
                        titleField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.Title))
                    End If
                End Set
            End Property

            Public Property Picture As BitmapImage
                Get
                    Return pictureField
                End Get
                Private Set(value As BitmapImage)
                    If pictureField IsNot value Then
                        pictureField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.Picture))
                    End If
                End Set
            End Property

            Public Property CanClose As Boolean
                Get
                    Return canCloseField
                End Get
                Set(value As Boolean)
                    If canCloseField <> value Then
                        canCloseField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.CanClose))
                    End If
                End Set
            End Property

            Public Property CanMove As Boolean
                Get
                    Return canMoveField
                End Get
                Set(value As Boolean)
                    If canMoveField <> value Then
                        canMoveField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.CanMove))
                    End If
                End Set
            End Property

            Public Property RestoreMinimizedLocation As Boolean
                Get
                    Return restoreMinimizedLocationField
                End Get
                Set(value As Boolean)
                    If restoreMinimizedLocationField <> value Then
                        restoreMinimizedLocationField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.RestoreMinimizedLocation))
                    End If
                End Set
            End Property

            Public Property IsClosed As Boolean
                Get
                    Return isClosedField
                End Get
                Set(value As Boolean)
                    If isClosedField <> value Then
                        isClosedField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.IsClosed))
                    End If
                End Set
            End Property

            Public Property Height As Double
                Get
                    Return heightField
                End Get
                Set(value As Double)
                    If heightField <> value Then
                        heightField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.Height))
                    End If
                End Set
            End Property

            Public Property Width As Double
                Get
                    Return widthField
                End Get
                Set(value As Double)
                    If widthField <> value Then
                        widthField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.Width))
                    End If
                End Set
            End Property

            Public Property ResizeMode As ResizeMode
                Get
                    Return resizeModeField
                End Get
                Set(value As ResizeMode)
                    If resizeModeField <> value Then
                        resizeModeField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.ResizeMode))
                    End If
                End Set
            End Property

            Public Property StartupLocation As WindowStartupLocation
                Get
                    Return startupLocationField
                End Get
                Set(value As WindowStartupLocation)
                    If startupLocationField <> value Then
                        startupLocationField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.StartupLocation))
                    End If
                End Set
            End Property

            Public Property State As WindowState
                Get
                    Return stateField
                End Get
                Set(value As WindowState)
                    If stateField <> value Then
                        stateField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.State))
                    End If
                End Set
            End Property

            Public Property Left As Double
                Get
                    Return leftField
                End Get
                Set(value As Double)
                    If leftField <> value Then
                        leftField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.Left))
                    End If
                End Set
            End Property

            Public Property Top As Double
                Get
                    Return topField
                End Get
                Set(value As Double)
                    If topField <> value Then
                        topField = value
                        OnPropertyChanged(NameOf(WindowConfigurationViewModel.Top))
                    End If
                End Set
            End Property
        End Class
    End Class
End Namespace
