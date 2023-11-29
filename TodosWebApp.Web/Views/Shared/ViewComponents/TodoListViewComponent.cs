using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.BusinessLogic.Shared.Concrete;
using TodosWebApp.DataAccess.Entities;
using TodosWebApp.Web.ViewModels;

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

        public async Task<IViewComponentResult> InvokeAsync(int type = 1)
        {
            if (type == 2)
            {
                return View(_mapper.Map<List<TodoViewModel>>(_unitOfWork.Todos.GetAll(todo => todo.DueDate.Date < DateTime.Now.AddDays(-1))));
            }
            else
            {
                return View(_mapper.Map<List<TodoViewModel>>(_unitOfWork.Todos.GetAll(todo => todo.DueDate.Date > DateTime.Today)));
            }
        }
    }
}