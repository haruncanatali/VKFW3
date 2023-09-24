using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VKFW3.Persistence.Context;

namespace VKFW3.Persistence;

public static class MigrationManager
{
    // uygulama ayağa kalktığında son migrationun ayağa kalkıp kalkmadığı kontrol eder.
    // migrate edilmemişse otomatik migrate eder.
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        return host;
    }
}