using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodosWebApp.BusinessLogic.Shared.Abstract;

namespace TodosWebApp.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TagController(ILogger<TagController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetAllTags()
        {
            return Json(_unitOfWork.Tags.GetAll().ToList());
        }
    }
}