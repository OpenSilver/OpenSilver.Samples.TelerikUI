using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class StartupWizard : UserControl
    {
        public StartupWizard()
        {
            InitializeComponent();
            listbox.ItemsSource = ThemeHelper.Themes;
            listbox.SelectedItem = ThemeHelper.DefaultTheme;
        }

        public event EventHandler Completed;

        private async void Wizard_Completed(object sender, RoutedEventArgs e)
        {
            Theme theme = (Theme)listbox.SelectedItem ?? ThemeHelper.DefaultTheme;

            busy.IsBusy = true;

            await ThemeHelper.SetThemeAsync(theme, choice.IsChecked == true);

            busy.IsBusy = false;

            Completed?.Invoke(this, EventArgs.Empty);
        }
    }
}
