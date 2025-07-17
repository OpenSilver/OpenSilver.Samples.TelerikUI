using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.Timeline;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadTimeline_Demo : UserControl
    {
        public RadTimeline_Demo()
        {
            InitializeComponent();
            DataContext = new RadTimelineGroupingViewModel();
        }

        private sealed class RadTimelineDataItem
        {
            public DateTime StartDate { get; set; }

            public TimeSpan Duration { get; set; }

            public string GroupName { get; set; }
        }

        private sealed class RadTimelineGroupingViewModel
        {
            public RadTimelineGroupingViewModel()
            {
                PeriodStart = new DateTime(2011, 1, 1);
                PeriodEnd = new DateTime(2012, 1, 1);

                GenerateTimelineData();
            }

            public DateTime PeriodStart { get; set; }

            public DateTime PeriodEnd { get; set; }

            public List<RadTimelineDataItem> TimelineItems { get; set; }

            private void GenerateTimelineData()
            {
                Random r = new Random();
                List<RadTimelineDataItem> items = new List<RadTimelineDataItem>();

                for (DateTime date = PeriodStart; date < PeriodEnd; date = date.AddDays(2))
                {
                    items.Add(new RadTimelineDataItem()
                    {
                        StartDate = date,
                        Duration = TimeSpan.FromDays(r.Next(0, 10)),
                        GroupName = $"Group{r.Next(1, 4)}",
                    });
                }

                TimelineItems = items;
            }
        }

        private void RadToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            timeline.GroupPath = "GroupName";
            switch (timeline.GroupExpandMode)
            {
                case GroupExpandMode.None:
                    choiceNone.IsChecked = true;
                    break;
                case GroupExpandMode.Single:
                    choiceSingle.IsChecked = true;
                    break;
                case GroupExpandMode.Multiple:
                    choiceMultiple.IsChecked = true;
                    break;
            }
            choiceNone.IsEnabled = true;
            choiceSingle.IsEnabled = true;
            choiceMultiple.IsEnabled = true;
        }

        private void RadToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            timeline.GroupPath = null;
            timeline.GroupExpandMode = GroupExpandMode.None;
            choiceNone.IsChecked = false;
            choiceSingle.IsChecked = false;
            choiceMultiple.IsChecked = false;
            choiceNone.IsEnabled = false;
            choiceSingle.IsEnabled = false;
            choiceMultiple.IsEnabled = false;
        }

        private void NoneRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            timeline.GroupExpandMode = GroupExpandMode.None;
        }

        private void SingleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            timeline.GroupExpandMode = GroupExpandMode.Single;
        }

        private void MultipleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            timeline.GroupExpandMode = GroupExpandMode.Multiple;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadTimeline_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTimeline/RadTimeline_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadTimeline_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTimeline/RadTimeline_Demo.xaml.cs"
                },
            });
        }
    }
}
