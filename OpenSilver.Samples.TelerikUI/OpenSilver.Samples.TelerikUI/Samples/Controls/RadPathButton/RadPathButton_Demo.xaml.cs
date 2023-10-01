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
    public partial class RadPathButton_Demo : UserControl
    {
        public RadPathButton_Demo()
        {
            this.InitializeComponent();
        }

        private void RadPathButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You pressed the button");
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadPathButton_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadPathButton/RadPathButton_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadPathButton_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadPathButton/RadPathButton_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadPathButton_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI.VB/Samples/Controls/RadPathButton/RadPathButton_Demo.xaml.vb"
                }
            });
        }
    }
}
