using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodosWebApp.BusinessLogic.Shared.Abstract;

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
            List<UserViewModel> users = _mapper.Map<List<UserViewModel>>(_unitOfWork.Users.GetAll().ToList());
            users.ForEach(u =>
            {
                u.TotalTask = _unitOfWork.Todos.GetAll(t => t.User.Id == u.Id).Count();
                u.CompletedTask = _unitOfWork.Todos.GetAll(t => t.User.Id == u.Id && t.IsDone).Count();
                u.IsActive = true;
            });
            return Json(new { data = users});
        }
    }
}