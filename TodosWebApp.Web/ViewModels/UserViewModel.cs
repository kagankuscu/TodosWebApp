using TodosWebApp.Model;

namespace TodosWebApp.Web;

public class UserViewModel : BaseModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
