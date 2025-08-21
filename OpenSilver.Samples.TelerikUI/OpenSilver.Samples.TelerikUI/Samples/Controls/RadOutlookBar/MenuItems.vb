Imports System.Collections.ObjectModel

Namespace OpenSilver.Samples.TelerikUI.RadOutlookBar
    Public Class MenuItemBase
        Public Property Header As String
        Public Property Content As String
        Public Property IconSource As String
        Public Property IconSourceSmall As String

        Public Overrides Function ToString() As String
            Return String.Empty
        End Function
    End Class

    Public Class MailMenuItem
        Inherits MenuItemBase
        Public Property MailDirectories As ObservableCollection(Of MailDirectoryItem)
        Public Sub New()
            MailDirectories = New ObservableCollection(Of MailDirectoryItem)()
        End Sub
    End Class

    Public Class MailDirectoryItem
        Public Property Header As String
        Public Property IconSource As String
        Public Property Children As ObservableCollection(Of MailDirectoryItem)

        Public Sub New()
            Children = New ObservableCollection(Of MailDirectoryItem)()
        End Sub
    End Class

    Public Class CalendarMenuItem
        Inherits MenuItemBase
    End Class

    Public Class ContactsMenuItem
        Inherits MenuItemBase
        Public Property ContactsList As ObservableCollection(Of Person)
    End Class

    Public Class Person
        Public Property Name As String
        Public Property IconSource As String
    End Class
End Namespace
