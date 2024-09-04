using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestTask.Context;

namespace TestTask.Extensions;

public static class EfDatabaseExtension
{
    public static async Task<IHost> MigrateEfDbContext(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = ServiceProviderServiceExtensions.GetService<TestTaskContext>(services);

            await context?.Database?.MigrateAsync();
            await context.SaveChangesAsync();
        }

        return host;
    }
    public static void InitEfDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<TestTaskContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                opts =>
                {
          
                    opts.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    opts.MigrationsAssembly(typeof(EfDatabaseExtension).GetTypeInfo().Assembly.GetName().Name);
                }
            );
        });
    }
}