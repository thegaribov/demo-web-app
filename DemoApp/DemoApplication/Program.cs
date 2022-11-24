using DemoApplication.Database;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
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