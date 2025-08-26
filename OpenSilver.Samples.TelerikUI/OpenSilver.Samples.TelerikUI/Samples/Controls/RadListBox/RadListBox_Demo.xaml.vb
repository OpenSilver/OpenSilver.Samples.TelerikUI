Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadListBox_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            DataContext = TelerikUI.Planet.GetListOfPlanets()
        End Sub
    End Class
End Namespace
