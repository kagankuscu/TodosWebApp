using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TodosWebApp.Model.Entities;
using TodosWebApp.Web.ViewModels;

namespace TodosWebApp.Web.Mapping
{
    public class MappingViewModel : Profile
    {
        public MappingViewModel()
        {
            CreateMap<Todo, TodoViewModel>().ReverseMap();
        }
    }
}