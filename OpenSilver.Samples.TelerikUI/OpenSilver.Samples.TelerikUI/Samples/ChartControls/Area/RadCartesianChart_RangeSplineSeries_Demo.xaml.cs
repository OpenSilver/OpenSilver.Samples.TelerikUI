using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadCartesianChart_RangeSplineSeries_Demo : UserControl
    {
        public RadCartesianChart_RangeSplineSeries_Demo()
        {
            this.InitializeComponent();
        }
        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadCartesianChart_RangeSplineSeries_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadCartesianChart/Area/RadCartesianChart_RangeSplineSeries_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadCartesianChart_RangeSplineSeries_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadCartesianChart/Area/RadCartesianChart_RangeSplineSeries_Demo.xaml.cs"
                }
            });
        }
    }
}
