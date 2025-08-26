using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;

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
    }
}
