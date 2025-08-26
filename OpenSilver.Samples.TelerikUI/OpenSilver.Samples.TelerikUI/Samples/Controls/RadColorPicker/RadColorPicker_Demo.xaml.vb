Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadColorPicker_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub SelectedColor_Changed(sender As Object, e As EventArgs)
            Dim color As Color = Me.ColorPicker.SelectedColor
            Dim brush As SolidColorBrush = New SolidColorBrush(color)
            Me.ColorBorder.Background = brush
        End Sub
    End Class
End Namespace
