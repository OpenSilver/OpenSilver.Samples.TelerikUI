Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls.ScheduleView

Namespace Global.OpenSilver.Samples.TelerikUI
    Partial Public Class RadScheduleView_Demo
        Inherits UserControl
        Private _Appointments As Telerik.Windows.Controls.ScheduleView.ObservableAppointmentCollection = New ObservableAppointmentCollection()
        Private _SpecialSlots As System.Collections.Generic.IEnumerable(Of Telerik.Windows.Controls.ScheduleView.Slot)

        Public Property Appointments As ObservableAppointmentCollection
            Get
                Return _Appointments
            End Get
            Private Set(ByVal value As ObservableAppointmentCollection)
                _Appointments = value
            End Set
        End Property

        Public Property SpecialSlots As IEnumerable(Of Slot)
            Get
                Return _SpecialSlots
            End Get
            Private Set(ByVal value As IEnumerable(Of Slot))
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

        Private Sub ButtonViewSource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Call ViewSource(New List(Of ViewSourceButtonInfo)() From {
                    New ViewSourceButtonInfo() With {
        .TabHeader = "RadScheduleView_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadScheduleView/RadScheduleView_Demo.xaml"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadScheduleView_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadScheduleView/RadScheduleView_Demo.xaml.cs"
    },
                    New ViewSourceButtonInfo() With {
         .TabHeader = "RadScheduleView_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI.VB/Samples/Controls/RadScheduleView/RadScheduleView_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
