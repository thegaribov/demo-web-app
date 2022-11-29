﻿using DemoApplication.Database.Configurations;
using DemoApplication.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DemoApplication.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(Program)));

        }
    }
}
