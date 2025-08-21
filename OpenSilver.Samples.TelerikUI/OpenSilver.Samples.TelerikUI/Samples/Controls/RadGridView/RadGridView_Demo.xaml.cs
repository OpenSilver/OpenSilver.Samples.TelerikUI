using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadGridView_Demo : UserControl
    {
        public RadGridView_Demo()
        {
            InitializeComponent();
            Loaded += RadGridView_Demo_Loaded;
            rowDetailsVisibilityModeCB.ItemsSource = new GridViewRowDetailsVisibilityMode[]
            {
                GridViewRowDetailsVisibilityMode.Collapsed,
                GridViewRowDetailsVisibilityMode.Visible,
                GridViewRowDetailsVisibilityMode.VisibleWhenSelected,
            };
            selectionModeCB.ItemsSource = new SelectionMode[]
            {
                SelectionMode.Single,
                SelectionMode.Multiple,
                SelectionMode.Extended,
            };
            gridLinesVisibilityCB.ItemsSource = new GridLinesVisibility[]
            {
                GridLinesVisibility.None,
                GridLinesVisibility.Horizontal,
                GridLinesVisibility.Vertical,
                GridLinesVisibility.Both,
            };
            selectionUnitCB.ItemsSource = new GridViewSelectionUnit[]
            {
                GridViewSelectionUnit.Cell,
                GridViewSelectionUnit.FullRow,
                GridViewSelectionUnit.Mixed,
            };
            filteringModeCB.ItemsSource = new FilteringMode[]
            {
                FilteringMode.Popup,
                FilteringMode.FilterRow,
            };
        }

        private void RadGridView_Demo_Loaded(object sender, RoutedEventArgs e)
        {
            radGridView.ItemsSource = Planet.GetListOfPlanets();
        }

        private void radGridView_AutoGeneratingColumn(object sender, Telerik.Windows.Controls.GridViewAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.UniqueName == "ImagePath")
            {
                e.Cancel = true;
            }
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadGridView_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadGridView_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadGridView_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml.vb"
                },
            });
        }
    }
}
