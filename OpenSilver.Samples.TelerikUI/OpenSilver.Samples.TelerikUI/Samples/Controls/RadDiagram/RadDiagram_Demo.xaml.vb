Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports Telerik.Windows.Controls
Imports Telerik.Windows.Controls.Diagrams.Extensions

Namespace OpenSilver.Samples.TelerikUI
    Public Partial Class RadDiagram_Demo
        Inherits UserControl
        Public Sub New()
            Me.InitializeComponent()

            DataContext = New MainViewModel()
            AddHandler Loaded, AddressOf OnLoaded
        End Sub

        Private Sub OnLoaded(sender As Object, routedEventArgs As RoutedEventArgs)
            SamplesFactory.StakeholderSample(Me.diagram)
        End Sub

        Private Sub OnOpenCycle3Click(sender As Object, e As RoutedEventArgs)
            SamplesFactory.CycleSample(Me.diagram)
        End Sub

        Private Sub OnOpenFloorPlanClick(sender As Object, e As RoutedEventArgs)
            SamplesFactory.FloorPlanSample(Me.diagram)
        End Sub

        Private Sub OnOpenFlow2Click(sender As Object, e As RoutedEventArgs)
            SamplesFactory.SimpleDiagramSample(Me.diagram)
        End Sub

        Private Sub OnOpenRollsClick(sender As Object, e As RoutedEventArgs)
            SamplesFactory.SequenceSample(Me.diagram)
        End Sub

        Private Sub OnOpenSimpleFlowClick(sender As Object, e As RoutedEventArgs)
            SamplesFactory.SimpleFlowSample(Me.diagram)
        End Sub

        Private Sub OnOpenStakeholderClick(sender As Object, e As RoutedEventArgs)
            SamplesFactory.StakeholderSample(Me.diagram)
        End Sub

        Private Sub OnOpenSupplyClick(sender As Object, e As RoutedEventArgs)
            SamplesFactory.BezierSample(Me.diagram)
        End Sub

        Public Class MainViewModel
            Inherits ViewModelBase
            Private zoomLevelField As Double
            Private isSnapEnabledField As Boolean = True
            Private snapValueField As Integer = 20
            Private cellSizeField As Size = New Size(20, 20)
            Private ReadOnly itemsField As IEnumerable

            Public Sub New()
                zoomLevelField = 1.0R
                itemsField = New HierarchicalGalleryItemsCollection()
            End Sub

            Public ReadOnly Property Items As IEnumerable
                Get
                    Return itemsField
                End Get
            End Property
            Public Property ZoomLevel As Double
                Get
                    Return zoomLevelField
                End Get
                Set(value As Double)
                    Dim coercedValue = Math.Round(value, 2)
                    If zoomLevelField <> coercedValue Then
                        zoomLevelField = coercedValue
                        OnPropertyChanged("ZoomLevel")
                    End If
                End Set
            End Property
            Public Property IsSnapEnabled As Boolean
                Get
                    Return isSnapEnabledField
                End Get
                Set(value As Boolean)
                    If isSnapEnabledField <> value Then
                        isSnapEnabledField = value
                        OnPropertyChanged("IsSnapEnabled")
                    End If
                End Set
            End Property
            Public Property SnapValue As String
                Get
                    Return snapValueField.ToString()
                End Get
                Set(value As String)
                    Dim posibleValue As Integer
                    Dim result = Integer.TryParse(value, posibleValue)
                    If result Then
                        snapValueField = posibleValue
                        OnPropertyChanged("SnapValue")
                    End If
                End Set
            End Property
            Public Property CellSize As Size
                Get
                    Return cellSizeField
                End Get
                Set(value As Size)
                    If cellSizeField <> value Then
                        cellSizeField = value
                        OnPropertyChanged("CellSize")
                    End If
                End Set
            End Property
        End Class

        ''' <summary>
        ''' 
        ''' </summary>
        Public NotInheritable Class SampleItem
            ''' <summary>
            ''' Gets or sets the title.
            ''' </summary>
            ''' <value>The title.</value>
            Public Property Title As String

            ''' <summary>
            ''' Gets or sets the icon.
            ''' </summary>
            ''' <value>The icon.</value>
            Public Property Icon As String

            ''' <summary>
            ''' Gets or sets the description.
            ''' </summary>
            ''' <value>The description.</value>
            Public Property Description As String

            ''' <summary>
            ''' Gets or sets the run.
            ''' </summary>
            ''' <value>The run.</value>
            Public Property Run As Action(Of RadDiagram)
        End Class

        ''' <summary>
        ''' 
        ''' </summary>
        Public NotInheritable Class SamplesFactory
            ''' <summary>
            ''' Loads the stakeholders sample.
            ''' </summary>
            ''' <paramname="diagram">The diagram.</param>
            Public Shared Sub StakeholderSample(diagram As RadDiagram)
                LoadSample(diagram, "Stakeholder")
            End Sub

            ''' <summary>
            ''' Loads the decision sample.
            ''' </summary>
            ''' <paramname="diagram">The diagram.</param>
            Public Shared Sub SimpleFlowSample(diagram As RadDiagram)
                LoadSample(diagram, "SimpleFlow")
            End Sub

            ''' <summary>
            ''' Loads the floor plan sample.
            ''' </summary>
            ''' <paramname="diagram">The diagram.</param>
            Public Shared Sub FloorPlanSample(diagram As RadDiagram)
                LoadSample(diagram, "FloorPlan")
            End Sub

            ''' <summary>
            ''' Loads the cycle sample.
            ''' </summary>
            ''' <paramname="diagram">The diagram.</param>
            Public Shared Sub CycleSample(diagram As RadDiagram)
                LoadSample(diagram, "Cycle3")
            End Sub

            ''' <summary>
            ''' Loads the cycle sample.
            ''' </summary>
            ''' <paramname="diagram">The diagram.</param>
            Public Shared Sub BezierSample(diagram As RadDiagram)
                LoadSample(diagram, "Supply")
            End Sub

            ''' <summary>
            ''' Loads the sequence sample.
            ''' </summary>
            ''' <paramname="diagram">The diagram.</param>
            Public Shared Sub SequenceSample(diagram As RadDiagram)
                LoadSample(diagram, "Rolls")
            End Sub

            ''' <summary>
            ''' Loads the simple diagram sample.
            ''' </summary>
            ''' <paramname="diagram">The diagram.</param>
            Public Shared Sub SimpleDiagramSample(diagram As RadDiagram)
                LoadSample(diagram, "Flow2")
            End Sub

            Private Shared Sub LoadSample(diagram As RadDiagram, name As String)
                diagram.Clear()
                Using stream = ExtensionUtilities.GetStream(String.Format("/Samples/Controls/RadDiagram/SampleDiagrams/{0}.xml", name))
                    Using reader = New StreamReader(stream)
                        Dim xml = reader.ReadToEnd()
                        If Not String.IsNullOrEmpty(xml) Then
                            diagram.Load(xml)
                        End If
                    End Using
                End Using
                diagram.Dispatcher.BeginInvoke(New Action(Sub() diagram.AutoFit()), Threading.DispatcherPriority.Loaded)
            End Sub
        End Class

        ''' <summary>
        ''' Utilities to ease the integration in and development of diagramming applications.
        ''' </summary>
        Public NotInheritable Class ExtensionUtilities
            ''' <summary>
            ''' Gets the name of the executing assembly.
            ''' </summary>
            ''' <value>The name of the executing assembly.</value>
            Public Shared ReadOnly Property ExecutingAssemblyName As String
                Get
                    Dim name = Reflection.Assembly.GetExecutingAssembly().FullName
                    Return name.Substring(0, name.IndexOf(","c))
                End Get
            End Property

            ''' <summary>
            ''' Gets the stream at the given path inside the current assembly.
            ''' </summary>
            ''' <paramname="relativeUri">
            ''' The relative URI.
            ''' </param>
            ''' <returns>
            ''' </returns>
            Public Shared Function GetStream(relativeUri As String) As Stream
                Dim uri = New Uri(relativeUri, UriKind.RelativeOrAbsolute)
                Return GetStream(uri, ExecutingAssemblyName)
            End Function

            ''' <summary>
            ''' Gets the stream at the given path inside the current assembly.
            ''' </summary>
            ''' <paramname="uri">
            ''' The relative URI.
            ''' </param>
            ''' <returns>
            ''' </returns>
            Public Shared Function GetStream(uri As Uri) As Stream
                Return GetStream(uri, ExecutingAssemblyName)
            End Function

            ''' <summary>
            ''' Gets a bitmap inside the given assembly at the given path therein.
            ''' </summary>
            ''' <paramname="uri">
            ''' The relative URI.
            ''' </param>
            ''' <paramname="assemblyName">
            ''' Name of the assembly.
            ''' </param>
            ''' <returns>
            ''' </returns>
            Public Shared Function GetBitmap(uri As Uri, assemblyName As String) As BitmapImage
                If uri Is Nothing Then
                    Return Nothing
                End If

                Dim stream = GetStream(uri, assemblyName)

                If stream Is Nothing Then
                    Return Nothing
                End If

                Using stream
                    Dim bmp = New BitmapImage()

                    bmp.SetSource(stream)

                    Return bmp
                End Using
            End Function

            ''' <summary>
            ''' Gets a bitmap inside the given assembly at the given path therein.
            ''' </summary>
            ''' <paramname="relativeUri">
            ''' The relative URI.
            ''' </param>
            ''' <paramname="assemblyName">
            ''' Name of the assembly.
            ''' </param>
            ''' <returns>
            ''' </returns>
            Public Shared Function GetBitmap(relativeUri As String, assemblyName As String) As BitmapImage
                Dim uri = New Uri(relativeUri, UriKind.RelativeOrAbsolute)
                Return GetBitmap(uri, assemblyName)
            End Function

            ''' <summary>
            ''' Gets a bitmap in the current assembly.
            ''' </summary>
            Public Shared Function GetBitmap(relativePath As String) As BitmapImage
                Dim uri = New Uri(relativePath, UriKind.RelativeOrAbsolute)
                Return GetBitmap(uri, ExecutingAssemblyName)
            End Function

            ''' <summary>
            ''' Gets the stream in the given assembly at the specified path.
            ''' </summary>
            ''' <paramname="uri">
            ''' The relative URI.
            ''' </param>
            ''' <paramname="assemblyName">
            ''' Name of the assembly.
            ''' </param>
            ''' <returns>
            ''' </returns>
            Public Shared Function GetStream(uri As Uri, assemblyName As String) As Stream
                Return If(uri IsNot Nothing, GetStream(uri.ToString(), assemblyName), Nothing)
            End Function

            ''' <summary>
            ''' Gets the stream in the given assembly at the specified path.
            ''' </summary>
            ''' <paramname="relativeUri">
            ''' The relative URI.
            ''' </param>
            ''' <paramname="assemblyName">
            ''' Name of the assembly.
            ''' </param>
            ''' <returns>
            ''' </returns>
            Public Shared Function GetStream(relativeUri As String, assemblyName As String) As Stream
                Try
                    If Application.Current Is Nothing Then Return Nothing

                    If relativeUri.StartsWith("/", StringComparison.Ordinal) Then relativeUri = relativeUri.Remove(0, 1)

                    If assemblyName.ToLower().EndsWith(".dll", StringComparison.Ordinal) Then assemblyName = assemblyName.Replace(".dll", String.Empty)

                    Dim res = If(Application.GetResourceStream(New Uri(assemblyName & ";component/" & relativeUri, UriKind.Relative)).Result, Application.GetResourceStream(New Uri(relativeUri, UriKind.Relative)).Result)

                    If res IsNot Nothing Then Return res.Stream
                Catch __unusedException1__ As Exception
                    Return Nothing
                End Try
                Return Nothing
            End Function
        End Class
    End Class
End Namespace
