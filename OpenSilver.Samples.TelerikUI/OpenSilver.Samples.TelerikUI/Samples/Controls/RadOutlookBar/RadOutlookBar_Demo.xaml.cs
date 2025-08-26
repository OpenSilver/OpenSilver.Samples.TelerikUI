using OpenSilver.Samples.TelerikUI.RadOutlookBar;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadOutlookBar_Demo : UserControl
    {
        public RadOutlookBar_Demo()
        {
            InitializeComponent();
            radOutlookBar.DataContext = new MailMenuViewModel();
        }

        private sealed class MailMenuViewModel : ViewModelBase
        {
            public ObservableCollection<MenuItemBase> MenuItems { get; set; }

            private MenuItemBase selectedItem;
            public MenuItemBase SelectedItem
            {
                get { return selectedItem; }
                set
                {
                    if (selectedItem != value)
                    {
                        selectedItem = value;
                        OnPropertyChanged("SelectedItem");
                    }
                }
            }

            public MailMenuViewModel()
            {
                MenuItems = new ObservableCollection<MenuItemBase>();

                PopulateMenuItems();

                selectedItem = MenuItems[0];
            }

            private void PopulateMenuItems()
            {
                var mailMenuItem = new MailMenuItem() { Content = "Mails content", Header = "Mail", IconSource = GetIconSource("mailBig.png"), IconSourceSmall = GetIconSource("mailSmall.png") };
                mailMenuItem.MailDirectories.Add(new MailDirectoryItem()
                {
                    Header = "Personal Folders",
                    IconSource = GetIconSource("1PersonalFolders.png"),
                    Children = new ObservableCollection<MailDirectoryItem>()
                    {
                        new MailDirectoryItem { Header = "Deleted Items", IconSource = GetIconSource("2DeletedItems.png"), },
                        new MailDirectoryItem { Header = "Drafts", IconSource = GetIconSource("3Drafts.png"), },
                        new MailDirectoryItem()
                        {
                            Header = "Inbox", IconSource = GetIconSource("4Inbox.png"),
                            Children = new ObservableCollection<MailDirectoryItem>()
                            {
                                new MailDirectoryItem() { Header = "Nancy Davolio", IconSource = GetIconSource("letter.png") },
                                new MailDirectoryItem() { Header = "Janer Leverling", IconSource = GetIconSource("letter.png") },
                                new MailDirectoryItem() { Header = "Robert King", IconSource = GetIconSource("letter.png") },
                            }
                        },
                        new MailDirectoryItem { Header = "Junk Emails", IconSource = GetIconSource("junk.png"), },
                        new MailDirectoryItem { Header = "Outbox", IconSource = GetIconSource("outbox.png"), },
                        new MailDirectoryItem { Header = "Sent Items", IconSource = GetIconSource("sent.png"), }
                    }
                });

                MenuItems.Add(mailMenuItem);

                var calendarMenuItem = new CalendarMenuItem() { Content = "Calendar content", Header = "Calendar", IconSource = GetIconSource("calendarBig.png"), IconSourceSmall = GetIconSource("calendarSmall.png") };
                MenuItems.Add(calendarMenuItem);

                var contactsMenuItem = new ContactsMenuItem() { Content = "Contacts content", Header = "Contacts", IconSource = GetIconSource("contactsBig.png"), IconSourceSmall = GetIconSource("contactsSmall.png") };
                contactsMenuItem.ContactsList = new ObservableCollection<Person>()
                {
                    new Person() { Name = "John Smith", IconSource = GetIconSource("contact.png") },
                    new Person() { Name = "James Bond", IconSource = GetIconSource("contact.png") },
                    new Person() { Name = "Haris Pilton", IconSource = GetIconSource("contact.png") },
                    new Person() { Name = "Kim LeBlank", IconSource = GetIconSource("contact.png") },
                    new Person() { Name = "Rock Lee", IconSource = GetIconSource("contact.png") },
                    new Person() { Name = "Jim Brown", IconSource = GetIconSource("contact.png") },
                };

                MenuItems.Add(contactsMenuItem);
            }

            private static string GetIconSource(string icon)
            {
                return $"/OpenSilver.Samples.TelerikUI;component/Other/Images/{icon}";
            }
        }
    }
}
