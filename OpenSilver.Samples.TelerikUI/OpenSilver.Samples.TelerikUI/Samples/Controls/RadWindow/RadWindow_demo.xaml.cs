using OpenSilver.Samples.TelerikUI.Window;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;

namespace OpenSilver.Samples.TelerikUI
{
    public partial class RadWindow_Demo : UserControl
    {
        private readonly WindowConfigurationViewModel viewModel;
        private RadWindow window;

        public RadWindow_Demo()
        {
            DataContext = viewModel = new WindowConfigurationViewModel();

            InitializeComponent();

            resizeModeCB.ItemsSource = new ResizeMode[]
            {
                ResizeMode.CanResize,
                ResizeMode.CanMinimize,
                ResizeMode.NoResize,
            };

            windowStartupLocationCB.ItemsSource = new WindowStartupLocation[]
            {
                WindowStartupLocation.Manual,
                WindowStartupLocation.CenterScreen,
                WindowStartupLocation.CenterOwner,
            };

            windowStateCB.ItemsSource = new WindowState[]
            {
                WindowState.Normal,
                WindowState.Minimized,
                WindowState.Maximized,
            };

            viewModel.CanClose = true;
            viewModel.CanMove = true;
            viewModel.RestoreMinimizedLocation = false;
            viewModel.IsClosed = true;
            viewModel.Height = 250;
            viewModel.Width = 250;
            viewModel.ResizeMode = ResizeMode.CanResize;
            viewModel.StartupLocation = WindowStartupLocation.CenterOwner;
            viewModel.State = WindowState.Normal;
            viewModel.Left = 0;
            viewModel.Top = 0;

            Unloaded += OnExampleUnloaded;
        }

