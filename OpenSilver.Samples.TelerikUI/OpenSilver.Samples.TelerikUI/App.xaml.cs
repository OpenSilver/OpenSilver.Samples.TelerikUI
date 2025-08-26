using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Startup += OnStartup;
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var rootVisual = new Grid();

            RootVisual = rootVisual;

            if (ThemeHelper.LoadTheme())
            {
                rootVisual.Children.Add(new MainPage());
                return;
            }

            Resources[ThemeHelper.ApplicationThemeKey] = ThemeHelper.DefaultTheme;

            var wizard = new StartupWizard()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            wizard.Completed += (o, arg) =>
            {
                rootVisual.Children.Clear();
                rootVisual.Children.Add(new MainPage());
            };

            rootVisual.Children.Add(wizard);
        }
    }
}
