using CalendarRazor.DTO;
using CalendarRazor.Models;
using CalendarRazor.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.UnitOfWork
{
    public class CalendarUoW
    {
        private readonly CalendarContext db;
        public TypesRepo TypesRepo { get; set; }
        //private TasksRepo tasksRepo { get; set; }
        public Repo<CalendarTask> TasksRepo { get; set; }

        public CalendarUoW(CalendarContext db)
        {
            this.db = db;
            TypesRepo = new TypesRepo(db);
            TasksRepo = new Repo<CalendarTask>(db);
        }
        public async Task<List<CalendarTask>> GetTasksByTypeAsync(CalendarType type)
        {
            var currentType = await TypesRepo.GetAsync(type.Id);
            var list = await TasksRepo.GetListAsync();
            return list.Where(a => a.CalendarType.Id == type.Id).ToList();
        }
        public async Task<int> AddTypeWithTask(TypeTaskDTO item)
        {
            await TypesRepo.AddAsync(item.CalendarType);
            item.CalendarTask.CalendarType = item.CalendarType;
            await TasksRepo.AddAsync(item.CalendarTask);
            await SaveChanges();
            return item.CalendarTask.Id;
        }
        public async Task<List<CalendarTask>> GetTasks(DateTime start, DateTime stop)
        {
            var result = await db.Tasks.Include(a => a.CalendarType)
                .Where(a => a.StartDate >= start && a.StartDate <= stop)
             .ToListAsync();
            //var temp = await TasksRepo.GetListAsync();//;ista tasków bez typów
            //var result = temp
            //.Where(a => a.StartDate >= start && a.StartDate <= stop)
            // .ToListAsync();
            //var types = await TypesRepo.GetListAsync();
            //result.ForEach(a =>
            //{
            //    a.CalendarType = types.SingleOrDefault(b => b.Id == a.CalendarTypeID);// przypisujemy ty do taska
            //});
            return result;


        }
        public async Task SaveChanges()
        {
            await db.SaveChangesAsync();
        }
    }
}
