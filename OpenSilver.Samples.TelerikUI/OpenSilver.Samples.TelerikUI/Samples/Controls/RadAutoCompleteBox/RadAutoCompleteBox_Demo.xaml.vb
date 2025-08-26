Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadAutoCompleteBox_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            Me.autoComplete.ItemsSource = TelerikUI.Planet.GetListOfPlanets()
        End Sub
    End Class
End Namespace
