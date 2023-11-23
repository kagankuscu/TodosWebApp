using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.DataAccess.Entities;

namespace TodosWebApp.BusinessLogic
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo> GetById(int id);
        Task SaveAsync(Todo todo);
        Task RemoveAsync(int id);
        Task UpdateAsync(Todo todo);

    }
}