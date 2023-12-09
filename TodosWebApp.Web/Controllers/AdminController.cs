using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.Model.Entities;

namespace TodosWebApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminController(ILogger<AdminController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public IActionResult GetAllUsers()
        {
            List<User> users = _unitOfWork.Users.GetAll().Include(u => u.Todos).ToList();
            List<UserViewModel> usersVM = _mapper.Map<List<UserViewModel>>(users);
            users.ForEach(u =>
            {
                usersVM.Find(x => x.Id == u.Id)!.TotalTask = u.Todos.Where(t => t.IsDeleted == false).Count();
                usersVM.Find(x => x.Id == u.Id)!.CompletedTask = u.Todos.Where(t => t.IsDone && t.IsDeleted == false).Count();
                usersVM.Find(x => x.Id == u.Id)!.IsActive = true;
            });
            return Json(new { data = usersVM});
        }
    }
}