Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadWrapPanel_Demo
        Inherits UserControl
        Private Shared ReadOnly brushes As SolidColorBrush() = New SolidColorBrush() {Media.Brushes.Blue, Media.Brushes.Red, Media.Brushes.Orange, Media.Brushes.Yellow, Media.Brushes.SkyBlue, Media.Brushes.Green, Media.Brushes.Purple, Media.Brushes.Aqua, Media.Brushes.Silver, Media.Brushes.Gold, Media.Brushes.Olive, Media.Brushes.Magenta}

        Public Sub New()
            Me.InitializeComponent()
            Me.radWrapPanelListBox.ItemsSource = GenerateItems(10)
            Me.virtualizingWrapPanelListBox.ItemsSource = GenerateItems(10)
        End Sub

        Private Sub RadWrapPanelButton_Click(sender As Object, e As RoutedEventArgs)
            Dim maxItems As Integer = Nothing

            If Not Integer.TryParse(Me.radWrapPanelTextbox.Text, maxItems) Then
                maxItems = 10
            End If

            Me.radWrapPanelListBox.ItemsSource = GenerateItems(maxItems)
        End Sub

        Private Sub VirtualizingWrapPanelButton_Click(sender As Object, e As RoutedEventArgs)
            Dim maxItems As Integer = Nothing

            If Not Integer.TryParse(Me.virtualizingWrapPanelTextBox.Text, maxItems) Then
                maxItems = 10
            End If

            Me.virtualizingWrapPanelListBox.ItemsSource = GenerateItems(maxItems)
        End Sub

        Private Shared Function GenerateItems(maxItems As Integer) As Border()
            Return Enumerable.Range(0, maxItems).[Select](Function(i) New Border With {
.Width = 40,
.Height = 20,
.Margin = New Thickness(2),
.Background = brushes(i Mod brushes.Length)
}).ToArray()
        End Function
    End Class
End Namespace
