using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.Models
{
    public class CalendarContext: DbContext
    {
        public CalendarContext(DbContextOptions<CalendarContext> options):base(options)
        {

        }
        public DbSet<CalendarTask> Tasks { get; set; }
        public DbSet<CalendarType> Types { get; set; }

    }
}
