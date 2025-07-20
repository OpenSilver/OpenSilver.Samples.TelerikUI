using System.Windows;
using System.Windows.Controls;

namespace OpenSilver.Samples.TelerikUI.RadOutlookBar
{
    public class OutlookBarContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MailTemplate { get; set; }
        public DataTemplate CalendarTemplate { get; set; }
        public DataTemplate ContactsTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MailMenuItem)
            {
                return MailTemplate;
            }
            else if (item is CalendarMenuItem)
            {
                return CalendarTemplate;
            }
            else if (item is ContactsMenuItem)
            {
                return ContactsTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
