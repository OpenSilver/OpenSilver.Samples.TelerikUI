using OpenSilver.Samples.TelerikUI.RadChart3D.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSilver.Samples.TelerikUI.RadChart3D.ViewModel
{
    public sealed class RadialViewModel
    {
        private IEnumerable<double> _data;

        public IEnumerable<double> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = SeriesExtensions.GetUserRadialData();
                }

                return _data;
            }
        }
    }
}
