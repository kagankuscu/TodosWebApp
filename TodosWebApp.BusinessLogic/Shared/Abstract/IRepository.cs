using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodosWebApp.Model;

namespace TodosWebApp.BusinessLogic.Shared.Abstract
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        void Add(T item);
        void AddRange(IEnumerable<T> items);

        void Update(T item);
        void Remove(T item);

        void RemoveRange(IEnumerable<T> items);

        T GetById(int id);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
    }
}