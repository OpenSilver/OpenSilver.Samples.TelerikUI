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
using Telerik.Windows;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadContextMenu_Demo : UserControl
    {
        public RadContextMenu_Demo()
        {
            this.InitializeComponent();
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadContextMenu_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadContextMenu/RadContextMenu_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadContextMenu_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadContextMenu/RadContextMenu_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadContextMenu_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadContextMenu/RadContextMenu_Demo.xaml.vb"
                }
            });
        }

        private void RadMenuItemRed_Click(object sender, RadRoutedEventArgs e)
        {
            ContextMenuBorder.Background = new SolidColorBrush(Colors.Red); 
        }
        private void RadMenuItemGreen_Click(object sender, RadRoutedEventArgs e)
        {
            ContextMenuBorder.Background = new SolidColorBrush(Colors.Green);
        }
        private void RadMenuItemBlue_Click(object sender, RadRoutedEventArgs e)
        {
            ContextMenuBorder.Background = new SolidColorBrush(Colors.Blue);
        }
        private void RadMenuItemReset_Click(object sender, RadRoutedEventArgs e)
        {
            ContextMenuBorder.Background = new SolidColorBrush(Colors.LightGray);
        }
    }
}
