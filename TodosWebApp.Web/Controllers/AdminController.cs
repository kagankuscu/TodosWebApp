using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.DTOLayer;
using TodosWebApp.DTOLayer.DTO;
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
        [HttpPost]
        public IActionResult GetUserById(int id)
        {
            return Json(_unitOfWork.Users.GetById(id));
        }
        [HttpPost]
        public IActionResult UserRemove(int id)
        {
            try
            {
                User user = _unitOfWork.Users.GetById(id);
                _unitOfWork.Users.Remove(user);
                _unitOfWork.Save();
                return Ok("User has been removed.");
            }
            catch
            {
                return BadRequest("User could not be removed.");
            }
        }
        [HttpPost]
        public IActionResult UserUpdate(UserUpdateDTO user)
        {
            try
            {
                User userReal = _unitOfWork.Users.GetById(user.Id);
                userReal.FirstName = user.FirstName;
                userReal.LastName = user.LastName;
                userReal.Email = user.Email;
                userReal.IsAdmin = user.IsAdmin;
                _unitOfWork.Users.Update(userReal);
                _unitOfWork.Save();
                return Ok("User has been updated.");
            }
            catch
            {
                return BadRequest("User could not be updated.");
            }
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