using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadWrapPanel_Demo : UserControl
    {
        private static readonly SolidColorBrush[] brushes = new SolidColorBrush[]
        {
            Brushes.Blue, Brushes.Red, Brushes.Orange, Brushes.Yellow, Brushes.SkyBlue, Brushes.Green,
            Brushes.Purple, Brushes.Aqua, Brushes.Silver, Brushes.Gold, Brushes.Olive, Brushes.Magenta,
        };

        public RadWrapPanel_Demo()
        {
            InitializeComponent();
            radWrapPanelListBox.ItemsSource = GenerateItems(10);
            virtualizingWrapPanelListBox.ItemsSource = GenerateItems(10);
        }

        private void RadWrapPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(radWrapPanelTextbox.Text, out int maxItems))
            {
                maxItems = 10;
            }

            radWrapPanelListBox.ItemsSource = GenerateItems(maxItems);
        }

        private void VirtualizingWrapPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(virtualizingWrapPanelTextBox.Text, out int maxItems))
            {
                maxItems = 10;
            }

            virtualizingWrapPanelListBox.ItemsSource = GenerateItems(maxItems);
        }

        private static Border[] GenerateItems(int maxItems)
        {
            return Enumerable.Range(0, maxItems)
                .Select(i => new Border
                {
                    Width = 40,
                    Height = 20,
                    Margin = new Thickness(2),
                    Background = brushes[i % brushes.Length],
                }).ToArray();
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadWrapPanel_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWrapPanel/RadWrapPanel_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadWrapPanel_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWrapPanel/RadWrapPanel_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadWrapPanel_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWrapPanel/RadWrapPanel_Demo.xaml.vb"
                }
            });
        }
    }
}
