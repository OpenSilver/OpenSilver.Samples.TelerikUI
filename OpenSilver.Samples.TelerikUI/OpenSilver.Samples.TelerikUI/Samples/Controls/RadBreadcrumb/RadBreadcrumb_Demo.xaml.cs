using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadBreadcrumb_Demo : UserControl
    {
        public RadBreadcrumb_Demo()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private sealed class ExplorerItem
        {
            public string Header { get; set; }
            public string PreviewHeader { get; set; }
            public string Path { get; set; }
            public ImageSource IconPath { get; set; }
            public ObservableCollection<ExplorerItem> Children { get; set; }
            public ExplorerItem()
            {
                Children = new ObservableCollection<ExplorerItem>();
            }
        }

        private sealed class MainViewModel
        {
            public ObservableCollection<ExplorerItem> Items { get; set; }
            public ExplorerItem Root { get; set; }
            public MainViewModel()
            {
                Items = new ObservableCollection<ExplorerItem>();
                LoadItems();
            }

            private static BitmapImage CreateBitmapImage(string image)
            {
                return new BitmapImage(new Uri($"/OpenSilver.Samples.TelerikUI;component/Other/Images/{image}", UriKind.RelativeOrAbsolute));
            }

            public void LoadItems()
            {
                ExplorerItem personalInfo = new ExplorerItem()
                {
                    Header = "Personal Folders",
                    IconPath = CreateBitmapImage("1PersonalFolders.png"),
                    Path = "PersonalFolders",
                    Children = new ObservableCollection<ExplorerItem>()
                    {
                        new ExplorerItem() { Header = "Deleted Items(6)", IconPath =  CreateBitmapImage("2DeletedItems.png"), Path = "DeletedItems" },
                        new ExplorerItem() { Header = "Drafts", IconPath =  CreateBitmapImage("3Drafts.png"), Path = "Drafts" },
                        new ExplorerItem()
                        {
                            Header = "Inbox(14)",
                            IconPath =  CreateBitmapImage("4Inbox.png"),
                            Path = "Inbox",
                            Children = new ObservableCollection<ExplorerItem>()
                            {
                                new ExplorerItem() { Header = "Folders", IconPath = CreateBitmapImage("folder.png"), Path = "Folders" },
                            }
                        },
                        new ExplorerItem() { Header = "Junk E-mails", IconPath = CreateBitmapImage("junk.png"), Path = "JunkEmails" },
                        new ExplorerItem() { Header = "Outbox", IconPath = CreateBitmapImage("outbox.png"), Path = "Outbox" },
                        new ExplorerItem() { Header = "Sent Items", IconPath = CreateBitmapImage("sent.png"), Path = "SentItems" },
                        new ExplorerItem()
                        {
                            Header = "Search Folder",
                            IconPath = CreateBitmapImage("searchFolder.png"),
                            Path = "SearchFolder",
                            Children = new ObservableCollection<ExplorerItem>()
                            {
                                new ExplorerItem() { Header = "From Follow up", IconPath = CreateBitmapImage("search.png"), Path = "FromFollowup" },
                                new ExplorerItem() { Header = "Large Mail", IconPath = CreateBitmapImage("search.png"), Path = "LargeMail" },
                                new ExplorerItem() { Header = "Unread Mail", IconPath = CreateBitmapImage("search.png"), Path = "UnreadMail"},
                            }
                        }
                    },
                };
                ExplorerItem programFiles = new ExplorerItem()
                {
                    Header = "Program Files",
                    IconPath = CreateBitmapImage("folder2.png"),
                    Children = new ObservableCollection<ExplorerItem>()
                    {
                        new ExplorerItem() { Header = "Microsoft", IconPath = CreateBitmapImage("folder.png"), Path = "Microsoft" },
                        new ExplorerItem() { Header = "Microsoft.NET", IconPath = CreateBitmapImage("folder.png"), Path = "Microsoft.NET" },
                        new ExplorerItem()
                        {
                            Header = "Internet Explorer",
                            IconPath = CreateBitmapImage("folder2.png"),
                            Path = "InternetExplorer",
                            Children = new ObservableCollection<ExplorerItem>()
                            {
                                new ExplorerItem() { Header = "SIGNUP", IconPath = CreateBitmapImage("folder.png"), Path = "SIGNUP" }
                            }
                        }
                    },
                    Path = "ProgramFiles"
                };
                ExplorerItem programFiles86 = new ExplorerItem()
                {
                    Header = "Program Files(86)",
                    IconPath = CreateBitmapImage("folder2.png"),
                    Path = "ProgramFiles(86)",
                    Children = new ObservableCollection<ExplorerItem>()
                    {
                        new ExplorerItem() { Header = "Microsoft", IconPath = CreateBitmapImage("folder.png"), Path = "Microsoft" },
                        new ExplorerItem() { Header = "Microsoft.NET", IconPath = CreateBitmapImage("folder.png"), Path = "Microsoft.NET" },
                        new ExplorerItem()
                        {
                            Header = "Skype",
                            IconPath = CreateBitmapImage("folder2.png"),
                            Path = "Skype",
                            Children = new ObservableCollection<ExplorerItem>()
                            {
                                new ExplorerItem() { Header = "Phone", IconPath = CreateBitmapImage("folder.png"), Path = "Phone" },
                                new ExplorerItem() { Header = "Toolbars", IconPath = CreateBitmapImage("folder.png"), Path = "Toolbars" },
                                new ExplorerItem() { Header = "Plugin Manager", IconPath = CreateBitmapImage("folder.png"), Path = "PluginManager" }
                            }
                        },
                        new ExplorerItem()
                        {
                            Header = "Notepad++",
                            IconPath = CreateBitmapImage("folder2.png"),
                            Path = "Notepad++",
                            Children = new ObservableCollection<ExplorerItem>()
                            {
                                new ExplorerItem() {Header = "localization", IconPath = CreateBitmapImage("folder.png"), Path = "localization" },
                                new ExplorerItem() {Header = "plugins", IconPath = CreateBitmapImage("junk.png"), Path = "plugins" }
                            }
                        }
                    },
                };
                ExplorerItem downloads = new ExplorerItem()
                {
                    Header = "Downloads",
                    IconPath = CreateBitmapImage("folder2.png"),
                    Path = "Downloads",
                    Children = new ObservableCollection<ExplorerItem>()
                    {
                        new ExplorerItem() { Header = "Music", IconPath = CreateBitmapImage("folder.png"), Path = "Music" },
                        new ExplorerItem() { Header = "Movies", IconPath = CreateBitmapImage("folder.png"), Path = "Movies" }
                    },
                };
                ExplorerItem localHard = new ExplorerItem()
                {
                    Header = "Local Disk (C:)",
                    Path = "LocalDisk(C:)",
                    IconPath = CreateBitmapImage("HardDrive16.png"),
                    Children = new ObservableCollection<ExplorerItem>()
                    {
                        personalInfo,
                        programFiles,
                        programFiles86,
                        downloads
                    }
                };
                ExplorerItem localHard2 = new ExplorerItem()
                {
                    Header = "Local Disk (D:)",
                    Path = "LocalDisk(D:)",
                    IconPath = CreateBitmapImage("HardDrive16.png")
                };
                ExplorerItem computer = new ExplorerItem()
                {
                    Header = "Computer",
                    Path = "Computer",
                    IconPath = CreateBitmapImage("Computer.png"),
                    Children = new ObservableCollection<ExplorerItem>()
                    {
                        localHard,
                        localHard2
                    }
                };
                ExplorerItem computer2 = new ExplorerItem()
                {
                    Header = "Computer2",
                    Path = "Computer2",
                    Children = new ObservableCollection<ExplorerItem>()
                    {
                        localHard,
                        localHard2
                    }
                };
                Root = new ExplorerItem()
                {
                    Header = "Desktop",
                    Path = "Desktop",
                    IconPath = CreateBitmapImage("Desktop.png"),
                    Children = new ObservableCollection<ExplorerItem>()
                    {
                        computer,
                        computer2
                    }
                };
                Items = new ObservableCollection<ExplorerItem>() { Root };
            }
        }
    }
}
