using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI
{
    static class ViewSourceButtonHelper
    {
        public static void ViewSource(List<ViewSourceButtonInfo> sourcePaths)
        {
            if (sourcePaths.Count > 0)
            {
                var tabControl = new RadTabControl();

                foreach (ViewSourceButtonInfo viewSourceButtonInfo in sourcePaths)
                {
                    var tabItem = new RadTabItem()
                    {
                        Header = viewSourceButtonInfo.TabHeader,
                        Content = new ControlToDisplayCodeHostedOnGitHub()
                        {
                            FilePathOnGitHub = viewSourceButtonInfo.FilePathOnGitHub
                        }
                    };

                    tabControl.Items.Add(tabItem);
                }

                ((RadTabItem)tabControl.Items[0]).IsSelected = true;

                MainPage.Current.ViewSourceCode(tabControl);
            }
        }
    }
}
