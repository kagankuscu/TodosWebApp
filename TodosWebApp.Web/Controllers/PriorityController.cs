using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodosWebApp.BusinessLogic.Shared.Abstract;
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
    }
}