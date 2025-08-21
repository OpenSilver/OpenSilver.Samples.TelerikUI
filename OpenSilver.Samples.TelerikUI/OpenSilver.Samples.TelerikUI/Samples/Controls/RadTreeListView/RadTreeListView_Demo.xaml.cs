using OpenSilver.Samples.TelerikUI.TreeListView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Telerik.Windows.Controls.TreeListView;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadTreeListView_Demo : UserControl
    {
        public RadTreeListView_Demo()
        {
            InitializeComponent();

            treeLinesVisibilityCB.ItemsSource = new TreeLinesVisibility[]
            {
                TreeLinesVisibility.Hidden,
                TreeLinesVisibility.Visible,
            };
            treeLinesVisibilityCB.SelectedItem = TreeLinesVisibility.Visible;

            var stream = Application.GetResourceStream(
                new Uri("/OpenSilver.Samples.TelerikUI;component/Samples/Controls/RadTreeListView/Folders.xml", UriKind.RelativeOrAbsolute))
                .Result.Stream;

            var data = XDocument.Load(stream)
                .Element("folders")
                .Elements("folder")
                .Select(f => new FolderViewModel(
                    f.Attribute("Name").Value,
                    bool.Parse(f.Attribute("IsEmpty").Value),
                    DateTime.Parse(f.Attribute("CreationTime").Value, CultureInfo.InvariantCulture),
                    f));

            DataContext = new ObservableCollection<FolderViewModel>(data);
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadTreeListView_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/RadTreeListView_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadTreeListView_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/RadTreeListView_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadTreeListView_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/RadTreeListView_Demo.xaml.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "FolderViewModel.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/ViewModel/FolderViewModel.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "FolderViewModel.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/ViewModel/FolderViewModel.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "ColorToBrushConverter.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/ColorToBrushConverter.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "ColorToBrushConverter.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/ColorToBrushConverter.vb"
                },
            });
        }
    }
}
