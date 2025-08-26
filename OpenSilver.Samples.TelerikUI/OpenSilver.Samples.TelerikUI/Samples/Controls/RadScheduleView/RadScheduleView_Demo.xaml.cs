using System;
using System.Collections.Generic;
using System.Windows.Controls;
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

            SpecialSlots = new List<Slot> { new Slot { IsReadOnly = true, Start = appt.Start, End = appt.End.AddDays(1) } };

            Appointments.Clear();
            Appointments.Add(appt);
            Appointments.Add(appt2);

        }

        public RadScheduleView_Demo()
        {
            InitializeComponent();
            CreateAppointments();

            scheduleView.AppointmentsSource = Appointments;
            scheduleView.SpecialSlotsSource = SpecialSlots;
        }
    }
}
