Imports OpenSilver.Samples.TelerikUI.RadOutlookBar
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadOutlookBar_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            Me.radOutlookBar.DataContext = New MailMenuViewModel()
        End Sub

        Private NotInheritable Class MailMenuViewModel
            Inherits ViewModelBase
            Public Property MenuItems As ObservableCollection(Of TelerikUI.RadOutlookBar.MenuItemBase)

            Private selectedItemField As TelerikUI.RadOutlookBar.MenuItemBase
            Public Property SelectedItem As TelerikUI.RadOutlookBar.MenuItemBase
                Get
                    Return selectedItemField
                End Get
                Set(value As TelerikUI.RadOutlookBar.MenuItemBase)
                    If selectedItemField IsNot value Then
                        selectedItemField = value
                        OnPropertyChanged("SelectedItem")
                    End If
                End Set
            End Property

            Public Sub New()
                MenuItems = New ObservableCollection(Of OpenSilver.Samples.TelerikUI.RadOutlookBar.MenuItemBase)()

                PopulateMenuItems()

                selectedItemField = MenuItems(0)
            End Sub

            Private Sub PopulateMenuItems()
                Dim mailMenuItem = New OpenSilver.Samples.TelerikUI.RadOutlookBar.MailMenuItem() With {
                    .Content = "Mails content",
                    .Header = "Mail",
                    .IconSource = GetIconSource("mailBig.png"),
                    .IconSourceSmall = GetIconSource("mailSmall.png")
                }
                mailMenuItem.MailDirectories.Add(New TelerikUI.RadOutlookBar.MailDirectoryItem() With {
    .Header = "Personal Folders",
    .IconSource = GetIconSource("1PersonalFolders.png"),
                        .Children = New ObservableCollection(Of OpenSilver.Samples.TelerikUI.RadOutlookBar.MailDirectoryItem)() From {
        New TelerikUI.RadOutlookBar.MailDirectoryItem With {
            .Header = "Deleted Items",
            .IconSource = GetIconSource("2DeletedItems.png")
        },
        New TelerikUI.RadOutlookBar.MailDirectoryItem With {
            .Header = "Drafts",
            .IconSource = GetIconSource("3Drafts.png")
        },
                                New TelerikUI.RadOutlookBar.MailDirectoryItem() With {
            .Header = "Inbox",
            .IconSource = GetIconSource("4Inbox.png"),
                                        .Children = New ObservableCollection(Of OpenSilver.Samples.TelerikUI.RadOutlookBar.MailDirectoryItem)() From {
                New TelerikUI.RadOutlookBar.MailDirectoryItem() With {
                    .Header = "Nancy Davolio",
                    .IconSource = GetIconSource("letter.png")
                },
                New TelerikUI.RadOutlookBar.MailDirectoryItem() With {
                    .Header = "Janer Leverling",
                    .IconSource = GetIconSource("letter.png")
                },
                New TelerikUI.RadOutlookBar.MailDirectoryItem() With {
                    .Header = "Robert King",
                    .IconSource = GetIconSource("letter.png")
                }
            }
        },
        New TelerikUI.RadOutlookBar.MailDirectoryItem With {
            .Header = "Junk Emails",
            .IconSource = GetIconSource("junk.png")
        },
        New TelerikUI.RadOutlookBar.MailDirectoryItem With {
            .Header = "Outbox",
            .IconSource = GetIconSource("outbox.png")
        },
        New TelerikUI.RadOutlookBar.MailDirectoryItem With {
            .Header = "Sent Items",
            .IconSource = GetIconSource("sent.png")
        }
    }
})

                MenuItems.Add(mailMenuItem)

                Dim calendarMenuItem = New OpenSilver.Samples.TelerikUI.RadOutlookBar.CalendarMenuItem() With {
                    .Content = "Calendar content",
                    .Header = "Calendar",
                    .IconSource = GetIconSource("calendarBig.png"),
                    .IconSourceSmall = GetIconSource("calendarSmall.png")
                }
                MenuItems.Add(calendarMenuItem)

                Dim contactsMenuItem = New OpenSilver.Samples.TelerikUI.RadOutlookBar.ContactsMenuItem() With {
                    .Content = "Contacts content",
                    .Header = "Contacts",
                    .IconSource = GetIconSource("contactsBig.png"),
                    .IconSourceSmall = GetIconSource("contactsSmall.png")
                }
                contactsMenuItem.ContactsList = New ObservableCollection(Of OpenSilver.Samples.TelerikUI.RadOutlookBar.Person)() From {
    New TelerikUI.RadOutlookBar.Person() With {
        .Name = "John Smith",
        .IconSource = GetIconSource("contact.png")
    },
    New TelerikUI.RadOutlookBar.Person() With {
        .Name = "James Bond",
        .IconSource = GetIconSource("contact.png")
    },
    New TelerikUI.RadOutlookBar.Person() With {
        .Name = "Haris Pilton",
        .IconSource = GetIconSource("contact.png")
    },
    New TelerikUI.RadOutlookBar.Person() With {
        .Name = "Kim LeBlank",
        .IconSource = GetIconSource("contact.png")
    },
    New TelerikUI.RadOutlookBar.Person() With {
        .Name = "Rock Lee",
        .IconSource = GetIconSource("contact.png")
    },
    New TelerikUI.RadOutlookBar.Person() With {
        .Name = "Jim Brown",
        .IconSource = GetIconSource("contact.png")
    }
}

                MenuItems.Add(contactsMenuItem)
            End Sub

            Private Shared Function GetIconSource(icon As String) As String
                Return $"/OpenSilver.Samples.TelerikUI;component/Other/Images/{icon}"
            End Function
        End Class
    End Class
End Namespace
