using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodosWebApp.BusinessLogic;
using TodosWebApp.DataAccess.Entities;
using TodosWebApp.Web.ViewModels;

namespace TodosWebApp.Web.Views.Shared.ViewComponents
{
    public class TodoListViewComponent : ViewComponent
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodoListViewComponent(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type = 1)
        {
            List<Todo> todos = await _todoService.GetAllAsync();
            List<TodoViewModel> todoViewModels = _mapper.Map<List<TodoViewModel>>(todos);

            if (type == 1)
            {
                todoViewModels = _mapper.Map<List<TodoViewModel>>(todos.OrderByDescending(x=>x.DueDate).ToList());
            }
            if (type == 2)
            {
                todoViewModels = _mapper.Map<List<TodoViewModel>>(todos.OrderBy(x=>x.DueDate).TakeWhile(x=>x.DueDate < DateTime.Now).OrderByDescending(x=>x.CreatedDate).ToList());
            }
            return View(todoViewModels);
        }
    }
}