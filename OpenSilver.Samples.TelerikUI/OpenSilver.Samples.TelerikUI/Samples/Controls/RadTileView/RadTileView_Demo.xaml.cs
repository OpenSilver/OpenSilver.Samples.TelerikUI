using System.Linq;
using System.Windows.Controls;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadTileView_Demo : UserControl
    {
        public RadTileView_Demo()
        {
            InitializeComponent();

            DataContext = Planet.GetListOfPlanets();
        }

        private void tileView1_TileStateChanged(object sender, RadRoutedEventArgs e)
        {
            RadTileViewItem item = e.OriginalSource as RadTileViewItem;
            if (item != null)
            {
                RadFluidContentControl fluid = item.ChildrenOfType<RadFluidContentControl>().FirstOrDefault();
                if (fluid != null)
                {
                    switch (item.TileState)
                    {
                        case TileViewItemState.Maximized:
                            fluid.State = FluidContentControlState.Large;
                            break;
                        case TileViewItemState.Minimized:
                            fluid.State = FluidContentControlState.Normal;
                            break;
                        case TileViewItemState.Restored:
                            fluid.State = FluidContentControlState.Normal;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
