using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Infastracted.Data;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infastracted;

public static class InfrastructureStartUp
{
    public static IServiceCollection TryAddInfastracted(this IServiceCollection services)
    {
        services.TryAddScoped<IStorePost, PostRepository>();
        services.TryAddScoped<ILikePost, LikeRepository>();

        return services;
    }
}