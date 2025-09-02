Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadRibbonView_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            OpenHelpPageCommand = New Telerik.Windows.Controls.DelegateCommand(AddressOf ExecuteOpenHelpPage)
            DataContext = OpenHelpPageCommand
            InputBindings.Add(New KeyBinding(OpenHelpPageCommand, New KeyGesture(Key.F1, ModifierKeys.Control)))

            AddHandler MouseLeftButtonDown, Sub(o, e)
                                                If Focus() Then
                                                    e.Handled = True
                                                End If
                                            End Sub
        End Sub

        Public Property OpenHelpPageCommand As Telerik.Windows.Controls.DelegateCommand

        Private Sub ExecuteOpenHelpPage(obj As Object)
            Dim radWindow = New Telerik.Windows.Controls.RadWindow()
            radWindow.Owner = Me.root
            radWindow.ResizeMode = Telerik.Windows.Controls.ResizeMode.NoResize
            radWindow.Height = 320
            radWindow.Width = 400
            radWindow.Header = "Help"
            radWindow.WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation.CenterOwner
            Dim sp = New StackPanel()
            Dim tb1 = New TextBlock With {
    .Text = "Help window header",
    .Margin = New Thickness(20),
    .HorizontalAlignment = HorizontalAlignment.Center,
    .FontSize = 22,
    .Foreground = New SolidColorBrush(Colors.Gray),
    .FontWeight = FontWeights.Bold
}
            sp.Children.Add(tb1)
            Dim tb2 = New TextBlock With {
    .TextWrapping = TextWrapping.Wrap,
    .Margin = New Thickness(20),
    .Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut sed erat sit amet lorem cursus tristique non quis nisi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Integer posuere velit id faucibus consectetur. Proin aliquam elit nec enim bibendum auctor. Proin aliquam justo rhoncus enim fermentum accumsan. Curabitur ipsum purus, gravida non tellus vitae, accumsan aliquam lectus. Curabitur nibh arcu, convallis eget consectetur a, molestie eget ante. Cras sed mauris non erat ultrices hendrerit."
}
            sp.Children.Add(tb2)

            radWindow.Content = sp
            radWindow.Show()
        End Sub
    End Class
End Namespace
