Imports Bogus
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports Telerik.Windows.Controls

Namespace OpenSilver.Samples.TelerikUI
    Partial Public Class RadBook_Demo
        Inherits UserControl
        Private Shared ReadOnly faker As Faker(Of RadBookPage) = New Faker(Of RadBookPage)().RuleFor(Function(o) o.Title, Function(f) f.Lorem.Word()).RuleFor(Function(o) o.Content, Function(f) f.Lorem.Paragraph(1))

        Public Sub New()
            Me.InitializeComponent()

            Me.firstPagePositionCB.ItemsSource = New PagePosition() {PagePosition.Left, PagePosition.Right}

            Me.hardPagesCB.ItemsSource = New HardPages() {HardPages.None, HardPages.First, HardPages.Last, HardPages.FirstAndLast, HardPages.All}

            Me.pageFlipModeCB.ItemsSource = New PageFlipMode() {PageFlipMode.None, PageFlipMode.SingleClick, PageFlipMode.DoubleClick}

            Me.showPageFoldCB.ItemsSource = New PageFoldVisibility() {PageFoldVisibility.OnFoldEnter, PageFoldVisibility.OnPageEnter, PageFoldVisibility.Never}

            Me.foldHintPositionCB.ItemsSource = New FoldHintPosition() {FoldHintPosition.Top, FoldHintPosition.Bottom}

            Me.book.ItemsSource = Enumerable.Range(1, 999).[Select](Function(i)
                                                                        Dim page = faker.Generate()
                                                                        page.PageNumber = i
                                                                        Return page
                                                                    End Function)
        End Sub

        Private NotInheritable Class RadBookPage
            Inherits ViewModelBase
            Private titleField As String
            Private contentField As String
            Private pageNumberField As Integer

            Public Sub New()
            End Sub

            Public Property Title As String
                Get
                    Return titleField
                End Get
                Set(value As String)
                    If Not Equals(titleField, value) Then
                        titleField = value
                        OnPropertyChanged(NameOf(RadBookPage.Title))
                    End If
                End Set
            End Property

            Public Property Content As String
                Get
                    Return contentField
                End Get
                Set(value As String)
                    If Not Equals(contentField, value) Then
                        contentField = value
                        OnPropertyChanged(NameOf(RadBookPage.Content))
                    End If
                End Set
            End Property

            Public Property PageNumber As Integer
                Get
                    Return pageNumberField
                End Get
                Set(value As Integer)
                    If pageNumberField <> value Then
                        pageNumberField = value
                        OnPropertyChanged(NameOf(RadBookPage.PageNumber))
                    End If
                End Set
            End Property
        End Class
    End Class
End Namespace
