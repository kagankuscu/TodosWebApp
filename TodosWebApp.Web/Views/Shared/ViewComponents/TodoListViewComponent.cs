using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.BusinessLogic.Shared.Concrete;
using TodosWebApp.Model.Entities;
using TodosWebApp.Web.ViewModels;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace TodosWebApp.Web.Views.Shared.ViewComponents
{
    public class TodoListViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoListViewComponent(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int type = 1)
        {
            int? userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            if (type == 2)
            {
                return View(_mapper.Map<List<TodoViewModel>>(_unitOfWork.Todos.GetAll(todo => todo.DueDate.Date < DateTime.Now.AddDays(-1) && todo.User.Id == userId).Include(t => t.Priority).Include(t => t.Tags).Include(t => t.Priority.Type)));
            }
            else
            {
                return View(_mapper.Map<List<TodoViewModel>>(_unitOfWork.Todos.GetAll(todo => todo.DueDate.Date > DateTime.Today && todo.User.Id == userId).Include(t => t.Priority).Include(t => t.Priority.Type).Include(t => t.Tags)));
            }
        }
    }
}