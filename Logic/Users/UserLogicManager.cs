using Dal.Users;
using Dal.Users.Models;
using Logic.Users.Interfaces;
using Logic.Users.Models;

namespace Logic.Users;

public class UserLogicManager: IUserLogicManager
{
    
    private readonly IUserRepository _userRepository;

    public UserLogicManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Guid> AddNewUserAsync(UserLogic user)
    {
        return await _userRepository.AddNewUserAsync(new UserDal
        {
            Name = user.Name,
            Login = user.Login,
            BirthDate = user.BirthDate,
            Information = user.Information
        });
    }
    

    public async Task<string> GetUserNameAsync(Guid userId)
    {
        return await _userRepository.GetUserNameAsync(userId);
    }
    
}