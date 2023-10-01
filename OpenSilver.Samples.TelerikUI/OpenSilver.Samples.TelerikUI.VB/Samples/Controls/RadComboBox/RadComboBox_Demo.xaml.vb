Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace Global.OpenSilver.Samples.TelerikUI.VB
    Public Partial Class RadComboBox_Demo
        Inherits UserControl
        Private isInitialized As Boolean = False
        Public Property SelectedLanguage As Language
        Public Property Languages As Language()

        Public Sub New()
            Me.InitializeComponent()

            Languages = {New Language With {
.ID = 1,
.DisplayName = "English"
}, New Language With {
.ID = 2,
.DisplayName = "French"
}}

            SelectedLanguage = Languages(0)
            Me.LanguagesComboBox.ItemsSource = Languages
        End Sub

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadComboBox_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadComboBox/RadComboBox_Demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadComboBox_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadComboBox/RadComboBox_Demo.xaml.cs"
    }
})
        End Sub

        Private Sub LanguagesComboBox_SelectionChanged(ByVal sender As Object, ByVal e As Telerik.Windows.Controls.SelectionChangedEventArgs)
            If isInitialized Then
                MessageBox.Show($"You have selected {SelectedLanguage.DisplayName}")
            Else
                isInitialized = True
            End If
        End Sub

        Public Class Language
            Public Property ID As Integer

            Public Property DisplayName As String
        End Class
    End Class
End Namespace
