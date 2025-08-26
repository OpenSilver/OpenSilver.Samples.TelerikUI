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
    }
}
