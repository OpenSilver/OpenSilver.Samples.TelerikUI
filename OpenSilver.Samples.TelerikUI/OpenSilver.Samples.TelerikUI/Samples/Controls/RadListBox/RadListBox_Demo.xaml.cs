using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadListBox_Demo : UserControl
    {
        public RadListBox_Demo()
        {
            InitializeComponent();
            DataContext = Planet.GetListOfPlanets();
        }
    }
}
