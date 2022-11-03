using Microsoft.AspNetCore.Mvc;

namespace DemoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc();
            var app = builder.Build();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}");

            app.Run();
        }
    }

    public class EducationFieldsController 
    {
        public string DigitalMarketing()
        {
            return "Salam this page is marketing";
        }

        public string Programing()
        {
            return "This is programming page";
        }
    }

    public class HomeController
    {
        public string Programing()
        {
            return "This is programming page";
        }
    }
}