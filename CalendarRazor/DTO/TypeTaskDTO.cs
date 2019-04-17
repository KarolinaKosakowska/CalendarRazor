using CalendarRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.DTO
{
    public class TypeTaskDTO
    {
        public CalendarTask CalendarTask { get; set; }
        public CalendarType CalendarType { get; set; }
    }
}
