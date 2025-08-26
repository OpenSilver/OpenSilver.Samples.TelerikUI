using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using CSHTML5.Internal;

namespace OpenSilver.Samples.TelerikUI
{
    public class ControlToDisplayCodeHostedOnGitHub : ContentControl
    {
        string _filePathOnGitHub;
        string _displayedHtmlString;

        public ControlToDisplayCodeHostedOnGitHub(string absolutePath)
        {
            Loaded += OnLoaded;

            VerticalContentAlignment = VerticalAlignment.Stretch;
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
            FilePathOnGitHub = absolutePath;
        }

        string GetHtmlString(string filePath)
        {
            var embedJs = INTERNAL_UriHelper.ConvertToHtml5Path("ms-appx:/Other/embed.js");
            return $"<script src=\"{embedJs}?target={HttpUtility.UrlEncode(filePath)}&style=github&showBorder=on&showLineNumbers=on&showCopy=on\"></script>";
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_filePathOnGitHub))
            {
                string htmlString = GetHtmlString(_filePathOnGitHub);
                DisplayHtmlString(htmlString);
            }
        }

        void DisplayHtmlString(string htmlString)
        {
            var webView = new WebBrowser();
            webView.NavigateToString(htmlString);
            Content = webView;
            _displayedHtmlString = htmlString;
        }

        public string FilePathOnGitHub
        {
            get
            {
                return _filePathOnGitHub;
            }
            set
            {
                _filePathOnGitHub = value;

                if (IsLoaded)
                {
                    string htmlString = GetHtmlString(FilePathOnGitHub);
                    if (htmlString != _displayedHtmlString)
                    {
                        DisplayHtmlString(htmlString);
                    }
                }
            }
        }
    }
}
