using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using Telerik.Windows.Controls.ScheduleView;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadScheduleView_Demo : UserControl
    {
        public ObservableAppointmentCollection Appointments { get; private set; } = new ObservableAppointmentCollection();
        public IEnumerable<Slot> SpecialSlots { get; private set; }

        private void CreateAppointments()
        {

            Appointment appt = new Appointment
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(2),
                Body = "appointment body 1",
                Location = "appointment location 1"
            };
            Appointment appt2 = new Appointment
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(4),
                Body = "appointment body 2",
                Location = "appointment location 2"
            };

            this.SpecialSlots = new List<Slot> { new Slot { IsReadOnly = true, Start = appt.Start, End = appt.End.AddDays(1) } };


            this.Appointments.Clear();
            this.Appointments.Add(appt);
            this.Appointments.Add(appt2);

        }


        public RadScheduleView_Demo()
        {
            InitializeComponent();
            CreateAppointments();

            scheduleView.AppointmentsSource = this.Appointments;
            scheduleView.SpecialSlotsSource = this.SpecialSlots;
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadScheduleView_Demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadScheduleView/RadScheduleView_Demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadScheduleView_Demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadScheduleView/RadScheduleView_Demo.xaml.cs"
                }
            });
        }
    }
}
