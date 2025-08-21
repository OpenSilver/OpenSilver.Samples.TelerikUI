using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadDataForm_Demo : UserControl
    {
        public RadDataForm_Demo()
        {
            InitializeComponent();
            RadGridView1.ItemsSource = Employee.GetEmployees();
        }

        private sealed class Employee : ViewModelBase
        {
            private string firstName;
            private string lastName;
            private string occupation;
            private DateTime startingDate;
            private bool isMarried;
            private int salary;
            private Gender gender;

            public string FirstName
            {
                get { return firstName; }
                set
                {
                    if (firstName != value)
                    {
                        firstName = value;
                        OnPropertyChanged(nameof(FirstName));
                    }
                }
            }

            public string LastName
            {
                get { return lastName; }
                set
                {
                    if (lastName != value)
                    {
                        lastName = value;
                        OnPropertyChanged(nameof(LastName));
                    }
                }
            }

            public string Occupation
            {
                get { return occupation; }
                set
                {
                    if (occupation != value)
                    {
                        occupation = value;
                        OnPropertyChanged(nameof(Occupation));
                    }
                }
            }

            public DateTime StartingDate
            {
                get { return startingDate; }
                set
                {
                    if (startingDate != value)
                    {
                        startingDate = value;
                        OnPropertyChanged(nameof(StartingDate));
                    }
                }
            }

            public bool IsMarried
            {
                get { return isMarried; }
                set
                {
                    if (isMarried != value)
                    {
                        isMarried = value;
                        OnPropertyChanged(nameof(IsMarried));
                    }
                }
            }

            public int Salary
            {
                get { return salary; }
                set
                {
                    if (salary != value)
                    {
                        salary = value;
                        OnPropertyChanged(nameof(Salary));
                    }
                }
            }

            public Gender Gender
            {
                get { return gender; }
                set
                {
                    if (gender != value)
                    {
                        gender = value;
                        OnPropertyChanged(nameof(Gender));
                    }
                }
            }

            public Employee() { }

            public static ObservableCollection<Employee> GetEmployees()
            {
                ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
                employees.Add(new Employee() { FirstName = "Sarah", LastName = "Blake", Occupation = "Supplied Manager", StartingDate = new DateTime(2005, 04, 12), IsMarried = true, Salary = 3500, Gender = Gender.Female });
                employees.Add(new Employee() { FirstName = "Jane", LastName = "Simpson", Occupation = "Security", StartingDate = new DateTime(2008, 12, 03), IsMarried = true, Salary = 2000, Gender = Gender.Female });
                employees.Add(new Employee() { FirstName = "John", LastName = "Peterson", Occupation = "Consultant", StartingDate = new DateTime(2005, 04, 12), IsMarried = false, Salary = 2600, Gender = Gender.Male });
                employees.Add(new Employee() { FirstName = "Peter", LastName = "Bush", Occupation = "Cashier", StartingDate = new DateTime(2005, 04, 12), IsMarried = true, Salary = 2300, Gender = Gender.Male });
                return employees;
            }
        }

        private enum Gender
        {
            Female,
            Male
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadDataForm_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataForm/RadDataForm_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadDataForm_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataForm/RadDataForm_Demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadDataForm_Demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataForm/RadDataForm_Demo.xaml.vb"
                },
            });
        }
    }
}
