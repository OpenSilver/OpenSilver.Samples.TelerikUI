Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public NotInheritable Class ViewSourceButton
        Inherits Button
        Public Sub New()
            Style = TryCast(Application.Current.Resources("ButtonViewSource_Style"), Style)
        End Sub

        Public ReadOnly Property Sources As List(Of TelerikUI.ViewSourceButtonInfo) = New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)()

        Protected Overrides Sub OnClick()
            MyBase.OnClick()
            ViewSource(Sources)
        End Sub

        Private Shared Sub ViewSource(sourcePaths As ICollection(Of TelerikUI.ViewSourceButtonInfo))
            If sourcePaths Is Nothing OrElse sourcePaths.Count = 0 Then
                Return
            End If

            Dim panel = New OpenSilver.Samples.TelerikUI.ViewSourcePanel()
            panel.ViewSource(sourcePaths)
            TelerikUI.MainPage.Current.ViewSourceCode(panel)
        End Sub
    End Class
End Namespace
