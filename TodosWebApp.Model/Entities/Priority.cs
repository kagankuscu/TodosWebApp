using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosWebApp.Model.Entities;

namespace TodosWebApp.Model
{
    public class Priority : BaseModel
    {
        public int TypeId { get; set; }
        public virtual PriorityType Type { get; set; }
        public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}
