using System;
using System.Collections.ObjectModel;
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
    }
}
