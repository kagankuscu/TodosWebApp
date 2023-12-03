using TodosWebApp.Model;

namespace TodosWebApp.Web;

public class UserViewModel : BaseModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ConfirmPassword { get; set; }
}
