using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodosWebApp.Model.Entities
{
    public class Todo : BaseModel
    {
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; } = false;
        public User User { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public int PriorityId { get; set; }
        public virtual Priority Priority { get; set; }
    }
}