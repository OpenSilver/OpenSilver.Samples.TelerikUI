using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Wizard;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadWizard_Demo : UserControl
    {
        private readonly ViewModel viewModel = new ViewModel();

        public RadWizard_Demo()
        {
            InitializeComponent();
            DataContext = viewModel;
            this.AddHandler(RadToggleButton.ClickEvent, new RoutedEventHandler(OnClick));
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var toggleButton = e.OriginalSource as RadToggleButton;

            if (toggleButton != null)
            {
                if ((bool)toggleButton.IsChecked)
                {
                    this.viewModel.ButtonClicksCount++;
                }
                else
                {
                    this.viewModel.ButtonClicksCount--;
                }
            }
        }

        private void wizard_Completed(object sender, WizardCompletedEventArgs e)
        {
            (sender as RadWizard).SelectedPageIndex = 0;
        }

        private sealed class ViewModel : ViewModelBase
        {
            private int buttonClicksCount;
            public int ButtonClicksCount
            {
                get { return this.buttonClicksCount; }
                set
                {
                    if (value != this.buttonClicksCount)
                    {
                        this.buttonClicksCount = value;
                        this.OnPropertyChanged("IsSelected");
                    }
                }
            }

            public bool IsSelected
            {
                get
                {
                    return this.buttonClicksCount > 0;
                }
            }
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadWizard_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWizard/RadWizard_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadWizard_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWizard/RadWizard_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadWizard_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWizard/RadWizard_Demo.xaml.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "ProgressPageBehavior.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWizard/ProgressPageBehavior.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "ProgressPageBehavior.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWizard/ProgressPageBehavior.vb"
                },
            });
        }
    }
}
