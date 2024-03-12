using Core.Dal.Base;

namespace Dal.Users.Models;

public record UserDal: BaseEntityDal<Guid>
{
    
    public required string Name { get; set; }
    
    public required string Login { get; set; }
    
    public required DateTime? BirthDate { get; set; }
    
    public required string Information { get; set; }
}