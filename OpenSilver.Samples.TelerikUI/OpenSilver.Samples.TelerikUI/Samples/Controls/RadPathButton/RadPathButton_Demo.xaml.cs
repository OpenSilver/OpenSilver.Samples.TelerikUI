using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadPathButton_Demo : UserControl
    {
        private int _clickCount = 0;

        public RadPathButton_Demo()
        {
            InitializeComponent();
        }

        private void RadPathButton_Click(object sender, RoutedEventArgs e)
        {
            _clickCount++;
            counter.Text = _clickCount.ToString();
        }
    }
}
