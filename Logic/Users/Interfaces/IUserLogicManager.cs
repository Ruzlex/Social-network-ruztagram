using Logic.Users.Models;

namespace Logic.Users.Interfaces;

public interface IUserLogicManager
{
    Task<Guid> AddNewUserAsync(UserLogic user);

    Task<string> GetUserNameAsync(Guid userId);
    
}