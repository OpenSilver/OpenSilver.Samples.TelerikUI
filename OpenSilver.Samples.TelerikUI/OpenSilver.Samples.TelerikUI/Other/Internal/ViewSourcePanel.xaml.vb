Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class ViewSourcePanel
        Inherits Grid
        Private _sources As IEnumerable(Of TelerikUI.ViewSourceButtonInfo)

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Public Sub ViewSource(sources As IEnumerable(Of TelerikUI.ViewSourceButtonInfo))
            _sources = sources
            Me.cSharpButton.IsChecked = True
        End Sub

        Private Sub UpdateTabs(sources As IEnumerable(Of TelerikUI.ViewSourceButtonInfo))
            Dim selectedIndex = Me.TabControl.SelectedIndex
            Me.TabControl.Items.Clear()

            For Each viewSourceButtonInfo In sources
                Me.TabControl.Items.Add(New RadTabItem() With {
    .Header = viewSourceButtonInfo.GetHeader(),
    .Content = New TelerikUI.ControlToDisplayCodeHostedOnGitHub(viewSourceButtonInfo.GetAbsoluteUrl()),
    .DataContext = viewSourceButtonInfo
})
            Next

            If selectedIndex >= 0 AndAlso Me.TabControl.Items.Count > selectedIndex Then
                Me.TabControl.SelectedIndex = selectedIndex
            End If
        End Sub

        Private Function GetCSharpSources() As IEnumerable(Of TelerikUI.ViewSourceButtonInfo)
            Return GetSources(".vb", ".fs")
        End Function
        Private Function GetVBNETSources() As IEnumerable(Of TelerikUI.ViewSourceButtonInfo)
            Return GetSources(".cs", ".fs")
        End Function

        Private Function GetSources(ParamArray extensionsToIgnore As String()) As IEnumerable(Of TelerikUI.ViewSourceButtonInfo)
            Return _sources.Where(Function(x) String.IsNullOrEmpty(x.FileName) OrElse Not extensionsToIgnore.Contains(Path.GetExtension(x.FileName)?.ToLower()))
        End Function

        Private Sub OnCSharpRadioButtonChecked(sender As Object, e As RoutedEventArgs)
            UpdateTabs(GetCSharpSources())
        End Sub

        Private Sub OnVBNETRadioButtonChecked(sender As Object, e As RoutedEventArgs)
            UpdateTabs(GetVBNETSources())
        End Sub
    End Class
End Namespace
