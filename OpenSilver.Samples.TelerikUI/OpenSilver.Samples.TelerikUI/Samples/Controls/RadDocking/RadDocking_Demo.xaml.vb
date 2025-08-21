Imports OpenSilver.Samples.TelerikUI.Docking
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls
Imports Telerik.Windows.Controls.Docking

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadDocking_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            AddHandler Loaded, AddressOf OnLoaded
            DataContext = New TelerikUI.Docking.MainWindowViewModel()
        End Sub

        Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
            Dim viewModel = TryCast(DataContext, OpenSilver.Samples.TelerikUI.Docking.MainWindowViewModel)
            If viewModel IsNot Nothing Then
                Dispatcher.BeginInvoke(Sub() viewModel.Load(Me.radDocking))
            End If
        End Sub

        Private Sub OnPreviewShowCompass(sender As Object, e As PreviewShowCompassEventArgs)
            Dim isRootCompass = TypeOf e.Compass Is RootCompass
            Dim splitContainer = TryCast(e.DraggedElement, RadSplitContainer)
            If splitContainer IsNot Nothing Then
                Dim isDraggingDocument As Boolean = splitContainer.EnumeratePanes().Any(Function(p) TypeOf p Is RadDocumentPane)
                Dim isTargetDocument = If(e.TargetGroup Is Nothing, True, e.TargetGroup.EnumeratePanes().Any(Function(p) TypeOf p Is RadDocumentPane))
                If isDraggingDocument Then
                    e.Canceled = isRootCompass OrElse Not isTargetDocument
                Else
                    e.Canceled = Not isRootCompass AndAlso isTargetDocument
                End If
            End If
        End Sub

        Private Sub OnClose(sender As Object, e As StateChangeEventArgs)
            Dim documents = e.Panes.[Select](Function(p) p.DataContext).OfType(Of OpenSilver.Samples.TelerikUI.Docking.PaneViewModel)().Where(Function(vm) vm.IsDocument).ToList()
            For Each document In documents
                CType(DataContext, TelerikUI.Docking.MainWindowViewModel).Panes.Remove(document)
            Next
        End Sub

        Private Sub FilterActiveViewsSource(sender As Object, e As Windows.Data.FilterEventArgs)
            Dim vm = TryCast(e.Item, OpenSilver.Samples.TelerikUI.Docking.PaneViewModel)
            e.Accepted = vm.IsDocument
        End Sub

        Private Sub FilterToolboxesSource(sender As Object, e As Windows.Data.FilterEventArgs)
            Dim vm = TryCast(e.Item, OpenSilver.Samples.TelerikUI.Docking.PaneViewModel)
            e.Accepted = Not vm.IsDocument
        End Sub

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadDocking_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadDocking_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadDocking_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml.vb"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "ErrorList.xaml",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/ErrorList.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "Output.xaml",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/Output.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "PropertiesPane.xaml",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/PropertiesPane.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "ServerExplorer.xaml",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/ServerExplorer.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "SolutionExplorer.xaml",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/SolutionExplorer.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "ToolBox.xaml",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/ToolBox.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "MainWindowViewModel.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/ViewModel/MainWindowViewModel.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "MainWindowViewModel.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/ViewModel/MainWindowViewModel.vb"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "PaneViewModel.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/ViewModel/PaneViewModel.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "PaneViewModel.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/ViewModel/PaneViewModel.vb"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "CustomDockingPanesFactory.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Helpers/CustomDockingPanesFactory.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "CustomDockingPanesFactory.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Helpers/CustomDockingPanesFactory.vb"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "CustomSaveLoadLayoutHelper.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Helpers/CustomSaveLoadLayoutHelper.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "CustomSaveLoadLayoutHelper.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Helpers/CustomSaveLoadLayoutHelper.vb"
    }
})
        End Sub
    End Class
End Namespace
