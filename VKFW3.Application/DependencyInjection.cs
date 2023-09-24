using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using VKFW3.Application.Common.Mappings;

namespace VKFW3.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // yapılandırma konseptleri için gerekli ayar
        services.AddOptions();
        // Mevcut kütüphanedeki tüm Automapper dan miras alan dto ları tanıyıp yürütmek için
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //MediatR yapılandırması için
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MappingProfile).Assembly));
        return services;
    }
}