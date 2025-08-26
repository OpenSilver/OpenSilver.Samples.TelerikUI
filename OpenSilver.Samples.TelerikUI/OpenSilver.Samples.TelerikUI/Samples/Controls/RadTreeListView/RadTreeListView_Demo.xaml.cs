using OpenSilver.Samples.TelerikUI.TreeListView;
using System;
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
    }
}
