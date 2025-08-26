using Bogus;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Telerik.Windows.Data;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadDataFilter_Demo : UserControl
    {
        public RadDataFilter_Demo()
        {
            InitializeComponent();

            radDataFilter.FilterDescriptors.Add(new FilterDescriptor("Name", FilterOperator.Contains, string.Empty));

            var titles = new string[] { "Sales Representative", "Owner", "Marketing Manager", "Accounting manager", "Engineer", "Intern" };
            var faker = new Faker<Employee>();
            faker.StrictMode(true)
                .RuleFor(o => o.Name, f => f.Name.FullName())
                .RuleFor(o => o.CompanyName, f => f.Company.CompanyName())
                .RuleFor(o => o.Title, f => f.PickRandom(titles));

            DataContext = new ObservableCollection<Employee>(faker.Generate(100));
        }

        private sealed class Employee
        {
            public Employee() { }

            public Employee(string name, string companyName, string title)
            {
                Name = name;
                CompanyName = companyName;
                Title = title;
            }

            public string Name { get; set; }
            public string CompanyName { get; set; }
            public string Title { get; set; }
        }
    }
}
