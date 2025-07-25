using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadBook_Demo : UserControl
    {
        private static readonly Faker<RadBookPage> faker = new Faker<RadBookPage>()
            .RuleFor(o => o.Title, f => f.Lorem.Word())
            .RuleFor(o => o.Content, f => f.Lorem.Paragraph(1));

        public RadBook_Demo()
        {
            InitializeComponent();

            firstPagePositionCB.ItemsSource = new PagePosition[]
            {
                PagePosition.Left,
                PagePosition.Right,
            };

            hardPagesCB.ItemsSource = new HardPages[]
            {
                HardPages.None,
                HardPages.First,
                HardPages.Last,
                HardPages.FirstAndLast,
                HardPages.All,
            };

            pageFlipModeCB.ItemsSource = new PageFlipMode[]
            {
                PageFlipMode.None,
                PageFlipMode.SingleClick,
                PageFlipMode.DoubleClick,
            };

            showPageFoldCB.ItemsSource = new PageFoldVisibility[]
            {
                PageFoldVisibility.OnFoldEnter,
                PageFoldVisibility.OnPageEnter,
                PageFoldVisibility.Never,
            };

            foldHintPositionCB.ItemsSource = new FoldHintPosition[]
            {
                FoldHintPosition.Top,
                FoldHintPosition.Bottom,
            };

            book.ItemsSource = Enumerable.Range(1, 999).Select(i =>
            {
                var page = faker.Generate();
                page.PageNumber = i;
                return page;
            });
        }

        private sealed class RadBookPage : ViewModelBase
        {
            private string title;
            private string content;
            private int pageNumber;

            public RadBookPage() { }

            public string Title
            {
                get { return title; }
                set
                {
                    if (title != value)
                    {
                        title = value;
                        OnPropertyChanged(nameof(Title));
                    }
                }
            }

            public string Content
            {
                get { return content; }
                set
                {
                    if (content != value)
                    {
                        content = value;
                        OnPropertyChanged(nameof(Content));
                    }
                }
            }

            public int PageNumber
            {
                get { return pageNumber; }
                set
                {
                    if (pageNumber != value)
                    {
                        pageNumber = value;
                        OnPropertyChanged(nameof(PageNumber));
                    }
                }
            }
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadBook_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadBook/RadBook_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadBook_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadBook/RadBook_Demo.xaml.cs"
                },
            });
        }
    }
}
