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
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadProgressBar_Demo : UserControl
    {
        public RadProgressBar_Demo()
        {
            InitializeComponent();

            ProgressBar.Loaded += OnProgressBarLoaded;
            ProgressBar.Unloaded += OnProgressBarUnloaded;
        }

        private void OnProgressBarLoaded(object sender, RoutedEventArgs e)
        {
            ProgressBar.BeginAnimation(RangeBase.ValueProperty, new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(5)),
                From = ProgressBar.Minimum,
                To = ProgressBar.Maximum,
                RepeatBehavior = RepeatBehavior.Forever,
            });
        }

        private void OnProgressBarUnloaded(object sender, RoutedEventArgs e)
        {
            ProgressBar.BeginAnimation(RangeBase.ValueProperty, null);
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadProgressBar_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadProgressBar/RadProgressBar_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadProgressBar_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadProgressBar/RadProgressBar_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadProgressBar_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadProgressBar/RadProgressBar_Demo.xaml.vb"
                }
            });
        }
    }
}
