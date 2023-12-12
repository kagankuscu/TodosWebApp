using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.Model;
using TodosWebApp.Web.ViewModels;

namespace TodosWebApp.Web.Views.Shared.ViewComponents
{
    public class FormViewComponent : ViewComponent
    {

        public readonly IUnitOfWork _unitOfWork;

        public FormViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(string action, TodoViewModel formModel)
        {
            List<Priority> priorities = _unitOfWork.Priorities.GetAll().Include(p => p.Type).ToList();
            ViewBag.title = action;
            ViewBag.priorities = priorities;
            return View(formModel);
        }
    }
}