        public RadWindow Window
        {
            get
            {
                if (window == null)
                {
                    window = CreateWindow();
                }

                return window;
            }
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        private void OnShowModalClicked(object sender, RoutedEventArgs e)
        {
            if (!Window.IsOpen)
            {
                viewModel.CanClose = true;
                Window.ShowDialog();
            }
        }

        private void OnShowClicked(object sender, RoutedEventArgs e)
        {
            if (!Window.IsOpen)
            {
                Window.Show();
            }
        }

        private RadWindow CreateWindow()
        {
            window = new ExampleWindow
            {
                DataContext = DataContext
            };

            window.Owner = owner;
            window.Closed += new EventHandler<WindowClosedEventArgs>(window_Closed);
            window.Loaded += new RoutedEventHandler(window_Loaded);
            return window;
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.IsClosed = false;
        }

        private void window_Closed(object sender, WindowClosedEventArgs e)
        {
            viewModel.IsClosed = true;
        }

        private void OnAlertClicked(object sender, RoutedEventArgs e)
        {
            string alertText = "The picture has been uploaded.";
            RadWindow.Alert(new DialogParameters
            {
                Content = alertText,
                Closed = new EventHandler<WindowClosedEventArgs>(OnClosed),
                DialogStartupLocation = WindowStartupLocation.CenterScreen,
            });
        }

        private void OnClosed(object sender, WindowClosedEventArgs e)
        {
            RadWindow.Alert(new DialogParameters
            {
                Content = $"DialogResult: {e.DialogResult}, PromptResult: {e.PromptResult}",
                DialogStartupLocation = WindowStartupLocation.CenterScreen,
            });
        }

        private void OnPromptClicked(object sender, RoutedEventArgs e)
        {
            string promptText = "Change title:";
            RadWindow.Prompt(new DialogParameters
            {
                Content = promptText,
                Closed = new EventHandler<WindowClosedEventArgs>(OnPromptClosed),
                DialogStartupLocation = WindowStartupLocation.CenterScreen,
            });
        }

        private void OnPromptClosed(object sender, WindowClosedEventArgs e)
        {
            RadWindow.Alert(new DialogParameters
            {
                Content = $"DialogResult: {e.DialogResult}, PromptResult: {e.PromptResult}",
                DialogStartupLocation = WindowStartupLocation.CenterScreen,
            });

            if (e.PromptResult != null && e.PromptResult != string.Empty)
            {
                viewModel.Title = e.PromptResult;
            }
        }

        private void OnConfirmClicked(object sender, RoutedEventArgs e)
        {
            string confirmText = "Are you sure you want to switch the picture?";
            RadWindow.Confirm(new DialogParameters
            {
                Content = confirmText,
                Closed = new EventHandler<WindowClosedEventArgs>(OnConfirmClosed),
                DialogStartupLocation = WindowStartupLocation.CenterScreen,
            });
        }

        private void OnConfirmClosed(object sender, WindowClosedEventArgs e)
        {
            RadWindow.Alert(new DialogParameters
            {
                Content = $"DialogResult: {e.DialogResult}, PromptResult: {e.PromptResult}",
                DialogStartupLocation = WindowStartupLocation.CenterScreen,
            });

            if (e.DialogResult == true)
            {
                viewModel.NextPicture();
            }
        }

        private sealed class WindowConfigurationViewModel : ViewModelBase
        {
            private static readonly BitmapImage[] images = new BitmapImage[]
            {
                new BitmapImage(new Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Earth.png", UriKind.RelativeOrAbsolute)),
                new BitmapImage(new Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Jupiter.png", UriKind.RelativeOrAbsolute)),
                new BitmapImage(new Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Mars.png", UriKind.RelativeOrAbsolute)),
                new BitmapImage(new Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Mercury.png", UriKind.RelativeOrAbsolute)),
                new BitmapImage(new Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Neptune.png", UriKind.RelativeOrAbsolute)),
                new BitmapImage(new Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Saturn.png", UriKind.RelativeOrAbsolute)),
                new BitmapImage(new Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Uranus.png", UriKind.RelativeOrAbsolute)),
                new BitmapImage(new Uri("/OpenSilver.Samples.TelerikUI;component/Other/Planets/Venus.png", UriKind.RelativeOrAbsolute)),
            };

            private string title = "RadWindow";
            private BitmapImage picture = images[0];
            private bool canClose;
            private bool canMove;
            private bool restoreMinimizedLocation;
            private bool isClosed;
            private double height;
            private double width;
            private ResizeMode resizeMode;
            private WindowStartupLocation startupLocation;
            private WindowState state;
            private double left;
            private double top;

            public void NextPicture()
            {
                Picture = images[(Array.IndexOf(images, picture) + 1) % images.Length];
            }

            public string Title
            {
                get { return title; }
                set
                {
                    if (title != value)
                    {
                        title = value;
                        OnPropertyChanged(nameof(Title));
                    }
                }
            }

            public BitmapImage Picture
            {
                get { return picture; }
                private set
                {
                    if (picture != value)
                    {
                        picture = value;
                        OnPropertyChanged(nameof(Picture));
                    }
                }
            }

            public bool CanClose
            {
                get { return canClose; }
                set
                {
                    if (canClose != value)
                    {
                        canClose = value;
                        OnPropertyChanged(nameof(CanClose));
                    }
                }
            }

            public bool CanMove
            {
                get { return canMove; }
                set
                {
                    if (canMove != value)
                    {
                        canMove = value;
                        OnPropertyChanged(nameof(CanMove));
                    }
                }
            }

            public bool RestoreMinimizedLocation
            {
                get { return restoreMinimizedLocation; }
                set
                {
                    if (restoreMinimizedLocation != value)
                    {
                        restoreMinimizedLocation = value;
                        OnPropertyChanged(nameof(RestoreMinimizedLocation));
                    }
                }
            }

            public bool IsClosed
            {
                get { return isClosed; }
                set
                {
                    if (isClosed != value)
                    {
                        isClosed = value;
                        OnPropertyChanged(nameof(IsClosed));
                    }
                }
            }

            public double Height
            {
                get { return height; }
                set
                {
                    if (height != value)
                    {
                        height = value;
                        OnPropertyChanged(nameof(Height));
                    }
                }
            }

            public double Width
            {
                get { return width; }
                set
                {
                    if (width != value)
                    {
                        width = value;
                        OnPropertyChanged(nameof(Width));
                    }
                }
            }

            public ResizeMode ResizeMode
            {
                get { return resizeMode; }
                set
                {
                    if (resizeMode != value)
                    {
                        resizeMode = value;
                        OnPropertyChanged(nameof(ResizeMode));
                    }
                }
            }

            public WindowStartupLocation StartupLocation
            {
                get { return startupLocation; }
                set
                {
                    if (startupLocation != value)
                    {
                        startupLocation = value;
                        OnPropertyChanged(nameof(StartupLocation));
                    }
                }
            }

            public WindowState State
            {
                get { return state; }
                set
                {
                    if (state != value)
                    {
                        state = value;
                        OnPropertyChanged(nameof(State));
                    }
                }
            }

            public double Left
            {
                get { return left; }
                set
                {
                    if (left != value)
                    {
                        left = value;
                        OnPropertyChanged(nameof(Left));
                    }
                }
            }

            public double Top
            {
                get { return top; }
                set
                {
                    if (top != value)
                    {
                        top = value;
                        OnPropertyChanged(nameof(Top));
                    }
                }
            }
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSourceButtonHelper.ViewSource(new List<ViewSourceButtonInfo>()
            {
                new ViewSourceButtonInfo()
                {
                    TabHeader = "RadWindow_demo.xaml",
                    FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWindow/RadWindow_demo.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadWindow_demo.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWindow/RadWindow_demo.xaml.cs"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "RadWindow_demo.xaml.vb",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWindow/RadWindow_demo.xaml.vb"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "ExampleWindow.xaml",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWindow/ExampleWindow.xaml"
                },
                new ViewSourceButtonInfo()
                {
                     TabHeader = "ExampleWindow.xaml.cs",
                     FilePathOnGitHub = "github/OpenSilver/OpenSilver.Samples.TelerikUI/blob/master/OpenSilver.Samples.TelerikUI/OpenSilver.Samples.TelerikUI/Samples/Controls/RadWindow/ExampleWindow.xaml.cs"
                },
            });
        }
    }
}
