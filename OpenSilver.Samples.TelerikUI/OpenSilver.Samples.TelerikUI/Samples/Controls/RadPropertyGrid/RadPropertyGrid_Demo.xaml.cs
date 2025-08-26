using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.Data.PropertyGrid;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadPropertyGrid_Demo : UserControl
    {
        public RadPropertyGrid_Demo()
        {
            InitializeComponent();
        }

        private void rpg_AutoGeneratingPropertyDefinition(object sender, AutoGeneratingPropertyDefinitionEventArgs e)
        {
            if (e.PropertyDefinition.DisplayName == "Opacity")
            {
                e.PropertyDefinition.OrderIndex = 0;
                e.PropertyDefinition.EditorTemplate = (DataTemplate)Resources["opacityEditorTemplate"];
                return;
            }

            if (e.PropertyDefinition.DisplayName == "Width" || e.PropertyDefinition.DisplayName == "Height")
            {
                e.PropertyDefinition.OrderIndex = 1;
                e.PropertyDefinition.EditorTemplate = (DataTemplate)Resources["widthHeightEditorTemplate"];
                return;
            }

            e.PropertyDefinition.OrderIndex = 2;
            e.PropertyDefinition.IsReadOnly = true;
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            rpg.ReloadData();
        }

        private void image_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            image.SizeChanged -= image_SizeChanged;
            rpg.Item = image;

        }
    }
}
