using System.Windows;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class SettingsWindow : RadWindow
    {
        public SettingsWindow()
        {
            InitializeComponent();

            listbox.ItemsSource = ThemeHelper.Themes;
            listbox.SelectedItem = StyleManager.ApplicationTheme;
        }

        private void ResetTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeHelper.ResetTheme();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Theme theme = (Theme)listbox.SelectedItem;

            if (theme != null)
            {
                await ThemeHelper.SetThemeAsync(theme, choice.IsChecked == true);
            }

            Close();
        }
    }
}
