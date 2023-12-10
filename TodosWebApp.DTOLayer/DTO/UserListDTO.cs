namespace TodosWebApp.DTOLayer;

public class UserListDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Fullname 
    { 
        get 
        { 
            return $"{FirstName} {LastName}";
        }
    }
    public int TotalTask { get; set; }
    public int CompletedTask { get; set; }
    public bool IsActive { get; set; }
}
