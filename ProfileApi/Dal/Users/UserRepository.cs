using System.Collections.Concurrent;
using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;

namespace ProfileDal.Users;

/// <inheritdoc />
public class UserRepository: IUserRepository
{
    
    private static readonly ConcurrentDictionary<Guid, UserDal> Conection = new();
    
    public async Task<Guid> AddNewUserAsync(UserDal user)
    {
        if (user.Id == Guid.Empty)
        {
            user = user with { Id = Guid.NewGuid() };
        }
        
        if (Conection.TryAdd(user.Id, user))
        {
            return user.Id;
        }
        
        throw new Exception("Ошибка добавления пользователя");
    }

    public async Task<string> AddNewLoginAsync(UserDal user, string login)
    {
        if (Conection.TryGetValue(user.Id, out user))
        {
            return user.Login = login;
        }

        throw new Exception("Ошибка добавления логина");
    }

    public async Task<string> AddNewNameAsync(UserDal user, string name)
    {
        if (Conection.TryGetValue(user.Id, out user))
        {
            return user.Name = name;
        }

        throw new Exception("Ошибка добавления имени");
    }

    public async Task<DateTime> AddBirthdayDateAsync(UserDal user, DateTime birthDate)
    {
        if (Conection.TryGetValue(user.Id, out user))
        {
            return (DateTime)(user.BirthDate = birthDate);
        }

        throw new Exception("Ошибка добавления даты рождения");
    }

    public async Task<string> GetUserNameAsync(Guid userId)
    {
        if (Conection.TryGetValue(userId, out var user))
        {
            return user.Name;
        }

        throw new Exception("Пользователь не найден");
    }

    public async Task<string> AddUserInformation(UserDal user, string info)
    {
        if (Conection.TryGetValue(user.Id, out user))
        {
            return user.Information = info;
        }

        throw new Exception("Ошибка добавления информации о пользователе");
    }

    public async Task<Guid> CheckUserExist(Guid userId)
    {
        
        if (Conection.TryGetValue(userId, out var user))
        {
            return user.Id = userId;
        }
        throw new Exception("Пользователь не найден");
    }
}