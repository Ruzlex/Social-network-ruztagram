using ProfileDal.Users.Models;

namespace ProfileDal.Users.Interfaces;

public interface IUserRepository
{
    Task<Guid> AddNewUserAsync(UserDal user);

    Task<string> AddNewLoginAsync(UserDal user, string login);

    Task<string> AddNewNameAsync(UserDal user, string name);

    Task<DateTime> AddBirthdayDateAsync(UserDal user, DateTime birthDate);

    Task<string> GetUserNameAsync(Guid userId);

    Task<string> AddUserInformation(UserDal user, string info);
    
    public Task<Guid> CheckUserExist(Guid userId);
}