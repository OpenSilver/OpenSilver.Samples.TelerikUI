using OpenSilver.Samples.TelerikUI.Docking;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadDocking_Demo : UserControl
    {
        public RadDocking_Demo()
        {
            InitializeComponent();

            Loaded += OnLoaded;
            DataContext = new MainWindowViewModel();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as MainWindowViewModel;
            if (viewModel != null)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    viewModel.Load(this.radDocking);
                });
            }
        }

        private void OnPreviewShowCompass(object sender, PreviewShowCompassEventArgs e)
        {
            bool isRootCompass = e.Compass is RootCompass;
            var splitContainer = e.DraggedElement as RadSplitContainer;
            if (splitContainer != null)
            {
                bool isDraggingDocument = splitContainer.EnumeratePanes().Any(p => p is RadDocumentPane);
                var isTargetDocument = e.TargetGroup == null ? true : e.TargetGroup.EnumeratePanes().Any(p => p is RadDocumentPane);
                if (isDraggingDocument)
                {
                    e.Canceled = isRootCompass || !isTargetDocument;
                }
                else
                {
                    e.Canceled = !isRootCompass && isTargetDocument;
                }
            }
        }

        private void OnClose(object sender, StateChangeEventArgs e)
        {
            var documents = e.Panes.Select(p => p.DataContext).OfType<PaneViewModel>().Where(vm => vm.IsDocument).ToList();
            foreach (var document in documents)
            {
                ((MainWindowViewModel)this.DataContext).Panes.Remove(document);
            }
        }

        private void FilterActiveViewsSource(object sender, System.Windows.Data.FilterEventArgs e)
        {
            var vm = e.Item as PaneViewModel;
            e.Accepted = vm.IsDocument;
        }

        private void FilterToolboxesSource(object sender, System.Windows.Data.FilterEventArgs e)
        {
            var vm = e.Item as PaneViewModel;
            e.Accepted = !vm.IsDocument;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadDocking_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadDocking_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadDocking_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/RadDocking_Demo.xaml.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "ErrorList.xaml",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/ErrorList.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "Output.xaml",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/Output.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "PropertiesPane.xaml",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/PropertiesPane.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "ServerExplorer.xaml",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/ServerExplorer.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "SolutionExplorer.xaml",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/SolutionExplorer.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "ToolBox.xaml",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Views/ToolBox.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "MainWindowViewModel.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/ViewModel/MainWindowViewModel.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "MainWindowViewModel.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/ViewModel/MainWindowViewModel.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "PaneViewModel.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/ViewModel/PaneViewModel.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "PaneViewModel.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/ViewModel/PaneViewModel.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "CustomDockingPanesFactory.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Helpers/CustomDockingPanesFactory.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "CustomDockingPanesFactory.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Helpers/CustomDockingPanesFactory.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "CustomSaveLoadLayoutHelper.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Helpers/CustomSaveLoadLayoutHelper.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "CustomSaveLoadLayoutHelper.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDocking/Helpers/CustomSaveLoadLayoutHelper.vb"
                },
            });
        }
    }
}
