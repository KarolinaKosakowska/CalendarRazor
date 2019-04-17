using CalendarRazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.Repos
{
    public class Repo<T> : IDisposable, IRepo<T> where T : Entity
    {
        private readonly CalendarContext db;
        private DbSet<T> dbSet = null;

        public Repo(CalendarContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }
        public async Task<T> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<List<T>> GetListAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<int> AddAsync(T item)
        {
            await dbSet.AddAsync(item);
            return item.Id;
        }
        public async Task<bool> UpdateAsync(T item)
        {
            var dbItem = await GetAsync(item.Id);
            if (dbItem == null)
            {
                return false;
            }
            //dbItem.Localization = item.Localization;
            //dbItem.Owner = item.Owner;
            //dbItem.StartDate = item.StartDate;
            //dbItem.EndDate = item.EndDate;
            //dbItem.Description = item.Description;
            //dbItem.CalendarType = item.CalendarType;
            db.Entry(dbItem).CurrentValues.SetValues(item);
            // await Task.Run(()=>db.Update(dbItem));
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var dbItem = await GetAsync(id);
            if (dbItem == null)
            {
                return false;
            }
            await Task.Run(() => dbSet.Remove(dbItem));
            return true;
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public async Task SaveChanges()
        {
            await db.SaveChangesAsync();
        }

    }
}
