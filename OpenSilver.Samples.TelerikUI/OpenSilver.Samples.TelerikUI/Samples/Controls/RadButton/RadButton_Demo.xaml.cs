using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadButton_Demo : UserControl
    {
        public RadButton_Demo()
        {
            InitializeComponent();
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You pressed the button");
        }
    }
}
