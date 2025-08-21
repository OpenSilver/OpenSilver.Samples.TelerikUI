Imports System.Collections.ObjectModel
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Xml.Linq
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI.TreeListView
    Public NotInheritable Class FolderViewModel
        Inherits ViewModelBase
        Private nameField As String
        Private isEmptyField As Boolean
        Private createdOnField As Date
        Private itemsField As ObservableCollection(Of FolderViewModel)
        Private ReadOnly folderElement As XElement

        Public Sub New(element As XElement)
            folderElement = element
        End Sub

        Public Sub New(name As String, isEmpty As Boolean, createdOn As Date, element As XElement)
            Me.Name = name
            Me.IsEmpty = isEmpty
            folderElement = element
            Me.CreatedOn = createdOn
            itemsField = New ObservableCollection(Of FolderViewModel)(From f In folderElement.Elements("folder") Select New FolderViewModel(f.Attribute("Name").Value, Boolean.Parse(f.Attribute("IsEmpty").Value), Date.Parse(f.Attribute("CreationTime").Value, System.Globalization.CultureInfo.InvariantCulture), f))
        End Sub

        Public Property Name As String
            Get
                Return nameField
            End Get
            Set(value As String)
                nameField = value
            End Set
        End Property

        Public Property CreatedOn As Date
            Get
                Return createdOnField
            End Get
            Set(value As Date)
                createdOnField = value
            End Set
        End Property

        <Display(AutoGenerateField:=False)>
        Public Property IsEmpty As Boolean
            Get
                Return isEmptyField
            End Get
            Set(value As Boolean)
                isEmptyField = value
            End Set
        End Property

        <Display(AutoGenerateField:=False)>
        Public ReadOnly Property Items As ObservableCollection(Of FolderViewModel)
            Get
                Return itemsField
            End Get
        End Property

        Private isExpandedField As Boolean

        <Display(AutoGenerateField:=False)>
        Public Property IsExpanded As Boolean
            Get
                Return isExpandedField
            End Get
            Set(value As Boolean)
                If isExpandedField <> value Then
                    isExpandedField = value

                    LoadChildren()

                    OnPropertyChanged("IsExpanded")
                End If
            End Set
        End Property

        Public Sub LoadChildren()
            If itemsField Is Nothing Then
                itemsField = New ObservableCollection(Of FolderViewModel)(From f In folderElement.Elements("folder") Select New FolderViewModel(f) With {
.Name = f.Attribute("Name").Value,
.IsEmpty = Boolean.Parse(f.Attribute("IsEmpty").Value),
.CreatedOn = Date.Parse(f.Attribute("CreationTime").Value, System.Globalization.CultureInfo.InvariantCulture)
})
                OnPropertyChanged("Items")
            End If
        End Sub
    End Class
End Namespace
