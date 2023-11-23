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
            return View(todosVM);
        }

        public async Task<IActionResult> History()
        {
            List<Todo> todos = await _todoService.GetAllAsync();
            todos = todos.OrderByDescending(x=>x.CreatedDate).ToList();
            List<TodoViewModel> todosVM = _mapper.Map<List<TodoViewModel>>(todos);
            return View(todosVM);
        }
    }
}