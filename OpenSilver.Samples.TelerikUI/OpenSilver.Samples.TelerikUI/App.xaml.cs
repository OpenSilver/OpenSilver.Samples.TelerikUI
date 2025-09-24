using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Startup += OnStartup;
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            RootVisual = new MainPage();
        }
    }
}
