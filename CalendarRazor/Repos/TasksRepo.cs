using CalendarRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.Repos
{
    public class TasksRepo: Repo<CalendarTask>
    {
        public TasksRepo(CalendarContext context): base(context)
        {

        }
    }
}
