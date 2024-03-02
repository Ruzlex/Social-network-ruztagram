namespace Ruztagram.Controllers.Users.Requests;

public class CreateUserRequest
{
    public required string Name { get; set; }
    
    public required string Login { get; set; }
    
    public required DateTime? BirthDate { get; set; }
    
    public required string Information { get; set; }
}