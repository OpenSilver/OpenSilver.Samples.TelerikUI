Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadDataForm_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()
            Me.RadGridView1.ItemsSource = Employee.GetEmployees()
        End Sub

        Private NotInheritable Class Employee
            Inherits ViewModelBase
            Private firstNameField As String
            Private lastNameField As String
            Private occupationField As String
            Private startingDateField As Date
            Private isMarriedField As Boolean
            Private salaryField As Integer
            Private genderField As Gender

            Public Property FirstName As String
                Get
                    Return firstNameField
                End Get
                Set(value As String)
                    If Not Equals(firstNameField, value) Then
                        firstNameField = value
                        OnPropertyChanged(NameOf(Employee.FirstName))
                    End If
                End Set
            End Property

            Public Property LastName As String
                Get
                    Return lastNameField
                End Get
                Set(value As String)
                    If Not Equals(lastNameField, value) Then
                        lastNameField = value
                        OnPropertyChanged(NameOf(Employee.LastName))
                    End If
                End Set
            End Property

            Public Property Occupation As String
                Get
                    Return occupationField
                End Get
                Set(value As String)
                    If Not Equals(occupationField, value) Then
                        occupationField = value
                        OnPropertyChanged(NameOf(Employee.Occupation))
                    End If
                End Set
            End Property

            Public Property StartingDate As Date
                Get
                    Return startingDateField
                End Get
                Set(value As Date)
                    If startingDateField <> value Then
                        startingDateField = value
                        OnPropertyChanged(NameOf(Employee.StartingDate))
                    End If
                End Set
            End Property

            Public Property IsMarried As Boolean
                Get
                    Return isMarriedField
                End Get
                Set(value As Boolean)
                    If isMarriedField <> value Then
                        isMarriedField = value
                        OnPropertyChanged(NameOf(Employee.IsMarried))
                    End If
                End Set
            End Property

            Public Property Salary As Integer
                Get
                    Return salaryField
                End Get
                Set(value As Integer)
                    If salaryField <> value Then
                        salaryField = value
                        OnPropertyChanged(NameOf(Employee.Salary))
                    End If
                End Set
            End Property

            Public Property Gender As Gender
                Get
                    Return genderField
                End Get
                Set(value As Gender)
                    If genderField <> value Then
                        genderField = value
                        OnPropertyChanged(NameOf(Employee.Gender))
                    End If
                End Set
            End Property

            Public Sub New()
            End Sub

            Public Shared Function GetEmployees() As ObservableCollection(Of Employee)
                Dim employees As ObservableCollection(Of Employee) = New ObservableCollection(Of Employee)()
                employees.Add(New Employee() With {
                    .FirstName = "Sarah",
                    .LastName = "Blake",
                    .Occupation = "Supplied Manager",
                    .StartingDate = New DateTime(2005, 04, 12),
                    .IsMarried = True,
                    .Salary = 3500,
                    .Gender = Gender.Female
                })
                employees.Add(New Employee() With {
                    .FirstName = "Jane",
                    .LastName = "Simpson",
                    .Occupation = "Security",
                    .StartingDate = New DateTime(2008, 12, 03),
                    .IsMarried = True,
                    .Salary = 2000,
                    .Gender = Gender.Female
                })
                employees.Add(New Employee() With {
                    .FirstName = "John",
                    .LastName = "Peterson",
                    .Occupation = "Consultant",
                    .StartingDate = New DateTime(2005, 04, 12),
                    .IsMarried = False,
                    .Salary = 2600,
                    .Gender = Gender.Male
                })
                employees.Add(New Employee() With {
                    .FirstName = "Peter",
                    .LastName = "Bush",
                    .Occupation = "Cashier",
                    .StartingDate = New DateTime(2005, 04, 12),
                    .IsMarried = True,
                    .Salary = 2300,
                    .Gender = Gender.Male
                })
                Return employees
            End Function
        End Class

        Private Enum Gender
            Female
            Male
        End Enum

        Private Sub ButtonViewSource_Click(sender As Object, e As RoutedEventArgs)
            Call TelerikUI.ViewSourceButtonHelper.ViewSource(New List(Of OpenSilver.Samples.TelerikUI.ViewSourceButtonInfo)() From {
                    New TelerikUI.ViewSourceButtonInfo() With {
        .TabHeader = "RadDataForm_Demo.xaml",
        .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataForm/RadDataForm_Demo.xaml"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadDataForm_Demo.xaml.cs",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataForm/RadDataForm_Demo.xaml.cs"
    },
                    New TelerikUI.ViewSourceButtonInfo() With {
         .TabHeader = "RadDataForm_Demo.xaml.vb",
         .FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadDataForm/RadDataForm_Demo.xaml.vb"
    }
})
        End Sub
    End Class
End Namespace
