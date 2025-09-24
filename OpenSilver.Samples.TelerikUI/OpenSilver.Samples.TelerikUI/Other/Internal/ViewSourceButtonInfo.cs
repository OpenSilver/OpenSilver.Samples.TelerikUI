﻿namespace OpenSilver.Samples.TelerikUI
{
    public class ViewSourceButtonInfo
    {
        public ViewSourceButtonInfo() { }

        public ViewSourceButtonInfo(string relativePath, string fileName)
        {
            RelativePath = relativePath;
            FileName = fileName;
        }

        public string FileName { get; set; }

        public string RelativePath { get; set; }

        public string Branch { get; set; } = "master";

        public string Repository { get; set; } = "OpenSilver.Samples.TelerikUI";

        public string Owner { get; set; } = "OpenSilver";

        public string TabHeader { get; set; }

        public string Fragment { get; set; }

        public string Notes { get; set; }

        public string GetHeader() => !string.IsNullOrEmpty(TabHeader) ? TabHeader : FileName;

        public string GetAbsoluteUrl() => $"https://github.com/{Owner}/{Repository}/blob/{Branch}/{RelativePath}/{FileName}{Fragment}";
    }
}
