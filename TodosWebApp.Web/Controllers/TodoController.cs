using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View();
        }
        public async Task<IActionResult> GetTodayTask()
        {
            int? userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            // data for datatable library
            // var data = _unitOfWork.Todos.GetAll(todo => todo.DueDate.Date == DateTime.Today && todo.User.Id == userId)
            //     .Include(t => t.Priority).ThenInclude(t => t.Type)
            //     .Include(t => t.Tags).ToList();
             var data = _unitOfWork.Todos.GetAll(todo => todo.DueDate.Date == DateTime.Today && todo.User.Id == userId).Select(t => new {
                id = t.Id,
                isDone = t.IsDone,
                name = new { t.Name, t.Tags, t.Priority, t.Priority.Type },
                dueDate = t.DueDate,
             }).ToList();
            return Json(new 
            {
                data = data
            });
        }

        [HttpPost("{id}")]
        public IActionResult RemoveAJAX(int id)
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
        public IActionResult History()
        {
            int? userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<Todo> todos = _unitOfWork.Todos.GetAll(todo => todo.DueDate.Date < DateTime.Now.AddDays(-1) && todo.User.Id == userId).ToList();
            todos = todos.OrderByDescending(x=>x.CreatedDate).ToList();
            List<TodoViewModel> todosVM = _mapper.Map<List<TodoViewModel>>(todos);
            return View(todosVM);
        }

        [HttpGet]
        public IActionResult Upcoming()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TodoViewModel todoViewModel)
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (todoViewModel.DueDate.Year == 1)
            {
                todoViewModel.DueDate = DateTime.Now;
            }

            Todo todo = _mapper.Map<Todo>(todoViewModel);
            todo.User = _unitOfWork.Users.GetFirstOrDefault(u => u.Id == userId);

            foreach(int tagId in todoViewModel.TagsId)
                todo.Tags.Add(_unitOfWork.Tags.GetById(tagId));

            _unitOfWork.Todos.Add(todo);
            _unitOfWork.Save();
            return RedirectToAction("index");
        }

        [HttpGet("{id}")]
        public IActionResult Remove(int id)
        {
            _unitOfWork.Todos.Remove(_unitOfWork.Todos.GetById(id));
            _unitOfWork.Save();
            return RedirectToAction("index");
        }

        [HttpGet("{id}")]
        public IActionResult Update(int id)
        {
            Todo todo = _unitOfWork.Todos.GetAll(t => t.Id == id).Include(t=>t.Tags).FirstOrDefault()!;
            return View(_mapper.Map<TodoViewModel>(todo));
        }

        [HttpPost("{id}")]
        public IActionResult Update(TodoViewModel updateTodo)
        {
            Todo real = _unitOfWork.Todos.GetAll(t => t.Id == updateTodo.Id).Include(t => t.Priority).Include(t => t.Tags).Include(t => t.User).First();
            
            real.Name = updateTodo.Name;
            real.PriorityId = updateTodo.PriorityId;
            real.DueDate = updateTodo.DueDate;

            List<Tag> tags = new();
            foreach(int tagId in updateTodo.TagsId)
                tags.Add(_unitOfWork.Tags.GetById(tagId));

            real.Tags = tags;
            _unitOfWork.Todos.Update(real);
            _unitOfWork.Save();

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult UpdateIsDone(TodoViewModel updateTodoVM)
        {
            _unitOfWork.Todos.Update(_mapper.Map<Todo>(updateTodoVM));
            _unitOfWork.Save();
            return Json(new { UptadedTodo = updateTodoVM });
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Json(_unitOfWork.Todos.GetAll(t => t.Id == id).Include(t => t.Tags).First());
        }
    }
}