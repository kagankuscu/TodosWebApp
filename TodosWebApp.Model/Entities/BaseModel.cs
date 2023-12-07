using System.ComponentModel.DataAnnotations;

namespace TodosWebApp.Model;

public class BaseModel
{
    [Key]
    public int Id { get; set; }
    public bool IsDeleted { get; set; } = false;
}
