using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarRazor.DTO;
using CalendarRazor.Models;
using CalendarRazor.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalendarRazor.Pages
{
    public class CreateModel : PageModel
    {
        CalendarUoW uow = null;
        [BindProperty]
        public TypeTaskDTO Item { get; set; }
        public CreateModel(CalendarContext db)
        {
            uow = new CalendarUoW(db);
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()

        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await uow.AddTypeWithTask(Item);
            return RedirectToPage("./Index");
        }

    }
}