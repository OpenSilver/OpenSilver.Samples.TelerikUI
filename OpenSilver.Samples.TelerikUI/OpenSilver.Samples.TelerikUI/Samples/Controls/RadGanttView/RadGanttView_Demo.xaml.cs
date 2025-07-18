using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadGanttView_Demo : UserControl
    {
        public RadGanttView_Demo()
        {
            InitializeComponent();
            Loaded += RadGanttView_Demo_Loaded;
        }

        private void RadGanttView_Demo_Loaded(object sender, RoutedEventArgs e)
        {
            GanttViewModel model = new GanttViewModel();
            model.IsBusy = true;
            DataContext = model;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadGanttVieww_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGanttView/RadGanttView_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadGanttView_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGanttView/RadGanttView_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "GanttViewModel.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Other/GanttViewModel.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadGanttView_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGanttView/RadGanttView_Demo.xaml.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "GanttViewModel.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Other/GanttViewModel.vb"
                }
            });
        }
    }
}
