Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace Global.OpenSilver.Samples.TelerikUI
    Public Partial Class RadTreeListView_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            Me.radTreeListView.DataContext = New WarehouseViewModel()
        End Sub

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadTreeListView_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/RadTreeListView_Demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadTreeListView_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadTreeListView/RadTreeListView_Demo.xaml.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadTreeListView_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI.VB/Samples/Controls/RadTreeListView/RadTreeListView_Demo.xaml.vb"
    }
})
        End Sub

        Public Class WarehouseItem
            Implements INotifyPropertyChanged
            Private nameField As String
            Private countField As Integer
            Private itemsField As ObservableCollection(Of WarehouseItem)

            Public Sub New(ByVal name As String, ByVal count As Integer)
                Me.Name = name
                Me.Count = count
                Items = New ObservableCollection(Of WarehouseItem)()
            End Sub
            Public Property Name As String
                Get
                    Return nameField
                End Get
                Set(ByVal value As String)
                    If Not Equals(value, nameField) Then
                        nameField = value
                        OnPropertyChanged("Name")
                    End If
                End Set
            End Property
            Public Property Items As ObservableCollection(Of WarehouseItem)
                Get
                    Return itemsField
                End Get
                Set(ByVal value As ObservableCollection(Of WarehouseItem))
                    If value IsNot itemsField Then
                        itemsField = value
                        OnPropertyChanged("Items")
                    End If
                End Set
            End Property
            Public Property Count As Integer
                Get
                    Return countField
                End Get
                Set(ByVal value As Integer)
                    If value <> countField Then
                        countField = value
                        OnPropertyChanged("Count")
                    End If
                End Set
            End Property

            Protected Overridable Sub OnPropertyChanged(ByVal args As PropertyChangedEventArgs)
                Dim handler = PropertyChangedEvent
                If handler IsNot Nothing Then
                    handler(Me, args)
                End If
            End Sub

            Private Sub OnPropertyChanged(ByVal propertyName As String)
                OnPropertyChanged(New PropertyChangedEventArgs(propertyName))
            End Sub

            Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        End Class

        Public Class WarehouseService
            Public Shared Function GetWarehouseData() As ObservableCollection(Of WarehouseItem)
                Dim data As ObservableCollection(Of WarehouseItem) = New ObservableCollection(Of WarehouseItem)()
                Dim drinks As WarehouseItem = New WarehouseItem("Drinks", 35)
                drinks.Items.Add(New WarehouseItem("Water", 10))
                Dim tea As WarehouseItem = New WarehouseItem("Tea", 20)
                tea.Items.Add(New WarehouseItem("Black", 10))
                tea.Items.Add(New WarehouseItem("Green", 10))
                drinks.Items.Add(tea)
                drinks.Items.Add(New WarehouseItem("Coffee", 5))
                data.Add(drinks)
                Dim vegetables As WarehouseItem = New WarehouseItem("Vegeatbles", 75)
                vegetables.Items.Add(New WarehouseItem("Tomato", 40))
                vegetables.Items.Add(New WarehouseItem("Carrot", 25))
                vegetables.Items.Add(New WarehouseItem("Onion", 10))
                data.Add(vegetables)
                Dim fruits As WarehouseItem = New WarehouseItem("Fruits", 55)
                fruits.Items.Add(New WarehouseItem("Cherry", 30))
                fruits.Items.Add(New WarehouseItem("Apple", 20))
                fruits.Items.Add(New WarehouseItem("Melon", 5))
                data.Add(fruits)
                Return data
            End Function
        End Class
        Public Class WarehouseViewModel
            Inherits ViewModelBase
            Private warehouseItemsField As ObservableCollection(Of WarehouseItem)

            Public ReadOnly Property WarehouseItems As ObservableCollection(Of WarehouseItem)
                Get
                    If warehouseItemsField Is Nothing Then
                        warehouseItemsField = WarehouseService.GetWarehouseData()
                    End If

                    Return warehouseItemsField
                End Get
            End Property
        End Class
    End Class
End Namespace
