using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadHeatMap_Demo : UserControl
    {
        public RadHeatMap_Demo()
        {
            InitializeComponent();

            radHeatMap.Definition.ItemsSource = CreateWeatherData();
        }

        private static List<MonthlyTemperature> CreateWeatherData()
        {
            var time = new DateTime(2004, 1, 1);
            var result = new List<MonthlyTemperature>();
            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    result.Add(new MonthlyTemperature(time, r.Next(0, 10)));
                    time = time.AddMonths(1);
                }
                for (int a = 0; a < 3; a++)
                {
                    result.Add(new MonthlyTemperature(time, r.Next(10, 20)));
                    time = time.AddMonths(1);
                }
                for (int a = 0; a < 3; a++)
                {
                    result.Add(new MonthlyTemperature(time, r.Next(20, 30)));
                    time = time.AddMonths(1);
                }
                for (int a = 0; a < 3; a++)
                {
                    result.Add(new MonthlyTemperature(time, r.Next(10, 20)));
                    time = time.AddMonths(1);
                }
            }
            return result;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadHeatMap_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadHeatMap/RadHeatMap_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadHeatMap_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadHeatMap/RadHeatMap_Demo.xaml.cs"
                },
            });
        }

        private sealed class MonthlyTemperature
        {
            public MonthlyTemperature(DateTime time, double temp)
            {
                Time = time;
                Temperature = temp;
            }

            public DateTime Time { get; set; }

            public double Temperature { get; set; }
        }
    }
}
