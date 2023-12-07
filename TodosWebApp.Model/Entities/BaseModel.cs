using System.ComponentModel.DataAnnotations;

namespace TodosWebApp.Model;

public class BaseModel
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;
}
