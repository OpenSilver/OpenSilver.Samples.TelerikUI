using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadComboBox_Demo : UserControl
    {
        public Language SelectedLanguage { get; set; }

        public Language[] Languages { get; set; }

        public RadComboBox_Demo()
        {
            InitializeComponent();

            Languages = new[]
            {
                new Language { ID = 1, DisplayName = "Arabic" },
                new Language { ID = 2, DisplayName = "English" },
                new Language { ID = 3, DisplayName = "French" },
                new Language { ID = 4, DisplayName = "German" },
                new Language { ID = 5, DisplayName = "Hindi" },
                new Language { ID = 6, DisplayName = "Indonesian" },
                new Language { ID = 7, DisplayName = "Italian" },
                new Language { ID = 8, DisplayName = "Japanese" },
                new Language { ID = 9, DisplayName = "Korean" },
                new Language { ID = 10, DisplayName = "Mandarin Chinese" },
                new Language { ID = 11, DisplayName = "Portuguese" },
                new Language { ID = 12, DisplayName = "Russian" },
                new Language { ID = 13, DisplayName = "Spanish" },
                new Language { ID = 14, DisplayName = "Turkish" },
            };

            SelectedLanguage = Languages[0];

            DataContext = this;
        }

        public class Language
        {
            public int ID { get; set; }

            public string DisplayName { get; set; }
        }
    }
}
