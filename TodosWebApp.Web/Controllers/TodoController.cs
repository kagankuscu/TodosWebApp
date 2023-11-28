using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodosWebApp.BusinessLogic;
using TodosWebApp.DataAccess.Entities;
using TodosWebApp.Web.ViewModels;

namespace TodosWebApp.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodoController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [Route("/")]
        [Route("/todo")]
        [Route("/todo/index")]
        public async Task<IActionResult> Index()
        {
            List<Todo> todos = await _todoService.GetAllAsync();
            todos = todos.OrderByDescending(x=>x.CreatedDate).ToList();
            List<TodoViewModel> todosVM = _mapper.Map<List<TodoViewModel>>(todos);
            return View();
        }

        [HttpGet("{pageSize}")]
        public async Task<IActionResult> GetTodayTask(int pageSize)
        {
            // data for datatable library
            return Json(new 
            {
                data = await _todoService.GetTodayTaskAsync()
            });
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            List<Todo> todos = await _todoService.GetAllAsync();
            todos = todos.OrderByDescending(x=>x.CreatedDate).ToList();
            List<TodoViewModel> todosVM = _mapper.Map<List<TodoViewModel>>(todos);
            return View(todosVM);
        }

        [HttpGet]
        public async Task<IActionResult> Upcoming()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TodoViewModel todoViewModel)
        {
            todoViewModel.CreatedDate = DateTime.Now;
            if (todoViewModel.DueDate.Year == 1)
            {
                todoViewModel.DueDate = DateTime.Now;
            }
            await _todoService.SaveAsync(_mapper.Map<Todo>(todoViewModel));
            return RedirectToAction("index");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _todoService.RemoveAsync(id);
            return RedirectToAction("index");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            Todo todo = await _todoService.GetById(id);
            return View(_mapper.Map<TodoViewModel>(todo));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(TodoViewModel updateTodo)
        {
            await _todoService.UpdateAsync(_mapper.Map<Todo>(updateTodo));

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIsDone(TodoViewModel updateTodoVM)
        {
            await _todoService.UpdateAsync(_mapper.Map<Todo>(updateTodoVM));
            return Json(new { UptadedTodo = updateTodoVM });
        }
    }
}