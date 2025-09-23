Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IO.IsolatedStorage
Imports System.Threading.Tasks
Imports System.Windows
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Friend Module ThemeHelper
        Public Const ApplicationThemeKey As String = "ApplicationTheme"
        Private Const ThemeSettingKey As String = "TelerikTheme"
        Private Const LoadThemeOnceSettingKey As String = "TelerikThemeLoadOnce"

        Private _assemblyLoader As TelerikUI.ILazyAssemblyLoader

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

        Public Async Function LoadThemeAsync() As Task(Of Boolean)
            If IsolatedStorageSettings.ApplicationSettings.Contains(LoadThemeOnceSettingKey) Then
                Dim themeName = CStr(IsolatedStorageSettings.ApplicationSettings(LoadThemeOnceSettingKey))
                IsolatedStorageSettings.ApplicationSettings.Remove(LoadThemeOnceSettingKey)

                Dim theme = ThemeManager.FromName(themeName)
                If theme IsNot Nothing Then
                    Await SetThemeAsync(theme, False)
                    Return True
                End If
            End If

            If IsolatedStorageSettings.ApplicationSettings.Contains(ThemeSettingKey) Then
                Dim themeName = CStr(IsolatedStorageSettings.ApplicationSettings(ThemeSettingKey))
                Dim theme = ThemeManager.FromName(themeName)
                If theme IsNot Nothing Then
                    Await SetThemeAsync(theme, False)
                    Return True
                End If
            End If

            Return False
        End Function

        Public Async Function SetThemeAsync(theme As Theme, Optional remember As Boolean = False) As Task
            If StyleManager.ApplicationTheme Is Nothing Then
                If theme IsNot DefaultTheme Then
                    Await LoadThemeAssembly(theme)
                End If

                StyleManager.ApplicationTheme = theme
                Application.Current.Resources(ApplicationThemeKey) = theme

                If remember Then
                    IsolatedStorageSettings.ApplicationSettings(ThemeSettingKey) = theme.ToString()
                End If
                Return
            End If

            SetNextTheme(theme, remember)
        End Function

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

        Friend Sub Initialize(assemblyLoader As TelerikUI.ILazyAssemblyLoader)
            _assemblyLoader = If(assemblyLoader, CSharpImpl.__Throw(Of TelerikUI.ILazyAssemblyLoader)(New ArgumentNullException(NameOf(assemblyLoader))))
        End Sub

        Private Function LoadThemeAssembly(theme As Theme) As Task
            If _assemblyLoader Is Nothing Then
                Throw New InvalidOperationException()
            End If

            Return _assemblyLoader.LoadAssembliesAsync(New String(0) {GetAssemblyName(theme.Source)})
        End Function

        Private Function GetAssemblyName(themeUri As Uri) As String
            Dim uri As String = themeUri.ToString()

            If Not IsComponentUri(uri) Then
                Throw New InvalidOperationException()
            End If

            Return ExtractAssemblyNameFromComponentUri(uri)
        End Function

        Private Function IsComponentUri(uri As String) As Boolean
            Dim index = uri.IndexOf(";"c)
            If index > -1 Then
                Return uri.AsSpan(index).StartsWith(";component/".AsSpan(), StringComparison.OrdinalIgnoreCase)
            End If

            Return False
        End Function

        Private Function ExtractAssemblyNameFromComponentUri(uri As String) As String
            Dim offset = If(uri(0) = "/"c, 1, 0)
            Return uri.Substring(offset, uri.IndexOf(";"c) - offset)
        End Function

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal throw statements")>
            Shared Function __Throw(Of T)(ByVal e As Exception) As T
                Throw e
            End Function
        End Class
    End Module
End Namespace
