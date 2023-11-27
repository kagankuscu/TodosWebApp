using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.DataAccess.Entities;
using TodosWebApp.DataAccess.Interfaces;

namespace TodosWebApp.BusinessLogic
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<Todo> GetById(int id)
        {
            return await _todoRepository.GetById(id);
        }

        public async Task<List<Todo>> GetHistoryTaskAsync()
        {
            return await _todoRepository.GetHistoryTaskAsync();
        }

        public async Task<List<Todo>> GetTodayTaskAsync()
        {
            return await _todoRepository.GetTodayTaskAsync();
        }

        public async Task<List<Todo>> GetUpcomingTaskAsync()
        {
            return await _todoRepository.GetUpcomingTaskAsync();
        }

        public async Task RemoveAsync(int id)
        {
            await _todoRepository.RemoveAsync(id);
        }

        public async Task SaveAsync(Todo todo)
        {
            await _todoRepository.SaveAsync(todo);
        }

        public async Task UpdateAsync(Todo todo)
        {
            await _todoRepository.UpdateAsync(todo);
        }
    }
}