using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams.Extensions;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadDiagram_Demo : UserControl
    {
        public RadDiagram_Demo()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            SamplesFactory.StakeholderSample(this.diagram);
        }

        private void OnOpenCycle3Click(object sender, RoutedEventArgs e)
        {
            SamplesFactory.CycleSample(this.diagram);
        }

        private void OnOpenFloorPlanClick(object sender, RoutedEventArgs e)
        {
            SamplesFactory.FloorPlanSample(this.diagram);
        }

        private void OnOpenFlow2Click(object sender, RoutedEventArgs e)
        {
            SamplesFactory.SimpleDiagramSample(this.diagram);
        }

        private void OnOpenRollsClick(object sender, RoutedEventArgs e)
        {
            SamplesFactory.SequenceSample(this.diagram);
        }

        private void OnOpenSimpleFlowClick(object sender, RoutedEventArgs e)
        {
            SamplesFactory.SimpleFlowSample(this.diagram);
        }

        private void OnOpenStakeholderClick(object sender, RoutedEventArgs e)
        {
            SamplesFactory.StakeholderSample(this.diagram);
        }

        private void OnOpenSupplyClick(object sender, RoutedEventArgs e)
        {
            SamplesFactory.BezierSample(this.diagram);
        }

        public class MainViewModel : ViewModelBase
        {
            private double zoomLevel;
            private bool isSnapEnabled = true;
            private int snapValue = 20;
            private Size cellSize = new Size(20, 20);
            private readonly IEnumerable items;

            public MainViewModel()
            {
                this.zoomLevel = 1d;
                this.items = new HierarchicalGalleryItemsCollection();
            }

            public IEnumerable Items
            {
                get
                {
                    return this.items;
                }
            }
            public double ZoomLevel
            {
                get
                {
                    return this.zoomLevel;
                }
                set
                {
                    var coercedValue = Math.Round(value, 2);
                    if (this.zoomLevel != coercedValue)
                    {
                        this.zoomLevel = coercedValue;
                        this.OnPropertyChanged("ZoomLevel");
                    }
                }
            }
            public bool IsSnapEnabled
            {
                get
                {
                    return this.isSnapEnabled;
                }
                set
                {
                    if (this.isSnapEnabled != value)
                    {
                        this.isSnapEnabled = value;
                        this.OnPropertyChanged("IsSnapEnabled");
                    }
                }
            }
            public string SnapValue
            {
                get
                {
                    return this.snapValue.ToString();
                }
                set
                {
                    int posibleValue;
                    var result = int.TryParse(value, out posibleValue);
                    if (result)
                    {
                        this.snapValue = posibleValue;
                        this.OnPropertyChanged("SnapValue");
                    }
                }
            }
            public Size CellSize
            {
                get
                {
                    return this.cellSize;
                }
                set
                {
                    if (this.cellSize != value)
                    {
                        this.cellSize = value;
                        this.OnPropertyChanged("CellSize");
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public sealed class SampleItem
        {
            /// <summary>
            /// Gets or sets the title.
            /// </summary>
            /// <value>The title.</value>
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets the icon.
            /// </summary>
            /// <value>The icon.</value>
            public string Icon { get; set; }

            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public string Description { get; set; }

            /// <summary>
            /// Gets or sets the run.
            /// </summary>
            /// <value>The run.</value>
            public Action<RadDiagram> Run { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static class SamplesFactory
        {
            /// <summary>
            /// Loads the stakeholders sample.
            /// </summary>
            /// <param name="diagram">The diagram.</param>
            public static void StakeholderSample(RadDiagram diagram)
            {
                LoadSample(diagram, "Stakeholder");
            }

            /// <summary>
            /// Loads the decision sample.
            /// </summary>
            /// <param name="diagram">The diagram.</param>
            public static void SimpleFlowSample(RadDiagram diagram)
            {
                LoadSample(diagram, "SimpleFlow");
            }

            /// <summary>
            /// Loads the floor plan sample.
            /// </summary>
            /// <param name="diagram">The diagram.</param>
            public static void FloorPlanSample(RadDiagram diagram)
            {
                LoadSample(diagram, "FloorPlan");
            }

            /// <summary>
            /// Loads the cycle sample.
            /// </summary>
            /// <param name="diagram">The diagram.</param>
            public static void CycleSample(RadDiagram diagram)
            {
                LoadSample(diagram, "Cycle3");
            }

            /// <summary>
            /// Loads the cycle sample.
            /// </summary>
            /// <param name="diagram">The diagram.</param>
            public static void BezierSample(RadDiagram diagram)
            {
                LoadSample(diagram, "Supply");
            }

            /// <summary>
            /// Loads the sequence sample.
            /// </summary>
            /// <param name="diagram">The diagram.</param>
            public static void SequenceSample(RadDiagram diagram)
            {
                LoadSample(diagram, "Rolls");
            }

            /// <summary>
            /// Loads the simple diagram sample.
            /// </summary>
            /// <param name="diagram">The diagram.</param>
            public static void SimpleDiagramSample(RadDiagram diagram)
            {
                LoadSample(diagram, "Flow2");
            }

            private static void LoadSample(RadDiagram diagram, string name)
            {
                diagram.Clear();
                using (var stream = ExtensionUtilities.GetStream(string.Format("/Samples/Controls/RadDiagram/SampleDiagrams/{0}.xml", name)))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var xml = reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(xml))
                        {
                            diagram.Load(xml);
                        }
                    }
                }
                diagram.Dispatcher.BeginInvoke(new Action(() => diagram.AutoFit()), System.Windows.Threading.DispatcherPriority.Loaded);
            }
        }

        /// <summary>
        /// Utilities to ease the integration in and development of diagramming applications.
        /// </summary>
        public static class ExtensionUtilities
        {
            /// <summary>
            /// Gets the name of the executing assembly.
            /// </summary>
            /// <value>The name of the executing assembly.</value>
            public static string ExecutingAssemblyName
            {
                get
                {
                    var name = System.Reflection.Assembly.GetExecutingAssembly().FullName;
                    return name.Substring(0, name.IndexOf(','));
                }
            }

            /// <summary>
            /// Gets the stream at the given path inside the current assembly.
            /// </summary>
            /// <param name="relativeUri">
            /// The relative URI.
            /// </param>
            /// <returns>
            /// </returns>
            public static Stream GetStream(string relativeUri)
            {
                var uri = new Uri(relativeUri, UriKind.RelativeOrAbsolute);
                return GetStream(uri, ExecutingAssemblyName);
            }

            /// <summary>
            /// Gets the stream at the given path inside the current assembly.
            /// </summary>
            /// <param name="uri">
            /// The relative URI.
            /// </param>
            /// <returns>
            /// </returns>
            public static Stream GetStream(Uri uri)
            {
                return GetStream(uri, ExecutingAssemblyName);
            }

            /// <summary>
            /// Gets a bitmap inside the given assembly at the given path therein.
            /// </summary>
            /// <param name="uri">
            /// The relative URI.
            /// </param>
            /// <param name="assemblyName">
            /// Name of the assembly.
            /// </param>
            /// <returns>
            /// </returns>
            public static BitmapImage GetBitmap(Uri uri, string assemblyName)
            {
                if (uri == null)
                {
                    return null;
                }

                var stream = GetStream(uri, assemblyName);

                if (stream == null)
                {
                    return null;
                }

                using (stream)
                {
                    var bmp = new BitmapImage();

                    bmp.SetSource(stream);

                    return bmp;
                }
            }

            /// <summary>
            /// Gets a bitmap inside the given assembly at the given path therein.
            /// </summary>
            /// <param name="relativeUri">
            /// The relative URI.
            /// </param>
            /// <param name="assemblyName">
            /// Name of the assembly.
            /// </param>
            /// <returns>
            /// </returns>
            public static BitmapImage GetBitmap(string relativeUri, string assemblyName)
            {
                var uri = new Uri(relativeUri, UriKind.RelativeOrAbsolute);
                return GetBitmap(uri, assemblyName);
            }

            /// <summary>
            /// Gets a bitmap in the current assembly.
            /// </summary>
            public static BitmapImage GetBitmap(string relativePath)
            {
                var uri = new Uri(relativePath, UriKind.RelativeOrAbsolute);
                return GetBitmap(uri, ExecutingAssemblyName);
            }

            /// <summary>
            /// Gets the stream in the given assembly at the specified path.
            /// </summary>
            /// <param name="uri">
            /// The relative URI.
            /// </param>
            /// <param name="assemblyName">
            /// Name of the assembly.
            /// </param>
            /// <returns>
            /// </returns>
            public static Stream GetStream(Uri uri, string assemblyName)
            {
                return uri != null ? GetStream(uri.ToString(), assemblyName) : null;
            }

            /// <summary>
            /// Gets the stream in the given assembly at the specified path.
            /// </summary>
            /// <param name="relativeUri">
            /// The relative URI.
            /// </param>
            /// <param name="assemblyName">
            /// Name of the assembly.
            /// </param>
            /// <returns>
            /// </returns>
            public static Stream GetStream(string relativeUri, string assemblyName)
            {
                try
                {
                    if (Application.Current == null)
                        return null;

                    if (relativeUri.StartsWith("/", StringComparison.Ordinal))
                        relativeUri = relativeUri.Remove(0, 1);

                    if (assemblyName.ToLower().EndsWith(".dll", StringComparison.Ordinal))
                        assemblyName = assemblyName.Replace(".dll", string.Empty);

                    var res = Application.GetResourceStream(new Uri(assemblyName + ";component/" + relativeUri, UriKind.Relative)).Result ??
                              Application.GetResourceStream(new Uri(relativeUri, UriKind.Relative)).Result;

                    if (res != null)
                        return res.Stream;
                }
                catch (Exception)
                {
                    return null;
                }
                return null;
            }
        }
    }
}
