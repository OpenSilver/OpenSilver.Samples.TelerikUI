Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Browser


Namespace Global.OpenSilver.Samples.TelerikUI.VB
    Partial Public Class MainPage
        Inherits Page

        Private Shared _Current As OpenSilver.Samples.TelerikUI.VB.MainPage

        Public Sub New()
            Me.InitializeComponent()

            Current = Me
            AddHandler Loaded, AddressOf MainPage_Loaded
            AddHandler Window.Current.SizeChanged, AddressOf Window_SizeChanged
        End Sub

        Public Shared Property Current As MainPage
            Get
                Return _Current
            End Get
            Private Set(ByVal value As MainPage)
                _Current = value
            End Set
        End Property

        Private Sub MainPage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Navigate to the "Welcome" page by default:
            If Not HtmlPage.Document.DocumentUri.OriginalString.Contains("#") Then
                NavigateToPage("/Welcome")
            End If

            UpdateMenuDispositionBasedOnDisplaySize()
        End Sub

        Private Sub ButtonControls_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            NavigateToPage("/Controls")
        End Sub

        Private Sub ButtonCharts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            NavigateToPage("/Charts")
        End Sub

        Private Sub ButtonEditors_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            NavigateToPage("/Editors")
        End Sub

        Private Sub ButtonLayouts_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            NavigateToPage("/Layouts")
        End Sub

        Private Sub ButtonNavigations_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            NavigateToPage("/Navigations")
        End Sub

        Private Sub ButtonScheduling_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            NavigateToPage("/Scheduling")
        End Sub

        Private Sub ButtonDataManagement_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            NavigateToPage("/DataManagement")
        End Sub
        Private Sub ButtonHome_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            NavigateToPage("/Welcome")
        End Sub

        Public Sub NavigateToPage(ByVal targetUri As String)
            'Hide the menu:
            If _currentState = CurrentState.SmallResolution_ShowMenu Then GoToState(CurrentState.SmallResolution_HideMenu)

            ' Navigate to the target page:
            Dim uri As Uri = New Uri(targetUri, UriKind.Relative)
            Me.PageContainer.Source = uri

            ' Scroll to top:
            Me.ScrollViewer1.ScrollToVerticalOffset(0R)
        End Sub

#Region "Show/hide source code"

        Public Sub ViewSourceCode(ByVal controlThatDisplaysTheSourceCode As UIElement)
            ' Open the Source Code Pane, which is the place where the source code will be displayed:
            If Me.SourceCodePane.Visibility = Visibility.Collapsed Then
                Me.RowThatContainsThePage.Height = New GridLength(0.5R, GridUnitType.Star)
                Me.RowThatContainsTheGridSplitter.Height = New GridLength(5.0R)
                Me.RowThatContainsTheSourceCodePane.Height = New GridLength(0.5R, GridUnitType.Star)
                Me.GridSplitter1.Visibility = Visibility.Visible
                Me.SourceCodePane.Visibility = Visibility.Visible
            End If

            ' Display the source code:
            Me.PlaceWhereSourceCodeWillBeDisplayed.Child = controlThatDisplaysTheSourceCode
        End Sub

        Private Sub ButtonToCloseSourceCode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Close the Source Code Pane, which is the place where the source code is displayed:
            Me.PlaceWhereSourceCodeWillBeDisplayed.Child = Nothing
            Me.GridSplitter1.Visibility = Visibility.Collapsed
            Me.SourceCodePane.Visibility = Visibility.Collapsed
            Me.RowThatContainsThePage.Height = New GridLength(1.0R, GridUnitType.Star)
            Me.RowThatContainsTheGridSplitter.Height = New GridLength(0R)
            Me.RowThatContainsTheSourceCodePane.Height = New GridLength(0R)
        End Sub

#End Region

