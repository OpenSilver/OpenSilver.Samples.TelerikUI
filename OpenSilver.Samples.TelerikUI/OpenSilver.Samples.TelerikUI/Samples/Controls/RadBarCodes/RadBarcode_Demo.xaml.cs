using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadBarcode_Demo : UserControl
    {
        public RadBarcode_Demo()
        {
            InitializeComponent();

            barcodeComboBox.ItemsSource = new List<BarcodeDemoItem>
            {
                new BarcodeDemoItem("Code 11", new RadBarcode11
                {
                    Text = "0123-4567",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 128", new RadBarcode128A
                {
                    Text = "ABC-abc-1234",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 128 A", new RadBarcode128A
                {
                    Text = "ABC1234abc",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 128 B", new RadBarcode128B
                {
                    Text = "ABC1234abc",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 128 C", new RadBarcode128C
                {
                    Text = "1234567",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 25 Interleaved", new RadBarcode25Interleaved
                {
                    Text = "1234567890",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 25 Standard", new RadBarcode25Standard
                {
                    Text = "1234567",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 39", new RadBarcode39
                {
                    Text = "ABC-1234",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 39 Extended", new RadBarcode39Extended
                {
                    Text = "Aa-1234",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 93", new RadBarcode93
                {
                    Text = "ABC-1234-/+",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Code 93 Extended", new RadBarcode93Extended
                {
                    Text = "Aa-1234-B1c2",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("Codebar", new RadBarcodeCodebar
                {
                    Text = "012-345-6789",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("EAN 13", new RadBarcodeEAN13
                {
                    Text = "978020137962",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("EAN 8", new RadBarcodeEAN8
                {
                    Text = "9031101",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("MSI", new RadBarcodeMSI
                {
                    Text = "01234567",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("PDF417", new RadBarcodePDF417
                {
                    Text = "This is a PDF417 by Telerik UI",
                }),
                new BarcodeDemoItem("Postnet", new RadBarcodePostnet
                {
                    Text = "1234567",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("QR Code", new RadBarcodeQR
                {
                    Text = "https://github.com/OpenSilver/OpenSilver",
                }),
                new BarcodeDemoItem("UPC A", new RadBarcodeUPCA
                {
                    Text = "72527273070",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("UPC E", new RadBarcodeUPCE
                {
                    Text = "0123456",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("UPC Supplement 2", new RadBarcodeUPCSupplement2
                {
                    Text = "42",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
                new BarcodeDemoItem("UPC Supplement 5", new RadBarcodeUPCSupplement5
                {
                    Text = "19876",
                    ShowText = true,
                    ShowChecksum = true,
                    RestrictAspectRatio = true,
                }),
            };
            barcodeComboBox.SelectedIndex = 0;
        }

        private sealed class BarcodeDemoItem
        {
            public BarcodeDemoItem(string barcode, UIElement demo)
            {
                Barcode = barcode;
                Demo = demo;
            }

            public string Barcode { get; set; }
            public UIElement Demo { get; set; }
        }
    }
}
