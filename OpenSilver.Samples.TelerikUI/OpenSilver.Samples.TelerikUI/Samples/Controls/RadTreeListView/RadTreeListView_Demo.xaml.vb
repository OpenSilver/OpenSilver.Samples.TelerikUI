Imports OpenSilver.Samples.TelerikUI.TreeListView
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Xml.Linq
Imports Telerik.Windows.Controls.TreeListView

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadTreeListView_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            Me.treeLinesVisibilityCB.ItemsSource = New TreeLinesVisibility() {TreeLinesVisibility.Hidden, TreeLinesVisibility.Visible}
            Me.treeLinesVisibilityCB.SelectedItem = TreeLinesVisibility.Visible

            Dim stream = Application.GetResourceStream(New Uri("/OpenSilver.Samples.TelerikUI;component/Samples/Controls/RadTreeListView/Folders.xml", UriKind.RelativeOrAbsolute)).Result.Stream

            Dim data = XDocument.Load(CType(stream, System.IO.Stream)).Element("folders").Elements("folder").[Select](Function(f) New TelerikUI.TreeListView.FolderViewModel(f.Attribute("Name").Value, Boolean.Parse(f.Attribute("IsEmpty").Value), Date.Parse(f.Attribute("CreationTime").Value, CultureInfo.InvariantCulture), f))

            DataContext = New ObservableCollection(Of OpenSilver.Samples.TelerikUI.TreeListView.FolderViewModel)(data)
        End Sub

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadTreeListView_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/RadTreeListView_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTreeListView_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/RadTreeListView_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadTreeListView_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/RadTreeListView_Demo.xaml.vb"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "FolderViewModel.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/ViewModel/FolderViewModel.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "FolderViewModel.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/ViewModel/FolderViewModel.vb"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "ColorToBrushConverter.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/ColorToBrushConverter.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "ColorToBrushConverter.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/ColorToBrushConverter.vb"
    }
})
        End Sub
    End Class
End Namespace
