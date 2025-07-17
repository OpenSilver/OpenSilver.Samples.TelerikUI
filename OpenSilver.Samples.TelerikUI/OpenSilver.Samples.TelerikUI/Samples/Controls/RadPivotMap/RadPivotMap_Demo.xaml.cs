using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadPivotMap_Demo : UserControl
    {
        public RadPivotMap_Demo()
        {
            InitializeComponent();
            DataContext = GetData();
        }

        private static ObservableCollection<MovieInfo> GetData()
        {
            var movies = new ObservableCollection<MovieInfo>()
            {
                new MovieInfo() { Genre = "Adventure", Title = "Toy Story 3", GrossSales = 415004880 },
                new MovieInfo() { Genre = "Adventure", Title = "Iron Man 3", GrossSales = 409013994 },
                new MovieInfo() { Genre = "Adventure", Title = "Tangled", GrossSales = 200821936 },
                new MovieInfo() { Genre = "Adventure", Title = "The Karate Kid", GrossSales = 176591618 },
                new MovieInfo() { Genre = "Action", Title = "Avatar", GrossSales = 760507625 },
                new MovieInfo() { Genre = "Action", Title = "Sherlock Holmes", GrossSales = 186848418 },
                new MovieInfo() { Genre = "Action", Title = "Red", GrossSales = 130380162 },
                new MovieInfo() { Genre = "Comedy", Title = "Despicable Me 3", GrossSales = 264624300 },
                new MovieInfo() { Genre = "Comedy", Title = "Easy A", GrossSales = 158401464 },
                new MovieInfo() { Genre = "Comedy", Title = "Superbad", GrossSales = 61979680 },
                new MovieInfo() { Genre = "Comedy", Title = "Date Night", GrossSales = 121463226 },
                new MovieInfo() { Genre = "Horror", Title = "The Ring", GrossSales = 129128133 },
                new MovieInfo() { Genre = "Horror", Title = "The Grudge", GrossSales = 110359362 },
            };
            return movies;
        }

        private sealed class MovieInfo
        {
            public string Genre { get; set; }
            public string Title { get; set; }
            public double GrossSales { get; set; }
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadPivotMap_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadPivotMap/RadPivotMap_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadPivotMap_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadPivotMap/RadPivotMap_Demo.xaml.cs"
                },
            });
        }
    }
}
