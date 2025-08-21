Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Windows.Input
Imports Telerik.Windows.Controls
Imports Telerik.Windows.Controls.Docking

Namespace OpenSilver.Samples.TelerikUI.Docking
    Public Class MainWindowViewModel
        Inherits ViewModelBase
        Private newDocumentCommandField As DelegateCommand
        Private saveCommandField As DelegateCommand
        Private loadCommandField As DelegateCommand

        Public Sub New()
            Panes = New ObservableCollection(Of PaneViewModel)()
        End Sub

        Public Property Panes As ObservableCollection(Of PaneViewModel)

        Public ReadOnly Property NewDocumentCommand As ICommand
            Get
                If newDocumentCommandField Is Nothing Then newDocumentCommandField = New DelegateCommand(AddressOf CreateNewDocument)

                Return newDocumentCommandField
            End Get
        End Property

        Public ReadOnly Property SaveCommand As ICommand
            Get
                If saveCommandField Is Nothing Then saveCommandField = New DelegateCommand(AddressOf Save)

                Return saveCommandField
            End Get
        End Property

        Public ReadOnly Property LoadCommand As ICommand
            Get
                If loadCommandField Is Nothing Then loadCommandField = New DelegateCommand(AddressOf Load)

                Return loadCommandField
            End Get
        End Property

        Public Sub Load(param As Object)
            Dim docking = CType(param, RadDocking)

            If savedPanes IsNot Nothing Then
                Dim xmlSerializer = New DataContractSerializer(Panes.GetType())
                savedPanes.Seek(0, SeekOrigin.Begin)
                Dim documents = CType(xmlSerializer.ReadObject(savedPanes), IEnumerable(Of PaneViewModel))
                Panes.Clear()
                For Each document In documents
                    Panes.Add(document)
                Next
            Else
                ' Initial layout in Docking
                Panes.Add(New PaneViewModel(GetType(Docking.ErrorList)) With {
                    .Header = "Error List",
                    .InitialPosition = DockState.DockedBottom
                })
                Panes.Add(New PaneViewModel(GetType(Docking.PropertiesPane)) With {
                    .Header = "Properties",
                    .InitialPosition = DockState.DockedRight
                })
                Panes.Add(New PaneViewModel(GetType(Docking.ServerExplorer)) With {
                    .Header = "Server Explorer",
                    .InitialPosition = DockState.DockedLeft
                })
                Panes.Add(New PaneViewModel(GetType(Docking.Output)) With {
                    .Header = "Output",
                    .InitialPosition = DockState.DockedBottom
                })
                Panes.Add(New PaneViewModel(GetType(Docking.SolutionExplorer)) With {
                    .Header = "Solution Explorer",
                    .InitialPosition = DockState.DockedRight
                })
                Panes.Add(New PaneViewModel(GetType(Docking.ToolBox)) With {
                    .Header = "ToolBox",
                    .InitialPosition = DockState.DockedLeft
                })
            End If

            If savedLayout IsNot Nothing Then
                savedLayout.Seek(0, SeekOrigin.Begin)
                docking.LoadLayout(savedLayout)
            End If
        End Sub

        Public Sub Save(param As Object)
            Dim docking = CType(param, RadDocking)

            If savedPanes IsNot Nothing Then
                savedPanes.Dispose()
                savedPanes = Nothing
            End If

            If savedLayout IsNot Nothing Then
                savedLayout.Dispose()
                savedLayout = Nothing
            End If

            savedPanes = New MemoryStream()
            savedLayout = New MemoryStream()

            Dim xmlSerializer = New DataContractSerializer(Panes.GetType())
            xmlSerializer.WriteObject(savedPanes, Panes)

            docking.SaveLayout(savedLayout)
        End Sub

        Private savedPanes As MemoryStream
        Private savedLayout As MemoryStream

        Private Sub CreateNewDocument(param As Object)
            Panes.Add(New PaneViewModel(Nothing) With {
    .Header = "New Document " & Guid.NewGuid().ToString(),
    .IsDocument = True,
    .IsHidden = False
})
        End Sub
    End Class
End Namespace
