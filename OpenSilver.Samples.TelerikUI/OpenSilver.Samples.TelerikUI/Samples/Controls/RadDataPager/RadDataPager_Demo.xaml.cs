using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadDataPager_Demo : UserControl
    {
        public RadDataPager_Demo()
        {
            InitializeComponent();

            autoEllipsisModeCB.ItemsSource = new AutoEllipsisModes[]
            {
                AutoEllipsisModes.None,
                AutoEllipsisModes.Before,
                AutoEllipsisModes.After,
                AutoEllipsisModes.Both,
            };

            displayModeCB.ItemsSource = new PagerDisplayModes[]
            {
                PagerDisplayModes.First,
                PagerDisplayModes.Last,
                PagerDisplayModes.Previous,
                PagerDisplayModes.Next,
                PagerDisplayModes.Numeric,
                PagerDisplayModes.FirstLastNumeric,
                PagerDisplayModes.PreviousNextNumeric,
                PagerDisplayModes.FirstLastPreviousNextNumeric,
                PagerDisplayModes.Text,
                PagerDisplayModes.PreviousNext,
                PagerDisplayModes.FirstLastPreviousNext,
                PagerDisplayModes.All,
            };

            var view = new MyPagedCollectionView() { PageSize = 10 };
            view.SetCount(25000000);

            gridView.ItemsSource = view;

            gridView.Loaded += GridView_Loaded;
        }

        private void GridView_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(() => pager.Source = gridView.Items, DispatcherPriority.Loaded);
        }

        private sealed class MyPagedCollectionView : IPagedCollectionView, IEnumerable, INotifyPropertyChanged, INotifyCollectionChanged
        {
            public void SetCount(int count)
            {
                this.count = count;
            }

            public bool CanChangePage
            {
                get { return true; }
            }

            readonly bool isPageChanging = false;
            public bool IsPageChanging
            {
                get { return isPageChanging; }
            }

            int count;
            public int ItemCount
            {
                get { return count; }
            }

            public bool MoveToFirstPage()
            {
                return MoveToPage(0);
            }

            public bool MoveToLastPage()
            {
                var page = PageCount - 1;
                return MoveToPage(page);
            }

            public bool MoveToNextPage()
            {
                var page = pageIndex + 1;
                return MoveToPage(page);
            }

            public bool MoveToPage(int pageIndex)
            {
                if ((pageIndex <= (PageCount - 1)) && pageIndex >= 0)
                {
                    this.pageIndex = pageIndex;

                    OnPropertyChanged("PageIndex");

                    if (CollectionChanged != null)
                    {
                        CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    }

                    return true;
                }

                return false;
            }

            public bool MoveToPreviousPage()
            {
                var page = pageIndex - 1;
                return MoveToPage(page);
            }

            public event EventHandler<EventArgs> PageChanged;

            public event EventHandler<PageChangingEventArgs> PageChanging;

            int pageIndex;
            public int PageIndex
            {
                get { return pageIndex; }
            }

            int pageSize;
            public int PageSize
            {
                get
                {
                    return pageSize;
                }
                set
                {
                    pageSize = value;
                }
            }

            public int TotalItemCount
            {
                get { return count; }
            }

            public int PageCount
            {
                get { return TotalItemCount / PageSize; }
            }

            public IEnumerator GetEnumerator()
            {
                return (from i in Enumerable.Range(PageIndex * PageSize, PageSize) select i).GetEnumerator();
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            public event NotifyCollectionChangedEventHandler CollectionChanged;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadDataPager_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataPager/RadDataPager_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadDataPager_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataPager/RadDataPager_Demo.xaml.cs"
                },
            });
        }
    }
}
