using FastEndpoints;

namespace ATech.DDD.Template.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddAuthorization()
            .AddFastEndpoints()
            ;

        return services;
    }
}
