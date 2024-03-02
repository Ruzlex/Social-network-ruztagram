namespace Ruztagram.Controllers.Users.Responses;

public class UserInfoResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; set; }
    
    public required string Login { get; set; }
    
    public required DateTime? BirthDate { get; set; }
    
    public required string Information { get; set; }
}