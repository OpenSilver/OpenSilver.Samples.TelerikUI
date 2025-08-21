Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Threading
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadDataPager_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            Me.autoEllipsisModeCB.ItemsSource = New AutoEllipsisModes() {AutoEllipsisModes.None, AutoEllipsisModes.Before, AutoEllipsisModes.After, AutoEllipsisModes.Both}

            Me.displayModeCB.ItemsSource = New PagerDisplayModes() {PagerDisplayModes.First, PagerDisplayModes.Last, PagerDisplayModes.Previous, PagerDisplayModes.Next, PagerDisplayModes.Numeric, PagerDisplayModes.FirstLastNumeric, PagerDisplayModes.PreviousNextNumeric, PagerDisplayModes.FirstLastPreviousNextNumeric, PagerDisplayModes.Text, PagerDisplayModes.PreviousNext, PagerDisplayModes.FirstLastPreviousNext, PagerDisplayModes.All}

            Dim view = New MyPagedCollectionView() With {
                .PageSize = 10
            }
            view.SetCount(25000000)

            Me.gridView.ItemsSource = view

            AddHandler Me.gridView.Loaded, AddressOf Me.GridView_Loaded
        End Sub

        Private Sub GridView_Loaded(sender As Object, e As RoutedEventArgs)
            Dispatcher.InvokeAsync(Function() CSharpImpl.__Assign(Me.pager.Source, Me.gridView.Items), DispatcherPriority.Loaded)
        End Sub

        Private NotInheritable Class MyPagedCollectionView
            Implements IPagedCollectionView, IEnumerable, INotifyPropertyChanged, INotifyCollectionChanged
            Public Sub SetCount(count As Integer)
                Me.count = count
            End Sub

            Public ReadOnly Property CanChangePage As Boolean Implements IPagedCollectionView.CanChangePage
                Get
                    Return True
                End Get
            End Property

            Private ReadOnly isPageChangingField As Boolean = False
            Public ReadOnly Property IsPageChanging As Boolean Implements IPagedCollectionView.IsPageChanging
                Get
                    Return isPageChangingField
                End Get
            End Property

            Private count As Integer
            Public ReadOnly Property ItemCount As Integer Implements IPagedCollectionView.ItemCount
                Get
                    Return count
                End Get
            End Property

            Public Function MoveToFirstPage() As Boolean Implements IPagedCollectionView.MoveToFirstPage
                Return MoveToPage(0)
            End Function

            Public Function MoveToLastPage() As Boolean Implements IPagedCollectionView.MoveToLastPage
                Dim page = PageCount - 1
                Return MoveToPage(page)
            End Function

            Public Function MoveToNextPage() As Boolean Implements IPagedCollectionView.MoveToNextPage
                Dim page = pageIndexField + 1
                Return MoveToPage(page)
            End Function

            Public Function MoveToPage(pageIndex As Integer) As Boolean Implements IPagedCollectionView.MoveToPage
                If pageIndex <= PageCount - 1 AndAlso pageIndex >= 0 Then
                    pageIndexField = pageIndex

                    OnPropertyChanged("PageIndex")

                    RaiseEvent CollectionChanged(Me, New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))

                    Return True
                End If

                Return False
            End Function

            Public Function MoveToPreviousPage() As Boolean Implements IPagedCollectionView.MoveToPreviousPage
                Dim page = pageIndexField - 1
                Return MoveToPage(page)
            End Function

            Public Event PageChanged As EventHandler(Of EventArgs) Implements IPagedCollectionView.PageChanged

            Public Event PageChanging As EventHandler(Of PageChangingEventArgs) Implements IPagedCollectionView.PageChanging

            Private pageIndexField As Integer
            Public ReadOnly Property PageIndex As Integer Implements IPagedCollectionView.PageIndex
                Get
                    Return pageIndexField
                End Get
            End Property

            Private pageSizeField As Integer
            Public Property PageSize As Integer Implements IPagedCollectionView.PageSize
                Get
                    Return pageSizeField
                End Get
                Set(value As Integer)
                    pageSizeField = value
                End Set
            End Property

            Public ReadOnly Property TotalItemCount As Integer Implements IPagedCollectionView.TotalItemCount
                Get
                    Return count
                End Get
            End Property

            Public ReadOnly Property PageCount As Integer
                Get
                    Return TotalItemCount / PageSize
                End Get
            End Property

            Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
                Return (From i In Enumerable.Range(PageIndex * PageSize, PageSize) Select i).GetEnumerator()
            End Function

            Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

            Private Sub OnPropertyChanged(propertyName As String)
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
            End Sub

            Public Event CollectionChanged As NotifyCollectionChangedEventHandler Implements INotifyCollectionChanged.CollectionChanged
        End Class

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadDataPager_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataPager/RadDataPager_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadDataPager_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataPager/RadDataPager_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadDataPager_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataPager/RadDataPager_Demo.xaml.vb"
    }
})
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
