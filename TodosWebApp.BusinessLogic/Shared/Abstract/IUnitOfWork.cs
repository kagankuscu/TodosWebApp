using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.Model;
using TodosWebApp.Model.Entities;

namespace TodosWebApp.BusinessLogic.Shared.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<Todo> Todos { get;}
        IRepository<User> Users { get;}
        IRepository<Priority> Priorities { get;}

        void Save();
    }
}