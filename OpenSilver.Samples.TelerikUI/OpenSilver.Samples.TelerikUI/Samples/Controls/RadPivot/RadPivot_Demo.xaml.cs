﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Telerik.Pivot.Core;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadPivot_Demo : UserControl
    {
        public RadPivot_Demo()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadPivot_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadPivot/RadPivot_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadPivot_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadPivot/RadPivot_Demo.xaml.cs"
                },
            });
        }

        public class ViewModel : ViewModelBase
        {
            private IDataProvider dataProvider;

            public ViewModel()
            {
                var localProvider = new LocalDataSourceProvider();
                localProvider.ItemsSource = new AllOrders();
                localProvider.RowGroupDescriptions.Add(new PropertyGroupDescription { PropertyName = "Product" });
                localProvider.RowGroupDescriptions.Add(new DateTimeGroupDescription { PropertyName = "Date", Step = DateTimeStep.Month });
                localProvider.ColumnGroupDescriptions.Add(new PropertyGroupDescription { PropertyName = "Advertisement" });
                localProvider.ColumnGroupDescriptions.Add(new PropertyGroupDescription { PropertyName = "Promotion" });

                localProvider.AggregateDescriptions.Add(new PropertyAggregateDescription { PropertyName = "Net" });
                localProvider.AggregateDescriptions.Add(new PropertyAggregateDescription { PropertyName = "Quantity" });

                DataProvider = localProvider;
            }

            public IDataProvider DataProvider
            {
                get
                {
                    return dataProvider;
                }
                set
                {
                    if (dataProvider != value)
                    {
                        dataProvider = value;
                        OnPropertyChanged("DataProvider");
                    }
                }
            }
        }

        public class Order : ViewModelBase
        {
            private DateTime date;
            private string product;
            private int quantity;
            private double net;
            private string promotion;
            private string advertisement;

            public DateTime Date
            {
                get
                {
                    return date;
                }
                set
                {
                    if (date != value)
                    {
                        date = value;
                        OnPropertyChanged("Date");
                    }
                }
            }

            public string Product
            {
                get
                {
                    return product;
                }
                set
                {
                    if (product != value)
                    {
                        product = value;
                        OnPropertyChanged("Product");
                    }
                }
            }

            public int Quantity
            {
                get
                {
                    return quantity;
                }
                set
                {
                    if (quantity != value)
                    {
                        quantity = value;
                        OnPropertyChanged("Quantity");
                    }
                }
            }

            public double Net
            {
                get
                {
                    return net;
                }
                set
                {
                    if (net != value)
                    {
                        net = value;
                        OnPropertyChanged("Net");
                    }
                }
            }

            public string Promotion
            {
                get
                {
                    return promotion;
                }
                set
                {
                    if (promotion != value)
                    {
                        promotion = value;
                        OnPropertyChanged("Promotion");
                    }
                }
            }

            public string Advertisement
            {
                get
                {
                    return advertisement;
                }
                set
                {
                    if (advertisement != value)
                    {
                        advertisement = value;
                        OnPropertyChanged("Advertisement");
                    }
                }
            }
        }

        public class AllOrders : Collection<Order>
        {
            public AllOrders()
            {
                Add(new Order { Date = new DateTime(2010, 6, 1), Product = "Printer stand", Quantity = 11, Net = 200.26, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 1), Product = "Glare filter", Quantity = 6, Net = 77.82, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 1), Product = "Mouse pad", Quantity = 15, Net = 100.95, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 1), Product = "Glare filter", Quantity = 11, Net = 149.71, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 2), Product = "Mouse pad", Quantity = 22, Net = 155.40, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 2), Product = "Mouse pad", Quantity = 3, Net = 20.19, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 2), Product = "Copy holder", Quantity = 5, Net = 33.65, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 2), Product = "Printer stand", Quantity = 22, Net = 239.36, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 2), Product = "Glare filter", Quantity = 10, Net = 129.70, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 5), Product = "Mouse pad", Quantity = 22, Net = 155.40, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 5), Product = "Printer stand", Quantity = 8, Net = 82.96, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 5), Product = "Printer stand", Quantity = 22, Net = 239.40, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 5), Product = "Copy holder", Quantity = 55, Net = 388.50, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 5), Product = "Mouse pad", Quantity = 25, Net = 168.25, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 5), Product = "Glare filter", Quantity = 22, Net = 299.42, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 6), Product = "Mouse pad", Quantity = 33, Net = 256.41, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 6), Product = "Printer stand", Quantity = 11, Net = 119.70, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 6), Product = "Glare filter", Quantity = 22, Net = 329.34, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 6), Product = "Copy holder", Quantity = 20, Net = 134.60, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 24), Product = "Printer stand", Quantity = 99, Net = 1185.03, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 24), Product = "Printer stand", Quantity = 55, Net = 658.35, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 5), Product = "Printer stand", Quantity = 11, Net = 131.67, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 8), Product = "Printer stand", Quantity = 25, Net = 299.25, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 9), Product = "Printer stand", Quantity = 22, Net = 263.34, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 12), Product = "Printer stand", Quantity = 11, Net = 131.67, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 13), Product = "Printer stand", Quantity = 22, Net = 263.34, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 14), Product = "Printer stand", Quantity = 30, Net = 311.10, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 15), Product = "Printer stand", Quantity = 15, Net = 155.55, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 16), Product = "Printer stand", Quantity = 20, Net = 207.40, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 17), Product = "Printer stand", Quantity = 74, Net = 767.38, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 7), Product = "Printer stand", Quantity = 102, Net = 1057.74, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 8), Product = "Glare filter", Quantity = 22, Net = 329.34, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 9), Product = "Glare filter", Quantity = 11, Net = 164.67, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 12), Product = "Glare filter", Quantity = 33, Net = 494.01, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 13), Product = "Glare filter", Quantity = 33, Net = 494.01, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 14), Product = "Glare filter", Quantity = 25, Net = 374.25, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 15), Product = "Glare filter", Quantity = 30, Net = 449.10, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 16), Product = "Glare filter", Quantity = 30, Net = 449.10, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 16), Product = "Glare filter", Quantity = 25, Net = 374.25, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 17), Product = "Glare filter", Quantity = 15, Net = 224.55, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 20), Product = "Glare filter", Quantity = 99, Net = 1482.03, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 21), Product = "Glare filter", Quantity = 132, Net = 1976.04, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 22), Product = "Glare filter", Quantity = 15, Net = 194.55, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 23), Product = "Glare filter", Quantity = 69, Net = 894.93, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 24), Product = "Glare filter", Quantity = 120, Net = 1556.40, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 7), Product = "Mouse pad", Quantity = 55, Net = 427.35, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 8), Product = "Mouse pad", Quantity = 44, Net = 341.88, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 9), Product = "Mouse pad", Quantity = 55, Net = 427.35, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 12), Product = "Mouse pad", Quantity = 66, Net = 512.82, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 13), Product = "Mouse pad", Quantity = 50, Net = 336.50, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 14), Product = "Mouse pad", Quantity = 45, Net = 302.85, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 15), Product = "Mouse pad", Quantity = 75, Net = 504.75, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 16), Product = "Mouse pad", Quantity = 50, Net = 336.50, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 25), Product = "Mouse pad", Quantity = 77, Net = 598.29, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 26), Product = "Mouse pad", Quantity = 165, Net = 1282.05, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 17), Product = "Mouse pad", Quantity = 187, Net = 1452.99, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 18), Product = "Mouse pad", Quantity = 68, Net = 457.64, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 19), Product = "Mouse pad", Quantity = 122, Net = 821.06, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 20), Product = "Mouse pad", Quantity = 175, Net = 1177.75, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 7), Product = "Copy holder", Quantity = 25, Net = 168.25, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 8), Product = "Copy holder", Quantity = 30, Net = 201.90, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 9), Product = "Copy holder", Quantity = 15, Net = 100.95, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 12), Product = "Copy holder", Quantity = 20, Net = 134.60, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 13), Product = "Copy holder", Quantity = 11, Net = 85.47, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 14), Product = "Copy holder", Quantity = 22, Net = 170.94, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 15), Product = "Copy holder", Quantity = 22, Net = 170.94, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 16), Product = "Copy holder", Quantity = 33, Net = 256.41, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 21), Product = "Copy holder", Quantity = 22, Net = 170.94, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 22), Product = "Copy holder", Quantity = 66, Net = 512.82, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 23), Product = "Copy holder", Quantity = 121, Net = 940.17, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 6, 24), Product = "Copy holder", Quantity = 62, Net = 417.26, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 6, 25), Product = "Copy holder", Quantity = 65, Net = 437.45, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 6, 26), Product = "Copy holder", Quantity = 21, Net = 141.33, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 7, 1), Product = "Printer stand", Quantity = 88, Net = 1053.36, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 7, 2), Product = "Printer stand", Quantity = 44, Net = 526.68, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 7, 3), Product = "Printer stand", Quantity = 77, Net = 921.69, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 7, 4), Product = "Printer stand", Quantity = 102, Net = 1057.74, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 7, 5), Product = "Printer stand", Quantity = 60, Net = 622.20, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 7, 6), Product = "Printer stand", Quantity = 80, Net = 829.60, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 7, 7), Product = "Glare filter", Quantity = 110, Net = 1646.70, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 7, 8), Product = "Glare filter", Quantity = 77, Net = 1152.69, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 7, 9), Product = "Glare filter", Quantity = 77, Net = 1152.69, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 7, 10), Product = "Glare filter", Quantity = 124, Net = 1608.28, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 7, 11), Product = "Glare filter", Quantity = 65, Net = 843.05, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 7, 12), Product = "Glare filter", Quantity = 130, Net = 1686.10, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 7, 13), Product = "Mouse pad", Quantity = 275, Net = 2136.75, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 7, 14), Product = "Mouse pad", Quantity = 121, Net = 940.17, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 7, 15), Product = "Mouse pad", Quantity = 176, Net = 1367.52, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 7, 16), Product = "Mouse pad", Quantity = 274, Net = 1844.02, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 7, 17), Product = "Mouse pad", Quantity = 141, Net = 948.93, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 7, 18), Product = "Mouse pad", Quantity = 166, Net = 1117.18, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 7, 19), Product = "Copy holder", Quantity = 99, Net = 769.23, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 7, 20), Product = "Copy holder", Quantity = 55, Net = 427.35, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 7, 21), Product = "Copy holder", Quantity = 132, Net = 1025.64, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 7, 22), Product = "Copy holder", Quantity = 75, Net = 504.75, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 7, 23), Product = "Copy holder", Quantity = 60, Net = 403.80, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 7, 24), Product = "Copy holder", Quantity = 88, Net = 592.24, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 8, 1), Product = "Printer stand", Quantity = 66, Net = 790.02, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 8, 2), Product = "Printer stand", Quantity = 44, Net = 526.68, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 8, 3), Product = "Printer stand", Quantity = 33, Net = 395.01, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 8, 4), Product = "Printer stand", Quantity = 90, Net = 933.30, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 8, 5), Product = "Printer stand", Quantity = 20, Net = 207.40, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 8, 6), Product = "Printer stand", Quantity = 80, Net = 829.60, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 8, 7), Product = "Glare filter", Quantity = 88, Net = 1317.36, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 8, 8), Product = "Glare filter", Quantity = 44, Net = 658.68, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 8, 9), Product = "Glare filter", Quantity = 33, Net = 494.01, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 8, 10), Product = "Glare filter", Quantity = 87, Net = 1128.39, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 8, 11), Product = "Glare filter", Quantity = 48, Net = 622.56, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 8, 12), Product = "Glare filter", Quantity = 95, Net = 1232.15, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 8, 13), Product = "Mouse pad", Quantity = 187, Net = 1452.99, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 8, 14), Product = "Mouse pad", Quantity = 99, Net = 769.23, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 8, 15), Product = "Mouse pad", Quantity = 121, Net = 940.17, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 8, 16), Product = "Mouse pad", Quantity = 198, Net = 1332.54, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 8, 17), Product = "Mouse pad", Quantity = 104, Net = 699.92, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 8, 18), Product = "Mouse pad", Quantity = 144, Net = 969.12, Promotion = "Extra Discount", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 8, 19), Product = "Copy holder", Quantity = 77, Net = 598.29, Promotion = "1 Free with 10", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 8, 20), Product = "Copy holder", Quantity = 33, Net = 256.41, Promotion = "1 Free with 10", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 8, 21), Product = "Copy holder", Quantity = 44, Net = 341.88, Promotion = "1 Free with 10", Advertisement = "Newspaper" });
                Add(new Order { Date = new DateTime(2010, 8, 22), Product = "Copy holder", Quantity = 57, Net = 383.61, Promotion = "Extra Discount", Advertisement = "Magazine" });
                Add(new Order { Date = new DateTime(2010, 8, 23), Product = "Copy holder", Quantity = 38, Net = 255.74, Promotion = "Extra Discount", Advertisement = "Direct mail" });
                Add(new Order { Date = new DateTime(2010, 8, 24), Product = "Copy holder", Quantity = 66, Net = 444.18, Promotion = "Extra Discount", Advertisement = "Newspaper" });
            }
        }
    }
}
