using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.DTOLayer.DTO;
using TodosWebApp.Model.Entities;

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
        [HttpPost]
        public IActionResult SaveTag(TagDTO tagDTO)
        {
            try
            {

                _unitOfWork.Tags.Add(new Tag 
                {
                    Name = tagDTO.Name,
                    Color = tagDTO.Color
                });
                _unitOfWork.Save();
                return Ok("Tag saved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while saving tag");
                return BadRequest("Something went wrong. Save unsuccessful. Please try againg");
            }
        }
    }
}