using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadButton_Demo : UserControl
    {
        private int _clickCount = 0;

        public RadButton_Demo()
        {
            InitializeComponent();
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            _clickCount++;
            counter.Text = _clickCount.ToString();
        }
    }
}
