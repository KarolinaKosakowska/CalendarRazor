using CalendarRazor.Models;
using CalendarRazor.UnitOfWork;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.Hubs
{
    public class CalendarHub:Hub
    {
        private readonly CalendarContext db;

        public CalendarHub(CalendarContext db)
        {
            this.db = db;
        }
        public async Task SendCalendar()
        {
            var uow = new CalendarUoW(db);
            var model = await uow.GetTasks(new DateTime(2019,4,15),new DateTime(2019,4,21));
            await Clients.All.SendAsync("ReciveCalendar",model);
        }
    }
}
