using DemoApplication.Database;
using DemoApplication.Infrastructure.Extensions;
using DemoApplication.Options;
using DemoApplication.Services.Abstracts;
using DemoApplication.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DemoApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //setup
            var builder = WebApplication.CreateBuilder(args);

            //Register services (IoC container)
            builder.Services.ConfigureServices(builder.Configuration);

            //setup
            var app = builder.Build();

            //Configuration of middleware pipeline
            app.ConfigureMiddlewarePipeline();

            //setup
            app.Run();
        }
    }
}