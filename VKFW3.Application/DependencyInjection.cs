using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using VKFW3.Application.Common.Mappings;

namespace VKFW3.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddOptions();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MappingProfile).Assembly));
        return services;
    }
}