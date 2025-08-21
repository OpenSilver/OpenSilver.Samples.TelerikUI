Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls.ScheduleView

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadScheduleView_Demo
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

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadScheduleView_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadScheduleView/RadScheduleView_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadScheduleView_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadScheduleView/RadScheduleView_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadScheduleView_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadScheduleView/RadScheduleView_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
