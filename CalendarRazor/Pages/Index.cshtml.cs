using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalendarRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CalendarContext db;

        public List<DateTime> Dates { get; set; } = new List<DateTime>();
        public List<CalendarTask> Tasks { get; set; }
        public IndexModel(CalendarContext db)
        {
            this.db = db;
        }
        public async Task OnGetAsync()
        {
            for (int i = 15; i <=21; i++)
            {
                Dates.Add(new DateTime(2019, 04, i));
            }
            Tasks = await new UnitOfWork.CalendarUoW(db).GetTasks(Dates[0], Dates[Dates.Count - 1]);
        }
       
    }
}
