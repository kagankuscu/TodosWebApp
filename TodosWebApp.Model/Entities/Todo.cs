using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodosWebApp.Model.Entities
{
    public class Todo : BaseModel
    {
        public string? Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; } = false;
        public User User { get; set; } = null!;
    }
}