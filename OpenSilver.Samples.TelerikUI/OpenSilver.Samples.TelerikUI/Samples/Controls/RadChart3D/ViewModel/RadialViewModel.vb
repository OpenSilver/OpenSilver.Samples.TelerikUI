Imports OpenSilver.Samples.TelerikUI.RadChart3D.Helpers
Imports System.Collections.Generic

Namespace OpenSilver.Samples.TelerikUI.RadChart3D.ViewModel
    Public NotInheritable Class RadialViewModel
        Private _data As IEnumerable(Of Double)

        Public ReadOnly Property Data As IEnumerable(Of Double)
            Get
                If _data Is Nothing Then
                    _data = RadChart3D.Helpers.SeriesExtensions.GetUserRadialData()
                End If

                Return _data
            End Get
        End Property
    End Class
End Namespace
