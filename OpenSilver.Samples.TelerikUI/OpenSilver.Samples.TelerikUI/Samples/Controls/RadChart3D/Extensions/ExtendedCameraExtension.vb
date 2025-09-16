Imports Telerik.Windows.Controls.Charting

Namespace OpenSilver.Samples.TelerikUI.RadChart3D.Extensions
    Public Class ExtendedCameraExtension
        Inherits CameraExtension
        Public Overrides Sub Attach(owner As ChartArea)
            MyBase.Attach(owner)
            AddHandler owner.MouseWheel, AddressOf OnMouseWheel
        End Sub

        Public Overrides Sub Detach(owner As ChartArea)
            MyBase.Detach(owner)
            RemoveHandler owner.MouseWheel, AddressOf OnMouseWheel
        End Sub


        Private Sub OnMouseWheel(sender As Object, e As Windows.Input.MouseWheelEventArgs)
            If Not ZoomEnabled Then
                Return
            End If

            If e.Delta > 0 Then
                Zoom(1.1)
            Else
                Zoom(0.9)
            End If

            e.Handled = True
        End Sub
    End Class
End Namespace
