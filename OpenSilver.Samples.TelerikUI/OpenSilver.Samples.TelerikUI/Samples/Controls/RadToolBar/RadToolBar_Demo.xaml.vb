Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadToolBar_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            DataContext = New RadToolBarMainViewModel()
        End Sub

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadToolBar_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadToolBar/RadToolBar_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadToolBar_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadToolBar/RadToolBar_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadToolBar_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadToolBar/RadToolBar_Demo.xaml.vb"
    }
})
        End Sub
    End Class

    Public Class RadToolBarMainViewModel
        Public Sub New()
            PopulateSampleViewModel()
        End Sub
        Public Property Items As ObservableCollection(Of ViewModelBase)

        Private Sub PopulateSampleViewModel()
            Items = New ObservableCollection(Of ViewModelBase)() From {
    New TextBlockViewModel("Foreground:"),
    New ColorPickerViewModel(),
    New TextBlockViewModel("Background:"),
    New ColorPickerViewModel(),
    New TextBlockViewModel("BorderColor:"),
    New ColorPickerViewModel(),
    New SeparatorViewModel(),
    New ButtonViewModel("SAVE !", "Save colors configuration.")
}
        End Sub
    End Class

    Public Class TextBlockViewModel
        Inherits ViewModelBase
        Public Sub New(text As String)
            Me.Text = text
        End Sub

        Private textField As String
        Public Property Text As String
            Get
                Return textField
            End Get
            Set(value As String)
                If Not Equals(textField, value) Then
                    textField = value
                    MyBase.OnPropertyChanged("Text")
                End If
            End Set
        End Property

    End Class

    Public Class ColorPickerViewModel
        Inherits ViewModelBase
        Public Sub New()
            MainPaletteColors = New ObservableCollection(Of Color)() From {
    Color.FromArgb(255, 253, 253, 0),
    Color.FromArgb(255, 0, 253, 0),
    Color.FromArgb(255, 0, 253, 253),
    Color.FromArgb(255, 253, 0, 253),
    Color.FromArgb(255, 0, 0, 253),
    Color.FromArgb(255, 253, 0, 0),
    Color.FromArgb(255, 0, 0, 126),
    Color.FromArgb(255, 0, 126, 126),
    Color.FromArgb(255, 0, 126, 0),
    Color.FromArgb(255, 126, 0, 126),
    Color.FromArgb(255, 126, 0, 0),
    Color.FromArgb(255, 126, 126, 0),
    Color.FromArgb(255, 126, 126, 126),
    Color.FromArgb(255, 190, 190, 190),
    Color.FromArgb(255, 0, 1, 1)
}
        End Sub
        Public Property MainPaletteColors As ObservableCollection(Of Color)
    End Class

    Public Class ButtonViewModel
        Inherits ViewModelBase
        Public Sub New(content As String, tooltip As String)
            ToolTipContent = tooltip
            Me.Content = content
            InfoCommand = New DelegateCommand(Sub(x) MessageBox.Show("Colors Saved!"))
        End Sub

        Private tooltip As String

        Public Property ToolTipContent As String
            Get
                Return tooltip
            End Get
            Set(value As String)
                If Not Equals(tooltip, value) Then
                    tooltip = value
                    MyBase.OnPropertyChanged("ToolTipContent")
                End If
            End Set
        End Property


        Private contentField As String

        Public Property Content As String
            Get
                Return contentField
            End Get
            Set(value As String)
                If Not Equals(contentField, value) Then
                    contentField = value
                    MyBase.OnPropertyChanged("Content")
                End If
            End Set
        End Property

        Public Property InfoCommand As DelegateCommand

    End Class

    Public Class SeparatorViewModel
        Inherits ViewModelBase
    End Class

    Public Class ToolBarItemTemplateSelector
        Inherits DataTemplateSelector
        Public Overrides Function SelectTemplate(item As Object, container As DependencyObject) As DataTemplate
            If TypeOf item Is TextBlockViewModel Then
                Return TextBlockTemplate
            ElseIf TypeOf item Is SeparatorViewModel Then
                Return SeparatorTemplate
            ElseIf TypeOf item Is ButtonViewModel Then
                Return ButtonTemplate
            ElseIf TypeOf item Is ColorPickerViewModel Then
                Return ColorPickerTemplate
            End If
            Return MyBase.SelectTemplate(item, container)
        End Function

        Public Property ButtonTemplate As DataTemplate
        Public Property TextBlockTemplate As DataTemplate
        Public Property SeparatorTemplate As DataTemplate
        Public Property ColorPickerTemplate As DataTemplate
    End Class
End Namespace
