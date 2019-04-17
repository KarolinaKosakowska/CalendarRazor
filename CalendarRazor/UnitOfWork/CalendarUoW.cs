using CalendarRazor.DTO;
using CalendarRazor.Models;
using CalendarRazor.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.UnitOfWork
{
    public class CalendarUoW<T>: Repo<T> where T: Entity
    {
        private readonly CalendarContext db;
        private TypesRepo typesRepo { get; set; }
        private TasksRepo tasksRepo { get; set; }

        public CalendarUoW(CalendarContext db): base (db)
        {
            this.db = db;
            typesRepo = new TypesRepo(db);
            tasksRepo = new TasksRepo(db);
        }
        public async Task<List<CalendarTask>> GetTasksByTypeAsync(CalendarType type)
        {
            var currentType = await typesRepo.GetAsync(type.Id);
            var list=await tasksRepo.GetListAsync();
            return list.Where(a => a.CalendarType.Id == type.Id).ToList();
        }
        public async Task<int>AddTypeWithTask(TypeTaskDTO item)
        {
           await  typesRepo.AddAsync(item.CalendarType);
            item.CalendarTask.CalendarType = item.CalendarType;
            await tasksRepo.AddAsync(item.CalendarTask);
            await SaveChanges();
            return item.CalendarTask.Id;
        }
        public async Task SaveChanges()
        {
           await db.SaveChangesAsync();
        }
    }
}
