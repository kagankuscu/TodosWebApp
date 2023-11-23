using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodosWebApp.DataAccess.Data;
using TodosWebApp.DataAccess.Entities;

namespace TodosWebApp.DataAccess.Interfaces
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            Todo todo = await _context.Todos.FindAsync(id);
            if (todo is not null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Todo todo)
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> GetById(int id)
        {
            Todo todo = await _context.Todos.FindAsync(id); 
            return todo;
        }
    }
}