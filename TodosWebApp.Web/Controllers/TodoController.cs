using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodosWebApp.BusinessLogic;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.BusinessLogic.Shared.Concrete;
using TodosWebApp.Model.Entities;
using TodosWebApp.Web.ViewModels;

namespace TodosWebApp.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TodoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("/")]
        [Route("/todo")]
        [Route("/todo/index")]
        public async Task<IActionResult> Index()
        {
            List<Todo> todos = _unitOfWork.Todos.GetAll().ToList();
            todos = todos.OrderByDescending(x=>x.CreatedDate).ToList();
            List<TodoViewModel> todosVM = _mapper.Map<List<TodoViewModel>>(todos);
            return View();
        }
        public async Task<IActionResult> GetTodayTask()
        {
            int? userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            // data for datatable library
            return Json(new 
            {
                data = _unitOfWork.Todos.GetAll(todo => todo.DueDate.Date == DateTime.Today && todo.User.Id == userId).ToList()
            });
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> RemoveAJAX(int id)
        {
            Todo todo = _unitOfWork.Todos.GetById(id);
            if(todo != null)
            {
                _unitOfWork.Todos.Remove(todo);
                _unitOfWork.Save();
                return Json(new { Success = true, Message = $"The Task was removed successfuly. {todo.Id}" });
            }

            return Json(new { Success = false, Error = new { Message = $"{id} was not found."} });
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            int? userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<Todo> todos = _unitOfWork.Todos.GetAll(todo => todo.DueDate.Date < DateTime.Now.AddDays(-1) && todo.User.Id == userId).ToList();
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
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            todoViewModel.CreatedDate = DateTime.Now;
            if (todoViewModel.DueDate.Year == 1)
            {
                todoViewModel.DueDate = DateTime.Now;
            }

            Todo todo = _mapper.Map<Todo>(todoViewModel);
            todo.User = _unitOfWork.Users.GetFirstOrDefault(u => u.Id == userId);

            _unitOfWork.Todos.Add(todo);
            _unitOfWork.Save();
            return RedirectToAction("index");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            _unitOfWork.Todos.Remove(_unitOfWork.Todos.GetById(id));
            _unitOfWork.Save();
            return RedirectToAction("index");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            Todo todo = _unitOfWork.Todos.GetById(id);
            return View(_mapper.Map<TodoViewModel>(todo));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(TodoViewModel updateTodo)
        {
            _unitOfWork.Todos.Update(_mapper.Map<Todo>(updateTodo));
            _unitOfWork.Save();

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIsDone(TodoViewModel updateTodoVM)
        {
            _unitOfWork.Todos.Update(_mapper.Map<Todo>(updateTodoVM));
            _unitOfWork.Save();
            return Json(new { UptadedTodo = updateTodoVM });
        }
    }
}