#Region "States management"

        'This region contains all that we use to make the menu on the left disappear when the screen is too small.

        Friend Enum CurrentState
            Unset ' Initial value
            LargeResolution_SeeBothMenuAndPage ' This corresponds to tablets and other devices with high resolution. In this case we see both the menu and the page.
            SmallResolution_ShowMenu ' This corresponds to smartphones and other devices with low resolution. In this case we see the menu.
            SmallResolution_HideMenu ' This corresponds to smartphones and other devices with low resolution. In this case we do not see the menu.
        End Enum

        Private _currentState As CurrentState

        Private Sub GoToState(ByVal newState As CurrentState)
            If newState <> _currentState Then
                If newState = CurrentState.LargeResolution_SeeBothMenuAndPage Then
                    ' Hide the button to hide/show the menu:
                    Me.ButtonToHideOrShowMenu.Visibility = Visibility.Collapsed
                    Me.PageContainer.Margin = New Thickness(0, 0, 0, 30)

                    ' Set the translation of the frame to 0:
                    CType(Me.PageContainer.RenderTransform, TranslateTransform).X = 0

                    ' Set the margin of the frame to 180 (which is the size of the menu):
                    Dim margin As Thickness = Me.PageContainer.Margin
                    margin.Left = 180
                    Me.PageContainer.Margin = margin

                    ' Set the translation of the border to 0:
                    CType(Me.MenuBorder.RenderTransform, TranslateTransform).X = 0
                Else
                    ' Revert the changes that are specific to the CurrentState.LargeResolution_SeeBothMenuAndPage state.

                    ' Show the button to hide/show the menu:
                    Me.ButtonToHideOrShowMenu.Visibility = Visibility.Visible
                    Me.PageContainer.Margin = New Thickness(0, 50, 0, 30)

                    Dim margin As Thickness = Me.PageContainer.Margin
                    margin.Left = 0
                    Me.PageContainer.Margin = margin

                    If newState = CurrentState.SmallResolution_ShowMenu Then
                        ' Show the menu:
                        CType(Me.PageContainer.RenderTransform, TranslateTransform).X = 180
                        CType(Me.ButtonToHideOrShowMenu.RenderTransform, TranslateTransform).X = 180
                        CType(Me.MenuBorder.RenderTransform, TranslateTransform).X = 0
                    Else
                        ' Hide the menu:
                        CType(Me.PageContainer.RenderTransform, TranslateTransform).X = 0
                        CType(Me.ButtonToHideOrShowMenu.RenderTransform, TranslateTransform).X = 0
                        CType(Me.MenuBorder.RenderTransform, TranslateTransform).X = -180
                    End If
                End If
                _currentState = newState
            End If
        End Sub


        Private Sub Window_SizeChanged(ByVal sender As Object, ByVal e As WindowSizeChangedEventArgs)
            UpdateMenuDispositionBasedOnDisplaySize()
        End Sub

        Private Sub UpdateMenuDispositionBasedOnDisplaySize()
            'note: another way to get the display width is commented below:
            'Rect windowBounds = Window.Current.Bounds;
            'double displayWidth = windowBounds.Width;

            Dim actualWidth = Me.ActualWidth
            If Not Double.IsNaN(actualWidth) AndAlso actualWidth > 560.0R Then
                GoToState(CurrentState.LargeResolution_SeeBothMenuAndPage)
            ElseIf _currentState = CurrentState.LargeResolution_SeeBothMenuAndPage OrElse _currentState = CurrentState.Unset Then
                GoToState(CurrentState.SmallResolution_HideMenu)
            End If
        End Sub

        Private Sub ButtonToHideOrShowMenu_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If _currentState = CurrentState.SmallResolution_ShowMenu Then
                GoToState(CurrentState.SmallResolution_HideMenu)
            ElseIf _currentState = CurrentState.SmallResolution_HideMenu Then
                GoToState(CurrentState.SmallResolution_ShowMenu)
            Else
                ' Not supposed to happen because the button is not visible when in large resolution mode.
            End If
        End Sub



#End Region




    End Class
End Namespace
