﻿Imports System.Collections.Generic
Imports System.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Friend Module ViewSourceButtonHelper
        Public Sub ViewSource(ByVal sourcePaths As List(Of ViewSourceButtonInfo))
            If sourcePaths.Count > 0 Then
                Dim tabControl = New TabControl()

                For Each viewSourceButtonInfo In sourcePaths
                    Dim tabItem = New TabItem() With {
    .Header = viewSourceButtonInfo.TabHeader,
                            .Content = New ControlToDisplayCodeHostedOnGitHub() With {
        .FilePathOnGitHub = viewSourceButtonInfo.FilePathOnGitHub
    }
}

                    tabControl.Items.Add(tabItem)
                Next

                CType(tabControl.Items(0), TabItem).IsSelected = True

                MainPage.Current.ViewSourceCode(tabControl)
            End If
        End Sub
    End Module
End Namespace
