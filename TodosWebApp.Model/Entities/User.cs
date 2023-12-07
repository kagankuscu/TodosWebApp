namespace TodosWebApp.Model.Entities;

public class User: BaseModel
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Token { get; set; }
    public bool IsAdmin { get; set; }

    public ICollection<Todo> Todos { get; set; } = new List<Todo>();
}
