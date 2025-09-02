using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadRibbonView_Demo : UserControl
    {
        public RadRibbonView_Demo()
        {
            InitializeComponent();
            OpenHelpPageCommand = new Telerik.Windows.Controls.DelegateCommand(ExecuteOpenHelpPage);
            DataContext = OpenHelpPageCommand;
            InputBindings.Add(new KeyBinding(OpenHelpPageCommand, new KeyGesture(Key.F1, ModifierKeys.Control)));

            MouseLeftButtonDown += (o, e) =>
            {
                if (Focus())
                {
                    e.Handled = true;
                }
            };
        }

        public Telerik.Windows.Controls.DelegateCommand OpenHelpPageCommand { get; set; }

        private void ExecuteOpenHelpPage(object obj)
        {
            var radWindow = new Telerik.Windows.Controls.RadWindow();
            radWindow.Owner = root;
            radWindow.ResizeMode = Telerik.Windows.Controls.ResizeMode.NoResize;
            radWindow.Height = 320;
            radWindow.Width = 400;
            radWindow.Header = "Help";
            radWindow.WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation.CenterOwner;
            var sp = new StackPanel();
            var tb1 = new TextBlock
            {
                Text = "Help window header",
                Margin = new Thickness(20),
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 22,
                Foreground = new SolidColorBrush(Colors.Gray),
                FontWeight = FontWeights.Bold,
            };
            sp.Children.Add(tb1);
            var tb2 = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(20),
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut sed erat sit amet lorem cursus tristique non quis nisi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Integer posuere velit id faucibus consectetur. Proin aliquam elit nec enim bibendum auctor. Proin aliquam justo rhoncus enim fermentum accumsan. Curabitur ipsum purus, gravida non tellus vitae, accumsan aliquam lectus. Curabitur nibh arcu, convallis eget consectetur a, molestie eget ante. Cras sed mauris non erat ultrices hendrerit."
            };
            sp.Children.Add(tb2);

            radWindow.Content = sp;
            radWindow.Show();
        }
    }
}
