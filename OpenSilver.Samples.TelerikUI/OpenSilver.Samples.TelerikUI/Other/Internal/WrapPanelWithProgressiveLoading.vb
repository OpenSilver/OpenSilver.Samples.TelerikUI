﻿Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Class WrapPanelWithProgressiveLoading
        Inherits WrapPanel
        Public Sub New()
            ProgressiveRenderingChunkSize = 3
        End Sub
    End Class
End Namespace
