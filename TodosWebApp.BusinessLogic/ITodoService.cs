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
    }
}