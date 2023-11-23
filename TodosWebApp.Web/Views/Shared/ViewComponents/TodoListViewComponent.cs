using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodosWebApp.Web.ViewModels;

namespace TodosWebApp.Web.Views.Shared.ViewComponents
{
    public class TodoListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(TodoViewModel todo)
        {
            return View(todo);
        }
    }
}