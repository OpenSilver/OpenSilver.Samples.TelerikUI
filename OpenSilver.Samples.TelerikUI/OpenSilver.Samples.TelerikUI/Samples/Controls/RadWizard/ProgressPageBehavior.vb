Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Threading
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI.Wizard
    Public Class ProgressPageBehavior
        Private ReadOnly page As WizardPage = Nothing
        Private timer As DispatcherTimer
        Private progressBar As RadProgressBar

        Public Sub New(page As WizardPage)
            Me.page = page
        End Sub

        Public Shared ReadOnly IsEnabledProperty As DependencyProperty = DependencyProperty.RegisterAttached("IsEnabled", GetType(Boolean), GetType(ProgressPageBehavior), New PropertyMetadata(New PropertyChangedCallback(AddressOf OnIsEnabledPropertyChanged)))

        Public Shared Sub SetIsEnabled(dependencyObject As DependencyObject, enabled As Boolean)
            dependencyObject.SetValue(IsEnabledProperty, enabled)
        End Sub

        Public Shared Function GetIsEnabled(dependencyObject As DependencyObject) As Boolean
            Return dependencyObject.GetValue(IsEnabledProperty)
        End Function

        Private Shared Sub OnIsEnabledPropertyChanged(dependencyObject As DependencyObject, e As DependencyPropertyChangedEventArgs)
            Dim page = TryCast(dependencyObject, WizardPage)
            If page IsNot Nothing Then
                If e.NewValue Then
                    Dim behavior = New ProgressPageBehavior(page)
                    behavior.Attach()
                End If
            End If
        End Sub

        Private Sub Attach()
            timer = New DispatcherTimer()
            timer.Interval = TimeSpan.FromMilliseconds(10.0)
            AddHandler timer.Tick, New EventHandler(AddressOf Timer_Tick)

            If page IsNot Nothing Then
                AddHandler page.Loaded, AddressOf page_Loaded
            End If
        End Sub

        Private Sub Timer_Tick(sender As Object, e As EventArgs)
            progressBar.Value += 1
        End Sub

        Private Sub page_Loaded(sender As Object, e As RoutedEventArgs)
            Call Deployment.Current.Dispatcher.InvokeAsync(Sub()
                                                               Dim page = TryCast(sender, WizardPage)
                                                               If Equals(page.Name, "progressPage") Then
                                                                   SetAllowProperties(page, False)
                                                                   progressBar = page.ChildrenOfType(Of RadProgressBar)().FirstOrDefault()
                                                                   If progressBar IsNot Nothing Then
                                                                       AddHandler progressBar.ValueChanged, AddressOf progressBar_ValueChanged
                                                                       progressBar.Value = 0
                                                                       timer.Start()
                                                                   End If
                                                               End If
                                                           End Sub, DispatcherPriority.Loaded)
        End Sub

        Private Sub progressBar_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double))
            Dim wizard = progressBar.ParentOfType(Of RadWizard)()
            If progressBar.Value = progressBar.Maximum AndAlso wizard IsNot Nothing Then
                SetAllowProperties(wizard.SelectedPage, True)
                timer.Stop()
            End If
        End Sub

        Private Sub SetAllowProperties(page As WizardPage, value As Boolean)
            page.AllowNext = value
            page.AllowPrevious = value
            page.AllowCancel = value
        End Sub
    End Class
End Namespace
