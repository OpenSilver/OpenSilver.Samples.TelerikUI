using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadPathButton_Demo : UserControl
    {
        public RadPathButton_Demo()
        {
            InitializeComponent();
        }

        private void RadPathButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You pressed the button");
        }
    }
}
