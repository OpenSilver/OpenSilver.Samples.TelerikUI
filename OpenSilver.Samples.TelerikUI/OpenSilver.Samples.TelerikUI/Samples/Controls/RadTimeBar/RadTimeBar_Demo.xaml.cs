using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadTimeBar_Demo : UserControl
    {
        private double sliderActualHeight;

        public RadTimeBar_Demo()
        {
            InitializeComponent();
            DataContext = GetData();
        }

        private static List<PlotInfo> GetData()
        {
            Random r = new Random();
            var data = new List<PlotInfo>();

            for (int i = 0; i < 100; i++)
            {
                data.Add(new PlotInfo { Date = new DateTime(2014, 10, 3).AddDays(i), Val = r.Next(0, 500), });
            }

            return data;
        }

        private void chart1_PlotAreaClipChanged(object sender, EventArgs e)
        {
            UpdateTimeBarMargin();
        }

        private void slider_SelectionChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            var slider = (RadSlider)sender;
            double range = slider.Maximum - slider.Minimum;
            if (range != 0)
            {
                chart1.HorizontalZoomRangeStart = (slider.SelectionStart - slider.Minimum) / range;
                chart1.HorizontalZoomRangeEnd = (slider.SelectionEnd - slider.Minimum) / range;
            }
        }

        private void timeBarContent_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateChartMargin();
        }

        private void slider_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sliderActualHeight = e.NewSize.Height;
            UpdateChartMargin();
        }

        private void UpdateChartMargin()
        {
            double topMargin = timeBar1.ActualHeight - (timeBarContent1.ActualHeight + sliderActualHeight);
            chart1.Margin = new Thickness(0, topMargin, 0, sliderActualHeight);
        }

        private void UpdateTimeBarMargin()
        {
            double verticalAxisWidth = chart1.PlotAreaClip.X + chart1.PanOffset.X;
            timeBar1.Margin = new Thickness(verticalAxisWidth, 0, 0, 0);
        }

        private sealed class PlotInfo
        {
            public DateTime Date { get; set; }
            public double Val { get; set; }
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadTimeBar_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTimeBar/RadTimeBar_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadTimeBar_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTimeBar/RadTimeBar_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadTimeBar_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTimeBar/RadTimeBar_Demo.xaml.vb"
                },
            });
        }
    }
}
