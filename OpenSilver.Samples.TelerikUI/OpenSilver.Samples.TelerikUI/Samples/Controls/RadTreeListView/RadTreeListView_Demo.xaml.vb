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
    Partial Public Class RadTreeListView_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            Me.treeLinesVisibilityCB.ItemsSource = New TreeLinesVisibility() {TreeLinesVisibility.Hidden, TreeLinesVisibility.Visible}
            Me.treeLinesVisibilityCB.SelectedItem = TreeLinesVisibility.Visible

            Dim stream = Application.GetResourceStream(New Uri("/OpenSilver.Samples.TelerikUI;component/Samples/Controls/RadTreeListView/Folders.xml", UriKind.RelativeOrAbsolute)).Result.Stream

            Dim data = XDocument.Load(CType(stream, System.IO.Stream)).Element("folders").Elements("folder").[Select](Function(f) New TelerikUI.TreeListView.FolderViewModel(f.Attribute("Name").Value, Boolean.Parse(f.Attribute("IsEmpty").Value), Date.Parse(f.Attribute("CreationTime").Value, CultureInfo.InvariantCulture), f))

            DataContext = New ObservableCollection(Of OpenSilver.Samples.TelerikUI.TreeListView.FolderViewModel)(data)
        End Sub
    End Class
End Namespace
