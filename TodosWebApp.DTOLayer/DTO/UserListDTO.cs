namespace TodosWebApp.DTOLayer;

public class UserListDTO
{
    public int Id { get; set; }    
    public string Email { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public int TotalTask { get; set; }
    public int CompletedTask { get; set; }
    public int UnCompletedTask { get; set; }
    public int DeletedTask { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsActive { get; set; }
}
