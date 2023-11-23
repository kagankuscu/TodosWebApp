using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodosWebApp.BusinessLogic;
using TodosWebApp.DataAccess.Entities;

namespace TodosWebApp.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [Route("/")]
        [Route("/todo")]
        [Route("/todo/index")]
        public async Task<IActionResult> Index()
        {
            List<Todo> todo = await _todoService.GetAllAsync();
            return View(todo.OrderByDescending(x=>x.CreatedDate).ToList());
        }

        public async Task<IActionResult> History()
        {
            List<Todo> todo = await _todoService.GetAllAsync();
            return View(todo);
        }
    }
}