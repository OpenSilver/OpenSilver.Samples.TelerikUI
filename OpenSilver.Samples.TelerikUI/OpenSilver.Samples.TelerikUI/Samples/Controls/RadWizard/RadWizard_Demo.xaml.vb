Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows
Imports Telerik.Windows.Controls
Imports Telerik.Windows.Controls.Wizard

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadWizard_Demo
        Inherits UserControl
        Private ReadOnly viewModel As ViewModelType = New ViewModelType()

        Public Sub New()
            Me.InitializeComponent()
            DataContext = viewModel
            [AddHandler](RadToggleButton.ClickEvent, New RoutedEventHandler(AddressOf OnClick))
        End Sub

        Private Sub OnClick(sender As Object, e As RoutedEventArgs)
            Dim toggleButton = TryCast(e.OriginalSource, RadToggleButton)

            If toggleButton IsNot Nothing Then
                If toggleButton.IsChecked Then
                    viewModel.ButtonClicksCount += 1
                Else
                    viewModel.ButtonClicksCount -= 1
                End If
            End If
        End Sub

        Private Sub wizard_Completed(sender As Object, e As WizardCompletedEventArgs)
            TryCast(sender, RadWizard).SelectedPageIndex = 0
        End Sub

        Private NotInheritable Class ViewModelType
            Inherits ViewModelBase
            Private _buttonClicksCount As Integer
            Public Property ButtonClicksCount As Integer
                Get
                    Return Me._buttonClicksCount
                End Get
                Set(value As Integer)
                    If value <> Me._buttonClicksCount Then
                        Me._buttonClicksCount = value
                        OnPropertyChanged("IsSelected")
                    End If
                End Set
            End Property

            Public ReadOnly Property IsSelected As Boolean
                Get
                    Return Me.ButtonClicksCount > 0
                End Get
            End Property
        End Class
    End Class
End Namespace
