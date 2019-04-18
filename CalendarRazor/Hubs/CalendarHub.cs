using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.Hubs
{
    public class CalendarHub:Hub
    {
        public async Task SendCalendar()
        {
            await Clients.All.SendAsync("ReciveCalendar", user, message);
        }
    }
}
