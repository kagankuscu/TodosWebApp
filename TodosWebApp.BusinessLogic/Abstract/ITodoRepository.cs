using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.Model.Entities;

namespace TodosWebApp.BusinessLogic.Abstract
{
    public interface ITodoRepository : IRepository<Todo>
    {
        
    }
}