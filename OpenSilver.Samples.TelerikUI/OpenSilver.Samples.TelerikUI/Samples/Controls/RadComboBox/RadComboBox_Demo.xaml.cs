using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadComboBox_Demo : UserControl
    {
        bool isInitialized = false;
        public Language SelectedLanguage { get; set; }
        public Language[] Languages { get; set; }

        public RadComboBox_Demo()
        {
            this.InitializeComponent();

            this.Languages = new[]
            {
                new Language { ID = 1, DisplayName = "English" },
                new Language { ID = 2, DisplayName = "French" },
            };

            this.SelectedLanguage = this.Languages[0];
            this.LanguagesComboBox.ItemsSource = this.Languages;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadComboBox_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadComboBox/RadComboBox_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadComboBox_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadComboBox/RadComboBox_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadComboBox_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadComboBox/RadComboBox_Demo.xaml.vb"
                }
            });
        }

        private void LanguagesComboBox_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (isInitialized)
                MessageBox.Show($"You have selected {this.SelectedLanguage.DisplayName}");
            else
                isInitialized = true;
        }

        public class Language
        {
            public int ID { get; set; }

            public string DisplayName { get; set; }
        }
    }
}
