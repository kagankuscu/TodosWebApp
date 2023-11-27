using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.DataAccess.Entities;

namespace TodosWebApp.DataAccess.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo> GetById(int id);
        Task SaveAsync(Todo todo);
        Task RemoveAsync(int id);
        Task UpdateAsync(Todo todo);
        Task<List<Todo>> GetTodayTaskAsync();
        Task<List<Todo>> GetUpcomingTaskAsync();
        Task<List<Todo>> GetHistoryTaskAsync();
    }
}