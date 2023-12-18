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
using TodosWebApp.DTOLayer;
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
            List<UserListDTO> users = _unitOfWork.Users.GetAll().Include(u => u.Todos).Select(u => new UserListDTO {
                Id = u.Id,
                Email = u.Email,
                Fullname = $"{u.FirstName} {u.LastName}",
                TotalTask = u.Todos.Count(),
                CompletedTask = u.Todos.Count(t => t.IsDone),
                UnCompletedTask = u.Todos.Count(t => !t.IsDone),
                DeletedTask = u.Todos.Count(t => t.IsDeleted),
                IsAdmin = u.IsAdmin,
                IsActive = true
            }).ToList();
            return Json(users);
        }
        public IActionResult Priorities()
        {
            return View();
        }
        public IActionResult Tags()
        {
            return View();
        }
    }
}