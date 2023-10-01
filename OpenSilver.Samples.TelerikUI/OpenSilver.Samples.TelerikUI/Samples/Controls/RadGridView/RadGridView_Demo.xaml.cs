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
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadGridView_Demo : UserControl
    {
        public RadGridView_Demo()
        {
            this.InitializeComponent();
            this.Loaded += RadGridView_Demo_Loaded;
        }

        private void RadGridView_Demo_Loaded(object sender, RoutedEventArgs e)
        {
            RadGridView1.ItemsSource = Planet.GetListOfPlanets();
            RadGridView1.AutoGenerateColumns = true;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadGridView_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadGridView_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "Planets.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Other/Planets.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadGridView_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI.VB/Samples/Controls/RadGridView/RadGridView_Demo.xaml.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "Planets.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI.VB/Other/Planets.vb"
                }
            });
        }
    }
}
