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
    public bool IsRememberMe { get; set; }
    public int TotalTask { get; set; }
    public int CompletedTask { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsActive { get; set; }
    public string Fullname 
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    } 
}
