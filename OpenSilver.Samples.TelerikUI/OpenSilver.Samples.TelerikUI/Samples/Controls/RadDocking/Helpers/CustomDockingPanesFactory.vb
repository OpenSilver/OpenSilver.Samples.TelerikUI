Imports System
Imports System.Linq
Imports Telerik.Windows.Controls
Imports Telerik.Windows.Controls.Docking

Namespace OpenSilver.Samples.TelerikUI.Docking
    Public Class CustomDockingPanesFactory
        Inherits DockingPanesFactory
        Protected Overrides Sub AddPane(radDocking As RadDocking, pane As RadPane)
            Dim paneModel = TryCast(pane.DataContext, OpenSilver.Samples.TelerikUI.Docking.PaneViewModel)
            If paneModel IsNot Nothing AndAlso Not paneModel.IsDocument Then
                Dim group As RadPaneGroup = Nothing
                Select Case paneModel.InitialPosition
                    Case DockState.DockedRight
                        group = TryCast(radDocking.SplitItems.ToList().FirstOrDefault(Function(i) Equals(i.Control.Name, "rightGroup")), RadPaneGroup)
                        If group IsNot Nothing Then
                            group.Items.Add(pane)

                        End If
                        Return
                    Case DockState.DockedBottom
                        group = TryCast(radDocking.SplitItems.ToList().FirstOrDefault(Function(i) Equals(i.Control.Name, "bottomGroup")), RadPaneGroup)
                        If group IsNot Nothing Then
                            group.Items.Add(pane)
                        End If
                        Return
                    Case DockState.DockedLeft
                        group = TryCast(radDocking.SplitItems.ToList().FirstOrDefault(Function(i) Equals(i.Control.Name, "leftGroup")), RadPaneGroup)
                        If group IsNot Nothing Then
                            group.Items.Add(pane)
                        End If
                        Return
                    Case DockState.FloatingDockable
                        Dim fdSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer()
                        group = radDocking.GeneratedItemsFactory.CreatePaneGroup()
                        fdSplitContainer.Items.Add(group)
                        group.Items.Add(pane)
                        radDocking.Items.Add(fdSplitContainer)
                        pane.MakeFloatingDockable()
                        Return
                    Case DockState.FloatingOnly
                        Dim foSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer()
                        group = radDocking.GeneratedItemsFactory.CreatePaneGroup()
                        foSplitContainer.Items.Add(group)
                        group.Items.Add(pane)
                        radDocking.Items.Add(foSplitContainer)
                        pane.MakeFloatingOnly()
                        Return
                    Case Else
                        Return
                End Select
            End If

            MyBase.AddPane(radDocking, pane)
        End Sub

        Protected Overrides Function CreatePaneForItem(item As Object) As RadPane
            Dim viewModel = TryCast(item, OpenSilver.Samples.TelerikUI.Docking.PaneViewModel)
            If viewModel IsNot Nothing Then
                Dim pane = If(viewModel.IsDocument, New RadDocumentPane(), New RadPane())
                pane.DataContext = item
                RadDocking.SetSerializationTag(pane, viewModel.Header)
                If viewModel.ContentType IsNot Nothing Then
                    pane.Content = Activator.CreateInstance(viewModel.ContentType)
                End If

                Return pane
            End If

            Return MyBase.CreatePaneForItem(item)
        End Function

        Protected Overrides Sub RemovePane(pane As RadPane)
            pane.DataContext = Nothing
            pane.Content = Nothing
            pane.ClearValue(RadDocking.SerializationTagProperty)
            pane.RemoveFromParent()
        End Sub
    End Class
End Namespace
