using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadToolBar_Demo : UserControl
    {
        public RadToolBar_Demo()
        {
            InitializeComponent();
            DataContext = new RadToolBarMainViewModel();
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadToolBar_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadToolBar/RadToolBar_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadToolBar_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadToolBar/RadToolBar_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadToolBar_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadToolBar/RadToolBar_Demo.xaml.vb"
                }
            });
        }
    }

    public class RadToolBarMainViewModel
    {
        public RadToolBarMainViewModel()
        {
            PopulateSampleViewModel();
        }
        public ObservableCollection<ViewModelBase> Items { get; set; }

        private void PopulateSampleViewModel()
        {
            Items = new ObservableCollection<ViewModelBase>()
            {
                new TextBlockViewModel("Foreground:"),
                new ColorPickerViewModel(),
                new TextBlockViewModel("Background:"),
                new ColorPickerViewModel(),
                new TextBlockViewModel("BorderColor:"),
                new ColorPickerViewModel(),
                new SeparatorViewModel(),
                new ButtonViewModel("SAVE !", "Save colors configuration."),
            };
        }
    }

    public class TextBlockViewModel : ViewModelBase
    {
        public TextBlockViewModel(string text)
        {
            Text = text;
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

    }

    public class ColorPickerViewModel : ViewModelBase
    {
        public ColorPickerViewModel()
        {
            MainPaletteColors = new ObservableCollection<Color>()
            {
                Color.FromArgb(255, 253, 253, 0),
                Color.FromArgb(255, 0, 253, 0),
                Color.FromArgb(255, 0, 253, 253),
                Color.FromArgb(255, 253, 0, 253),
                Color.FromArgb(255, 0, 0 , 253 ),
                Color.FromArgb(255, 253, 0 ,0),
                Color.FromArgb(255, 0 , 0, 126),
                Color.FromArgb(255, 0, 126, 126),
                Color.FromArgb(255, 0, 126, 0),
                Color.FromArgb(255, 126, 0, 126),
                Color.FromArgb(255, 126, 0, 0),
                Color.FromArgb(255, 126, 126, 0),
                Color.FromArgb(255, 126, 126, 126),
                Color.FromArgb(255, 190, 190, 190),
                Color.FromArgb(255, 0 , 1 , 1)
            };
        }
        public ObservableCollection<Color> MainPaletteColors { get; set; }
    }

    public class ButtonViewModel : ViewModelBase
    {
        public ButtonViewModel(string content, string tooltip)
        {
            ToolTipContent = tooltip;
            Content = content;
            InfoCommand = new DelegateCommand(x => MessageBox.Show("Colors Saved!"));
        }

        private string tooltip;

        public string ToolTipContent
        {
            get { return tooltip; }
            set
            {
                if (tooltip != value)
                {
                    tooltip = value;
                    OnPropertyChanged("ToolTipContent");
                }
            }
        }


        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                if (content != value)
                {
                    content = value;
                    OnPropertyChanged("Content");
                }
            }
        }

        public DelegateCommand InfoCommand { get; set; }

    }

    public class SeparatorViewModel : ViewModelBase
    {
    }

    public class ToolBarItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is TextBlockViewModel)
            {
                return TextBlockTemplate;
            }
            else if (item is SeparatorViewModel)
            {
                return SeparatorTemplate;
            }
            else if (item is ButtonViewModel)
            {
                return ButtonTemplate;
            }
            else if (item is ColorPickerViewModel)
            {
                return ColorPickerTemplate;
            }
            return base.SelectTemplate(item, container);
        }

        public DataTemplate ButtonTemplate { get; set; }
        public DataTemplate TextBlockTemplate { get; set; }
        public DataTemplate SeparatorTemplate { get; set; }
        public DataTemplate ColorPickerTemplate { get; set; }
    }
}
