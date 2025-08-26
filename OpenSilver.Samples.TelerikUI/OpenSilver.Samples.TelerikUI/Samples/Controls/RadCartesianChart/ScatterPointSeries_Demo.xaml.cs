using Bogus;
using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class ScatterPointSeries_Demo : UserControl
    {
        public ScatterPointSeries_Demo()
        {
            InitializeComponent();

            var faker = new Faker<EmployeeData>()
                .StrictMode(true)
                .RuleFor(o => o.Name, f => f.Name.FirstName())
                .RuleFor(o => o.Age, f => f.Random.Int(20, 40))
                .RuleFor(o => o.Salary, f => f.Random.Int(10000, 25000));

            DataContext = faker.Generate(30);
        }

        private void RadCartesianChart_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.KeyDown += this.MainWindow_KeyDown;
        }

        private void RadCartesianChart_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.KeyDown -= this.MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                panZoomBehavior.CancelDragToZoom();
            }
        }

        private sealed class EmployeeData
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public double Salary { get; set; }
        }
    }
}
