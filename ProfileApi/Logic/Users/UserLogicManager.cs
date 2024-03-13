using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;
using ProfileLogic.Users.Interfaces;
using ProfileLogic.Users.Models;

namespace ProfileLogic.Users;

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

    public async Task<Guid> CheckUserExist(Guid userId)
    {
        var res = await _userRepository.CheckUserExist(userId);
        return res;
    }


    public async Task<string> GetUserNameAsync(Guid userId)
    {
        return await _userRepository.GetUserNameAsync(userId);
    }
    
}