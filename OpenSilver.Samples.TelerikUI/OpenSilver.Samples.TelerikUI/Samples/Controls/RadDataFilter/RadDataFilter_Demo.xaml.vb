Imports Bogus
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Data

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadDataFilter_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            Me.radDataFilter.FilterDescriptors.Add(New FilterDescriptor("Name", FilterOperator.Contains, String.Empty))

            Dim titles = New String() {"Sales Representative", "Owner", "Marketing Manager", "Accounting manager", "Engineer", "Intern"}
            Dim faker = New Faker(Of Employee)()
            faker.StrictMode(True).RuleFor(Function(o) o.Name, Function(f) f.Name.FullName()).RuleFor(Function(o) o.CompanyName, Function(f) f.Company.CompanyName()).RuleFor(Function(o) o.Title, Function(f) f.PickRandom(titles))

            DataContext = New ObservableCollection(Of Employee)(faker.Generate(100))
        End Sub

        Private NotInheritable Class Employee
            Public Sub New()
            End Sub

            Public Sub New(name As String, companyName As String, title As String)
                Me.Name = name
                Me.CompanyName = companyName
                Me.Title = title
            End Sub

            Public Property Name As String
            Public Property CompanyName As String
            Public Property Title As String
        End Class
    End Class
End Namespace
