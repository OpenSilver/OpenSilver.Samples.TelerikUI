using OpenSilver.Samples.TelerikUI.RadChart3D.Helpers;
using System.Collections.Generic;

namespace OpenSilver.Samples.TelerikUI.RadChart3D.ViewModel
{
    public sealed class UserDataViewModel
    {
        private IList<IEnumerable<double>> _data;
        private int _itemsCount;
        private int _seriesCount;

        public IList<IEnumerable<double>> CollectionData
        {
            get
            {
                if (_data == null)
                {
                    _data = FillSampleChartData(SeriesCount, ItemsCount);
                }

                return _data;
            }
        }

        public IEnumerable<double> Data
        {
            get
            {
                return CollectionData[0];
            }
        }

        public int ItemsCount
        {
            get
            {
                return _itemsCount;
            }
            set
            {
                _itemsCount = value;
            }
        }

        public int SeriesCount
        {
            get
            {
                return _seriesCount;
            }
            set
            {
                _seriesCount = value;
            }
        }

        private IList<IEnumerable<double>> FillSampleChartData(int seriesCount, int numbOfItems)
        {
            List<IEnumerable<double>> itemsSource = new List<IEnumerable<double>>();

            for (int i = 0; i < seriesCount; i++)
            {
                itemsSource.Add(SeriesExtensions.GetUserData(numbOfItems, i));
            }

            return itemsSource;
        }
    }
}
