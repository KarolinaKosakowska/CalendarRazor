using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.Models
{
    public class CalendarTask:Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public string Owner { get; set; }
        public CalendarType CalendarType { get; set; }
    }
}
