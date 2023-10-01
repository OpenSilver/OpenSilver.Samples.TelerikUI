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
    public partial class RadDocking_Demo : UserControl
    {
        RadPane firstPane;
        public RadDocking_Demo()
        {
            this.InitializeComponent();
            firstPane = FirstPane;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadDocking_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadDocking_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadDocking_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI.VB/Samples/Controls/RadDocking/RadDocking_Demo.xaml.vb"
                }
            });
        }


        private void ButtonShowPanes_Click(object sender, RoutedEventArgs e)
        {
            //make sure the pane is rendered visible even if floating:    
            FirstPane.IsHidden = false;

            PaneGroup.ShowAllPanes();
        }
    }
}
