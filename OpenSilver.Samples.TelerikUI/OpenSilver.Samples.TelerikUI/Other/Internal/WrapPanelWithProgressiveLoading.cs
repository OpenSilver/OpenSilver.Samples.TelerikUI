using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public class WrapPanelWithProgressiveLoading : WrapPanel
    {
        public WrapPanelWithProgressiveLoading()
        {
            ProgressiveRenderingChunkSize = 3;
        }
    }
}
