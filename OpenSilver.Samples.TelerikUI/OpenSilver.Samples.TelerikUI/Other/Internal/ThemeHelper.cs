using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Windows;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    internal static class ThemeHelper
    {
        public const string ApplicationThemeKey = "ApplicationTheme";
        private const string ThemeSettingKey = "TelerikTheme";
        private const string LoadThemeOnceSettingKey = "TelerikThemeLoadOnce";

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

        public static bool LoadTheme()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(LoadThemeOnceSettingKey))
            {
                string themeName = (string)IsolatedStorageSettings.ApplicationSettings[LoadThemeOnceSettingKey];
                IsolatedStorageSettings.ApplicationSettings.Remove(LoadThemeOnceSettingKey);

                Theme theme = ThemeManager.FromName(themeName);
                if (theme != null)
                {
                    SetTheme(theme, false);
                    return true;
                }
            }

            if (IsolatedStorageSettings.ApplicationSettings.Contains(ThemeSettingKey))
            {
                string themeName = (string)IsolatedStorageSettings.ApplicationSettings[ThemeSettingKey];
                Theme theme = ThemeManager.FromName(themeName);
                if (theme != null)
                {
                    SetTheme(theme, false);
                    return true;
                }
            }

            return false;
        }

        public static void SetTheme(Theme theme, bool remember = false)
        {
            if (StyleManager.ApplicationTheme == null)
            {
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
    }
}
