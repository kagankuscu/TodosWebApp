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
    }
}