using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadTransitionControl_Demo : UserControl
    {
        public RadTransitionControl_Demo()
        {
            InitializeComponent();

            DataContext = new ViewModel();
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadTransitionControl_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTransitionControl/RadTransitionControl_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadTransitionControl_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTransitionControl/RadTransitionControl_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadTransitionControl_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTransitionControl/RadTransitionControl_Demo.xaml.vb"
                }
            });
        }

        public class ViewModel
        {
            public ObservableCollection<ColorItem> ColorItems { get; set; }

            public ViewModel()
            {
                ColorItems = new ObservableCollection<ColorItem>
                {
                    new ColorItem("Yellow", Colors.Yellow),
                    new ColorItem("Orange", Colors.Orange),
                    new ColorItem("Red", Colors.Red),
                    new ColorItem("Blue", Colors.Blue),
                    new ColorItem("Green", Colors.Green),
                    new ColorItem("Purple", Colors.Purple),
                };
            }
        }

        public class ColorItem
        {
            public ColorItem(string name, Color color)
            {
                Name = name;
                Color = color;
            }

            public string Name { get; set; }

            public Color Color { get; set; }
        }
    }
}
