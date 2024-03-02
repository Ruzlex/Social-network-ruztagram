using Dal.Users;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dal;

public static class LogicStartUp
{
    public static IServiceCollection TryAddDal(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IUserRepository, UserRepository>();
        return serviceCollection;
    }
}