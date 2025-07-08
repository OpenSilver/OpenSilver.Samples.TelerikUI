using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadBook_Demo : UserControl
    {
        public RadBook_Demo()
        {
            InitializeComponent();
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadBook_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadBook/RadBook_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadBook_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadBook/RadBook_Demo.xaml.cs"
                },
            });
        }
    }

    public class RadBookPage : ViewModelBase
    {
        private string content;

        public RadBookPage(string content)
        {
            this.content = content;
        }

        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                if (content != value)
                {
                    content = value;
                    OnPropertyChanged("Content");
                }
            }
        }
    }

    public class RadBookPageCollection : ObservableCollection<RadBookPage>
    {
        public RadBookPageCollection()
        {
            Add(new RadBookPage("Page 1"));
            Add(new RadBookPage("Page 2"));
            Add(new RadBookPage("Page 3"));
            Add(new RadBookPage("Page 4"));
            Add(new RadBookPage("Page 5"));
            Add(new RadBookPage("Page 6"));
            Add(new RadBookPage("Page 7"));
            Add(new RadBookPage("Page 8"));
            Add(new RadBookPage("Page 9"));
            Add(new RadBookPage("Page 10"));
        }
    }
}
