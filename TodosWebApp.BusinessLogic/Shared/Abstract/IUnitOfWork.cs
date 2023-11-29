using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.DataAccess.Entities;

namespace TodosWebApp.BusinessLogic.Shared.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<Todo> Todos { get;}

        void Save();
    }
}