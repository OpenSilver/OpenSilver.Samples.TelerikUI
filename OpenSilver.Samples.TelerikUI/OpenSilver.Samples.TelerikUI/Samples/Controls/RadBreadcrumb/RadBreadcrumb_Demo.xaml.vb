Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadBreadcrumb_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            DataContext = New MainViewModel()
        End Sub

        Private NotInheritable Class ExplorerItem
            Public Property Header As String
            Public Property PreviewHeader As String
            Public Property Path As String
            Public Property IconPath As ImageSource
            Public Property Children As ObservableCollection(Of ExplorerItem)
            Public Sub New()
                Children = New ObservableCollection(Of ExplorerItem)()
            End Sub
        End Class

        Private NotInheritable Class MainViewModel
            Public Property Items As ObservableCollection(Of ExplorerItem)
            Public Property Root As ExplorerItem
            Public Sub New()
                Items = New ObservableCollection(Of ExplorerItem)()
                LoadItems()
            End Sub

            Private Shared Function CreateBitmapImage(image As String) As BitmapImage
                Return New BitmapImage(New Uri($"/OpenSilver.Samples.TelerikUI;component/Other/Images/{image}", UriKind.RelativeOrAbsolute))
            End Function

            Public Sub LoadItems()
                Dim personalInfo As ExplorerItem = New ExplorerItem() With {
    .Header = "Personal Folders",
    .IconPath = CreateBitmapImage("1PersonalFolders.png"),
    .Path = "PersonalFolders",
                        .Children = New ObservableCollection(Of ExplorerItem)() From {
        New ExplorerItem() With {
            .Header = "Deleted Items(6)",
            .IconPath = CreateBitmapImage("2DeletedItems.png"),
            .Path = "DeletedItems"
        },
        New ExplorerItem() With {
            .Header = "Drafts",
            .IconPath = CreateBitmapImage("3Drafts.png"),
            .Path = "Drafts"
        },
                                New ExplorerItem() With {
            .Header = "Inbox(14)",
            .IconPath = CreateBitmapImage("4Inbox.png"),
            .Path = "Inbox",
                                        .Children = New ObservableCollection(Of ExplorerItem)() From {
                New ExplorerItem() With {
                    .Header = "Folders",
                    .IconPath = CreateBitmapImage("folder.png"),
                    .Path = "Folders"
                }
            }
        },
        New ExplorerItem() With {
            .Header = "Junk E-mails",
            .IconPath = CreateBitmapImage("junk.png"),
            .Path = "JunkEmails"
        },
        New ExplorerItem() With {
            .Header = "Outbox",
            .IconPath = CreateBitmapImage("outbox.png"),
            .Path = "Outbox"
        },
        New ExplorerItem() With {
            .Header = "Sent Items",
            .IconPath = CreateBitmapImage("sent.png"),
            .Path = "SentItems"
        },
                                New ExplorerItem() With {
            .Header = "Search Folder",
            .IconPath = CreateBitmapImage("searchFolder.png"),
            .Path = "SearchFolder",
                                        .Children = New ObservableCollection(Of ExplorerItem)() From {
                New ExplorerItem() With {
                    .Header = "From Follow up",
                    .IconPath = CreateBitmapImage("search.png"),
                    .Path = "FromFollowup"
                },
                New ExplorerItem() With {
                    .Header = "Large Mail",
                    .IconPath = CreateBitmapImage("search.png"),
                    .Path = "LargeMail"
                },
                New ExplorerItem() With {
                    .Header = "Unread Mail",
                    .IconPath = CreateBitmapImage("search.png"),
                    .Path = "UnreadMail"
                }
            }
        }
    }
}
                Dim programFiles As ExplorerItem = New ExplorerItem() With {
    .Header = "Program Files",
    .IconPath = CreateBitmapImage("folder2.png"),
                        .Children = New ObservableCollection(Of ExplorerItem)() From {
        New ExplorerItem() With {
            .Header = "Microsoft",
            .IconPath = CreateBitmapImage("folder.png"),
            .Path = "Microsoft"
        },
        New ExplorerItem() With {
            .Header = "Microsoft.NET",
            .IconPath = CreateBitmapImage("folder.png"),
            .Path = "Microsoft.NET"
        },
                                New ExplorerItem() With {
            .Header = "Internet Explorer",
            .IconPath = CreateBitmapImage("folder2.png"),
            .Path = "InternetExplorer",
                                        .Children = New ObservableCollection(Of ExplorerItem)() From {
                New ExplorerItem() With {
                    .Header = "SIGNUP",
                    .IconPath = CreateBitmapImage("folder.png"),
                    .Path = "SIGNUP"
                }
            }
        }
    },
    .Path = "ProgramFiles"
}
                Dim programFiles86 As ExplorerItem = New ExplorerItem() With {
    .Header = "Program Files(86)",
    .IconPath = CreateBitmapImage("folder2.png"),
    .Path = "ProgramFiles(86)",
                        .Children = New ObservableCollection(Of ExplorerItem)() From {
        New ExplorerItem() With {
            .Header = "Microsoft",
            .IconPath = CreateBitmapImage("folder.png"),
            .Path = "Microsoft"
        },
        New ExplorerItem() With {
            .Header = "Microsoft.NET",
            .IconPath = CreateBitmapImage("folder.png"),
            .Path = "Microsoft.NET"
        },
                                New ExplorerItem() With {
            .Header = "Skype",
            .IconPath = CreateBitmapImage("folder2.png"),
            .Path = "Skype",
                                        .Children = New ObservableCollection(Of ExplorerItem)() From {
                New ExplorerItem() With {
                    .Header = "Phone",
                    .IconPath = CreateBitmapImage("folder.png"),
                    .Path = "Phone"
                },
                New ExplorerItem() With {
                    .Header = "Toolbars",
                    .IconPath = CreateBitmapImage("folder.png"),
                    .Path = "Toolbars"
                },
                New ExplorerItem() With {
                    .Header = "Plugin Manager",
                    .IconPath = CreateBitmapImage("folder.png"),
                    .Path = "PluginManager"
                }
            }
        },
                                New ExplorerItem() With {
            .Header = "Notepad++",
            .IconPath = CreateBitmapImage("folder2.png"),
            .Path = "Notepad++",
                                        .Children = New ObservableCollection(Of ExplorerItem)() From {
                New ExplorerItem() With {
                    .Header = "localization",
                    .IconPath = CreateBitmapImage("folder.png"),
                    .Path = "localization"
                },
                New ExplorerItem() With {
                    .Header = "plugins",
                    .IconPath = CreateBitmapImage("junk.png"),
                    .Path = "plugins"
                }
            }
        }
    }
}
                Dim downloads As ExplorerItem = New ExplorerItem() With {
    .Header = "Downloads",
    .IconPath = CreateBitmapImage("folder2.png"),
    .Path = "Downloads",
                        .Children = New ObservableCollection(Of ExplorerItem)() From {
        New ExplorerItem() With {
            .Header = "Music",
            .IconPath = CreateBitmapImage("folder.png"),
            .Path = "Music"
        },
        New ExplorerItem() With {
            .Header = "Movies",
            .IconPath = CreateBitmapImage("folder.png"),
            .Path = "Movies"
        }
    }
}
                Dim localHard As ExplorerItem = New ExplorerItem() With {
    .Header = "Local Disk (C:)",
    .Path = "LocalDisk(C:)",
    .IconPath = CreateBitmapImage("HardDrive16.png"),
                        .Children = New ObservableCollection(Of ExplorerItem)() From {
        personalInfo,
        programFiles,
        programFiles86,
        downloads
    }
}
                Dim localHard2 As ExplorerItem = New ExplorerItem() With {
    .Header = "Local Disk (D:)",
    .Path = "LocalDisk(D:)",
    .IconPath = CreateBitmapImage("HardDrive16.png")
}
                Dim computer As ExplorerItem = New ExplorerItem() With {
    .Header = "Computer",
    .Path = "Computer",
    .IconPath = CreateBitmapImage("Computer.png"),
                        .Children = New ObservableCollection(Of ExplorerItem)() From {
        localHard,
        localHard2
    }
}
                Dim computer2 As ExplorerItem = New ExplorerItem() With {
    .Header = "Computer2",
    .Path = "Computer2",
                        .Children = New ObservableCollection(Of ExplorerItem)() From {
        localHard,
        localHard2
    }
}
                Root = New ExplorerItem() With {
    .Header = "Desktop",
    .Path = "Desktop",
    .IconPath = CreateBitmapImage("Desktop.png"),
                        .Children = New ObservableCollection(Of ExplorerItem)() From {
        computer,
        computer2
    }
}
                Items = New ObservableCollection(Of ExplorerItem)() From {
                    Root
                }
            End Sub
        End Class

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadBreadcrumb_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadBreadcrumb/RadBreadcrumb_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadBreadcrumb_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadBreadcrumb/RadBreadcrumb_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadBreadcrumb_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadBreadcrumb/RadBreadcrumb_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
