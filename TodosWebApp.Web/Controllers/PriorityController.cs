using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.DTOLayer.DTO;
using TodosWebApp.Model;

namespace TodosWebApp.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class PriorityController : Controller
    {
        private readonly ILogger<PriorityController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public PriorityController(ILogger<PriorityController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetAllPriorities()
        {
            List<Priority> priorities = _unitOfWork.Priorities.GetAll().Include(p => p.Type).ToList();
            return Json(priorities);
        }
        public IActionResult GetAllPriorityColors()
        {
            return Json(_unitOfWork.PriorityTypes.GetAll().ToList());
        }
        public IActionResult GetPriorityById(int id)
        {
            return Json(_unitOfWork.Priorities.GetById(id));
        }
        [HttpPost]
        public IActionResult SavePriority(PriorityUpdateDTO priorityUpdateDTO)
        {
            if (priorityUpdateDTO.Id != 0)
            {
                Priority priority = _unitOfWork.Priorities.GetById(priorityUpdateDTO.Id);
                priority.Name = priorityUpdateDTO.Name;
                priority.TypeId = priorityUpdateDTO.TypeId;
                _unitOfWork.Priorities.Update(priority);
                _unitOfWork.Save();
                return Ok("Priority has been updated successfully");
            }
            else
            {
                _unitOfWork.Priorities.Add(new Priority
                {
                    Name = priorityUpdateDTO.Name,
                    TypeId = priorityUpdateDTO.TypeId,
                });
                _unitOfWork.Save();
                return Ok("Priority added successfully");
            }
        }
        [HttpPost]
        public IActionResult RemovePriority(int id)
        {
            try
            {
                _unitOfWork.Priorities.Remove(_unitOfWork.Priorities.GetById(id));
                _unitOfWork.Save();
                return Ok("Priority removed successfully");
            }
            catch
            {
                _logger.LogError("Error while removing priority");
                return BadRequest("Something went wrong. Please try again");
            }
        }
    }
}