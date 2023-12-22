using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.Model;
using TodosWebApp.Model.Entities;

namespace TodosWebApp.Web.ViewModels
{
    public class TodoViewModel
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; } = null!;
        public List<Tag> Tags { get; set; } = null!;
        public List<int> TagsId { get; set; } = null!;
        public string GetDueDate() => DueDate.ToShortDateString();
    }
}