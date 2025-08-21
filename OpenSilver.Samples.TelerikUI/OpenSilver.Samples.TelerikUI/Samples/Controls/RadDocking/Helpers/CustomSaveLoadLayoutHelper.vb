Imports System.Windows
Imports Telerik.Windows.Controls
Imports Telerik.Windows.Controls.Docking

Namespace OpenSilver.Samples.TelerikUI.Docking
    Public Class CustomSaveLoadLayoutHelper
        Inherits DefaultSaveLoadLayoutHelper
        Protected Overrides Sub ElementLoadedOverride(serializationTag As String, element As DependencyObject)
            MyBase.ElementLoadedOverride(serializationTag, element)
            Dim document = TryCast(element, RadDocumentPane)
            If document IsNot Nothing Then
                ' Restore the content for the loaded document.
            End If
        End Sub
    End Class
End Namespace
