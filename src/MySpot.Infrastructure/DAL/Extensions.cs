using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MySpot.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services,
        IConfiguration configuration)
    {
        var section = configuration.GetSection("postgres");
        services.Configure<PostgresOptions>(section);
        var options = new PostgresOptions();
        section.Bind(options);
        services.AddDbContext<MySpotDbContext>(x => x.UseNpgsql(options.ConnectionString));
        
        return services;
    }
}