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
    public partial class RadProgressBar_Demo : UserControl
    {
        public RadProgressBar_Demo()
        {
            this.InitializeComponent();
        }

        public void decreaseProgress_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.Value--;
        }

        public void increaseProgress_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.Value++;
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
