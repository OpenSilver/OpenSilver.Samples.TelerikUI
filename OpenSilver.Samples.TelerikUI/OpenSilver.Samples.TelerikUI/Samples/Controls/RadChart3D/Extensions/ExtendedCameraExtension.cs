using Telerik.Windows.Controls.Charting;

namespace OpenSilver.Samples.TelerikUI.RadChart3D.Extensions
{
    public class ExtendedCameraExtension : CameraExtension
    {
        public override void Attach(ChartArea owner)
        {
            base.Attach(owner);
            owner.MouseWheel += OnMouseWheel;
        }

        public override void Detach(ChartArea owner)
        {
            base.Detach(owner);
            owner.MouseWheel -= OnMouseWheel;
        }


        private void OnMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (!ZoomEnabled)
            {
                return;
            }

            if (e.Delta > 0)
            {
                Zoom(1.1);
            }
            else
            {
                Zoom(0.9);
            }

            e.Handled = true;
        }
    }
}
