using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadRating_Demo : UserControl
    {
        public RadRating_Demo()
        {
            InitializeComponent();
            DataContext = new RatingViewModel(5);
        }

        private sealed class RatingViewModel : ViewModelBase
        {
            private static Random randomNumberGenerator = new Random();
            private double averageRating;
            private double totalVotes;
            private int ratingPoints;
            private double? value;

            public ObservableCollection<RatingItemModel> Items { get; set; }
            public DelegateCommand UpdateVotesCommand { get; set; }

            public RatingViewModel(int ratingPoints, bool generateRandomVotes = true)
            {
                this.ratingPoints = ratingPoints;
                this.Items = new ObservableCollection<RatingItemModel>();
                for (int i = 1; i <= ratingPoints; i++)
                {
                    this.Items.Add(new RatingItemModel() { Value = i });
                }

                this.UpdateVotesCommand = new DelegateCommand(OnUpdateVotesExecuted, OnCanUpdateVotesExecute);

                if (generateRandomVotes)
                {
                    this.GenerateRandomVotes();
                    this.TotalVotes = this.CalculateTotalVotesCount();
                    this.AverageRating = this.CalculateAverageRating();
                }
            }

            private void GenerateRandomVotes()
            {
                foreach (var item in this.Items)
                {
                    item.VotesCount = randomNumberGenerator.Next(10, 100);
                }
            }

            public double? Value
            {
                get
                {
                    return this.value;
                }

                set
                {
                    this.value = value;
                    this.OnPropertyChanged("Value");
                    this.UpdateVotesCommand.InvalidateCanExecute();
                }
            }

            public double TotalVotes
            {
                get
                {
                    return this.totalVotes;
                }

                set
                {
                    this.totalVotes = value;
                    this.OnPropertyChanged("TotalVotes");
                }
            }

            public double AverageRating
            {
                get
                {
                    return this.averageRating;
                }

                set
                {
                    this.averageRating = value;
                    this.OnPropertyChanged("AverageRating");
                }
            }

            public int RatingPoints
            {
                get
                {
                    return this.ratingPoints;
                }
            }

            private bool OnCanUpdateVotesExecute(object obj)
            {
                return obj != null ? true : false;
            }

            private void OnUpdateVotesExecuted(object obj)
            {
                var itemValue = (double)obj;
                var ratingModel = this.Items.FirstOrDefault(x => x.Value == itemValue);
                ratingModel.VotesCount++;

                this.TotalVotes = this.CalculateTotalVotesCount();
                this.AverageRating = this.CalculateAverageRating();
            }


            private double CalculateAverageRating()
            {
                var sum = this.SumAllVotes();

                var average = sum / this.TotalVotes;
                return Math.Round(average, 2);
            }

            private double CalculateTotalVotesCount()
            {
                var totalVotes = 0;
                foreach (var item in this.Items)
                {
                    totalVotes += item.VotesCount;
                }

                return totalVotes;
            }

            private double SumAllVotes()
            {
                double votesSum = 0;
                foreach (var item in this.Items)
                {
                    votesSum += item.VotesCount * item.Value;
                }

                return votesSum;
            }
        }

        private sealed class RatingItemModel : ViewModelBase
        {
            private int votesCount;

            public int Value { get; set; }

            public int VotesCount
            {
                get { return votesCount; }
                set
                {
                    if (this.votesCount != value)
                    {
                        this.votesCount = value;
                        this.OnPropertyChanged("VotesCount");
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
                    TabHeader = "RadRating_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadRating/RadRating_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadRating_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadRating/RadRating_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadRating_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadRating/RadRating_Demo.xaml.vb"
                },
            });
        }
    }
}
