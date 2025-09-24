﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    public sealed class ViewSourceButton : Button
    {
        public ViewSourceButton()
        {
            Style = Application.Current.Resources["ButtonViewSource_Style"] as Style;
        }

        public List<ViewSourceButtonInfo> Sources { get; } = new List<ViewSourceButtonInfo>();

        protected override void OnClick()
        {
            base.OnClick();
            ViewSource(Sources);
        }

        private static void ViewSource(ICollection<ViewSourceButtonInfo> sourcePaths)
        {
            if (sourcePaths is null || sourcePaths.Count == 0)
            {
                return;
            }

            var panel = new ViewSourcePanel();
            panel.ViewSource(sourcePaths);
            MainPage.Current.ViewSourceCode(panel);
        }
    }
}
