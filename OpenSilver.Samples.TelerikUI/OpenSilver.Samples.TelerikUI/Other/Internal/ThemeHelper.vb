Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IO.IsolatedStorage
Imports System.Windows
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Friend Module ThemeHelper
        Public Const ApplicationThemeKey As String = "ApplicationTheme"
        Private Const ThemeSettingKey As String = "TelerikTheme"
        Private Const LoadThemeOnceSettingKey As String = "TelerikThemeLoadOnce"

        Public ReadOnly Property Themes As ReadOnlyCollection(Of Theme) = New ReadOnlyCollection(Of Theme)(New List(Of Theme) From {
New Office_BlackTheme(),
New Office_BlueTheme(),
New Office_SilverTheme(),
New Expression_DarkTheme(),
New SummerTheme(),
New TransparentTheme(),
New VistaTheme(),
New Windows7Theme(),
New Windows8Theme()
})

        Public ReadOnly Property DefaultTheme As Theme
            Get
                Return Themes(0)
            End Get
        End Property

        Public Function LoadTheme() As Boolean
            If IsolatedStorageSettings.ApplicationSettings.Contains(LoadThemeOnceSettingKey) Then
                Dim themeName = CStr(IsolatedStorageSettings.ApplicationSettings(LoadThemeOnceSettingKey))
                IsolatedStorageSettings.ApplicationSettings.Remove(LoadThemeOnceSettingKey)

                Dim theme = ThemeManager.FromName(themeName)
                If theme IsNot Nothing Then
                    SetTheme(theme, False)
                    Return True
                End If
            End If

            If IsolatedStorageSettings.ApplicationSettings.Contains(ThemeSettingKey) Then
                Dim themeName = CStr(IsolatedStorageSettings.ApplicationSettings(ThemeSettingKey))
                Dim theme = ThemeManager.FromName(themeName)
                If theme IsNot Nothing Then
                    SetTheme(theme, False)
                    Return True
                End If
            End If

            Return False
        End Function

        Public Sub SetTheme(theme As Theme, Optional remember As Boolean = False)
            If StyleManager.ApplicationTheme Is Nothing Then
                StyleManager.ApplicationTheme = theme
                Application.Current.Resources(ApplicationThemeKey) = theme

                If remember Then
                    IsolatedStorageSettings.ApplicationSettings(ThemeSettingKey) = theme.ToString()
                End If
                Return
            End If

            SetNextTheme(theme, remember)
        End Sub

        Private Sub SetNextTheme(theme As Theme, remember As Boolean)
            If remember Then
                IsolatedStorageSettings.ApplicationSettings(ThemeSettingKey) = theme.ToString()
                IsolatedStorageSettings.ApplicationSettings.Remove(LoadThemeOnceSettingKey)
            Else
                IsolatedStorageSettings.ApplicationSettings(LoadThemeOnceSettingKey) = theme.ToString()
            End If
        End Sub

        Public Sub ResetTheme()
            IsolatedStorageSettings.ApplicationSettings.Remove(ThemeSettingKey)
        End Sub
    End Module
End Namespace
