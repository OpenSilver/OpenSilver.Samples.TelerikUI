using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    internal static class ThemeHelper
    {
        public const string ApplicationThemeKey = "ApplicationTheme";
        private const string ThemeSettingKey = "TelerikTheme";
        private const string LoadThemeOnceSettingKey = "TelerikThemeLoadOnce";

        private static ILazyAssemblyLoader _assemblyLoader;

        public static ReadOnlyCollection<Theme> Themes { get; } =
            new ReadOnlyCollection<Theme>(new List<Theme>
            {
                new Office_BlackTheme(),
                new Office_BlueTheme(),
                new Office_SilverTheme(),
                new Expression_DarkTheme(),
                new SummerTheme(),
                new TransparentTheme(),
                new VistaTheme(),
                new Windows7Theme(),
                new Windows8Theme()
            });

        public static Theme DefaultTheme => Themes[0];

        public static async Task<bool> LoadThemeAsync()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(LoadThemeOnceSettingKey))
            {
                string themeName = (string)IsolatedStorageSettings.ApplicationSettings[LoadThemeOnceSettingKey];
                IsolatedStorageSettings.ApplicationSettings.Remove(LoadThemeOnceSettingKey);

                Theme theme = ThemeManager.FromName(themeName);
                if (theme != null)
                {
                    await SetThemeAsync(theme, false);
                    return true;
                }
            }

            if (IsolatedStorageSettings.ApplicationSettings.Contains(ThemeSettingKey))
            {
                string themeName = (string)IsolatedStorageSettings.ApplicationSettings[ThemeSettingKey];
                Theme theme = ThemeManager.FromName(themeName);
                if (theme != null)
                {
                    await SetThemeAsync(theme, false);
                    return true;
                }
            }

            return false;
        }

        public static async Task SetThemeAsync(Theme theme, bool remember = false)
        {
            if (StyleManager.ApplicationTheme == null)
            {
                if (theme != DefaultTheme)
                {
                    await LoadThemeAssembly(theme);
                }

                StyleManager.ApplicationTheme = theme;
                Application.Current.Resources[ApplicationThemeKey] = theme;

                if (remember)
                {
                    IsolatedStorageSettings.ApplicationSettings[ThemeSettingKey] = theme.ToString();
                }
                return;
            }

            SetNextTheme(theme, remember);
        }

        private static void SetNextTheme(Theme theme, bool remember)
        {
            if (remember)
            {
                IsolatedStorageSettings.ApplicationSettings[ThemeSettingKey] = theme.ToString();
                IsolatedStorageSettings.ApplicationSettings.Remove(LoadThemeOnceSettingKey);
            }
            else
            {
                IsolatedStorageSettings.ApplicationSettings[LoadThemeOnceSettingKey] = theme.ToString();
            }
        }

        public static void ResetTheme()
        {
            IsolatedStorageSettings.ApplicationSettings.Remove(ThemeSettingKey);
        }

        internal static void Initialize(ILazyAssemblyLoader assemblyLoader)
        {
            _assemblyLoader = assemblyLoader ?? throw new ArgumentNullException(nameof(assemblyLoader));
        }

        private static Task LoadThemeAssembly(Theme theme)
        {
            if (_assemblyLoader is null)
            {
                throw new InvalidOperationException();
            }

            return _assemblyLoader.LoadAssembliesAsync(new string[1] { GetAssemblyName(theme.Source) });
        }

        private static string GetAssemblyName(Uri themeUri)
        {
            string uri = themeUri.ToString();

            if (!IsComponentUri(uri))
            {
                throw new InvalidOperationException();
            }

            return ExtractAssemblyNameFromComponentUri(uri);
        }

        private static bool IsComponentUri(string uri)
        {
            int index = uri.IndexOf(';');
            if (index > -1)
            {
                return uri.AsSpan(index).StartsWith(";component/".AsSpan(), StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        private static string ExtractAssemblyNameFromComponentUri(string uri)
        {
            int offset = uri[0] == '/' ? 1 : 0;
            return uri.Substring(offset, uri.IndexOf(';') - offset);
        }
    }
}
