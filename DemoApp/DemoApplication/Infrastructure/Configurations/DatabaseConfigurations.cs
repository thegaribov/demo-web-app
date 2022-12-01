using DemoApplication.Database;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Infrastructure.Configurations
{
    public static class DatabaseConfigurations
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("MahmoodPC"));
            });
        }
    }
}
