using DemoApplication.Database;
using DemoApplication.Options;
using DemoApplication.Services.Abstracts;
using DemoApplication.Services.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfigOptions>();
            builder.Services.AddSingleton(emailConfig);

            builder.Services.AddScoped<IEmailService, SMTPService>();
            builder.Services
                .AddDbContext<DataContext>(o =>
                {
                    o.UseSqlServer(builder.Configuration.GetConnectionString("MahmoodPC"));
                })
                .AddMvc()
                .AddRazorRuntimeCompilation();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}");

            app.Run();
        }
    }
}