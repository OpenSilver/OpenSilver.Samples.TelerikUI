Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls.GridView

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadGridView_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            AddHandler Loaded, AddressOf RadGridView_Demo_Loaded
            Me.rowDetailsVisibilityModeCB.ItemsSource = New GridViewRowDetailsVisibilityMode() {GridViewRowDetailsVisibilityMode.Collapsed, GridViewRowDetailsVisibilityMode.Visible, GridViewRowDetailsVisibilityMode.VisibleWhenSelected}
            Me.selectionModeCB.ItemsSource = New SelectionMode() {SelectionMode.Single, SelectionMode.Multiple, SelectionMode.Extended}
            Me.gridLinesVisibilityCB.ItemsSource = New GridLinesVisibility() {GridLinesVisibility.None, GridLinesVisibility.Horizontal, GridLinesVisibility.Vertical, GridLinesVisibility.Both}
            Me.selectionUnitCB.ItemsSource = New GridViewSelectionUnit() {GridViewSelectionUnit.Cell, GridViewSelectionUnit.FullRow, GridViewSelectionUnit.Mixed}
            Me.filteringModeCB.ItemsSource = New FilteringMode() {FilteringMode.Popup, FilteringMode.FilterRow}
        End Sub

        Private Sub RadGridView_Demo_Loaded(sender As Object, e As RoutedEventArgs)
            Me.radGridView.ItemsSource = TelerikUI.Planet.GetListOfPlanets()
        End Sub

        Private Sub radGridView_AutoGeneratingColumn(sender As Object, e As Telerik.Windows.Controls.GridViewAutoGeneratingColumnEventArgs)
            If Equals(e.Column.UniqueName, "ImagePath") Then
                e.Cancel = True
            End If
        End Sub

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadGridView_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadGridView_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadGridView_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadGridView/RadGridView_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
