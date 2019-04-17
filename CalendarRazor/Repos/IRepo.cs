using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarRazor.Repos
{
    public interface IRepo<T>
    {
        Task<int> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<List<T>> GetListAsync();
        Task SaveChanges();
    }
}
