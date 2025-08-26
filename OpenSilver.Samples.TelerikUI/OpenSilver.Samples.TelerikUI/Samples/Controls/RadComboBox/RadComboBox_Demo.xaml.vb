Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadComboBox_Demo
        Inherits UserControl
        Public Property SelectedLanguage As Language

        Public Property Languages As Language()

        Public Sub New()
            Me.InitializeComponent()

            Languages = {New Language With {
.ID = 1,
.DisplayName = "Arabic"
}, New Language With {
.ID = 2,
.DisplayName = "English"
}, New Language With {
.ID = 3,
.DisplayName = "French"
}, New Language With {
.ID = 4,
.DisplayName = "German"
}, New Language With {
.ID = 5,
.DisplayName = "Hindi"
}, New Language With {
.ID = 6,
.DisplayName = "Indonesian"
}, New Language With {
.ID = 7,
.DisplayName = "Italian"
}, New Language With {
.ID = 8,
.DisplayName = "Japanese"
}, New Language With {
.ID = 9,
.DisplayName = "Korean"
}, New Language With {
.ID = 10,
.DisplayName = "Mandarin Chinese"
}, New Language With {
.ID = 11,
.DisplayName = "Portuguese"
}, New Language With {
.ID = 12,
.DisplayName = "Russian"
}, New Language With {
.ID = 13,
.DisplayName = "Spanish"
}, New Language With {
.ID = 14,
.DisplayName = "Turkish"
}}

            SelectedLanguage = Languages(0)

            DataContext = Me
        End Sub

        Public Class Language
            Public Property ID As Integer

            Public Property DisplayName As String
        End Class
    End Class
End Namespace
