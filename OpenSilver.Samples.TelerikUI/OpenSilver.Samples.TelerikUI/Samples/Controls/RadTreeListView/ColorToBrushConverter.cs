using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace OpenSilver.Samples.TelerikUI.TreeListView
{
    public sealed class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                return new SolidColorBrush(color);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
