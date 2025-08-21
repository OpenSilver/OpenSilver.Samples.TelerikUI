using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadTileList_Demo : UserControl
    {
        private readonly NASDAQViewModel _viewModel;
        private readonly DispatcherTimer _timer;

        public RadTileList_Demo()
        {
            InitializeComponent();

            RadTileList.MouseWheel += (o, e) => e.Handled = true;

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;

            _viewModel = new NASDAQViewModel();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += OnTimerTick;

            DataContext = _viewModel;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _viewModel.UpdateDisplayValue();
        }

        private sealed class NASDAQViewModel : INotifyPropertyChanged
        {
            public NASDAQViewModel()
            {
                this.displayValue = 3498;
            }

            private double displayValue;
            public double DisplayValue
            {
                get
                {
                    return this.displayValue;
                }
                set
                {
                    if (this.displayValue != value)
                    {
                        this.displayValue = value;
                        this.OnPropertyChanged("DisplayValue");
                    }
                }
            }

            public void UpdateDisplayValue()
            {
                if (this.DisplayValue == 3498)
                {
                    this.DisplayValue = 3470;
                }
                else
                {
                    this.DisplayValue = (int)3498;
                }
            }

            private void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadTileList_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTileList/RadTileList_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadTileList_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTileList/RadTileList_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadTileList_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTileList/RadTileList_Demo.xaml.vb"
                },
            });
        }
    }
}
