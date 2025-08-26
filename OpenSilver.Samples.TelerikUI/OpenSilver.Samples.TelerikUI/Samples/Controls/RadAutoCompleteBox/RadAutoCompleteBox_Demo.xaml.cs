using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadAutoCompleteBox_Demo : UserControl
    {
        public RadAutoCompleteBox_Demo()
        {
            InitializeComponent();
            autoComplete.ItemsSource = Planet.GetListOfPlanets();
        }
    }
}
