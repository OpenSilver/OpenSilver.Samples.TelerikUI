Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadButton_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub RadButton_Click(sender As Object, e As RoutedEventArgs)
            MessageBox.Show("You pressed the button")
        End Sub
    End Class
End Namespace
