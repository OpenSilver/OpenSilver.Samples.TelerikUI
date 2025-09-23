using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public sealed partial class App : Application
    {
        public App()
            : this(new NoOpLazyAssemblyLoader())
        {
        }

        public App(ILazyAssemblyLoader assemblyLoader)
        {
            ThemeHelper.Initialize(assemblyLoader);

            InitializeComponent();
            Startup += OnStartup;
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            var rootVisual = new Grid();

            RootVisual = rootVisual;

            if (await ThemeHelper.LoadThemeAsync())
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

        private sealed class NoOpLazyAssemblyLoader : ILazyAssemblyLoader
        {
            public Task<IEnumerable<Assembly>> LoadAssembliesAsync(IEnumerable<string> assembliesToLoad) =>
                Task.FromResult(Enumerable.Empty<Assembly>());
        }
    }
}
