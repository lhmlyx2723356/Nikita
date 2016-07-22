using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.WinForm.ExtendControl
{
    public class EventItem
    {
        public EventItem(DateTime timeStamp, bool isImportant, string title, string detail)
        {
            TimeStamp = timeStamp;
            IsImportantNode = isImportant;
            Title = title;
            Detail = detail;
        }

        public string Detail { get; set; }
        public bool IsImportantNode { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Title { get; set; }
    }
}