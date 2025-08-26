Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls.ScheduleView

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadScheduleView_Demo
        Inherits UserControl
        Private _Appointments As Telerik.Windows.Controls.ScheduleView.ObservableAppointmentCollection = New ObservableAppointmentCollection(), _SpecialSlots As System.Collections.Generic.IEnumerable(Of Telerik.Windows.Controls.ScheduleView.Slot)

        Public Property Appointments As ObservableAppointmentCollection
            Get
                Return _Appointments
            End Get
            Private Set(value As ObservableAppointmentCollection)
                _Appointments = value
            End Set
        End Property

        Public Property SpecialSlots As IEnumerable(Of Slot)
            Get
                Return _SpecialSlots
            End Get
            Private Set(value As IEnumerable(Of Slot))
                _SpecialSlots = value
            End Set
        End Property

        Private Sub CreateAppointments()

            Dim appt As Appointment = New Appointment With {
    .Start = Date.Now,
    .[End] = Date.Now.AddDays(2),
    .Body = "appointment body 1",
    .Location = "appointment location 1"
}
            Dim appt2 As Appointment = New Appointment With {
    .Start = Date.Now,
    .[End] = Date.Now.AddDays(4),
    .Body = "appointment body 2",
    .Location = "appointment location 2"
}

            SpecialSlots = New List(Of Slot) From {
                New Slot With {
                    .IsReadOnly = True,
                    .Start = appt.Start,
                    .[End] = appt.End.AddDays(1)
                }
            }


            Appointments.Clear()
            Appointments.Add(appt)
            Appointments.Add(appt2)

        End Sub


        Public Sub New()
            Me.InitializeComponent()
            CreateAppointments()

            Me.scheduleView.AppointmentsSource = Appointments
            Me.scheduleView.SpecialSlotsSource = SpecialSlots
        End Sub
    End Class
End Namespace
