using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadColorPicker_Demo : UserControl
    {
        public RadColorPicker_Demo()
        {
            InitializeComponent();
        }

        private void SelectedColor_Changed(object sender, EventArgs e)
        {
            Color color = ColorPicker.SelectedColor;
            SolidColorBrush brush = new SolidColorBrush(color);
            ColorBorder.Background = brush;
        }
    }
}
