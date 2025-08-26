using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadGanttView_Demo : UserControl
    {
        public RadGanttView_Demo()
        {
            InitializeComponent();
            Loaded += RadGanttView_Demo_Loaded;
        }

        private void RadGanttView_Demo_Loaded(object sender, RoutedEventArgs e)
        {
            GanttViewModel model = new GanttViewModel();
            model.IsBusy = true;
            DataContext = model;
        }
    }
}
