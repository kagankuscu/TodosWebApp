using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodosWebApp.Model.Entities
{
    public class Tag : BaseModel
    {
        public int TagTypesId { get; set; }
        public virtual TagTypes Types { get; set; }
        public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}