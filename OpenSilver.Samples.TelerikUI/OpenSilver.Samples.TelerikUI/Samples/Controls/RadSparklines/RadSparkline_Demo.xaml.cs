using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadSparkline_Demo : UserControl
    {
        public RadSparkline_Demo()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private sealed class MyCost
        {
            public double Cost { get; set; }
            public double UnitCost { get; set; }
        }

        private sealed class ViewModel
        {
            public ViewModel()
            {
                Costs = new ObservableCollection<MyCost>();

                var randomGenerator = new Random();

                for (int i = 1; i < 100; i++)
                {
                    Costs.Add(new MyCost
                    {
                        Cost = i,
                        UnitCost = randomGenerator.Next(-10, 11)
                    });
                }
            }

            public ObservableCollection<MyCost> Costs { get; }
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadSparkline_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadSparklines/RadSparkline_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadSparkline_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadSparklines/RadSparkline_Demo.xaml.cs"
                },
            });
        }
    }
}
