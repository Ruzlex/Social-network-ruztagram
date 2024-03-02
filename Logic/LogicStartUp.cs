

using Logic.Users;
using Logic.Users.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Logic;

public static class LogicStartUp
{
    public static IServiceCollection TryAddLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IUserLogicManager, UserLogicManger>();
        return serviceCollection;
    }
}