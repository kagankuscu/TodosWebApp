using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodosWebApp.Web.ViewModels
{
    public class TodoViewModel
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDone { get; set; }
    }
}