Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI.RadOutlookBar
    Public Class OutlookBarContentTemplateSelector
        Inherits DataTemplateSelector
        Public Property MailTemplate As DataTemplate
        Public Property CalendarTemplate As DataTemplate
        Public Property ContactsTemplate As DataTemplate

        Public Overrides Function SelectTemplate(item As Object, container As DependencyObject) As DataTemplate
            If TypeOf item Is MailMenuItem Then
                Return MailTemplate
            ElseIf TypeOf item Is CalendarMenuItem Then
                Return CalendarTemplate
            ElseIf TypeOf item Is ContactsMenuItem Then
                Return ContactsTemplate
            End If

            Return MyBase.SelectTemplate(item, container)
        End Function
    End Class
End Namespace
