using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.DataAccess.Data;
using TodosWebApp.Model;
using TodosWebApp.Model.Entities;

namespace TodosWebApp.BusinessLogic.Shared.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Todo> Todos { get; private set; }

        public IRepository<User> Users { get; private set; }
        public IRepository<Priority> Priorities { get; private set; }
        public IRepository<PriorityType> PriorityTypes { get; private set; }
        public IRepository<Tag> Tags { get; private set; }
        public IRepository<TagTypes> TagTypes { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Todos = new Repository<Todo>(_context);
            Users = new Repository<User>(_context);
            Priorities = new Repository<Priority>(_context);
            PriorityTypes = new Repository<PriorityType>(_context);
            Tags = new Repository<Tag>(_context);
            TagTypes = new Repository<TagTypes>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}