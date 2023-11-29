using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.DataAccess.Data;
using TodosWebApp.Model.Entities;

namespace TodosWebApp.BusinessLogic.Shared.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Todo> Todos { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Todos = new Repository<Todo>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}