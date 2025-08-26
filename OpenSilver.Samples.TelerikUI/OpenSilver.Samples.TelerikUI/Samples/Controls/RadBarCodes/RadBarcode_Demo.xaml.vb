Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadBarcode_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            Me.barcodeComboBox.ItemsSource = New List(Of BarcodeDemoItem) From {
                    New BarcodeDemoItem("Code 11", New RadBarcode11 With {
        .Text = "0123-4567",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 128", New RadBarcode128A With {
        .Text = "ABC-abc-1234",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 128 A", New RadBarcode128A With {
        .Text = "ABC1234abc",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 128 B", New RadBarcode128B With {
        .Text = "ABC1234abc",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 128 C", New RadBarcode128C With {
        .Text = "1234567",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 25 Interleaved", New RadBarcode25Interleaved With {
        .Text = "1234567890",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 25 Standard", New RadBarcode25Standard With {
        .Text = "1234567",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 39", New RadBarcode39 With {
        .Text = "ABC-1234",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 39 Extended", New RadBarcode39Extended With {
        .Text = "Aa-1234",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 93", New RadBarcode93 With {
        .Text = "ABC-1234-/+",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Code 93 Extended", New RadBarcode93Extended With {
        .Text = "Aa-1234-B1c2",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("Codebar", New RadBarcodeCodebar With {
        .Text = "012-345-6789",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("EAN 13", New RadBarcodeEAN13 With {
        .Text = "978020137962",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("EAN 8", New RadBarcodeEAN8 With {
        .Text = "9031101",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("MSI", New RadBarcodeMSI With {
        .Text = "01234567",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("PDF417", New RadBarcodePDF417 With {
        .Text = "This is a PDF417 by Telerik UI"
    }),
                    New BarcodeDemoItem("Postnet", New RadBarcodePostnet With {
        .Text = "1234567",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("QR Code", New RadBarcodeQR With {
        .Text = "https://github.com/OpenSilver/OpenSilver"
    }),
                    New BarcodeDemoItem("UPC A", New RadBarcodeUPCA With {
        .Text = "72527273070",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("UPC E", New RadBarcodeUPCE With {
        .Text = "0123456",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("UPC Supplement 2", New RadBarcodeUPCSupplement2 With {
        .Text = "42",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    }),
                    New BarcodeDemoItem("UPC Supplement 5", New RadBarcodeUPCSupplement5 With {
        .Text = "19876",
        .ShowText = True,
        .ShowChecksum = True,
        .RestrictAspectRatio = True
    })
}
            Me.barcodeComboBox.SelectedIndex = 0
        End Sub

        Private NotInheritable Class BarcodeDemoItem
            Public Sub New(barcode As String, demo As UIElement)
                Me.Barcode = barcode
                Me.Demo = demo
            End Sub

            Public Property Barcode As String
            Public Property Demo As UIElement
        End Class
    End Class
End Namespace
