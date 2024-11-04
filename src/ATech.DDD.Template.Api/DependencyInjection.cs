using FastEndpoints;
using FastEndpoints.Swagger;

namespace ATech.DDD.Template.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddAuthorization()
            .AddFastEndpoints()
            .SwaggerDocument(opt =>
            {
                opt.DocumentSettings = s =>
                {
                    s.Title = "ATech.DDD.Template Api";
                    s.Version = "v1";
                };

                opt.AutoTagPathSegmentIndex = 0;
            });

        return services;
    }
}
