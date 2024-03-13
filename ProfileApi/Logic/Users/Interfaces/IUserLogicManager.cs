using ProfileLogic.Users.Models;

namespace ProfileLogic.Users.Interfaces;

public interface IUserLogicManager
{
    Task<Guid> AddNewUserAsync(UserLogic user);
    
    Task<Guid> CheckUserExist(Guid userId);

    Task<string> GetUserNameAsync(Guid userId);
    
}
