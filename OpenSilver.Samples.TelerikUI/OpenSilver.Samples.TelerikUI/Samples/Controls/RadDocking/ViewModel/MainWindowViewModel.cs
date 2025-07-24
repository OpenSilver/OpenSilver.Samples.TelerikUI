using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace OpenSilver.Samples.TelerikUI.Docking
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DelegateCommand newDocumentCommand;
        private DelegateCommand saveCommand;
        private DelegateCommand loadCommand;

        public MainWindowViewModel()
        {
            this.Panes = new ObservableCollection<PaneViewModel>();
        }

        public ObservableCollection<PaneViewModel> Panes
        {
            get;
            set;
        }

        public ICommand NewDocumentCommand
        {
            get
            {
                if (newDocumentCommand == null)
                    newDocumentCommand = new DelegateCommand(this.CreateNewDocument);

                return newDocumentCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new DelegateCommand(Save);

                return saveCommand;
            }
        }

        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                    loadCommand = new DelegateCommand(Load);

                return loadCommand;
            }
        }

        public void Load(object param)
        {
            var docking = (RadDocking)param;

            if (savedPanes != null)
            {
                var xmlSerializer = new DataContractSerializer(this.Panes.GetType());
                savedPanes.Seek(0, SeekOrigin.Begin);
                var documents = (IEnumerable<PaneViewModel>)xmlSerializer.ReadObject(savedPanes);
                this.Panes.Clear();
                foreach (var document in documents)
                {
                    this.Panes.Add(document);
                }
            }
            else
            {
                // Initial layout in Docking
                this.Panes.Add(new PaneViewModel(typeof(ErrorList)) { Header = "Error List", InitialPosition = DockState.DockedBottom });
                this.Panes.Add(new PaneViewModel(typeof(PropertiesPane)) { Header = "Properties", InitialPosition = DockState.DockedRight });
                this.Panes.Add(new PaneViewModel(typeof(ServerExplorer)) { Header = "Server Explorer", InitialPosition = DockState.DockedLeft });
                this.Panes.Add(new PaneViewModel(typeof(Output)) { Header = "Output", InitialPosition = DockState.DockedBottom });
                this.Panes.Add(new PaneViewModel(typeof(SolutionExplorer)) { Header = "Solution Explorer", InitialPosition = DockState.DockedRight });
                this.Panes.Add(new PaneViewModel(typeof(ToolBox)) { Header = "ToolBox", InitialPosition = DockState.DockedLeft });
            }

            if (savedLayout != null)
            {
                savedLayout.Seek(0, SeekOrigin.Begin);
                docking.LoadLayout(savedLayout);
            }
        }

        public void Save(object param)
        {
            var docking = (RadDocking)param;

            if (savedPanes != null)
            {
                savedPanes.Dispose();
                savedPanes = null;
            }

            if (savedLayout != null)
            {
                savedLayout.Dispose();
                savedLayout = null;
            }

            savedPanes = new MemoryStream();
            savedLayout = new MemoryStream();

            var xmlSerializer = new DataContractSerializer(this.Panes.GetType());
            xmlSerializer.WriteObject(savedPanes, this.Panes);

            docking.SaveLayout(savedLayout);
        }

        private MemoryStream savedPanes;
        private MemoryStream savedLayout;

        private void CreateNewDocument(object param)
        {
            this.Panes.Add(new PaneViewModel(null)
            {
                Header = "New Document " + Guid.NewGuid(),
                IsDocument = true,
                IsHidden = false
            });
        }
    }
}
