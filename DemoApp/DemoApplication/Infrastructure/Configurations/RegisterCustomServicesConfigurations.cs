using DemoApplication.Database;
using DemoApplication.Services.Abstracts;
using DemoApplication.Services.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Infrastructure.Configurations
{
    public static class RegisterCustomServicesConfigurations
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailService, SMTPService>();
        }
    }
}
