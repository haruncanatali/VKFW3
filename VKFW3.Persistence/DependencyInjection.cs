using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VKFW3.Application.Common.Interfaces;
using VKFW3.Persistence.Context;

namespace VKFW3.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"))
        );
        
        services.AddTransient<IApplicationContext>(provider => provider.GetService<ApplicationContext>());
        return services;
    }
}