using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Interfaces;

namespace Services;

public static class ServiceStartUp
{
    public static IServiceCollection TryAddService(this IServiceCollection services)
    {
        services.TryAddScoped<ICreatePost, CreatePost>();
        services.TryAddScoped<ILikeService, LikeService>();

        return services;
    }
}