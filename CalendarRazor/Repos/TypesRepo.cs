using CalendarRazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.Repos
{
    public class TypesRepo : Repo<CalendarType>
    {
        public TypesRepo(CalendarContext context) : base(context)
        {

        }
    }
}
